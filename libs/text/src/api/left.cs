//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SeqEnclosureKind;
    using static Chars;

    partial class RP
    {
        [MethodImpl(Inline), Op]
        public static char left(SeqEnclosureKind kind)
            => kind == Embraced ? LBrace : kind == Bracketed ? LBracket : LParen;
    }
}