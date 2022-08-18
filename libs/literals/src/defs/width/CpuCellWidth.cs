//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using DW = DataWidth;

    /// <summary>
    /// Defines a <see cref="DataWidth"/> constrained to widths supported by available fixed-width types
    /// </summary>
    [Flags]
    public enum CpuCellWidth : ushort
    {
        /// <summary>
        /// Void
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a bit-width of 1
        /// </summary>
        W1 = DW.W1,

        /// <summary>
        /// Indicates a bit-width of 2
        /// </summary>
        W2 = DW.W2,

        /// <summary>
        /// Indicates a bit-width of 4
        /// </summary>
        W4 = DW.W4,

        /// <summary>
        /// Indicates a bit-width of 8
        /// </summary>
        W8 = DW.W8,

        /// <summary>
        /// Indicates a bit-width of 16
        /// </summary>
        W16 = DW.W16,

        /// <summary>
        /// Indicates a bit-width of 32
        /// </summary>
        W32 = DW.W32,

        /// <summary>
        /// Indicates a bit-width of 64
        /// </summary>
        W64 = DW.W64,

        /// <summary>
        /// Indicates a bit-width of 128
        /// </summary>
        W128 = DW.W128,

        /// <summary>
        /// Indicates a bit-width of 256
        /// </summary>
        W256 = DW.W256,

        /// <summary>
        /// Indicates a bit-width of 512
        /// </summary>
        W512 = DW.W512,

        /// <summary>
        /// Indicates a bit-width of 1024
        /// </summary>
        W1024 = DW.W1024,

        /// <summary>
        /// Classifies widths that correspond numeric primitives
        /// </summary>
        Numeric =  W8 | W16 | W32 | W64,

        /// <summary>
        /// Classifies widths that correspond to vector primitives
        /// </summary>
        Vector = W128 | W256 | W512,

        /// <summary>
        /// Classifies widths that correspond to numeric and vector primitives
        /// </summary>
        TypeWidths = Numeric | Vector
    }
}