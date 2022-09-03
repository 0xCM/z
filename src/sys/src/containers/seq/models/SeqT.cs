//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public class Seq<T> : Seq<Seq<T>,T>
    {
        public Seq()
        {

        }

        [MethodImpl(Inline)]
        public Seq(T[] src)
            : base(src)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator Seq<T>(T[] src)
            => new Seq<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](Seq<T> src)
            => src.Data.Storage;

        [MethodImpl(Inline)]
        public static implicit operator Index<T>(Seq<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Seq<T>(Index<T> src)
            => new Seq<T>(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySeq<T>(Seq<T> src)
            => new ReadOnlySeq<T>(src.Data);
    }
}