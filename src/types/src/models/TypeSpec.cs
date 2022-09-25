//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeSpec : INullity, IEquatable<TypeSpec>
    {
        readonly string Pattern;

        [MethodImpl(Inline)]
        public TypeSpec(string src)
        {
            Pattern = src;
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Pattern ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Pattern);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(Pattern);
        }

        [MethodImpl(Inline)]
        public bool Equals(TypeSpec src)
            => Text.Equals(src.Text);

        public string Format(params object[] args)
            => TypeFormatter.format(this, args);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeSpec(string src)
            => new TypeSpec(src);

        [MethodImpl(Inline)]
        public static implicit operator TypeSpec(Type src)
            => new TypeSpec(src.DisplayName());

        [MethodImpl(Inline)]
        public static implicit operator string(TypeSpec src)
            => src.Text;

        public static TypeSpec Empty => new TypeSpec(EmptyString);
    }
}