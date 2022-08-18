//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ReadOnlySeq<T> : ReadOnlySeq<ReadOnlySeq<T>,T>
    {
        public ReadOnlySeq()
        {

        }

        [MethodImpl(Inline)]
        public ReadOnlySeq(T[] src)
            : base(src)
        {
        }

        public ref readonly T this[long i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly T this[ulong i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ReadOnlySeq<T> Reverse()
            => new ReadOnlySeq<T>(Data.Reverse());

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySeq<T>(T[] src)
            => new ReadOnlySeq<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySeq<T>(Index<T> src)
            => new ReadOnlySeq<T>(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(ReadOnlySeq<T> src)
            => src.View;
    }
}