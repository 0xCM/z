//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LetterCase
    {
        public readonly bool IsUpper;

        public readonly bool IsLower;

        public readonly LetterCaseKind Kind;

        [MethodImpl(Inline)]
        public LetterCase(bool upper, bool lower, LetterCaseKind kind)
        {
            IsUpper = upper;
            IsLower = lower;
            Kind = kind;
        }
    }
}