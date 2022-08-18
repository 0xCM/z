//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the available tuple format styles that may be applied when representing a tuple as text
    /// </summary>
    public enum TupleFormatKind
    {
        /// <summary>
        /// Indicates a tuple text representation of the form "(x1,...xn)"
        /// </summary>
        Coordinate,

        /// <summary>
        /// Indicates a tuple text representation of the form "A1xA2x ... xAn"
        /// </summary>
        Dimension,

        /// <summary>
        /// Indicates a tuple text representation of the form "[x1,...xn]"
        /// </summary>
        List,

        /// <summary>
        /// Indicates a tuple text representation of the form "{x1,...xn}"
        /// </summary>
        Record,

        /// <summary>
        /// Indicates a tuple text representation of the form "(x1:x2:...:x3)"
        /// </summary>
        Attribute,
    }
}