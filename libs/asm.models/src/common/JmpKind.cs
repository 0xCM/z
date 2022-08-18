//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [Flags]
    public enum JmpKind : ulong
    {
        None = 0,

        /// <summary> Unconditional Jump</summary>
        JMP = 1,

        JCC = 2,

        /// <summary> Jump if Above; CF=0 and ZF=0 </summary>
        JA = JCC*1 | JCC,

        /// <summary> Jump if Above or Equal; CF=0 </summary>
        JAE = JCC*2 | JCC,

        /// <summary> Jump if Below; CF=1 </summary>
        JB = JCC*3 | JCC,

        /// <summary> Jump if Below or Equal; CF=1 or ZF=1 </summary>
        JBE = JCC*4 | JCC,

        /// <summary> Jump if Carry; CF=1 </summary>
        JC = JCC*5 | JCC,

        /// <summary> Jump if CX Zero; CX=0 </summary>
        JCXZ = JCC*6 | JCC,

        /// <summary> Jump if Equal; ZF=1 </summary>
        JE = JCC*7 | JCC,

        /// <summary> Jump if Greater (signed); ZF=0 and SF=OF </summary>
        JG = JCC*8 | JCC,

        /// <summary> Jump if Greater or Equal (signed); SF=OF </summary>
        JGE = JCC*9 | JCC,

        /// <summary> Jump if Less (signed); SF != OF </summary>
        JL = JCC*10 | JCC,

        /// <summary> Jump if Less or Equal (signed) ;ZF=1 or SF != OF </summary>
        JLE = JCC*11 | JCC,

        /// <summary> Jump if Not Above; CF=1 or ZF=1 </summary>
        JNA = JCC*12 | JCC,

        /// <summary> Jump if Not Above or Equal; CF=1 </summary/>
        JNAE = JCC*13 | JCC,

        /// <summary> Jump if Not Below; CF=0 </summary/>
        JNB = JCC*14 | JCC,

        /// <summary> Jump if Not Below or Equal; CF=0 and ZF=0 </summary>
        JNBE = JCC*15 | JCC,

        /// <summary> Jump if Not Carry; CF=0 </summary/>
        JNC = JCC*16 | JCC,

        /// <summary> Jump if Not Equal; ZF=0 </summary/>
        JNE = JCC*17 | JCC,

        /// <summary> Jump if Not Greater (signed); ZF=1 or SF != OF </summary>
        JNG = JCC*18 | JCC,

        /// <summary> Jump if Not Greater or Equal (signed); SF != OF </summary>
        JNGE = JCC*19 | JCC,

        /// <summary> Jump if Not Less (signed); SF=OF </summary>
        JNL = JCC*20 | JCC,

        /// <summary> Jump if Not Less or Equal (signed); ZF=0 and SF=OF </summary>
        JNLE = JCC*21 | JCC,

        /// <summary> Jump if Not Overflow (signed); OF=0 </summary>
        JNO = JCC*22 | JCC,

        /// <summary> Jump if No Parity; PF=0 </summary/>
        JNP = JCC*23 | JCC,

        /// <summary> Jump if Not Signed (signed); SF=0 </summary>
        JNS = JCC*24 | JCC,

        /// <summary> Jump if Not Zero; ZF=0 </summary>
        JNZ = JCC*25 | JCC,

        /// <summary> Jump if Overflow (signed); OF=1 </summary>
        JO = JCC*26 | JCC,

        /// <summary> Jump if Parity; PF=1 </summary>
        JP = JCC*27 | JCC,

        /// <summary> Jump if Signed (signed); SF=1 </summary>
        JS = JCC*28 | JCC,

        /// <summary> Jump if Zero; ZF=1 </summary>
        JZ = JCC*29 | JCC,
    }
}