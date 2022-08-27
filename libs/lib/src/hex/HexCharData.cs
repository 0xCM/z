//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using HCL = HexLowerCode;
    using HCU = HexUpperCode;
    using HSU = HexUpperSym;
    using HSL = HexLowerSym;

    /// <summary>
    /// Defines codes and symbol datasets for hex digits
    /// </summary>
    [ApiComplete]
    public readonly struct HexCharData
    {
        public static MemorySeg[] Segments
            => sys.array(MemorySegs.define(UpperSymData), MemorySegs.define(LowerSymData), MemorySegs.define(UpperCodes), MemorySegs.define(LowerCodes));

        /// <summary>
        /// Defines a 16-byte sequence with terms that correspond to the ASCI codes the hex digits {0..9,A..F}
        /// </summary>
        public static ReadOnlySpan<byte> UpperCodes
            => new byte[]{
                (byte)HCU.x0, (byte)HCU.x1, (byte)HCU.x2, (byte)HCU.x3,
                (byte)HCU.x4, (byte)HCU.x5, (byte)HCU.x6, (byte)HCU.x7,
                (byte)HCU.x8, (byte)HCU.x9,
                (byte)HCU.A,  (byte)HCU.B, (byte)HCU.C, (byte)HCU.D, (byte)HCU.E, (byte)HCU.F,
                };

        /// <summary>
        /// Defines a 16-byte sequence with terms that correspond to the ASCI codes for hex digits {0..9,a..f}
        /// </summary>
        public static ReadOnlySpan<byte> LowerCodes
            => new byte[]{
                (byte)HCL.x0, (byte)HCL.x1, (byte)HCL.x2, (byte)HCL.x3,
                (byte)HCL.x4, (byte)HCL.x5, (byte)HCL.x6, (byte)HCL.x7,
                (byte)HCL.x8, (byte)HCL.x9,
                (byte)HCL.a,  (byte)HCL.b, (byte)HCL.c, (byte)HCL.d, (byte)HCL.e, (byte)HCL.f,
                };

        public static ReadOnlySpan<byte> UpperSymData
            => new byte[]{
                (byte)HSU.x0, 0, (byte)HSU.x1, 0, (byte)HSU.x2, 0, (byte)HSU.x3, 0,
                (byte)HSU.x4, 0, (byte)HSU.x5, 0, (byte)HSU.x6, 0, (byte)HSU.x7, 0,
                (byte)HSU.x8, 0, (byte)HSU.x9, 0,
                (byte)HSU.A,  0,  (byte)HSU.B, 0,
                (byte)HSU.C,  0, (byte)HSU.D,  0, (byte)HSU.E,  0,  (byte)HSU.F, 0,
                };

        public static ReadOnlySpan<byte> LowerSymData
            => new byte[]{
                (byte)HSL.x0, 0, (byte)HSL.x1, 0, (byte)HSL.x2, 0, (byte)HSL.x3, 0,
                (byte)HSL.x4, 0, (byte)HSL.x5, 0, (byte)HSL.x6, 0, (byte)HSL.x7, 0,
                (byte)HSL.x8, 0, (byte)HSL.x9, 0,
                (byte)HSL.a,  0,  (byte)HSL.b, 0,
                (byte)HSL.c,  0, (byte)HSL.d,  0, (byte)HSL.e,  0,  (byte)HSL.f, 0,
                };

        /// <summary>
        /// Defines a 16-element sequence with terms that correspond to the uppercase hex symbolic literals
        /// </summary>
        public static ReadOnlySpan<HSU> UpperSymbols
        {
            [MethodImpl(Inline)]
            get => recover<HSU>(UpperSymData);
        }

        /// <summary>
        /// Defines a 16-element sequence with terms that correspond to the lowercase hex symbolic literals
        /// </summary>
        public static ReadOnlySpan<HSL> LowerSymbols
        {
            [MethodImpl(Inline)]
            get => recover<HSL>(LowerSymData);
        }

        public static byte LowerSymbolCount
        {
            [MethodImpl(Inline)]
            get => (byte)LowerSymData.Length;
        }

        public static byte UpperSymbolCount
        {
            [MethodImpl(Inline)]
            get => (byte)UpperSymData.Length;
        }

        /// <summary>
        /// Defines the asci character codes for uppercase hex digits 1,2, ..., 9, A, ..., F
        /// </summary>
        public static ReadOnlySpan<byte> UpperHexDigits
            => new byte[]{48,49,50,51,52,53,54,55,56,57,65,66,67,68,69,70};

        /// <summary>
        /// Defines the asci character codes for uppercase hex digits 1,2, ..., 9, a, ..., f
        /// </summary>
        public static ReadOnlySpan<byte> LowerHexDigits
            => new byte[]{48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102};
    }
}