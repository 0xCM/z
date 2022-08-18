//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Arrays;

    public struct Stack<T>
    {
        readonly T[] Buffer;

        uint Pos;

        uint Capacity;

        public Stack(uint capacity)
        {
            Capacity = capacity;
            Buffer = sys.alloc<T>(Capacity);
            Pos = (uint)Buffer.Length - 1;
        }

        [MethodImpl(Inline)]
        public Stack(T[] buffer)
        {
            Capacity = (uint)buffer.Length;
            Buffer = buffer;
            Pos = (uint)Buffer.Length - 1;
        }

        [MethodImpl(Inline)]
        public bool Pop(out T cell)
        {
            if(Pos < Capacity - 1)
            {
                cell = seek(Buffer,++Pos);
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
                seek(Buffer,Pos--) = cell;
                return true;
            }
            else
                return false;
        }
    }
}