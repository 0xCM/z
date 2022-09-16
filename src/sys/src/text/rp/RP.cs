//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Chars;

    [LiteralProvider]
    public partial class RP
    {
        public static Fence<char> Vectorized => fence(Lt, Gt);

        const NumericKind Closure = UnsignedInts;

        const int NotFound = -1;

        public const char PropertySep = Chars.Colon;

        public const sbyte PropertyPad = -16;
    }
}