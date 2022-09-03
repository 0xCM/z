//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct UpperCased : ILetterCase<UpperCased>
    {
        public bool IsUpper
            => true;

        public bool IsLower
            => false;

        public LetterCaseKind Kind
            => LetterCaseKind.Upper;

        public static UpperCased Case
            => default(UpperCased);

        [MethodImpl(Inline)]
        public static implicit operator LetterCase(UpperCased src)
            => new LetterCase(src.IsUpper, src.IsLower, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator LetterCaseKind(UpperCased src)
            => src.Kind;
    }
}