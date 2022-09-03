//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Hex8Kind;

    using Operands;

    public class x86x
    {
        /// <summary>
        /// and r16, imm8 | 83 /4 ib | r/m16 AND imm8 (sign-extended).
        /// AND | LEGACY_MAP0 | 0x83 MOD[0b11] REG[0b100] RM[nnn] SIMM8()
        /// </summary>
        public static And16ri8 and_r16_imm8(r16 r16, Imm8 imm8)
        {
            var dst = And16ri8.Empty;
            var kind = AsmFormKind.and_r16_imm8;
            var sz = AsmPrefix.opsz();
            var mrm = AsmBytes.modrm(0b11, 0b100, r16.Index);
            dst.EncodingSize = (byte)PolyBits.pack(x83, mrm,imm8,dst.Buffer);
            return dst;
        }
    }
}