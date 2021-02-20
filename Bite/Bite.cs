using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

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

public class BiteMsg
{
    public string message;
    public Action<string> callback;

    public BiteMsg(string message, Action<string> callback)
    {
        this.message = message;
        this.callback = callback;
    }
}

public class Bite
{
    public Action<string> OnResponse;
    public Action<string> OnError;

    private Queue<BiteMsg> queue = new Queue<BiteMsg>();

    private TcpClient tcpClient;
    private Thread thread;
    private NetworkStream stream;

    private bool allowThread = false;

    private string host;
    private int port;

    public Bite(string host, int port)
    {
        this.host = host;
        this.port = port;

        StartConnectionThread();
    }

    public void Stop()
    {
        allowThread = false;

        tcpClient.Close();
    }

    public void Send(string message, Action<string> callback = null)
    {
        if (tcpClient == null || !tcpClient.Connected)
        {
            if (OnError != null)
                OnError($"Disconnected trying {message}");

            return;
        }

        Debug.Log($"Queued {message}");

        lock(queue)
        {
            queue.Enqueue(new BiteMsg(message, callback));
        }
    }

    private void StartConnectionThread()
    {
        try
        {
            allowThread = true;

            thread = new Thread(new ThreadStart(HandleConnection));
            thread.IsBackground = true;
            thread.Start();
        }
        catch (Exception e)
        {
            if (OnError != null)
                OnError($"{e}");
        }
    }

    private void HandleConnection()
    {
        try
        {
            tcpClient = new TcpClient(host, port);
            stream = tcpClient.GetStream();

            while (allowThread)
            {
                BiteMsg some;

                lock(queue)
                {
                    if (queue.Count < 1)
                        continue;

                    some = queue.Dequeue();
                }

                if (some == null)
                    continue;

                // Send

                var writer = new StreamWriter(stream);

                writer.WriteLine(some.message);
                writer.Flush();

                // Receive

                Debug.Log($"{some.message}");
                var isSubscription = some.message.Trim().ToLower().StartsWith("#");

                var reader = new StreamReader(stream);

                do
                {
                    var response = reader.ReadLine();

                    if (some.callback != null)
                        some.callback(response);

                    if (OnResponse != null)
                        OnResponse(response);
                }
                while (isSubscription && allowThread);
            }
        }
        catch (Exception e)
        {
            Stop();

            if (OnError != null)
                OnError($"{e}");
        }
    }

    public static int Int(string str, int or)
    {
        int n;
        return int.TryParse(str, out n) ? n : or;
    }

    public static float Float(string str, float or)
    {
        float n;
        return float.TryParse(str, out n) ? n : or;
    }

    public static long Long(string str, long or)
    {
        long n;
        return long.TryParse(str, out n) ? n : or;
    }
}