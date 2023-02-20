using System;
using System.Text;
using System.Collections.Generic;

namespace BiteClient
{
    public class Frame
    {
        public int ClientId { get { return (bytes[0] << 8) | bytes[1]; } }
        public int MessageId { get { return (bytes[2] << 8) | bytes[3]; } }
        public int Size { get { return (bytes[4] << 8) | bytes[5]; } }

        public byte[] Bytes { get { return bytes; } } // Full.
        public byte[] Body // No header.
        {
            get
            {
                var content = new byte[bytes.Length - 6];
                Array.Copy(bytes, 6, content, 0, content.Length);
                return content;
            }
        }

        public String Text
        {
            get
            {
                var text = Body;
                return Encoding.UTF8.GetString(text, 0, text.Length);
            }
        }

        private byte[] bytes = new byte[0];

        public Frame Feed(byte[] data)
        {
            var newData = new byte[this.bytes.Length + data.Length];
            Array.Copy(this.bytes, newData, this.bytes.Length);
            Array.Copy(data, 0, newData, this.bytes.Length, data.Length);

            this.bytes = newData;

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

            this.bytes = newData;

            return this;
        }

        /// Remove and returns the remainder data that overflows the protocol size.
        public byte[] SplitRemainder()
        {
            var size = Size;
            var remainder = new byte[bytes.Length - size];
            Array.Copy(bytes, size, remainder, 0, remainder.Length);
            Array.Resize(ref bytes, size);

            return remainder;
        }
    }

    public class Frames
    {
        public bool HasCompleteFrame { get { return frames.Count > 0; } }

        private Queue<Frame> frames = new Queue<Frame>();
        private Frame frame = new Frame();

        public void Feed(byte[] data)
        {
            frame.Feed(data);
        }

        public bool ProcessingCompleteFrames()
        {
            // A complete frame!
            if (frame.Size == frame.Bytes.Length)
            {
                frames.Enqueue(frame);
                frame = new Frame();

                return false;
            }

            // More than one frame in the buffer, lets split, save the frame, buffer the rest on a new frame.
            else if (frame.Size < frame.Bytes.Length)
            {
                var remainder = new Frame().Feed(frame.SplitRemainder());
                frames.Enqueue(frame);
                frame = remainder;

                return true;
            }

            // Not enough data in the buffer for a complete frame, maybe after the next feed.
            // else if (frame.Size > frame.Data.Length)
            return false;
        }

        public Frame Dequeue()
        {
            return frames.Dequeue();
        }
    }
}
