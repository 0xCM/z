//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public enum EncodingClass : byte
        {
            None = 0,

            ExplicitRegs,

            Imm,

            ModRm,

            Vex,

            Evex,

            Vsib,

            Arithmetic
        }
    }
}