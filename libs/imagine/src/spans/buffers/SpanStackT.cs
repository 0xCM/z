//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static sys;

    public ref struct SpanStack<T>
        where T : unmanaged
    {
        readonly Span<T> Buffer;

        readonly uint Capacity;

        uint Pos;

        [MethodImpl(Inline)]
        internal SpanStack(T[] buffer)
        {
            Buffer = buffer;
            Capacity = (uint)buffer.Length;
            Pos = 0;
        }

        [MethodImpl(Inline)]
        public void Push(T src)
        {
            if(Pos > MaxPos)
                --Pos;

            seek(Head, Pos++) = src;
        }

        [MethodImpl(Inline)]
        public ref T Pop()
        {
            if(Pos < 0)
                return ref seek(Head, 0);
            else
                return ref seek(Head, --Pos);
        }

        [MethodImpl(Inline)]
        public bool Pop(out T cell)
        {
            if(Pos < Capacity - 1)
            {
                cell = sys.skip(Buffer,++Pos);
                return true;
            }
            else
            {
                cell = default;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public bool Push(in T cell)
        {
            if(Pos > 0)
            {
                sys.seek(Buffer, Pos--) = cell;
                return true;
            }
            else
                return false;
        }

        ref T Head
        {
            [MethodImpl(Inline)]
            get => ref sys.first(Buffer);
        }

        uint MaxPos
        {
            [MethodImpl(Inline)]
            get => Capacity - 1;
        }

        public uint Enqueued
        {
            [MethodImpl(Inline)]
            get => Pos + 1;
        }

        [MethodImpl(Inline)]
        public S Peek<S>()
            where S : unmanaged
                => sys.first(Buffer.Recover<T,S>());
    }
}