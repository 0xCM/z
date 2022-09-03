//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies the sign aspect of a 32-bit value
    /// </summary>
    [SymSource(numeric)]
    public enum Sign32Kind : uint
    {
        /// <summary>
        /// Indicates a value is greater than or equal to zero
        /// </summary>
        Unsigned = 0,

        /// <summary>
        /// Indicates a value is less than zero
        /// </summary>
        Signed = uint.MaxValue ^ int.MaxValue
    }
}