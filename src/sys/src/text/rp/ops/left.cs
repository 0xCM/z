//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Chars;

    partial class RP
    {
        [MethodImpl(Inline), Op]
        public static char left(SeqEnclosureKind kind)
            => kind == SeqEnclosureKind.Embraced ? LBrace : kind == SeqEnclosureKind.Bracketed ? LBracket : LParen;
    }
}