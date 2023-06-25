//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    /// <summary>
    /// Constants for mantissa extraction
    /// </summary>
    [SymSource("dsl.intrinsics")]
    public enum _MM_MANTISSA_NORM_ENUM: byte
    {
        /// <summary>
        /// interval [1, 2)
        /// </summary>
        _MM_MANT_NORM_1_2,

        /// <summary>
        /// interval [1.5, 2)
        /// </summary>
        _MM_MANT_NORM_p5_2,

        /// <summary>
        /// interval [1.5, 1)
        /// </summary>
        _MM_MANT_NORM_p5_1,

        /// <summary>
        /// interval [0.75, 1.5)
        /// </summary>
        _MM_MANT_NORM_p75_1p5
    }        
}