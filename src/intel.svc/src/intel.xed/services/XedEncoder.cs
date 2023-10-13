//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

public class XedEncoder : AppService<XedEncoder>
{
    class EncoderState
    {
        public XedFields Fields;

        public EncoderState()
        {
            
        }
    }

    /// <summary>
    /// Based on xed/include/public/xed/xed-encode-direct.h
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public record struct RequestBits
    {
        public num1 HasSib;

        public num1 HasDisp8;

        public num1 HasDisp16;

        public num1 HasDisp32;

        public num1 RexW;

        public num1 RexR;

        public num1 RexX;

        public num1 RexB;

        /// <summary>
        /// for SIL,DIL,BPL,SPL
        /// </summary>
        public num1 NeedRex;

        public num1 EvexRR;

        public num1 VexL;

        /// <summary>
        /// lso sae enabler for reg-only & vl=512
        /// </summary>
        public num1 EvexB;

        public num1 EvexVV;

        public num1 EvexZ;

        /// <summary>
        /// also rc bits in some case
        /// </summary>
        public num2 EvexLL;

        public num2 Mod;

        public num3 Reg;

        public num3 Rm;

        public num2 SibScale;

        public num3 SibIndex;

        public num3 SibBase;

        public num3 EvexAAA;

        public num3 Map;

        /// <summary>
        /// and evex
        /// </summary>
        public num3 VexPP;

        public num4 VVVV;

        /// <summary>
        /// for "partial opcode" instructions
        /// </summary>
        public num3 Srm;
    }
}
