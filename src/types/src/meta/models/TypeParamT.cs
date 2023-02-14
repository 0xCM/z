//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeParam<T>
    {
        public @string Name {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public TypeParam(@string name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format(RP.Attrib, Name, Value);

        public override string ToString()
            => Format();


        [MethodImpl(Inline)]
        public static implicit operator TypeParam<T>((string name, T value) src)
            => new TypeParam<T>(src.name, src.value);

        public static implicit operator TypeParam(TypeParam<T> src)
            => new TypeParam(src.Name, src.Value?.ToString() ?? EmptyString);
    }

}