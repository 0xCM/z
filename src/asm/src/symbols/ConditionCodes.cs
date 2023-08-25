//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static BitSeq;

using TK = ConditionTokenKind;
using G = ConditionCodes;

public enum ConditionTokenKind : byte
{
    None = 0,

    Condition,

    Alt,
}

[LiteralProvider(Group)]
public class ConditionCodes
{
    public const string Group = "asm.cc";

    [LiteralProvider(Group)]
    public readonly struct ConditionFacets
    {
        public const byte ConditionCount = 16;

        public const byte Jcc8Base = 0x70;

        public const byte Jcc32Base = 0x80;
    }

    /// <summary>
    /// Defines the condition codes as the bitfield [tttn] where ttt indicates
    /// the condition being tested and n indicates where to use the condition (n=0)
    /// or its negation (n=1). For 1-byte primary opcodes, the tttn field is located
    /// in bits 3, 2, 1, and 0 of the opcode byte. For 2-byte primary opcodes, the tttn
    /// field is located in bits 3, 2, 1, and 0 of the second opcode byte
    /// </summary>
    /// <remarks>
    /// From Vol2D, appendix B.1.4.7
    /// </remarks>
    [SymSource(Group), TokenKind(TK.Condition)]
    public enum Condition : byte
    {
        /// <summary>
        /// Overflow
        /// </summary>
        [Symbol("O", "Overflow")]
        O = b0000,

        /// <summary>
        /// Not Overflow
        /// </summary>
        [Symbol("NO", "Not Overflow")]
        NO = b0001,

        /// <summary>
        /// Below, not above or equal
        /// </summary>
        [Symbol("B", "Below")]
        B = b0010,

        /// <summary>
        /// Not Below
        /// </summary>
        [Symbol("NB", "Not Below")]
        NB = b0011,

        /// <summary>
        /// Equal; Zero
        /// </summary>
        [Symbol("E", "Equal")]
        E = b0100,

        /// <summary>
        /// Not Equal; Not Zero
        /// </summary>
        [Symbol("NE", "Not Equal")]
        NE = b0101,

        /// <summary>
        /// Below or equal, Not above
        /// </summary>
        [Symbol("BE", "Below or Equal")]
        BE = b0110,

        /// <summary>
        /// Not below or equal, Above
        /// </summary>
        [Symbol("NBE", "Not Below or Equal")]
        NBE = b0111,

        /// <summary>
        /// Sign
        /// </summary>
        [Symbol("S", "Sign")]
        S = b1000,

        /// <summary>
        /// Not sign
        /// </summary>
        [Symbol("NS", "Not Signed")]
        NS = b1001,

        /// <summary>
        /// Parity Even
        /// </summary>
        [Symbol("P", "Parity")]
        P = b1010,

        /// <summary>
        /// Parity Odd
        /// </summary>
        [Symbol("NP", "Not Parity")]
        NP = b1011,

        /// <summary>
        /// Less than; Not greater than or equal to
        /// </summary>
        [Symbol("LT", "Less Than")]
        LT = b1100,

        /// <summary>
        /// Not less than, Greater than or equal to
        /// </summary>
        [Symbol("NLT", "Not Less Than")]
        NLT = b1101,

        /// <summary>
        /// Less Than or Equal
        /// </summary>
        [Symbol("LE", "Less Than or Equal")]
        LE = b1110,

        /// <summary>
        /// Not Less Than or Equal
        /// </summary>
        [Symbol("NLE", "Not Less Than or Equal")]
        NLE = b1111,
    }

    [SymSource(Group), TokenKind(TK.Alt)]
    public enum ConditionAlt : byte
    {
        /// <summary>
        /// Overflow
        /// </summary>
        [Symbol("O", "Overflow")]
        O = b0000,

        /// <summary>
        /// Not Overflow
        /// </summary>
        [Symbol("NO", "Not Overflow")]
        NO = b0001,

        /// <summary>
        /// Below, not above or equal
        /// </summary>
        [Symbol("NAE", "Not Above or Equal")]
        NAE = b0010,

        /// <summary>
        /// Not Below
        /// </summary>
        [Symbol("AE", "Above or Equal")]
        AE = b0011,

        /// <summary>
        /// Equal; Zero
        /// </summary>
        [Symbol("Z", "Zero")]
        Z = b0100,

        /// <summary>
        /// Not Equal; Not Zero
        /// </summary>
        [Symbol("NZ", "Not Zero")]
        NZ = b0101,

        /// <summary>
        /// Below or equal, Not above
        /// </summary>
        [Symbol("NA", "Not Above")]
        NA = b0110,

        /// <summary>
        /// Not below or equal, Above
        /// </summary>
        [Symbol("A", "Above")]
        A = b0111,

        /// <summary>
        /// Sign
        /// </summary>
        [Symbol("S", "Sign")]
        S = b1000,

        /// <summary>
        /// Not sign
        /// </summary>
        [Symbol("NS", "Not Signed")]
        NS = b1001,

        /// <summary>
        /// Parity Even
        /// </summary>
        [Symbol("PE", "Parity Even")]
        PE = b1010,

        /// <summary>
        /// Parity Odd
        /// </summary>
        [Symbol("PO", "Parity Odd")]
        PO = b1011,

        /// <summary>
        /// Less than; Not greater than or equal to
        /// </summary>
        [Symbol("NGE", "Not Greater Than or Equal")]
        NGE = b1100,

        /// <summary>
        /// Not less than, Greater than or equal to
        /// </summary>
        [Symbol("GE", "Greater Than or Equal")]
        GE = b1101,

        /// <summary>
        /// Less than or equal to, Not greater than
        /// </summary>
        [Symbol("NGT", "Not Greater Than")]
        NGT = b1110,

        /// <summary>
        /// Not less than or equal to, Greater than
        /// </summary>
        [Symbol("GT", "Greater Than")]
        GT = b1111,
    }
}
