//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies the precision with which time value should be interpreted
    /// </summary>
    public enum TimeResolution : byte
    {
        None = 0,

        /// <summary>
        /// Specifies date-level accuracy
        /// </summary>
        Date = 1,

        /// <summary>
        /// Specifies hour-level accuracy
        /// </summary>
        Hour = 2,

        /// <summary>
        /// Specifies minute-level accuracy
        /// </summary>
        Minute = 3,

        /// <summary>
        /// Specifies second-level accuracy
        /// </summary>
        Second = 4,

        /// <summary>
        /// Specifies millisecond-level accuracy
        /// </summary>
        Ms = 5
    }
}