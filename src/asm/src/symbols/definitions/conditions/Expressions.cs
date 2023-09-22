//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class ConditionTokens
{
    [LiteralProvider("asm.conditions")]
    public readonly struct Expressions
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

        /// <summary>
        /// Less or equal
        /// </summary>
        public const string LE = "ZF=1 or SF!=OF";

        /// <summary>
        /// Greater
        /// </summary>
        public const string G = "ZF=0 and SF=OF";
    }

}