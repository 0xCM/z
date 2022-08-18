//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ScalarValue<T> : IScalarValue<T>
        where T : unmanaged, IEquatable<T>
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public ScalarValue(T value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public bool Equals(ScalarValue<T> src)
            => Value.Equals(src.Value);

        public override bool Equals(object src)
            => src is ScalarValue<T> s &&  Equals(s);

        public override int GetHashCode()
            => Value.GetHashCode();

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(ScalarValue<T> a, ScalarValue<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ScalarValue<T> a, ScalarValue<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator T(ScalarValue<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ScalarValue<T>(T src)
            => new ScalarValue<T>(src);
    }
}