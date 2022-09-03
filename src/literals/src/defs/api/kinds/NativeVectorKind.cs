//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static NumericKind;

    using CW = CpuCellWidth;
    using NBK = NumericBaseKind;

    /// <summary>
    /// Classifies concrete intrinsic vectors of total width w over components of width t and sign indicator s where:
    /// w = kind[0..15]
    /// t = kind[16..23]
    /// s = {u | i | f} as determined by kind[30..31]
    /// </summary>
    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum NativeVectorKind : uint
    {
        None = 0,

        /// <summary>
        /// A 128-bit vector covering 16 8-bit unsigned segments
        /// </summary>
        v128x8u = CW.W128 | U8,

        /// <summary>
        /// A 128-bit vector covering 16 8-bit signed segments
        /// </summary>
        v128x8i = CW.W128 | I8,

        /// <summary>
        /// A 128-bit vector covering 8 16-bit unsigned segments
        /// </summary>
        v128x16u = CW.W128 | U16,

        /// <summary>
        /// A 128-bit vector covering 8 16-bit signed segments
        /// </summary>
        v128x16i = CW.W128 | I16,

        /// <summary>
        /// A 128-bit vector covering 4 32-bit unsigned segments
        /// </summary>
        v128x32u = CW.W128 | U32,

        /// <summary>
        /// A 128-bit vector covering 4 32-bit signed segments
        /// </summary>
        v128x32i = CW.W128 | I32,

        /// <summary>
        /// A 128-bit vector covering 2 64-bit unsigned segments
        /// </summary>
        v128x64u = CW.W128 | U64,

        /// <summary>
        /// A 128-bit vector covering 2 64-bit signed segments
        /// </summary>
        v128x64i = CW.W128 | I64,

        /// <summary>
        /// A 128-bit vector covering 4 32-bit floating-point segments
        /// </summary>
        v128x32f = CW.W128 | F32,

        /// <summary>
        /// A 128-bit vector covering 2 64-bit floating-point segments
        /// </summary>
        v128x64f = CW.W128 | F64,

        /// <summary>
        /// A 256-bit vector covering 32 8-bit unsigned segments
        /// </summary>
        v256x8u = CW.W256 | U8,

        /// <summary>
        /// A 256-bit vector covering 32 8-bit signed segments
        /// </summary>
        v256x8i = CW.W256 | I8,

        /// <summary>
        /// A 256-bit vector covering 16 16-bit unsigned segments
        /// </summary>
        v256x16u = CW.W256 | U16,

        /// <summary>
        /// A 256-bit vector covering 16 16-bit signed segments
        /// </summary>
        v256x16i = CW.W256 | I16,

        /// <summary>
        /// A 256-bit vector covering 8 32-bit signed segments
        /// </summary>
        v256x32i = CW.W256 | I32,

        /// <summary>
        /// A 256-bit vector covering 8 32-bit unsigned segments
        /// </summary>
        v256x32u = CW.W256 | U32,

        /// <summary>
        /// A 256-bit vector covering 4 64-bit unsigned segments
        /// </summary>
        v256x64u = CW.W256 | U64,

        /// <summary>
        /// A 256-bit vector covering 4 64-bit signed segments
        /// </summary>
        v256x64i = CW.W256 | I64,

        /// <summary>
        /// A 256-bit vector covering 8 32-bit floating-point segments
        /// </summary>
        v256x32f = CW.W256 | F32,

        /// <summary>
        /// A 256-bit vector covering 4 64-bit floating-point segments
        /// </summary>
        v256x64f = CW.W256 | F64,

        /// <summary>
        /// A 512-bit vector covering 32 8-bit unsigned segments
        /// </summary>
        v512x8u = CW.W512 | U8,

        /// <summary>
        /// A 512-bit vector covering 32 8-bit signed segments
        /// </summary>
        v512x8i = CW.W512 | I8,

        /// <summary>
        /// A 512-bit vector covering 16 16-bit unsigned segments
        /// </summary>
        v512x16u = CW.W512 | U16,

        /// <summary>
        /// A 512-bit vector covering 16 16-bit signed segments
        /// </summary>
        v512x16i = CW.W512 | I16,

        /// <summary>
        /// A 512-bit vector covering 8 32-bit unsigned segments
        /// </summary>
        v512x32u = CW.W512 | U32,

        /// <summary>
        /// A 512-bit vector covering 8 32-bit signed segments
        /// </summary>
        v512x32i = CW.W512 | I32,

        /// <summary>
        /// A 512-bit vector covering 4 64-bit unsigned segments
        /// </summary>
        v512x64u = CW.W512 | U64,

        /// <summary>
        /// A 512-bit vector covering 4 64-bit signed segments
        /// </summary>
        v512x64i = CW.W512 | I64,

        /// <summary>
        /// A 512-bit vector covering 8 32-bit floating-point segments
        /// </summary>
        v512x32f = CW.W512 | F32,

        /// <summary>
        /// A 512-bit vector covering 4 64-bit floating-point segments
        /// </summary>
        v512x64f = CW.W512 | F64,
    }
}