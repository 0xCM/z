//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static sys;

    public ref struct RingBuffer<T>
        where T : unmanaged
    {
        Span<T> Buffer;

        int Capacity;

        /// <summary>
        /// The current position of the writer
        /// </summary>
        int InPos;

        /// <summary>
        /// The current position of the reader
        /// </summary>
        int OutPos;

        /// <summary>
        /// The number of elements stored in the queue
        /// </summary>
        int Count;

        [MethodImpl(Inline)]
        public RingBuffer(Span<T> buffer)
        {
            Buffer = buffer;
            Capacity = buffer.Length;
            InPos = 0;
            OutPos = 0;
            Count = 0;
        }

        [MethodImpl(Inline)]
        public void Push(in T src)
        {
            if(InPos > MaxPos)
                InPos = 0;

            if(Count != Capacity)
                Count++;

            seek(Head, InPos++) = src;
        }

        [MethodImpl(Inline)]
        public ref readonly T Pop()
        {
            if(OutPos > MaxPos)
                OutPos = 0;

            Count--;

            return ref seek(Head, OutPos++);
        }

        ref T Head
        {
            [MethodImpl(Inline)]
            get => ref sys.first(Buffer);
        }

        int MaxPos
        {
            [MethodImpl(Inline)]
            get => Capacity - 1;
        }
    }
}