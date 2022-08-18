//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NumericKinds;

    partial class XTend
    {
        /// <summary>
        /// Determines the indicator of a numeric kind
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static NumericIndicator Indicator(this NumericKind src)
            => indicator(src);
    }
}