//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Any value, parametrically
    /// </summary>
    public struct Any<T>
    {
        public T Value;

        [MethodImpl(Inline)]
        public Any(in T src)
            => Value = src;

        [MethodImpl(Inline)]
        public bool Equals(T src)
            => Value.Equals(src);

        [MethodImpl(Inline)]
        public bool Equals(Any<T> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object src)
            => src is Any<T> a && Equals(a);

        [MethodImpl(Inline)]
        public static bool operator ==(Any<T> x, Any<T> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(Any<T> x, Any<T> y)
            => !x.Equals(y);

        [MethodImpl(Inline)]
        public static implicit operator Any<T>(T src)
            => new Any<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Any<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Any(Any<T> src)
            => new Any(src.Value);
    }
}