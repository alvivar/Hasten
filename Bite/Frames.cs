using System;
using System.Text;
using System.Collections.Generic;

namespace BiteClient
{
    public class Frame
    {
        public int ClientId { get { return (data[0] << 8) | data[1]; } }
        public int MessageId { get { return (data[2] << 8) | data[3]; } }
        public int Size { get { return (data[4] << 8) | data[5]; } }

        public byte[] Data { get { return data; } }

        public byte[] Content
        {
            get
            {
                var content = new byte[data.Length - 6];
                Array.Copy(data, 6, content, 0, content.Length);
                return content;
            }
        }

        public String Text
        {
            get
            {
                var text = Content;
                return Encoding.UTF8.GetString(text, 0, text.Length);
            }
        }

        private byte[] data = new byte[0];

        public Frame Feed(byte[] data)
        {
            var newData = new byte[this.data.Length + data.Length];
            Array.Copy(this.data, newData, this.data.Length);
            Array.Copy(data, 0, newData, this.data.Length, data.Length);

            this.data = newData;

            return this;
        }

        public Frame FromProtocol(int clientId, int messageId, byte[] data)
        {
            var header = new byte[6];

            header[0] = (byte)((clientId & 0xFF00) >> 8);
            header[1] = (byte)((clientId & 0x00FF));

            header[2] = (byte)((messageId & 0xFF00) >> 8);
            header[3] = (byte)((messageId & 0x00FF));

            var length = header.Length + data.Length;
            header[4] = (byte)((length & 0xFF00) >> 8);
            header[5] = (byte)((length & 0x00FF));

            // Concat
            var newData = new byte[header.Length + data.Length];
            Array.Copy(header, newData, header.Length);
            Array.Copy(data, 0, newData, header.Length, data.Length);

            this.data = newData;

            return this;
        }

        /// Remove and returns the remainder data that overflows the size.
        public byte[] SplitRemainder()
        {
            var size = Size;
            var remainder = new byte[data.Length - size];
            Array.Copy(data, size, remainder, 0, remainder.Length);
            Array.Resize(ref data, size);

            return remainder;
        }
    }

    public class Frames
    {
        public bool HasCompleteFrame { get { return frames.Count > 0; } }
        public bool HasPendingData
        {
            get
            {
                if (frame.Data.Length < 6)
                    return false;

                return frame.Size <= frame.Data.Length;
            }
        }

        private Queue<Frame> frames = new Queue<Frame>();
        private Frame frame = new Frame();

        public void Feed(byte[] data)
        {
            frame.Feed(data);
            TryCompleteFrame();
        }

        public void TryCompleteFrame()
        {
            // A complete frame!
            if (frame.Size == frame.Data.Length)
            {
                frames.Enqueue(frame);
                frame = new Frame();
            }

            // More than one frame in the buffer, lets split, save the frame,
            // buffer the rest on a new frame.
            else if (frame.Size < frame.Data.Length)
            {
                var remainder = new Frame().Feed(frame.SplitRemainder());
                frames.Enqueue(frame);
                frame = remainder;
            }

            // Not enough data in the buffer for a complete frame, maybe after
            // the next feed.
            else if (frame.Size > frame.Data.Length)
                return;
        }

        public Frame Dequeue()
        {
            return frames.Dequeue();
        }
    }
}