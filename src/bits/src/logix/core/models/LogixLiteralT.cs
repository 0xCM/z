//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Lifts a literal value to an expression
    /// </summary>
    public readonly struct LogixLiteral<T> : ILogixLiteral<T>
        where T : unmanaged
    {
        /// <summary>
        /// The literal value
        /// </summary>
        public T Value {get;}

        [MethodImpl(Inline)]
        public LogixLiteral(T value)
            => Value = value;

        [MethodImpl(Inline)]
        public bool Equals(T other)
            => Value.Equals(other);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object obj)
            => obj is LogixLiteral<T> x && Equals(x);

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        /// <summary>
        /// Implicitly converts a literal expression to the underlying value
        /// </summary>
        /// <param name="src">The source expression</param>
        [MethodImpl(Inline)]
        public static implicit operator T(LogixLiteral<T> src)
            => src.Value;

        /// <summary>
        /// Implicitly converts a value to a literal expression
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator LogixLiteral<T>(T src)
            => new LogixLiteral<T>(src);

        [MethodImpl(Inline)]
        public static bool operator ==(LogixLiteral<T> a, LogixLiteral<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(LogixLiteral<T> a, LogixLiteral<T> b)
            => !a.Equals(b);
    }
}