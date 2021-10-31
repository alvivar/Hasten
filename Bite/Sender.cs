using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace BiteServer
{
    internal sealed class Sender
    {
        internal Queue<string> messages = new Queue<string>();

        private NetworkStream stream;
        private StreamWriter writer;
        private Thread thread;

        internal Sender(NetworkStream stream)
        {
            this.stream = stream;
            writer = new StreamWriter(this.stream);
            thread = new Thread(Run);
            thread.Start();
        }

        internal void Send(string message)
        {
            lock(messages)
            {
                messages.Enqueue(message);
            }
        }

        private void Run()
        {
            while (true)
            {
                if (messages.Count < 1)
                    continue;

                lock(messages)
                {
                    writer.WriteLine(messages.Dequeue());
                    writer.Flush();
                }
            }
        }

        internal void Close()
        {
            if (writer != null)
                writer.Close();

            if (thread != null)
                thread.Abort();
        }
    }
}