//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static partial class text
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// An abbreviation for the ridiculously long "StringComparison.InvariantCultureIgnoreCase"
        /// </summary>
        public const StringComparison NoCase = StringComparison.InvariantCultureIgnoreCase;

        /// <summary>
        /// An abbreviation for the somewhat verbose "StringComparison.InvariantCulture"
        /// </summary>
        public const StringComparison Cased = StringComparison.InvariantCulture;
    }
}