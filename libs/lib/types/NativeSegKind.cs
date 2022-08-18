//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using SC = NativeClass;
    using SZ = NativeSizeCode;

    /// <summary>
    /// Classifies concrete storage blocks of total width w over segments of width t and sign indicator s where:
    /// w = kind[0..15]
    /// t = kind[16..23]
    /// s = {u | i | f} as determined by kind[30..31]
    /// </summary>
    [SymSource("native.types", NumericBaseKind.Base16), Flags]
    public enum NativeSegKind : ushort
    {
        [Symbol("", "")]
        Void = 0,

        /// <summary>
        /// An 8-bit unsigned segment
        /// </summary>
        [Symbol("8u", "An 8-bit unsigned segment")]
        Seg8u = (SZ.W8 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// An 8-bit signed segment
        /// </summary>
        [Symbol("8i", "An 8-bit signed segment")]
        Seg8i = (SZ.W8 | SC.I << 4) | (1 << 8),

        /// <summary>
        /// A 16-bit unsigned segment
        /// </summary>
        [Symbol("16u", "A 16-bit unsigned segment")]
        Seg16u = (SZ.W16 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 16-bit signed segment
        /// </summary>
        [Symbol("16i", "A 16-bit signed segment")]
        Seg16i = (SZ.W16 | SC.I << 4) | (1 << 8),

        /// <summary>
        /// A 32-bit unsigned segment
        /// </summary>
        [Symbol("32u", "A 32-bit unsigned segment")]
        Seg32u = (SZ.W32 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 32-bit signed segment
        /// </summary>
        [Symbol("32i", "A 64-bit unsigned segment")]
        Seg32i = (SZ.W32 | SC.I << 4) | (1 << 8),

        /// <summary>
        /// A 64-bit unsigned segment
        /// </summary>
        [Symbol("64u", "A 64-bit unsigned segment")]
        Seg64u = (SZ.W64 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 64-bit signed segment
        /// </summary>
        [Symbol("64i", "A 64-bit signed segment")]
        Seg64i = (SZ.W64 | SC.I << 4) | (1 << 8),

        /// <summary>
        /// A 32-bit floating-point segment
        /// </summary>
        [Symbol("32f", "A 32-bit floating-point segment")]
        Seg32f = (SZ.W32 | SC.F << 4) | (1 << 8),

        /// <summary>
        /// A 64-bit floating-point segment
        /// </summary>
        [Symbol("64f", "A 64-bit floating-point segment")]
        Seg64f = (SZ.W64 | SC.F << 4) | (1 << 8),

        /// <summary>
        /// A 128-bit unsigned segment
        /// </summary>
        [Symbol("128u", "A 128-bit unsigned segment")]
        Seg128u = (SZ.W128 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 256-bit unsigned segment
        /// </summary>
        [Symbol("256u", "A 256-bit unsigned segment")]
        Seg256u = (SZ.W256 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 512-bit unsigned segment
        /// </summary>
        [Symbol("512u", "A 512-bit unsigned segment")]
        Seg512u = (SZ.W512 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 16-bit segment covering 2 unsigned 8-bit partitions
        /// </summary>
        [Symbol("16x8u", "A 16-bit segment covering 2 unsigned 8-bit partitions")]
        Seg16x8u = (SZ.W8 | SC.U << 4) | (2 << 8),

        /// <summary>
        /// A 16-bit segment covering 2 signed 8-bit partitions
        /// </summary>
        [Symbol("16x8i", "A 16-bit segment covering 2 signed 8-bit partitions")]
        Seg16x8i = (SZ.W8 | SC.I << 4) | (2 << 8),

        /// <summary>
        /// A 32-bit segment covering 4 unsigned 8-bit partitions
        /// </summary>
        [Symbol("32x8u", "A 32-bit segment covering 4 unsigned 8-bit partitions")]
        Seg32x8u = (SZ.W8 | SC.U << 4) | (4 << 8),

        /// <summary>
        /// A 32-bit segment covering 4 unsigned 8-bit partitions
        /// </summary>
        [Symbol("32x8i", "A 32-bit segment covering 4 unsigned 8-bit partitions")]
        Seg32x8i = (SZ.W8 | SC.I << 4) | (4 << 8),

        /// <summary>
        /// A 32-bit segment covering 2 unsigned 16-bit partitions
        /// </summary>
        [Symbol("32x16u", "A 32-bit segment covering 2 unsigned 16-bit partitions")]
        Seg32x16u = (SZ.W16 | SC.U << 4) | (2 << 8),

        /// <summary>
        /// A 32-bit block covering 2 signed 16-bit partitions
        /// </summary>
        [Symbol("32x16i", "A 32-bit block covering 2 signed 16-bit partitions")]
        Seg32x16i = (SZ.W16 | SC.I << 4) | (2 << 8),

        /// <summary>
        /// A 64-bit block covering 8 unsigned 8-bit partitions
        /// </summary>
        [Symbol("64x8u", "A 64-bit block convering 8 unsigned 8-bit partitions")]
        Seg64x8u = (SZ.W8 | SC.U << 4) | (8 << 8),

        /// <summary>
        /// A 64-bit block covering 8 signed 8-bit partitions
        /// </summary>
        [Symbol("64x8i", "A 64-bit block covering 8 signed 8-bit partitions")]
        Seg64x8i = (SZ.W8 | SC.I << 4) | (8 << 8),

        /// <summary>
        /// A 64-bit block covering 4 unsigned 16-bit partitions
        /// </summary>
        [Symbol("64x16u", "A 64-bit block covering 4 unsigned 16-bit partitions")]
        Seg64x16u = (SZ.W16 | SC.U << 4) | (4 << 8),

        /// <summary>
        /// A 64-bit block covering 4 signed 16-bit partitions
        /// </summary>
        [Symbol("64x16i", "A 64-bit block covering 4 signed 16-bit partitions")]
        Seg64x16i = (SZ.W16 | SC.I << 4) | (4 << 8),

        /// <summary>
        /// A 64-bit block covering 2 unsigned 32-bit partitions
        /// </summary>
        [Symbol("64x32u", "A 64-bit block covering 2 unsigned 32-bit partitions")]
        Seg64x32u = (SZ.W32 | SC.U << 4) | (2 << 8),

        /// <summary>
        /// A 64-bit block covering 2 signed 32-bit partitions
        /// </summary>
        [Symbol("64x32i", "A 64-bit block covering 2 signed 32-bit partitions")]
        Seg64x32i = (SZ.W32 | SC.I << 4) | (2 << 8),

        /// <summary>
        /// A 64-bit block covering 2 32-bit floating-point partitions
        /// </summary>
        [Symbol("64x32f", "A 64-bit block covering 2 32-bit floating-point partitions")]
        Seg64x32f = (SZ.W32 | SC.F << 4) | (2 << 8),

        /// <summary>
        /// A 128-bit block covering 16 8-bit unsigned partitions
        /// </summary>
        [Symbol("128x8u", "A 128-bit block covering 16 8-bit unsigned partitions")]
        Seg128x8u = (SZ.W8 | SC.U << 4) | (16 << 8),

        /// <summary>
        /// A 128-bit block covering 16 8-bit signed partitions
        /// </summary>
        [Symbol("128x8i", "A 128-bit block covering 16 8-bit signed partitions")]
        Seg128x8i = (SZ.W8 | SC.I << 4) | (16 << 8),

        /// <summary>
        /// A 128-bit block covering 8 16-bit unsigned partitions
        /// </summary>
        [Symbol("128x16u", "A 128-bit block covering 8 16-bit unsigned partitions")]
        Seg128x16u = (SZ.W16 | SC.U << 4) | (8 << 8),

        /// <summary>
        /// A 128-bit block covering 8 16-bit signed partitions
        /// </summary>
        [Symbol("128x16i", "A 128-bit block covering 8 16-bit signed partitions")]
        Seg128x16i = (SZ.W16 | SC.I << 4) | (8 << 8),

        /// <summary>
        /// A 128-bit block covering 4 32-bit unsigned partitions
        /// </summary>
        [Symbol("128x32u", "A 128-bit block covering 4 32-bit unsigned partitions")]
        Seg128x32u = (SZ.W32 | SC.U << 4) | (4 << 8),

        /// <summary>
        /// A 128-bit block covering 4 32-bit signed partitions
        /// </summary>
        [Symbol("128x32i", "A 128-bit block covering 4 32-bit signed partitions")]
        Seg128x32i = (SZ.W32 | SC.I << 4) | (4 << 8),

        /// <summary>
        /// A 128-bit block covering 2 64-bit unsigned partitions
        /// </summary>
        [Symbol("128x64u", "A 128-bit block covering 2 64-bit unsigned partitions")]
        Seg128x64u = (SZ.W64 | SC.U << 4) | (2 << 8),

        /// <summary>
        /// A 128-bit block covering 2 64-bit signed partitions
        /// </summary>
        [Symbol("128x64i", "A 128-bit block covering 2 64-bit signed partitions")]
        Seg128x64i = (SZ.W64 | SC.I << 4) | (2 << 8),

        /// <summary>
        /// A 128-bit block covering 8 16-bit floating-point partitions
        /// </summary>
        [Symbol("128x16f", "A 128-bit block covering 8 32-bit floating-point partitions")]
        Seg128x16f = (SZ.W16 | SC.F << 4) | (8 << 8),

        /// <summary>
        /// A 128-bit block covering 4 32-bit floating-point partitions
        /// </summary>
        [Symbol("128x32f", "A 128-bit block covering 4 32-bit floating-point partitions")]
        Seg128x32f = (SZ.W32 | SC.F << 4) | (4 << 8),

        /// <summary>
        /// A 128-bit block covering 2 64-bit floating-point partitions
        /// </summary>
        [Symbol("128x64f", "A 128-bit block covering 2 64-bit floating-point partitions")]
        Seg128x64f = (SZ.W64 | SC.F << 4) | (2 << 8),

        /// <summary>
        /// A 256-bit block covering 32 8-bit unsigned partitions
        /// </summary>
        [Symbol("256x8u", "A 256-bit block covering 32 8-bit unsigned partitions")]
        Seg256x8u = (SZ.W8 | SC.U << 4) | (32 << 8),

        /// <summary>
        /// A 256-bit block covering 32 8-bit signed partitions
        /// </summary>
        [Symbol("256x8i", "A 256-bit block covering 32 8-bit signed partitions")]
        Seg256x8i = (SZ.W8 | SC.I << 4) | (32 << 8),

        /// <summary>
        /// A 256-bit block covering 16 16-bit unsigned partitions
        /// </summary>
        [Symbol("256x16u", "A 256-bit block covering 16 16-bit unsigned partitions")]
        Seg256x16u = (SZ.W16 | SC.U << 4) | (16 << 8),

        /// <summary>
        /// A 256-bit block covering 16 16-bit signed partitions
        /// </summary>
        [Symbol("256x16i", "A 256-bit block covering 16 16-bit signed partitions")]
        Seg256x16i = (SZ.W16 | SC.I << 4) | (16 << 8),

        /// <summary>
        /// A 256-bit block covering 8 32-bit unsigned partitions
        /// </summary>
        [Symbol("256x32u", "A 256-bit block covering 8 32-bit unsigned partitions")]
        Seg256x32u = (SZ.W32 | SC.U << 4) | (8 << 8),

        /// <summary>
        /// A 256-bit block covering 8 32-bit signed partitions
        /// </summary>
        [Symbol("256x32i", "A 256-bit block covering 8 32-bit signed partitions")]
        Seg256x32i = (SZ.W32 | SC.I << 4) | (8 << 8),

        /// <summary>
        /// A 256-bit block covering 4 64-bit unsigned partitions
        /// </summary>
        [Symbol("256x64u", "A 256-bit block covering 4 64-bit unsigned partitions")]
        Seg256x64u = (SZ.W64 | SC.U << 4) | (4 << 8),

        /// <summary>
        /// A 256-bit block covering 4 64-bit signed partitions
        /// </summary>
        [Symbol("256x64i", "A 256-bit block covering 4 64-bit signed partitions")]
        Seg256x64i = (SZ.W64 | SC.I << 4) | (4 << 8),

        /// <summary>
        /// A 256-bit block covering 16 16-bit floating-point partitions
        /// </summary>
        [Symbol("256x16f", "A 256-bit block covering 16 16-bit floating-point partitions")]
        Seg256x16f = (SZ.W16 | SC.F << 4) | (16 << 8),

        /// <summary>
        /// A 256-bit block covering 8 32-bit floating-point partitions
        /// </summary>
        [Symbol("256x32f", "A 256-bit block covering 8 32-bit floating-point partitions")]
        Seg256x32f = (SZ.W32 | SC.F << 4) | (8 << 8),

        /// <summary>
        /// A 256-bit block covering 4 64-bit floating-point partitions
        /// </summary>
        [Symbol("256x64f", "A 256-bit block covering 4 64-bit floating-point partitions")]
        Seg256x64f = (SZ.W64 | SC.F << 4) | (4 << 8),

        /// <summary>
        /// A 512-bit block covering 64 8-bit unsigned partitions
        /// </summary>
        [Symbol("512x86", "A 512-bit block covering 64 8-bit unsigned partitions")]
        Seg512x8u = (SZ.W8 | SC.U << 4) | (64 << 8),

        /// <summary>
        /// A 512-bit block covering 64 8-bit signed partitions
        /// </summary>
        [Symbol("512x8i", "A 512-bit block covering 64 8-bit signed partitions")]
        Seg512x8i = (SZ.W8 | SC.I << 4) | (64 << 8),

        /// <summary>
        /// A 512-bit block covering 32 16-bit unsigned partitions
        /// </summary>
        [Symbol("512x16u", "A 512-bit block covering 32 16-bit unsigned partitions")]
        Seg512x16u = (SZ.W16 | SC.U << 4) | (32 << 8),

        /// <summary>
        /// A 512-bit block covering 32 16-bit signed partitions
        /// </summary>
        [Symbol("512x16i", "A 512-bit block covering 32 16-bit signed partitions")]
        Seg512x16i = (SZ.W16 | SC.I << 4) | (32 << 8),

        /// <summary>
        /// A 512-bit block covering 16 32-bit unsigned partitions
        /// </summary>
        [Symbol("512x32u", "A 512-bit block covering 16 32-bit unsigned partitions")]
        Seg512x32u = (SZ.W32 | SC.U << 4) | (16 << 8),

        /// <summary>
        /// A 512-bit block covering 16 32-bit signed partitions
        /// </summary>
        [Symbol("512x32i", "A 512-bit block covering 16 32-bit signed partitions")]
        Seg512x32i = (SZ.W32 | SC.I << 4) | (16 << 8),

        /// <summary>
        /// A 512-bit block covering 8 64-bit unsigned partitions
        /// </summary>
        [Symbol("512x64u", "A 512-bit block covering 8 64-bit unsigned partitions")]
        Seg512x64u = (SZ.W64 | SC.U << 4) | (8 << 8),

        /// <summary>
        /// A 512-bit block covering 8 64-bit signed partitions
        /// </summary>
        [Symbol("512x64i", "A 512-bit block covering 4 64-bit signed partitions")]
        Seg512x64i = (SZ.W64 | SC.I << 4) | (8 << 8),

        /// <summary>
        /// A 512-bit block covering 32 16-bit floating-point partitions
        /// </summary>
        [Symbol("512x16f", "A 512-bit block covering 8 16-bit floating-point partitions")]
        Seg512x16f = (SZ.W16 | SC.F << 4) | (32 << 8),

        /// <summary>
        /// A 512-bit block covering 16 32-bit floating-point partitions
        /// </summary>
        [Symbol("512x32f", "A 512-bit block covering 8 32-bit floating-point partitions")]
        Seg512x32f = (SZ.W32 | SC.F << 4) | (16 << 8),

        /// <summary>
        /// A 512-bit block covering 8 64-bit floating-point partitions
        /// </summary>
        [Symbol("512x64f", "A 512-bit block covering 4 64-bit floating-point partitions")]
        Seg512x64f = (SZ.W64 | SC.F << 4) | (8 << 8),
    }
}