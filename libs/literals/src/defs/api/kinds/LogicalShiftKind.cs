//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines scalar shift operator classifiers
    /// </summary>
    [SymSource(api_kinds)]
    public enum LogicalShiftKind : byte
    {
        /// <summary>
        /// Shift left logical
        /// </summary>
        [Symbol("sll", "Shift left logical")]
        Sll,

        /// <summary>
        /// Shift right logical
        /// </summary>
        [Symbol("srl", "Shift right logical")]
        Srl,

        /// <summary>
        /// Rotate left
        /// </summary>
        [Symbol("rotl", "Rotate left")]
        Rotl,

        /// <summary>
        /// Rotate right
        /// </summary>
        [Symbol("rotr", "Rotate right")]
        Rotr
    }
}