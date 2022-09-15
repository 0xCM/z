//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct InputValue<T>
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public InputValue(T src)
            => Value = src;

        [MethodImpl(Inline)]
        public string Format()
            => Value?.ToString() ?? EmptyString;

        public override string ToString()
                => Format();

        [MethodImpl(Inline)]
        public static implicit operator InputValue<T>(T src)
            => new InputValue<T>(src);
    }
}