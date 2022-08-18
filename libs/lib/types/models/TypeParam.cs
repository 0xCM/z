//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

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

        public bool IsClosed
        {
            [MethodImpl(Inline)]
            get => TypeSyntax.closed(this);
        }

        public string Format()
            => string.Format(RpOps.Attrib, Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeParam((string name, string value) src)
            => new TypeParam(src.name, src.value);


        public static TypeParam Empty => new TypeParam(EmptyString,EmptyString);
    }
}