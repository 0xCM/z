//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Typed;

    /// <summary>
    /// Reifies a seven-term natural sequence
    /// </summary>
    public readonly struct NatSeq<D0,D1,D2,D3,D4,D5,D6,D7,D8> : INatSeq<NatSeq<D0,D1,D2,D3,D4,D5,D6,D7,D8>>
        where D0 : unmanaged, INatPrimitive<D0>
        where D1 : unmanaged, INatPrimitive<D1>
        where D2 : unmanaged, INatPrimitive<D2>
        where D3 : unmanaged, INatPrimitive<D3>
        where D4 : unmanaged, INatPrimitive<D4>
        where D5 : unmanaged, INatPrimitive<D5>
        where D6 : unmanaged, INatPrimitive<D6>
        where D7 : unmanaged, INatPrimitive<D7>
        where D8 : unmanaged, INatPrimitive<D8>
    {
        public static NatSeq<D0,D1,D2,D3,D4,D5,D6,D7,D8> Rep => default;

        public static ulong Value
        {
            [MethodImpl(Inline)]
            get =>
              value<D0>() * 100000000
            + value<D1>() * 10000000
            + value<D2>() * 1000000
            + value<D3>() * 100000
            + value<D4>() * 10000
            + value<D5>() * 1000
            + value<D6>() * 100
            + value<D7>() * 10
            + value<D8>();
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