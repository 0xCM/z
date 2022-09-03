//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines literals corresponding to parity state
    /// </summary>
    public enum ParityKind : byte
    {
        /// <summary>
        /// Even
        /// </summary>
        Even = BitSeq1.b0,

        /// <summary>
        /// Enabled
        /// </summary>
        Odd = BitSeq1.b1,
    }
}