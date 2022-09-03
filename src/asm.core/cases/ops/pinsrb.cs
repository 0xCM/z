//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCases
    {
        [MethodImpl(Inline), Op]
        public static ResText pinsrb_opcode(N0 n)
            => "66 0F 3A 20 /r ib";

        [MethodImpl(Inline), Op]
        public static ResText pinsrb_sig(N0 n)
            => "PINSRB xmm1, r32/m8, imm8";
    }
}