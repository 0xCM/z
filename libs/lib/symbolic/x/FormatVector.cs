//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static string FormatVector<T>(this ReadOnlySpan<T> src, char sep = Chars.Comma)
        {
            var body = src.Map(x => x.ToString()).Join(sep);
            return TextFormat.adjacent(Chars.Lt, body, Chars.Gt);
        }

        public static string FormatVector<T>(this Span<T> src, char sep = Chars.Comma)
            => src.ReadOnly().FormatVector(sep);
    }
}