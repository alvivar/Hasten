using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace BITEClient
{
    internal sealed class Sender
    {
        internal Queue<Frame> frames = new Queue<Frame>();

        private NetworkStream stream;
        private Thread thread;

        internal Sender(NetworkStream stream)
        {
            this.stream = stream;
            thread = new Thread(Run);
            thread.Start();
        }

        internal void Send(Frame frame)
        {
            lock (frames)
            {
                frames.Enqueue(frame);
            }
        }

        internal void Abort()
        {
            if (thread != null)
                thread.Abort();
        }

        private void Run()
        {
            while (true)
            {
                if (frames.Count < 1)
                    continue;

                lock (frames)
                {
                    var frame = frames.Dequeue();
                    stream.Write(frame.Bytes, 0, frame.Bytes.Length);
                }
            }
        }
    }
}
