//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    public ref struct SpanBuffer<T>
    {
        Span<T> Data;

        uint Pos;

        uint Capacity;

        [MethodImpl(Inline)]
        public SpanBuffer(Span<T> src)
        {
            Data = src;
            Pos = 0;
            Capacity = (uint)src.Length;
        }

        [MethodImpl(Inline)]
        public SpanBuffer<T> Clear()
        {
            Data.Clear();
            Pos = 0;
            return this;
        }

        [MethodImpl(Inline)]
        public bool Append(in T src)
        {
            if(Pos < Capacity)
            {
                seek(Data,Pos++) = src;
                return true;
            }
            else
                return false;
        }

        [MethodImpl(Inline)]
        public uint Append(ReadOnlySpan<T> src)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(Append(skip(src,i)))
                    counter++;
                else
                    break;
            }
            return counter;
        }

        public ReadOnlySpan<T> Content
        {
            [MethodImpl(Inline)]
            get => slice(Data,0,Pos);
        }
    }
}