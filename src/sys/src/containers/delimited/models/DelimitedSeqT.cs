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

        }

        [MethodImpl(Inline)]
        public DelimitedSeq(ReadOnlySeq<T> src, char delimiter = DelimitedSeq.DefaultDelimiter, int pad = 0, Fence<char>? fence = null)
            : base(src.Storage)
        {
            Delimiter = delimiter.ToString();
            CellPad = pad;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public static implicit operator DelimitedSeq<T>(ReadOnlySeq<T> src)
            => new DelimitedSeq<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator DelimitedSeq<T>(T[] src)
            => new DelimitedSeq<T>(src);
    }
}