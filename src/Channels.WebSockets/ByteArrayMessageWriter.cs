﻿using System;

namespace Channels.WebSockets
{
    internal struct ByteArrayMessageWriter : IMessageWriter
    {
        private byte[] value;
        private int offset, count;
        public ByteArrayMessageWriter(byte[] value, int offset, int count)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (offset + count > (value?.Length ?? 0)) throw new ArgumentOutOfRangeException(nameof(count));

            this.value = value;
            this.offset = offset;
            this.count = count;
        }

        unsafe void IMessageWriter.Write(ref WritableBuffer buffer)
        {
            if (count != 0) buffer.Write(value, offset, count);
        }

        unsafe int IMessageWriter.GetTotalBytes() => count;
    }
}
