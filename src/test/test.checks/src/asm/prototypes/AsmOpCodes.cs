//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmPrototypes
    {
        public enum AsmOpCodeId : ushort
        {
            /// <summary>
            /// 24 ib
            /// </summary>
            [Symbol("24 ib", "AND AL, imm8")]
            and_al_imm8,

            /// <summary>
            /// AND AX, imm16
            /// </summary>
            [Symbol("25 iw", "AND AX, imm16")]
            and_ax_imm16,

            /// <summary>
            /// AND EAX, imm32
            /// </summary>
            [Symbol("25 id", "AND EAX, imm32")]
            and_eax_imm32,

            /// <summary>
            /// AND RAX, imm32
            /// </summary>
            [Symbol("REX.W + 25 id", "AND RAX, imm32")]
            and_rax_imm32,

            /// <summary>
            /// AND r8, imm8
            /// </summary>
            [Symbol("80 /4 ib", "AND r8, imm8")]
            and_r8_imm8,

            /// <summary>
            /// AND m8, imm8
            /// </summary>
            [Symbol("80 /4 ib", "AND m8, imm8")]
            and_m8_imm8,

            /// <summary>
            /// AND r8, imm8
            /// </summary>
            [Symbol("REX + 80 /4 ib", "AND r8, imm8")]
            and_r8_imm8_rex,

            /// <summary>
            /// AND m8,imm8
            /// </summary>
            [Symbol("REX + 80 /4 ib", "AND m8,imm8")]
            and_m8_imm8_rex,

            /// <summary>
            /// AND r16, imm16
            /// </summary>
            [Symbol("81 /4 iw", "AND r16, imm16")]
            and_r16_imm16,

            /// <summary>
            /// AND m16, imm16
            /// </summary>
            [Symbol("81 /4 iw", "AND m16, imm16")]
            and_m16_imm16,

            /// <summary>
            /// AND r32, imm32
            /// </summary>
            [Symbol("81 /4 id", "AND r32, imm32")]
            and_r32_imm32,

            /// <summary>
            /// AND m32, imm32
            /// </summary>
            [Symbol("81 /4 id ", "AND m32, imm32")]
            and_m32_imm32,

            /// <summary>
            /// AND r64, imm32
            /// </summary>
            [Symbol("REX.W + 81 /4 id", "AND r64, imm32")]
            and_r64_imm32,

            /// <summary>
            /// AND m64, imm32
            /// </summary>
            [Symbol("REX.W + 81 /4 id", "AND m64, imm32")]
            and_m64_imm32,

            /// <summary>
            /// AND r16, imm8
            /// </summary>
            [Symbol("83 /4 ib", "AND r16, imm8")]
            and_r16_imm8,

            /// <summary>
            /// AND m16, imm8
            /// </summary>
            [Symbol("83 /4 ib", "AND m16, imm8")]
            and_m16_imm8,

            /// <summary>
            /// AND r32, imm8
            /// </summary>
            [Symbol("83 /4 ib", "AND r32, imm8")]
            amd_r32_imm8,

            /// <summary>
            /// 83 /4 ib
            /// </summary>
            [Symbol("83 /4 ib", "AND m32, imm8")]
            and_m32_imm8,

            /// <summary>
            /// AND r64, imm8
            /// </summary>
            [Symbol("REX.W + 83 /4 ib")]
            and_r64_imm8,

            /// <summary>
            /// AND m64, imm8
            /// </summary>
            [Symbol("REX.W + 83 /4 ib", "AND m64, imm8")]
            and_m64_imm8,

            /// <summary>
            /// AND r8, r8
            /// </summary>
            [Symbol("20 /r", "AND r8, r8")]
            and_r8_r8,

            /// <summary>
            /// AND m8, r8
            /// </summary>
            [Symbol("20 /r", "AND m8, r8")]
            and_m8_r8,

            /// <summary>
            /// AND r8, r8
            /// </summary>
            [Symbol("REX + 20 /r", "AND r8, r8")]
            and_r8_r8_rex,

            /// <summary>
            /// AND m8, r8
            /// </summary>
            [Symbol("REX + 20 /r", "AND m8, r8")]
            and_m8_r8_rex,

            /// <summary>
            /// AND r16, r16
            /// </summary>
            [Symbol("21 /r", "AND r16, r16")]
            and_r16_r16,

            /// <summary>
            /// AND m16, r16
            /// </summary>
            [Symbol("21 /r", "AND m16, r16")]
            and_m16_r16,

            /// <summary>
            /// AND r32, r32
            /// </summary>
            [Symbol("21 /r", "AND r32, r32")]
            and_r32_r32,

            /// <summary>
            /// AND m32, r32
            /// </summary>
            [Symbol("21 /r", "AND m32, r32")]
            and_m32_r32,

            /// <summary>
            /// AND r64, r64
            /// </summary>
            [Symbol("REX.W + 21 /r", "AND r64, r64")]
            and_r64_r64,

            /// <summary>
            /// AND m64, r64
            /// </summary>
            [Symbol("REX.W + 21 /r", "AND m64, r64")]
            and_m64_r64,

            /// <summary>
            /// AND r8, r8
            /// </summary>
            [Symbol("22 /r", "AND r8, r8")]
            and_r8_r8_x22,

            /// <summary>
            /// AND r8, m8
            /// </summary>
            [Symbol("22 /r", "AND r8, m8")]
            and_r8_m8,

            /// <summary>
            /// AND r16, m16
            /// </summary>
            [Symbol("23 /r", "AND r16, m16")]
            and_r16_m16,

            /// <summary>
            /// AND r32, m32
            /// </summary>
            [Symbol("23 /r", "AND r32, m32")]
            and_r32_m32,

            /// <summary>
            /// AND r64, m64
            /// </summary>
            [Symbol("REX.W + 23 /r", "AND r64, m64")]
            and_r64_m64,
        }
    }
}