//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public ref struct SpanIterator<T>
    {
        readonly Span<T> Data;

        uint Position;

        uint LastPosition;

        [MethodImpl(Inline)]
        public SpanIterator(Span<T> values)
        {
            Data = values;
            Position = 0;
            LastPosition = (uint)Data.Length - 1;
        }

        [MethodImpl(Inline)]
        public bool NextCell(out T value)
        {
            if(Position <= LastPosition)
            {
                value = seek(Data, Position++);
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public bool NextEdit<H>(H target)
            where H : IMutableIterator<H,T>
        {
            if(Position<= LastPosition)
            {
                var result = true;
                target.Edit(ref seek(Data, Position++), out result);
                return result;
            }
            else
            {
                var dst = default(T);
                var result = false;
                target.Edit(ref dst, out result);
                return result;
            }

        }

        [MethodImpl(Inline)]
        public bool NextView<H>(H target)
            where H : IReadOnlyIterator<H,T>
        {
            if(Position<=LastPosition)
            {
                var result = true;
                target.View(in skip(Data, Position++), out result);
                return result;
            }
            else
            {
                var result = false;
                var dst = default(T);
                target.View(in dst, out result);
                return result;
            }
        }

        [MethodImpl(Inline)]
        public bool NextOutput<H>(H target)
            where H : IOutputIterator<H,T>
        {
            if(NextCell(out var dst))
            {
                var result = true;
                target.Next(out dst, out result);
                return result;
            }
            else
            {
                var result = false;
                var value = default(T);
                target.Next(out value, out result);
                return result;
            }
        }
    }
}