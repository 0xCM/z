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
    public readonly struct NatSeq<D0,D1,D2,D3,D4,D5,D6> : INatSeq<NatSeq<D0,D1,D2,D3,D4,D5,D6>>
        where D0 : unmanaged, INatPrimitive<D0>
        where D1 : unmanaged, INatPrimitive<D1>
        where D2 : unmanaged, INatPrimitive<D2>
        where D3 : unmanaged, INatPrimitive<D3>
        where D4 : unmanaged, INatPrimitive<D4>
        where D5 : unmanaged, INatPrimitive<D5>
        where D6 : unmanaged, INatPrimitive<D6>
    {
        public static NatSeq<D0,D1,D2,D3,D4,D5,D6> Rep => default;

        public static ulong Value
        {
            [MethodImpl(Inline)]
            get =>
              value<D0>() * 1000000
            + value<D1>() * 100000
            + value<D2>() * 10000
            + value<D3>() * 1000
            + value<D4>() * 100
            + value<D5>() * 10
            + value<D6>();
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