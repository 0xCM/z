//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitSeq;

    using TK = ConditionCodes.TokenKind;
    using G = ConditionCodes;

    public class ConditionCodes : TokenGroup<G,TK>
    {
        public const string Group = "asm.cc";

        public override string GroupName
            => Group;

        public enum TokenKind : byte
        {
            None = 0,

            Condition,

            Alt,
        }

        public class TokenKindAttribute : TokenKindAttribute<TK>
        {
            public TokenKindAttribute(TK kind)
                : base(kind)
            {


            }
        }

        [LiteralProvider(Group)]
        public readonly struct ConditionFacets
        {
            public const byte ConditionCount = 16;

            public const byte Jcc8Base = 0x70;

            public const byte Jcc32Base = 0x80;
        }

        [LiteralProvider(Group)]
        public readonly struct FlagExpressions
        {
            /// <summary>
            /// Overflow
            /// </summary>
            public const string O = "OF=1";

            /// <summary>
            /// No Overflow
            /// </summary>
            public const string NO = "OF=0";

            /// <summary>
            /// Carry
            /// </summary>
            public const string C = "CF=1";

            /// <summary>
            /// No carry
            /// </summary>
            public const string NC = "CF=0";

            /// <summary>
            /// Zero
            /// </summary>
            public const string Z = "ZF=1";

            /// <summary>
            /// Nonzero
            /// </summary>
            public const string NZ = "ZF=0";

            /// <summary>
            /// Above
            /// </summary>
            public const string A = "CF=0 and ZF=0";

            /// <summary>
            /// Not Above
            /// </summary>
            public const string NA = "CF=1 or ZF=1";

            /// <summary>
            /// Sign
            /// </summary>
            public const string S = "SF=1";

            /// <summary>
            /// No Sign
            /// </summary>
            public const string NS = "SF=0";

            /// <summary>
            /// Parity
            /// </summary>
            public const string P = "PF=1";

            /// <summary>
            /// No Parity
            /// </summary>
            public const string NP = "PF=0";

            /// <summary>
            /// Parity Odd
            /// </summary>
            public const string PO = "PF=0";

            /// <summary>
            /// Parity Event
            /// </summary>
            public const string PE = "PF=1";

            /// <summary>
            /// Not Greater
            /// </summary>
            public const string NG = "ZF=1 or SF!=OF";

            /// <summary>
            /// Not Less than or Equal
            /// </summary>
            public const string NLE = "ZF=0 and SF=OF";

            /// <summary>
            /// Less than
            /// </summary>
            public const string LT = "SF != OF";

            /// <summary>
            /// Less
            /// </summary>
            public const string L = "SF != OF";

            /// <summary>
            /// Not Less
            /// </summary>
            public const string NL = "SF=OF";

            /// <summary>
            /// Below
            /// </summary>
            public const string B = "CF=1";

            /// <summary>
            /// Not Below
            /// </summary>
            public const string NB = "CF=0";

            /// <summary>
            /// Above or Equal
            /// </summary>
            public const string AE = "CF=0";

            /// <summary>
            /// Not Above or Equal
            /// </summary>
            public const string NAE = "CF=1";

            /// <summary>
            /// Equal
            /// </summary>
            public const string E = "ZF=1";

            /// <summary>
            /// Not Equal
            /// </summary>
            public const string NE = "ZF=0";

            /// <summary>
            /// Below or Equal
            /// </summary>
            public const string BE = "CF=1 or ZF=1";

            /// <summary>
            /// Not Below or Equal
            /// </summary>
            public const string NBE = "CF=0 and ZF=0";

            /// <summary>
            /// Not Greator or Equal
            /// </summary>
            public const string NGE = "SF!=OF";

            /// <summary>
            /// Greater or Equal
            /// </summary>
            public const string GE = "SF=OF";

            public const string LE = "ZF=1 or SF!=OF";

            public const string G = "ZF=0 and SF=OF";
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
    }
}