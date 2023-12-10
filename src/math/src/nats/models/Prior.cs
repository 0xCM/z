//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class TypeNats
{
    
    /// <summary>
    /// Captures evidence that k1 - 1 = k2
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="K2">The second nat type</typeparam>
    public readonly struct Prior<K1,K2> : INatPrior<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {
        static readonly K1 k1 = default;

        static readonly K2 k2 = default;

        static string Description => $"{k1} - 1 = {k2}";

        [MethodImpl(Inline)]
        public Prior(K1 n1, K2 n2)
        {
            valid = true;
            Require.invariant(n1.NatValue - 1 == n2.NatValue, () => Description);
        }

        public bool valid {get;}

        public ulong NatValue => value<K1>() -1;

        public override string ToString()
            => Description;
    }
    
}
