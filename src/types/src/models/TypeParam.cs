//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeParam
    {
        public @string Name {get;}

        public @string Value {get;}

        [MethodImpl(Inline)]
        public TypeParam(@string name, @string value)
        {
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty && Value.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty || Value.IsNonEmpty;
        }


        public string Format()
            => string.Format(RP.Attrib, Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeParam((string name, string value) src)
            => new TypeParam(src.name, src.value);


        public static TypeParam Empty => new TypeParam(EmptyString,EmptyString);
    }
}