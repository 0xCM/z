//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class NaturalSeq<N,T> : Seq<NaturalSeq<N,T>,T>
        where T : IEquatable<T>
        where N : unmanaged, ITypeNat
    {
        public static N n => default;

        public NaturalSeq()
            : base(alloc<T>(n.NatValue))
        {

        }

        [MethodImpl(Inline)]
        public NaturalSeq(T[] src)
            : base(src)
        {

        }

        public new NaturalSeq<N,T> Reverse()
            => new NaturalSeq<N,T>(Data.Reverse());

        [MethodImpl(Inline)]
        public static implicit operator T[](NaturalSeq<N,T> src)
            => src.Data.Storage;

        [MethodImpl(Inline)]
        public static implicit operator Index<T>(NaturalSeq<N,T> src)
            => src.Data;
    }
}