//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines polarity classifiers
    /// </summary>
    [SymSource(api_kinds)]
    public enum PolarityKind : sbyte
    {
        /// <summary>
        /// Indicates negative polarity
        /// </summary>
        Left = -1,

        /// <summary>
        /// Indicates nonnegative polarity
        /// </summary>
        Right = 0,
    }
}