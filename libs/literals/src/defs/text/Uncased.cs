//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Uncased : ILetterCase<Uncased>
    {
        public bool IsUpper
            => false;

        public bool IsLower
            => false;

        public LetterCaseKind Kind
            => LetterCaseKind.None;

        public static Uncased Case
            => default(Uncased);

        [MethodImpl(Inline)]
        public static implicit operator LetterCase(Uncased src)
            => new LetterCase(src.IsUpper, src.IsLower, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator LetterCaseKind(Uncased src)
            => src.Kind;
    }
}