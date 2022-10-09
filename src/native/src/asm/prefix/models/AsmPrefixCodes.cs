//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Hex8Kind;
    using static XedLiterals;

    using NBK = NumericBaseKind;

    [ApiHost]
    public class AsmPrefixCodes
    {
        public static RexPrefixCode RexW => RexPrefixCode.W;

        public const string Group = "asm.prefixes";

        [MethodImpl(Inline), Op]
        public static RexPrefix rex(uint4 wrxb)
            => math.or((byte)RexPrefixCode.Base, (byte)wrxb);

        [MethodImpl(Inline), Op]
        public static RexPrefix rex(bit w, bit r, bit x, bit b)
        {
            var bx = math.slor((byte)b, 0, (byte)x, 1);
            var rw = math.slor((byte)r, 2, (byte)w, 3);
            return math.or(bx, rw, rex());
        }

        [MethodImpl(Inline), Op]
        public static RexPrefix rex()
            => (byte)RexPrefixCode.Base;

        [SymSource(Group)]
        public enum VsibField : byte
        {
            /// <summary>
            /// VSIB.base, Bits [3:0]
            /// </summary>
            [Symbol("base")]
            Base = 0,

            /// <summary>
            /// VSIB.index, Bits [5:3]
            /// </summary>
            [Symbol("index")]
            Index = 3,

            /// <summary>
            /// VSIB.SS, Bits [7:6]
            /// </summary>
            [Symbol("SS")]
            SS = 6,
        }

        /// <summary>
        /// Defines 3-bit emission codes for vex map specification as determined by the presence
        /// of a <see cref='AsmVL'/> value and a <see cref='XedVexKind'/> value
        /// </summary>
        [SymSource(Group, NumericBaseKind.Base2), DataWidth(num3.Width)]
        public enum VexRXB : byte
        {
            /// <summary>
            /// VL128 VEX_PREFIX=0  ->	emit 0b000
            /// </summary>
            [Symbol("L0 + VNP", "VL128 VEX_PREFIX=0")]
            L0_VNP = 0b000,

            /// <summary>
            /// VL128 VEX_PREFIX=1  ->	emit 0b001
            /// </summary>
            [Symbol("L0 + V0F", "VL128 VEX_PREFIX=1")]
            L0_V0F = 0b001,

            /// <summary>
            /// VL128 VEX_PREFIX=2  ->	emit 0b011
            /// </summary>
            [Symbol("L0 + V0F38", "VL128 VEX_PREFIX=2")]
            L0_V0F38 = 0b011,

            /// <summary>
            /// VL128 VEX_PREFIX=3  ->	emit 0b010
            /// </summary>
            [Symbol("L0 + V0F3A", "VL128 VEX_PREFIX=3")]
            L0_V0F3A = 0b010,

            /// <summary>
            /// VL256 VEX_PREFIX=0  ->	emit 0b100
            /// </summary>
            [Symbol("L1 + VNP", "VL256 VEX_PREFIX=0")]
            L1_VNP = 0b100,

            /// <summary>
            /// VL256 VEX_PREFIX=1  ->	emit 0b101
            /// </summary>
            [Symbol("L1 + V0F", "VL256 VEX_PREFIX=1")]
            L1_V0F = 0b101,

            /// <summary>
            /// VL256 VEX_PREFIX=2  ->	emit 0b111
            /// </summary>
            [Symbol("L1 + V0F38", "VL256 VEX_PREFIX=2")]
            L1_V0F38 = 0b111,

            /// <summary>
            /// VL256 VEX_PREFIX=3  ->	emit 0b110
            /// </summary>
            [Symbol("L1 + V0F3A", "VL256 VEX_PREFIX=3")]
            L1_V0F3A = 0b110,
        }

        /// <summary>
        /// Specifies an opcode extension providing equivalent functionality of a SIMD prefix and specifies the encoding of the 'pp' field, Vol. 2A 2-15
        /// </summary>
        [SymSource(Group)]
        public enum VexOpCodeExtension : byte
        {
            None = 0,

            [Symbol("66")]
            X66 = 0b1,

            [Symbol("F3")]
            F3 = 0b10,

            [Symbol("F2")]
            F2 = 0b11,
        }

        /// <summary>
        /// Specifies a vector length in the context of the VEX encoding scheme, Vol. 2A 2-15
        /// </summary>
        [SymSource(Group)]
        public enum VexLengthCode : byte
        {
            [Symbol("L0", "Specifies a vector length of 128 in the contex of the VEX encoding scheme")]
            L0 = VectorWidthCode.V128,

            [Symbol("L1", "Specifies a vector length of 256 in the contex of the VEX encoding scheme")]
            L1 = VectorWidthCode.V256,
        }

        /// <summary>
        /// Specifies field bits m-mmmmm in the context of the VEX encoding scheme, Vol. 2A 2-15
        /// </summary>
        /// <remarks>
        /// 2.3.6.1 3-byte VEX byte 1, bits[4:0] - “m-mmmm
        /// VEX.m-mmmm   | Implied Leading Opcode Bytes
        /// 00000B       | Reserved
        /// 00001B       | 0F
        /// 00010B       | 0F 38
        /// 00011B       | 0F 3A
        /// 00100-11111B | Reserved
        /// 2-byte VEX   | 0F
        /// </remarks>
        [SymSource(Group,NumericBaseKind.Base2), DataWidth(2)]
        public enum VexM : byte
        {
            None = 0b0,

            [Symbol("0F", "Specifies 0x0F as the leading opcode byte in the context of the VEX encoding scheme")]
            x0F = 0b01,

            [Symbol("V0F38", "Specifies 0F 38 as the leading opcode byte in the context of the VEX encoding scheme")]
            x0F38 = 0b10,

            [Symbol("V0F3A", "Specifies 0F 3A as the leading opcode byte in the context of the VEX encoding scheme")]
            x0F3A = 0b11,
        }

        [SymSource(Group, NumericBaseKind.Base16)]
        public enum VexPrefixCode
        {
            [Symbol("C4", "Indicates a VEX prefix begins with 0xC4 and is 3 bytes in length")]
            C4 = 0xC4,

            [Symbol("C5", "Indicates a VEX prefix begins with 0xC5 and is 2 bytes in length")]
            C5 = 0xC5,
        }

        [SymSource(Group), DataWidth(3)]
        public enum VectorWidthCode : byte
        {
            [Symbol("V128", "VL=0")]
            V128 = 0,

            [Symbol("V256", "VL=1")]
            V256 = 1,

            [Symbol("V512", "VL=2")]
            V512 = 2,

            INVALID = 3,
        }

        [SymSource(Group), DataWidth(3)]
        public enum EvexWidthCode
        {
            [Symbol("V128", "VL=0")]
            V128 = VectorWidthCode.V128,

            [Symbol("V256", "VL=1")]
            V256 = VectorWidthCode.V256,

            [Symbol("V512", "VL=2")]
            V512 = VectorWidthCode.V512,
        }

        /// <summary>
        /// Defines REX field identifiers
        /// </summary>
        [SymSource(Group), DataWidth(3)]
        public enum RexFieldIndex : byte
        {
            [Symbol("b")]
            B = 0,

            [Symbol("x")]
            X = 1,

            [Symbol("r")]
            R = 2,

            [Symbol("w")]
            W = 3,
        }

        /// <summary>
        /// Defines the lock prefix code
        /// </summary>
        [SymSource(Group, NBK.Base16)]
        public enum LockPrefixCode : byte
        {
            None = 0,

            [Symbol("F0", "Lock Prefix")]
            LOCK = 0xF0,
        }

        [SymSource(Group, NBK.Base16)]
        public enum BranchHintCode : byte
        {
            /// <summary>
            /// Branch taken
            /// </summary>
            [Symbol("BT", "2e - Branch Taken")]
            BT = 0x2E,

            /// <summary>
            /// Branch not taken
            /// </summary>
            [Symbol("BT", "3e - Branch Not Taken")]
            BNT = 0x3e,
        }

        [SymSource(Group, NBK.Base16)]
        public enum SizeOverrideCode : byte
        {
            None = 0,

            /// <summary>
            /// Operand size override
            /// </summary>
            /// <remarks>
            /// The operand-size override prefix allows a program to switch between 16- and 32-bit operand sizes.
            /// Either size can be the default; use of the prefix selects the non-default size
            /// </remarks>
            [Symbol("66","Operand size override")]
            OPSZ = 0x66,

            /// <summary>
            /// Address size override
            /// </summary>
            /// <remarks>
            /// The address-size override prefix allows programs to switch between 16- and 32-bit addressing.
            /// Either size can be the default; the prefix selects the non-default size
            /// </remarks>
            [Symbol("67", "Address size override")]
            ADSZ = 0x67,
        }

        /// <summary>
        /// Defines the mandatory prefix codes as specified by Intel Vol II, 2.1.2
        /// </summary>
        [SymSource(Group, NBK.Base16)]
        public enum MandatoryPrefixCode : byte
        {
            [Symbol("66")]
            x66 = 0x66,

            [Symbol("F2")]
            F2 = 0xF2,

            [Symbol("F3")]
            F3 = 0xF3,
        }

        [SymSource(Group, NBK.Base16)]
        public enum BndPrefixCode : byte
        {
            [Symbol("BND")]
            BND = xf2
        }

        /// <summary>
        /// The segment override codes as specified by Intel Vol II, 2.1.1
        /// </summary>
        [SymSource(Group, NBK.Base16)]
        public enum SegOverrideCode : byte
        {
            [Symbol("cs", "CS segment override")]
            CS = 0x2e,

            [Symbol("ss", "SS segment override")]
            SS = 0x36,

            [Symbol("ds","DS segment override")]
            DS = 0x3e,

            [Symbol("es", "ES segment override")]
            ES = 0x26,

            [Symbol("fs", "FS segment override")]
            FS = 0x64,

            [Symbol("gs", "GS segment override")]
            GS = 0x65,
        }

        /// <summary>
        /// Classfies vex prefix codes
        /// </summary>
        [SymSource(Group, NBK.Base16)]
        public enum VexPrefixKind : byte
        {
            [Symbol("C4", "The leading byte of a 3-byte vex prefix sequence")]
            xC4 = 0xC4,

            [Symbol("C5", "The leading byte of a 2-byte vex prefix sequence")]
            xC5 = 0xC5,
        }

        /// <summary>
        /// [0100 0001] | W:0 | R:0 | X:0 | B:1
        /// </summary>
        [Flags]
        [SymSource(Group, NBK.Base16)]
        public enum RexPrefixCode : byte
        {
            /// <summary>
            /// [0100 0000] => [W:0 | R:0 | X:0 | B:0]
            /// </summary>
            [Symbol("REX", "[0100 0000]")]
            Base = 0x40,

            /// <summary>
            /// Extends one of:
            /// - The reg field in the ModR/M byte
            /// - The index field in the SIB byte
            /// - The reg field in the opcode byte
            /// </summary>
            [Symbol("REX.B", "[0100 0001]")]
            B = 0x41,

            /// <summary>
            /// Extends the index field in the SIB byte
            /// </summary>
            [Symbol("REX.X", "[0100 0010]")]
            X = 0x42,

            /// <summary>
            /// Extends the reg field in the ModR/M byte
            /// </summary>
            [Symbol("REX.R", "[0100 0100]")]
            R = 0x44,

            /// <summary>
            /// Wide, enables 64-bit execution
            /// </summary>
            [Symbol("REX.W", "[0100 1000]")]
            W = 0x48,
        }

        [SymSource(Group, NBK.Base16)]
        public enum RepPrefixCode : byte
        {
            [Symbol("F2")]
            REPNZ = 0xf2,

            [Symbol("F3")]
            REPZ = 0xf3,
        }
    }
}