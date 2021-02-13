using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

// To connect.

// Bite bite = new Bite("127.0.0.1", 1984);

// To send.

// bite.Send("s author Andrés Villalobos");
// bite.Send("j author");

// You can use a System.Action callback on send to deal directly with the response.

// bite.Send("g author", response => {
//     // Handle your response.
// });

// You also have a couple System.Action to subscribe.

// bite.OnResponse += YourOnResponse;
// bite.OnError += YourOnError;

// That's it!

public class Bite
{
    public List<string> queries = new List<string>();
    public List<Action<string>> callbacks = new List<Action<string>>();

    public Action<string> OnResponse;
    public Action<string> OnError;

    private TcpClient socketConnection;
    private Thread clientServerThread;
    private NetworkStream stream;

    private string host;
    private int port;

    public Bite(string host, int port)
    {
        this.host = host;
        this.port = port;

        ConnectToTcpServer();
    }

    private void ConnectToTcpServer()
    {
        try
        {
            clientServerThread = new Thread(new ThreadStart(HandleMessage));
            clientServerThread.IsBackground = true;
            clientServerThread.Start();
        }
        catch (Exception e)
        {
            if (OnError != null)
                OnError($"{e}");
        }
    }

    private void HandleMessage()
    {
        try
        {
            socketConnection = new TcpClient(host, port);
            stream = socketConnection.GetStream();

            while (true)
            {
                if (queries.Count <= 0)
                    continue;

                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);

                // Send

                var query = queries[0];
                queries.RemoveAt(0);

                var call = callbacks[0];
                callbacks.RemoveAt(0);

                writer.WriteLine(query);
                writer.Flush();

                // Receive

                var response = reader.ReadLine();

                if (call != null)
                    call(response);

                if (OnResponse != null)
                    OnResponse(response);
            }
        }
        catch (SocketException e)
        {
            if (OnError != null)
                OnError($"{e}");
        }
    }

    public void Send(string message, Action<string> callback = null)
    {
        if (socketConnection == null || !socketConnection.Connected)
        {
            if (OnError != null)
                OnError($"Disconnected while sending: {message}");

            return;
        }

        queries.Add(message);
        callbacks.Add(callback);
    }

    public static int IntOr(string str, int or)
    {
        int n;
        return int.TryParse(str, out n) ? n : or;
    }

    public static float FloatOr(string str, float or)
    {
        float n;
        return float.TryParse(str, out n) ? n : or;
    }

    public static float LongOr(string str, long or)
    {
        long n;
        return long.TryParse(str, out n) ? n : or;
    }
}