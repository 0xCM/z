//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Hex8Kind;
    using Operands;

    public class AsmHexEmitter : AppService<AsmHexEmitter>
    {
        /// <summary>
        /// (AND AL, imm8)[24 ib]
        /// </summary>
        /// <param name="r"></param>
        /// <param name="imm8"></param>
        [MethodImpl(Inline), Op]
        public void and(al r, Imm8 imm8, AsmHexWriter dst)
            => dst.Write(x24,imm8);

        /// <summary>
        /// 20 /r | AND r/m8, r8 | 0x20 MOD[0b11] REG[rrr] RM[nnn]
        /// </summary>
        /// <param name="r0">REG0=GPR8_B():rw</param>
        /// <param name="r1">REG1=GPR8_R():r</param>
        public static void and(r8 r0, r8 r1, AsmHexWriter dst)
        {
            var modrm = ModRm.init();
            modrm.Mod((uint2)0b11);
            modrm.Reg(r1);
            modrm.Rm(r0);
            dst.Write(x20, modrm);
        }

        [MethodImpl(Inline), Op]
        public static void jo(Hex8 cb, AsmHexWriter dst)
            => dst.Write(x70, cb);

        [MethodImpl(Inline), Op]
        public static void jo(Hex32 cd, AsmHexWriter dst)
            => dst.Write(x70, x86, cd);

        [MethodImpl(Inline), Op]
        public static void encode(Rip a0, Jcc8 a1, AsmHexWriter dst)
            => dst.Write(a1.JccCode, AsmRel.target(a0, a1.Disp));
    }
}