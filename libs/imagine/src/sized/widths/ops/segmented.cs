//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Widths
    {
        /// <summary>
        /// Determines the width of a (known) segmented type
        /// </summary>
        /// <param name="src">The source type</param>
        public static NativeTypeWidth segmented(Type src)
            => src.Tag<SpanBlockAttribute>().MapValueOrElse(a => a.TypeWidth, () => vector(src));
    }
}