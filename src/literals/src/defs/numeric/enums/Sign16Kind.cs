//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies the sign aspect of a 16-bit value
    /// </summary>
    [SymSource(numeric)]
    public enum Sign16Kind : ushort
    {
        /// <summary>
        /// Indicates a value is greater than or equal to zero
        /// </summary>
        Unsigned = 0,

        /// <summary>
        /// Indicates a value is less than zero
        /// </summary>
        Signed = ushort.MaxValue ^ short.MaxValue
    }
}