//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Typed;

    /// <summary>
    /// Reifies a two-term natural sequence that represents the value k := k1*10 + k2
    /// </summary>
    public readonly struct NatSeq<D0,D1> : INatSeq<NatSeq<D0,D1>>
        where D0 : unmanaged, INatPrimitive<D0>
        where D1 : unmanaged, INatPrimitive<D1>
    {
        public static NatSeq<D0,D1> Rep => default;

        public static ulong Value
        {
            [MethodImpl(Inline)]
            get =>
                value<D0>() * 10ul
              + value<D1>();
        }

        public ulong NatValue => Value;

        public INatSeq Sequence => Rep;

        public string format()
            => Value.ToString();

        public override string ToString()
            => Value.ToString();
    }
}