//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using TK = AsmOcTokenKind;
using T = AsmOcSymbols;

[LiteralProvider(GroupName)]
public class AsmOcTokens
{
    public const string GroupName = "asm.opcodes";

    [SymSource(GroupName), TokenKind(TK.Hex16)]
    public enum Hex16Token : byte
    {
        [Symbol(T.x0F38)]
        x0F38,

        [Symbol(T.x0F3A)]
        x0F3A,
    }

    [SymSource(GroupName), TokenKind(TK.Integer)]
    public enum IntegerToken : byte
    {
        [Symbol(T.n0)]
        n0,

        [Symbol(T.n1)]
        n1,

        [Symbol(T.n2)]
        n2,

        [Symbol(T.n3)]
        n3,

        [Symbol(T.n4)]
        n4,

        [Symbol(T.n5)]
        n5,

        [Symbol(T.n6)]
        n6,
    }

    [SymSource(GroupName), TokenKind(TK.Rex)]
    public enum RexToken : byte
    {
        [Symbol(T.Rex, "Indicates the presence of a REX prefix")]
        Rex,

        [Symbol(T.RexW, "Indicates the W-bit is enabled which signals a 64-bit operand size")]
        RexW,

        [Symbol(T.RexR, "Identifies the Rex 'R' bit")]
        RexR,
    }

    [SymSource(GroupName), TokenKind(TK.Vex)]
    public enum VexToken : byte
    {
        [Symbol(T.W, "Opcode extension field")]
        W,

        [Symbol(T.R, "Logically equivalent to REX.R, but represented in 1's complement form")]
        R,

        [Symbol(T.X, "Logically equivalent to REX.X, but represented in 1's complement form")]
        X,

        [Symbol(T.B, "Logically equivalent to REX.B, but represented in 1's complement form")]
        B,

        [Symbol(T.L0)]
        L0,

        [Symbol(T.L1, "Vector length, where 1 => w=256 and 2 => w=128 or scalar")]
        L1,

        [Symbol(T.L2, "Vector length, where 1 => w=256 and 2 => w=128 or scalar")]
        L2,

        [Symbol(T.Vex)]
        VEX,

        [Symbol(T.LZ)]
        LZ,

        [Symbol(T.LIG)]
        LIG,

        [Symbol(T.WIG)]
        WIG,

        [Symbol(T.W0)]
        W0,

        [Symbol(T.W1)]
        W1,

        [Symbol(T.n128)]
        W128,

        [Symbol(T.n256)]
        W256,

        [Symbol(T.vvvv, "A register specifier in 1's complement form")]
        vvvv,

        [Symbol(T.mmmmm, "In a 3-byte vex prefix, indicates the least 5 bits of the middle byte")]
        mmmmm,

        [Symbol(T.pp, "opcode extension providing equivalent functionality of a SIMD prefix")]
        pp,

        [Symbol(T.Vsib)]
        Vsib,
    }

    /// <summary>
    /// Table 2-30, EVEX Prefix Bit Field Functional Grouping
    /// </summary>
    [SymSource(GroupName), TokenKind(TK.Evex)]
    public enum EvexToken : byte
    {
        [Symbol(T.mmmm, "Access to up to eight decoding maps")]
        mmmm,

        [Symbol(T.RPrime, "High-16 register specifier modifier")]
        RPrime,

        [Symbol(T.RXB, "Next-8 register specifier modifier")]
        RXB,

        [Symbol(T.X, "High-16 register specifier modifier")]
        X,

        [Symbol(T.pp, "Compressed legacy prefix")]
        pp,

        [Symbol(T.vvv, "VVVV register specifier")]
        vvvv,

        [Symbol(T.W, "Operand size promotion/Opcode extension")]
        W,

        [Symbol(T.aaa, "Embedded opmask register specifier")]
        aaa,

        [Symbol(T.VPrime, "High-16 VVVV/VIDX register specifier")]
        VPrime,

        [Symbol(T.b, "Broadcast/RC/SAE Context")]
        b,

        [Symbol(T.LPrimeL, "Vector length/RC")]
        LPrimeL,
        
        [Symbol(T.z, "Zeroing/Merging")]
        z,

        [Symbol(T.n128)]
        W128,

        [Symbol(T.n256)]
        W256,

        [Symbol(T.n512, "zmm register")]
        W512,

        [Symbol(T.W0)]
        W0,
    }

    [SymSource(GroupName), TokenKind(TK.Disp)]
    public enum DispToken : byte
    {
        [Symbol(T.cb, "Indicates a 1-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
        cb,

        [Symbol(T.cw, "Indicates a 2-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
        cw,

        [Symbol(T.cd, "Indicates a 4-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
        cd,

        [Symbol(T.cp, "Indicates a 6-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
        cp,

        [Symbol(T.co, "Indicates an 8-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
        co,

        [Symbol(T.ct, "Indicates a 10-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
        ct,
    }

    [SymSource(GroupName), TokenKind(TK.SegOverride)]
    public enum SegOverrideToken : byte
    {
        [Symbol(T.cs, "CS segment override")]
        CS,

        [Symbol(T.ss, "SS segment override")]
        SS,

        [Symbol(T.ds, "DS segment override")]
        DS,

        [Symbol(T.es, "ES segment override")]
        ES,

        [Symbol(T.fs, "FS segment override")]
        FS,

        [Symbol(T.gs, "GS segment override")]
        GS,
    }

    [SymSource(GroupName), TokenKind(TK.RegDigit)]
    public enum RegDigitToken : byte
    {
        [Symbol(T.rd0, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 0 provides an extension to the instruction's opcode")]
        r0,

        [Symbol(T.rd1, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 1 provides an extension to the instruction's opcode")]
        r1,

        [Symbol(T.rd2, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 2 provides an extension to the instruction's opcode")]
        r2,

        [Symbol(T.rd3, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 3 provides an extension to the instruction's opcode")]
        r3,

        [Symbol(T.rd4, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 4 provides an extension to the instruction's opcode")]
        r4,

        [Symbol(T.rd5, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 5 provides an extension to the instruction's opcode")]
        r5,

        [Symbol(T.rd6, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 6 provides an extension to the instruction's opcode")]
        r6,

        [Symbol(T.rd7, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 7 provides an extension to the instruction's opcode")]
        r7,
    }

    /// <summary>
    /// Specifies a '/r' token where r = 0..7. A digit between 0 and 7 indicates that the ModR/M byte of the instruction
    /// uses only the r/m (register or memory) operand. The reg field contains the digit that provides an extension to the instruction's opcode.
    /// </summary>
    [SymSource(GroupName), TokenKind(TK.ModRm)]
    public enum ModRmToken : byte
    {
        [Symbol(T.RRM, "The ModR/M byte of the instruction contains a register operand and an r/m operand")]
        r,
    }

    /// <summary>
    /// Indicates the lower 3 bits of the opcode byte is used to encode the register operand without a modR/M byte Represents one of ['+rb', '+rw', '+rd', '+ro']
    /// </summary>
    [SymSource(GroupName), TokenKind(TK.RexB)]
    public enum RexBToken : byte
    {
        [Symbol(T.rb, "For an 8-bit register, indicates the four bit field of REX.b and opcode[2:0] field encodes the register operand of the instruction")]
        rb,

        [Symbol(T.rw, "For a 16-bit register, indicates the four bit field of REX.b and opcode[2:0] field encodes the register operand of the instruction")]
        rw,

        [Symbol(T.rd, "For a 32-bit register, indicates the four bit field of REX.b and opcode[2:0] field encodes the register operand of the instruction")]
        rd,

        [Symbol(T.ro, "For a 64-bit register, indicates the four bit field of REX.b and opcode[2:0] field encodes the register operand of the instruction")]
        ro,
    }

    /// <summary>
    /// "Specifies the size of an immediate operand in the context of an opcode specification"
    /// </summary>
    [SymSource(GroupName), TokenKind(TK.ImmSize)]
    public enum ImmSizeToken : byte
    {
        [Symbol(T.ib, "Indicates a 1-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
        ib,

        [Symbol(T.iw, "Indicates a 2-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
        iw,

        [Symbol(T.id, "Indicates a 4-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
        id,

        [Symbol(T.io, "Indicates An 8-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes")]
        io,
    }

    [SymSource(GroupName), TokenKind(TK.FpuDigit)]
    public enum FpuDigitToken : byte
    {
        [Symbol(T.ST0)]
        st0,

        [Symbol(T.ST1)]
        st1,

        [Symbol(T.ST2)]
        st2,

        [Symbol(T.ST3)]
        st3,

        [Symbol(T.ST4)]
        st4,

        [Symbol(T.ST5)]
        st5,

        [Symbol(T.ST6)]
        st6,

        [Symbol(T.ST7)]
        st7,
    }

    [SymSource(GroupName), TokenKind(TK.Exclusion)]
    public enum ExclusionToken
    {
        [Symbol(T.NP, "Indicates the use of 66/F2/F3 prefixes are not allowed with the instruction")]
        NP,

        [Symbol(T.NFx, "Indicates the use of F2/F3 prefixes are not allowed with the instruction")]
        NFx,

        [Symbol(T.NDS)]
        NDS,
    }

    [SymSource(GroupName), TokenKind(TK.Mask)]
    public enum MaskToken : byte
    {
        [Symbol(T.k1, "Indicates a mask register used as instruction writemask for instructions that do not allow zeroing-masking but support merging-masking")]
        Mask,

        [Symbol(T.z, "Indicates a mask register used as instruction writemask for instructions that allow zeroing-masking")]
        ZeroMask,

        [Symbol(T.k1z, "Indicates a mask register used as instruction writemask")]
        WriteMask,
    }

    [SymSource(GroupName), TokenKind(TK.Operator)]
    public enum OperatorToken : byte
    {
        [Symbol(T.Plus)]
        Plus,

        [Symbol(T.Dot)]
        Dot,
    }

    [SymSource(GroupName), TokenKind(TK.Sep)]
    public enum SeparatorToken : byte
    {
        [Symbol(T.Sep)]
        Sep,
    }

    [SymSource(GroupName), TokenKind(TK.Hex8)]
    public enum Hex8Kind : byte
    {
        [Symbol("00")]
        x00,
        [Symbol("01")]
        x01,
        [Symbol("02")]
        x02,
        [Symbol("03")]
        x03,
        [Symbol("04")]
        x04,
        [Symbol("05")]
        x05,
        [Symbol("06")]
        x06,
        [Symbol("07")]
        x07,
        [Symbol("08")]
        x08,
        [Symbol("09")]
        x09,
        [Symbol("0A")]
        x0A,
        [Symbol("0B")]
        x0B,
        [Symbol("0C")]
        x0C,
        [Symbol("0D")]
        x0D,
        [Symbol("0E")]
        x0E,
        [Symbol("0F")]
        x0F,
        [Symbol("10")]
        x10,
        [Symbol("11")]
        x11,
        [Symbol("12")]
        x12,
        [Symbol("13")]
        x13,
        [Symbol("14")]
        x14,
        [Symbol("15")]
        x15,
        [Symbol("16")]
        x16,
        [Symbol("17")]
        x17,
        [Symbol("18")]
        x18,
        [Symbol("19")]
        x19,
        [Symbol("1A")]
        x1A,
        [Symbol("1B")]
        x1B,
        [Symbol("1C")]
        x1C,
        [Symbol("1D")]
        x1D,
        [Symbol("1E")]
        x1E,
        [Symbol("1F")]
        x1F,
        [Symbol("20")]
        x20,
        [Symbol("21")]
        x21,
        [Symbol("22")]
        x22,
        [Symbol("23")]
        x23,
        [Symbol("24")]
        x24,
        [Symbol("25")]
        x25,
        [Symbol("26")]
        x26,
        [Symbol("27")]
        x27,
        [Symbol("28")]
        x28,
        [Symbol("29")]
        x29,
        [Symbol("2A")]
        x2A,
        [Symbol("2B")]
        x2B,
        [Symbol("2C")]
        x2C,
        [Symbol("2D")]
        x2D,
        [Symbol("2E")]
        x2E,
        [Symbol("2F")]
        x2F,
        [Symbol("30")]
        x30,
        [Symbol("31")]
        x31,
        [Symbol("32")]
        x32,
        [Symbol("33")]
        x33,
        [Symbol("34")]
        x34,
        [Symbol("35")]
        x35,
        [Symbol("36")]
        x36,
        [Symbol("37")]
        x37,
        [Symbol("38")]
        x38,
        [Symbol("39")]
        x39,
        [Symbol("3A")]
        x3A,
        [Symbol("3B")]
        x3B,
        [Symbol("3C")]
        x3C,
        [Symbol("3D")]
        x3D,
        [Symbol("3E")]
        x3E,
        [Symbol("3F")]
        x3F,
        [Symbol("40")]
        x40,
        [Symbol("41")]
        x41,
        [Symbol("42")]
        x42,
        [Symbol("43")]
        x43,
        [Symbol("44")]
        x44,
        [Symbol("45")]
        x45,
        [Symbol("46")]
        x46,
        [Symbol("47")]
        x47,
        [Symbol("48")]
        x48,
        [Symbol("49")]
        x49,
        [Symbol("4A")]
        x4A,
        [Symbol("4B")]
        x4B,
        [Symbol("4C")]
        x4C,
        [Symbol("4D")]
        x4D,
        [Symbol("4E")]
        x4E,
        [Symbol("4F")]
        x4F,
        [Symbol("50")]
        x50,
        [Symbol("51")]
        x51,
        [Symbol("52")]
        x52,
        [Symbol("53")]
        x53,
        [Symbol("54")]
        x54,
        [Symbol("55")]
        x55,
        [Symbol("56")]
        x56,
        [Symbol("57")]
        x57,
        [Symbol("58")]
        x58,
        [Symbol("59")]
        x59,
        [Symbol("5A")]
        x5A,
        [Symbol("5B")]
        x5B,
        [Symbol("5C")]
        x5C,
        [Symbol("5D")]
        x5D,
        [Symbol("5E")]
        x5E,
        [Symbol("5F")]
        x5F,
        [Symbol("60")]
        x60,
        [Symbol("61")]
        x61,
        [Symbol("62")]
        x62,
        [Symbol("63")]
        x63,
        [Symbol("64")]
        x64,
        [Symbol("65")]
        x65,
        [Symbol("66")]
        x66,
        [Symbol("67")]
        x67,
        [Symbol("68")]
        x68,
        [Symbol("69")]
        x69,
        [Symbol("6A")]
        x6A,
        [Symbol("6B")]
        x6B,
        [Symbol("6C")]
        x6C,
        [Symbol("6D")]
        x6D,
        [Symbol("6E")]
        x6E,
        [Symbol("6F")]
        x6F,
        [Symbol("70")]
        x70,
        [Symbol("71")]
        x71,
        [Symbol("72")]
        x72,
        [Symbol("73")]
        x73,
        [Symbol("74")]
        x74,
        [Symbol("75")]
        x75,
        [Symbol("76")]
        x76,
        [Symbol("77")]
        x77,
        [Symbol("78")]
        x78,
        [Symbol("79")]
        x79,
        [Symbol("7A")]
        x7A,
        [Symbol("7B")]
        x7B,
        [Symbol("7C")]
        x7C,
        [Symbol("7D")]
        x7D,
        [Symbol("7E")]
        x7E,
        [Symbol("7F")]
        x7F,
        [Symbol("80")]
        x80,
        [Symbol("81")]
        x81,
        [Symbol("82")]
        x82,
        [Symbol("83")]
        x83,
        [Symbol("84")]
        x84,
        [Symbol("85")]
        x85,
        [Symbol("86")]
        x86,
        [Symbol("87")]
        x87,
        [Symbol("88")]
        x88,
        [Symbol("89")]
        x89,
        [Symbol("8A")]
        x8A,
        [Symbol("8B")]
        x8B,
        [Symbol("8C")]
        x8C,
        [Symbol("8D")]
        x8D,
        [Symbol("8E")]
        x8E,
        [Symbol("8F")]
        x8F,
        [Symbol("90")]
        x90,
        [Symbol("91")]
        x91,
        [Symbol("92")]
        x92,
        [Symbol("93")]
        x93,
        [Symbol("94")]
        x94,
        [Symbol("95")]
        x95,
        [Symbol("96")]
        x96,
        [Symbol("97")]
        x97,
        [Symbol("98")]
        x98,
        [Symbol("99")]
        x99,
        [Symbol("9A")]
        x9A,
        [Symbol("9B")]
        x9B,
        [Symbol("9C")]
        x9C,
        [Symbol("9D")]
        x9D,
        [Symbol("9E")]
        x9E,
        [Symbol("9F")]
        x9F,
        [Symbol("A0")]
        xA0,
        [Symbol("A1")]
        xA1,
        [Symbol("A2")]
        xA2,
        [Symbol("A3")]
        xA3,
        [Symbol("A4")]
        xA4,
        [Symbol("A5")]
        xA5,
        [Symbol("A6")]
        xA6,
        [Symbol("A7")]
        xA7,
        [Symbol("A8")]
        xA8,
        [Symbol("A9")]
        xA9,
        [Symbol("AA")]
        xAA,
        [Symbol("AB")]
        xAB,
        [Symbol("AC")]
        xAC,
        [Symbol("AD")]
        xAD,
        [Symbol("AE")]
        xAE,
        [Symbol("AF")]
        xAF,
        [Symbol("B0")]
        xB0,
        [Symbol("B1")]
        xB1,
        [Symbol("B2")]
        xB2,
        [Symbol("B3")]
        xB3,
        [Symbol("B4")]
        xB4,
        [Symbol("B5")]
        xB5,
        [Symbol("B6")]
        xB6,
        [Symbol("B7")]
        xB7,
        [Symbol("B8")]
        xB8,
        [Symbol("B9")]
        xB9,
        [Symbol("BA")]
        xBA,
        [Symbol("BB")]
        xBB,
        [Symbol("BC")]
        xBC,
        [Symbol("BD")]
        xBD,
        [Symbol("BE")]
        xBE,
        [Symbol("BF")]
        xBF,
        [Symbol("C0")]
        xC0,
        [Symbol("C1")]
        xC1,
        [Symbol("C2")]
        xC2,
        [Symbol("C3")]
        xC3,
        [Symbol("C4")]
        xC4,
        [Symbol("C5")]
        xC5,
        [Symbol("C6")]
        xC6,
        [Symbol("C7")]
        xC7,
        [Symbol("C8")]
        xC8,
        [Symbol("C9")]
        xC9,
        [Symbol("CA")]
        xCA,
        [Symbol("CB")]
        xCB,
        [Symbol("CC")]
        xCC,
        [Symbol("CD")]
        xCD,
        [Symbol("CE")]
        xCE,
        [Symbol("CF")]
        xCF,
        [Symbol("D0")]
        xD0,
        [Symbol("D1")]
        xD1,
        [Symbol("D2")]
        xD2,
        [Symbol("D3")]
        xD3,
        [Symbol("D4")]
        xD4,
        [Symbol("D5")]
        xD5,
        [Symbol("D6")]
        xD6,
        [Symbol("D7")]
        xD7,
        [Symbol("D8")]
        xD8,
        [Symbol("D9")]
        xD9,
        [Symbol("DA")]
        xDA,
        [Symbol("DB")]
        xDB,
        [Symbol("DC")]
        xDC,
        [Symbol("DD")]
        xDD,
        [Symbol("DE")]
        xDE,
        [Symbol("DF")]
        xDF,
        [Symbol("E0")]
        xE0,
        [Symbol("E1")]
        xE1,
        [Symbol("E2")]
        xE2,
        [Symbol("E3")]
        xE3,
        [Symbol("E4")]
        xE4,
        [Symbol("E5")]
        xE5,
        [Symbol("E6")]
        xE6,
        [Symbol("E7")]
        xE7,
        [Symbol("E8")]
        xE8,
        [Symbol("E9")]
        xE9,
        [Symbol("EA")]
        xEA,
        [Symbol("EB")]
        xEB,
        [Symbol("EC")]
        xEC,
        [Symbol("ED")]
        xED,
        [Symbol("EE")]
        xEE,
        [Symbol("EF")]
        xEF,
        [Symbol("F0")]
        xF0,
        [Symbol("F1")]
        xF1,
        [Symbol("F2")]
        xF2,
        [Symbol("F3")]
        xF3,
        [Symbol("F4")]
        xF4,
        [Symbol("F5")]
        xF5,
        [Symbol("F6")]
        xF6,
        [Symbol("F7")]
        xF7,
        [Symbol("F8")]
        xF8,
        [Symbol("F9")]
        xF9,
        [Symbol("FA")]
        xFA,
        [Symbol("FB")]
        xFB,
        [Symbol("FC")]
        xFC,
        [Symbol("FD")]
        xFD,
        [Symbol("FE")]
        xFE,
        [Symbol("FF")]
        xFF,
    }        
}
