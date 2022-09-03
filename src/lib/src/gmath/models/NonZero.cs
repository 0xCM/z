//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct NonZero<T> : INonZero<NonZero<T>,T>, IEquatable<T>
        where T : unmanaged
    {
        public readonly T Value {get;}

        [MethodImpl(Inline)]
        public NonZero(T value)
        {
            Value = gmath.nonz(value) ? value : ones<T>();
        }

        [MethodImpl(Inline)]
        public bool Equals(NonZero<T> src)
            => gmath.eq(Value, src.Value);

        [MethodImpl(Inline)]
        public bool Equals(T src)
            => gmath.eq(Value, src);

        [MethodImpl(Inline)]
        public static implicit operator NonZero<T>(T src)
            => new NonZero<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(NonZero<T> src)
            => src.Value;
    }
}