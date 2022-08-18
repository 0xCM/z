//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Typed;

    /// <summary>
    /// Reifies a five-term natural sequence
    /// </summary>
    public readonly struct NatSeq<D0,D1,D2,D3,D4> : INatSeq<NatSeq<D0,D1,D2,D3,D4>>
        where D0 : unmanaged, INatPrimitive<D0>
        where D1 : unmanaged, INatPrimitive<D1>
        where D2 : unmanaged, INatPrimitive<D2>
        where D3 : unmanaged, INatPrimitive<D3>
        where D4 : unmanaged, INatPrimitive<D4>
    {
        public static NatSeq<D0,D1,D2,D3,D4> Rep => default;

        public static ulong Value
        {
            [MethodImpl(Inline)]
            get =>
              value<D0>() * 10000
            + value<D1>() * 1000
            + value<D2>() * 100
            + value<D3>() * 10
            + value<D4>();
        }

        public ulong NatValue
            => Value;

        public ITypeNat NatRep
            => Rep;

        public INatSeq Sequence
            => Rep;

        public string format()
            => Value.ToString();

        public override string ToString()
            => format();
    }
}