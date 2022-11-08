//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XTend
    {
        public static ReadOnlySpan<TextLine> Lines(this string src, bool keepblank = false, bool trim = true)
            => Z0.Lines.read(src, keepblank, trim);
    }
}