//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct BitMask<T>
        where T : unmanaged
    {
        public readonly T Invariant;

        public T Blend;

        [MethodImpl(Inline)]
        public BitMask(T invariant)
        {
            Invariant = invariant;
            Blend = default;
        }

        [MethodImpl(Inline)]
        public static implicit operator BitMask<T>(T invariant)
            => new BitMask<T>(invariant);

        [MethodImpl(Inline)]
        public static BitMask<T> operator &(BitMask<T> a, T b)
        {
            a.Blend = gmath.and(a.Invariant, gmath.and(a.Blend, b));
            return a;
        }

        [MethodImpl(Inline)]
        public static BitMask<T> operator |(BitMask<T> a, T b)
        {
            a.Blend = gmath.and(a.Invariant, gmath.or(a.Blend, b));
            return a;
        }

        [MethodImpl(Inline)]
        public static BitMask<T> operator ^(BitMask<T> a, T b)
        {
            a.Blend = gmath.and(a.Invariant, gmath.xor(a.Blend, b));
            return a;
        }
    }
}