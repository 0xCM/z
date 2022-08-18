//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SeqEnclosureKind;
    using static Chars;

    [LiteralProvider]
    public partial class RP
    {
        const NumericKind Closure = UnsignedInts;

        const int NotFound = -1;

        [MethodImpl(Inline), Op]
        public static char right(SeqEnclosureKind kind)
            => kind == Embraced ? RBrace : kind == Bracketed ? RBracket : RParen;

        [MethodImpl(Inline)]
        static string msgarg<T>(T src)
            => string.Format("<{0}>", src);

        public static string msg<T>(string pattern, T a)
            => string.Format(pattern, msgarg(a));
    }
}