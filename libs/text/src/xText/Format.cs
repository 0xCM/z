//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [TextUtility]
        public static string Format(this sbyte i, byte n)
            => string.Format(RP.digits(n), i);

        [TextUtility]
        public static string Format(this byte i, byte n)
            => string.Format(RP.digits(n), i);

        [TextUtility]
        public static string Format(this short i, byte n)
            => string.Format(RP.digits(n), i);

        [TextUtility]
        public static string Format(this ushort i, byte n)
            => string.Format(RP.digits(n), i);

        [TextUtility]
        public static string Format(this int i, byte n)
            => string.Format(RP.digits(n), i);

        [TextUtility]
        public static string Format(this uint i, byte n)
            => string.Format(RP.digits(n), i);

        [TextUtility]
        public static string Format(this ReadOnlySpan<char> src)
            => new string(src);

        [TextUtility]
        public static string Format(this Span<char> src)
            => new string(src);
    }
}