using System;
using System.Net.Sockets;

namespace BiteServer
{
    public sealed class Bite
    {
        internal event Action<string> DataReceived;

        private TcpClient client;
        private NetworkStream stream;
        private Sender sender;
        private Receiver receiver;

        internal Bite(string host, int port)
        {
            client = new TcpClient(host, port);
            stream = client.GetStream();

            sender = new Sender(stream);
            receiver = new Receiver(stream);
            receiver.DataReceived += OnDataReceived;
        }

        internal void Send(string data, Action<string> action = null)
        {
            sender.Send(data);

            if (action != null)
                receiver.React(action);
        }

        private void OnDataReceived(string data)
        {
            if (DataReceived != null)
                DataReceived(data);
        }

        internal void Close()
        {
            client.Close();
            stream.Close();
            sender.Close();
            receiver.Close();
        }
    }
}