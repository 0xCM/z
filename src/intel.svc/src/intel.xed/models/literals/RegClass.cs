//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource(xed), DataWidth(num5.Width)]
        public enum RegClass : byte
        {
            [Symbol("")]
            INVALID,

            BNDCFG,

            BNDSTAT,

            BOUND,

            CR,

            DR,

            FLAGS,

            GPR,

            GPR16,

            GPR32,

            GPR64,

            GPR8,

            IP,

            MASK,

            MMX,

            MSR,

            MXCSR,

            PSEUDO,

            PSEUDOX87,

            SR,

            TMP,

            TREG,

            UIF,

            X87,

            XCR,

            XMM,

            YMM,

            ZMM,
        }
    }
}