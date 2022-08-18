//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = DataWidth;

    /// <summary>
    /// Defines a <see cref="DataWidth"/> subset that is constrained to widths that correspond to x86 vectorized registers
    /// </summary>
    [SymSource]
    public enum NativeVectorWidth : ushort
    {
        /// <summary>
        /// Empty
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a bit-width of 128
        /// </summary>
        [Symbol("w128")]
        W128 = W.W128,

        /// <summary>
        /// Indicates a bit-width of 256
        /// </summary>
        [Symbol("w256")]
        W256 = W.W256,

        /// <summary>
        /// Indicates a bit-width of 512
        /// </summary>
        [Symbol("w512")]
        W512 = W.W512,
    }
}