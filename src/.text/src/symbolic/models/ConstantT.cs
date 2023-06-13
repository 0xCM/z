//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an invariant value
    /// </summary>
    public readonly struct Constant<T> : IConstExpr<Constant<T>,T>
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Constant(T value)
        {
            Value = value;
        }

        public bool IsEmpty => false;

        public bool IsNonEmpty => !IsEmpty;
        T IValued<T>.Value
            => Value;

        public string Format()
        {
            var pattern = EmptyString;
            if(typeof(T) == typeof(string))
                pattern = "\"{0}\"";
            else if(typeof(T) == typeof(char))
                pattern = "'{0}'";
            else if(typeof(T) == typeof(uint))
                pattern = "{0}u";
            else if(typeof(T) == typeof(ulong))
                pattern = "{0}ul";
            else if(typeof(T) == typeof(long))
                pattern = "{0}L";
            else
                pattern = "{0}";

            return string.Format(pattern, Value);
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Constant<T>(T src)
            => new Constant<T>(src);
    }
}