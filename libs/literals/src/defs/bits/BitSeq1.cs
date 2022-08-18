//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines literals corresponding to the set of unique 1-bit sequences
    /// </summary>
    [SymSource("bitseq")]
    public enum BitSeq1 : byte
    {
        /// <summary>
        /// Disabled
        /// </summary>
        b0 = 0b0,

        /// <summary>
        /// Enabled
        /// </summary>
        b1 = 0b1,
    }
}