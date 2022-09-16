//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DelimitedSeq<T> : ReadOnlySeq<DelimitedSeq<T>,T>
    {
        public override string Delimiter {get;}

        public override Fence<char>? Fence {get;}

        public override int CellPad {get;}

        public DelimitedSeq()
        {
            Delimiter = ",";
            CellPad = 0;
            Fence = null;
        }

        static string format(T item)
            => $"{item}";

        public override string Format()
        {
            var f = Delimiting.format(View, format, Delimiter, CellPad);
            if(Fence != null)
                f = Fence.Value.Format(f);
            return f;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public DelimitedSeq(ReadOnlySeq<T> src, char delimiter, int pad, Fence<char>? fence)
            : base(src.Storage)
        {
            Delimiter = delimiter.ToString();
            CellPad = pad;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public static implicit operator DelimitedSeq<T>(ReadOnlySeq<T> src)
            => new DelimitedSeq<T>(src, Chars.Comma, 0, null);

        [MethodImpl(Inline)]
        public static implicit operator DelimitedSeq<T>(T[] src)
            => new DelimitedSeq<T>(src, Chars.Comma, 0, null);
    }
}