//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies the sign aspect of an integral value
    /// </summary>
    [SymSource(numeric)]
    public enum SignKind : sbyte
    {
        /// <summary>
        /// The sign of 0
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a value is greater than or equal to zero
        /// </summary>
        Positive = 1,

        /// <summary>
        /// Indicates a value is less than zero
        /// </summary>
        Negative = -1
    }
}