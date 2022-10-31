using System;
using System.Net.Sockets;
using System.Text;

namespace BiteClient
{
    public sealed class Bite
    {
        internal bool Connected { get { return clientId > 0 || client.Connected; } }
        internal long ClientId { get { return clientId; } }
        internal event Action<Frame> OnConnected;
        internal event Action<Frame> OnFrameReceived;

        private TcpClient client;
        private NetworkStream stream;
        private Sender sender;
        private Receiver receiver;

        private int clientId;
        private static int messageId;

        internal Bite(string host, int port)
        {
            client = new TcpClient(host, port);
            stream = client.GetStream();

            try
            {
                sender = new Sender(stream);
                receiver = new Receiver(stream);
                receiver.OnFrameReceived += FrameReceived;
            }
            catch (SocketException e)
            {
                Shutdown();
                Console.WriteLine(e);
            }
        }

        internal void Send(byte[] data, Action<Frame> action = null)
        {
            if (!Connected)
                throw new SocketException((int)SocketError.NotConnected);

            messageId += 1;
            var frame = new Frame().FromProtocol((int)clientId, messageId, data);
            sender.Send(frame);

            if (action != null)
                receiver.React(action);
        }

        internal void Send(string text, Action<Frame> action = null)
        {
            Send(Encoding.ASCII.GetBytes(text), action);
        }

        /// Naturally throws an ThreadAbortException.
        internal void Shutdown()
        {
            client.Close();
            stream.Close();

            sender.Abort();
            receiver.Abort();
        }

        private void FrameReceived(Frame frame)
        {
            // The first frame received is the client id asigned by the server.
            if (clientId < 1)
            {
                clientId = frame.ClientId;

                if (OnConnected != null)
                    OnConnected(frame);

                return;
            }

            if (OnFrameReceived != null)
                OnFrameReceived(frame);
        }
    }
}