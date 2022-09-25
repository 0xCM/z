//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   /// <summary>
   // Captures evidence that k:K => k is prime
   // </summary>
   public readonly struct NatPrime<K> : INatPrime<K>
        where K : unmanaged, ITypeNat
    {
        static readonly K k = default;

        public static string Description => $"{k} is prime";

        [MethodImpl(Inline)]
        public NatPrime(K n)
            => Require.invariant(NatPrime.test(n.NatValue), () => Description);

        public ulong NatValue
            => k.NatValue;

        public string Format()
            => Description;

        public override string ToString()
            => Description;
    }
}