//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using F = AsmPrefixCodes.VsibField;

    /// <summary>
    /// Represents a VSIB address
    /// </summary>
    /// <remarks>
    /// Documentation taken from vol 4 of ADM reference manuals, p. 6
    /// </remarks>
    [DataTypeAttributeD("asm.vsib")]

    public readonly struct Vsib
    {
        [MethodImpl(Inline), Op]
        public static Vsib define(byte src)
            => new Vsib(src);

        /// <summary>
        /// Effective address computation with vsib addressing
        /// </summary>
        /// <remarks>
        /// Each element i of the effective address array is computed using the formula:
        /// effective address[i] = scale * index[i] + base + displacement, where index[i]
        /// is the i'th element of the XMM/YMM register specified by {X, VSIB.index}.
        /// An index element is either 32 or 64 bits wide and is treated as a signed integer
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static MemoryAddress effective(Vsib vsib, Vector256<uint> src, uint dx)
            => vsib.Scale()*src.GetElement(vsib.Index())+ (ulong)vsib.Base() + (ulong)dx;

        readonly byte Data;

        [MethodImpl(Inline)]
        public Vsib(byte data)
            => Data = data;

        /// <summary>
        /// VSIB.base, Bits [3:0]
        /// </summary>
        /// <remarks>
        /// This field is concatenated with the complement of the VEX.B bit ({B, base})
        /// to specify the general-purpose register (base GPR) that contains the base address base
        /// to be used in the computation of each of the effective addresses
        /// </remarks>
        public uint3 Base()
            => (uint3)(Data >> (byte)F.Base);

        /// <summary>
        /// VSIB.index, Bits [5:3]
        /// </summary>
        /// <remarks>
        /// This field is concatenated with the complement of the VEX.X bit ({X, index}) to specify the YMM/XMM
        /// register that contains the packed array of index values index[i] to be used in the computation of
        /// the array of effective addresses effective address[i].
        /// </remarks>
        public uint3 Index()
            => (uint3)(Data >> (byte)F.Index);

        /// <summary>
        /// VSIB.SS, Bits [7:6]
        /// </summary>
        /// <remarks>
        /// The SS field is used to specify the scale factor to be used in the computation of each of the
        /// effective addresses. The scale factor scale is equal to 2^SS. Therefore,
        /// SS = 00b => scale = 1
        /// SS = 01b => scale = 2
        /// SS = 10b => scale = 4
        /// SS = 11b => scale = 8
        /// </remarks>
        public uint2 SS()
            => (uint2)(Data >> (byte)F.SS);

        [MethodImpl(Inline)]
        public byte Scale()
            => (byte)Pow2.pow(SS());
    }
}