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
        public static char right(SeqEnclosureKind kind)
            => kind == SeqEnclosureKind.Embraced ? RBrace : kind == SeqEnclosureKind.Bracketed ? RBracket : RParen;
    }
}