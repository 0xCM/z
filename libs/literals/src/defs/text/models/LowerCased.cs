//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LowerCased : ILetterCase<LowerCased>
    {
        public static LowerCased Case => default(LowerCased);

        public bool IsUpper
            => false;

        public bool IsLower
            => true;

        public LetterCaseKind Kind
            => LetterCaseKind.Lower;

        [MethodImpl(Inline)]
        public static implicit operator LetterCase(LowerCased src)
            => new LetterCase(src.IsUpper, src.IsLower, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator LetterCaseKind(LowerCased src)
            => src.Kind;
    }
}