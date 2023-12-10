//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    public readonly struct Pow2<N> : INatPow2<N>
        where N : unmanaged, ITypeNat
    {
        public static ulong Value
            => Pow2.pow(sys.nat8u<N>());

        ulong ITypeNat.NatValue
            => Value;
    }
}