//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Typed;

    /// <summary>
    /// Reifies a four-term natural sequence
    /// </summary>
    public readonly struct NatSeq<D0,D1,D2,D3> : INatSeq<NatSeq<D0,D1,D2,D3>>
        where D0 : unmanaged, INatPrimitive<D0>
        where D1 : unmanaged, INatPrimitive<D1>
        where D2 : unmanaged, INatPrimitive<D2>
        where D3 : unmanaged, INatPrimitive<D3>
    {
        public static NatSeq<D0,D1,D2,D3> Rep => default;

        public static ulong Value
        {
            [MethodImpl(Inline)]
            get =>
              value<D0>() * 1000ul
            + value<D1>() * 100ul
            + value<D2>() * 10ul
            + value<D3>();
        }

        public ulong NatValue => Value;

        public INatSeq Sequence => Rep;

        public string format()
            => Value.ToString();

        public override string ToString()
            => Value.ToString();
    }
}