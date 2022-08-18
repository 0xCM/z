//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines interval classifications predicated on endpoint containment
    /// </summary>
    public enum IntervalKind : byte
    {
        /// <summary>
        /// Indicates a closed interval [a,b]
        /// </summary>
        [FormatPattern("[{0},{1}]")]
        Closed = 0,

        /// <summary>
        /// Indicates an open interval (a,b)
        /// </summary>
        [FormatPattern("({0},{1})")]
        Open = 1,

        /// <summary>
        /// Indicates a left-closed/right-open interval [a,b)
        /// </summary>
        [FormatPattern("[{0},{1})")]
        LeftClosed = 4,

        /// <summary>
        /// Indicates a right-closed/left-open interval (a,b]
        /// </summary>
        [FormatPattern("({0},{1}]")]
        RightClosed = 8,

        /// <summary>
        /// Indicates a left-open/right-closed interval (a,b], a synonym for <see cref='RightClosed'/>
        /// </summary>
        [FormatPattern("({0},{1}]")]
        LeftOpen = RightClosed,

        /// <summary>
        /// Indicates a right-open/left-closed interval [a,b), a synonym for <see cref='LeftClosed'/>
        /// </summary>
        [FormatPattern("[{0},{1})")]
        RightOpen = LeftClosed
    }
}