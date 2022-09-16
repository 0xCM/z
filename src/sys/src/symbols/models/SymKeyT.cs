//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct SymKey<T> : ISymKey<SymKey<T>,T>
        where T : unmanaged
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public SymKey(T value)
            => Value = value;

        public SymKey Untyped
        {
            [MethodImpl(Inline)]
            get => new SymKey(bw32(Value));
        }

        public override int GetHashCode()
            => Untyped.GetHashCode();

        [MethodImpl(Inline)]
        public bool Equals(SymKey<T> src)
            => bw64(Value) == bw64(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(SymKey<T> src)
            => Untyped.CompareTo(src.Untyped);

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SymKey<T>(T value)
            => new SymKey<T>(value);

        [MethodImpl(Inline)]
        public static implicit operator SymKey(SymKey<T> src)
            => src.Untyped;

        [MethodImpl(Inline)]
        public static implicit operator T(SymKey<T> src)
            => src.Value;
    }
}