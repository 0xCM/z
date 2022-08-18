//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Typed;

    /// <summary>
    /// Reifies a one-term natural sequence
    /// </summary>
    /// <typeparam name="D0">The type of the first term</typeparam>
    public readonly struct NatSeq0<D0> : INatSeq<NatSeq0<D0>>
        where D0 : unmanaged, INatPrimitive<D0>
    {
        public static NatSeq0<D0> Rep => default;

        public static ulong Value => value<D0>();

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