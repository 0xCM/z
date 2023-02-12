//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static SdmModels;

    using S = SdmModels.SdmEncodingSigs;

    [ApiComplete]
    public class SdmSymbols
    {
        public static SdmSymbols create()
            => new SdmSymbols();

        const string RegSpecial = "AL/AX/EAX/RAX";

        Index<string> _ExplicitRegs;

        Index<string> _Imm;

        Index<string> _ModRm;

        Index<string> _Vex;

        Index<string> _LegacyMode;

        Index<string> _Mode64;

        Index<string> _Mode64x32;

        SdmSymbols()
        {
            Init();
        }

        void Init()
        {
            _Imm = ImmEncData;
            _ModRm = ModRMEncData;
            _Vex = VexEncData;
            _LegacyMode = LegacyModeData;
            _Mode64 = Mode64Data;
            _Mode64x32 = Mode64x32Data;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<string> ImmEncSyms()
            => _Imm.View;

        [MethodImpl(Inline)]
        public ReadOnlySpan<string> ModRmEncSyms()
            => _ModRm.View;

        [MethodImpl(Inline)]
        public ReadOnlySpan<string> VexEncSyms()
            => _Vex.View;

        public string Lookup(EncodingClass @class, byte index)
        {
            var result = EmptyString;
            switch(@class)
            {
                case EncodingClass.ExplicitRegs:
                    if(index < ExplicitRegEncCount)
                        result = _ExplicitRegs[index];
                break;
                case EncodingClass.ModRm:
                    if(index < ModRmEncCount)
                        result = _ModRm[index];
                break;
                case EncodingClass.Imm:
                    if(index < ImmEncCount)
                        result = _Imm[index];
                break;
            }
            return result;
        }

        const byte ExplicitRegEncCount = 1;

        const byte ModRmEncCount = 8;

        const byte ImmEncCount = 4;

        static readonly string[] ExplicitRegEncData = new string[ExplicitRegEncCount]{
            "AL/AX/EAX/RAX"
        };

        static readonly string[] ImmEncData = new string[ImmEncCount]{
            "imm8",
            "imm8/r",
            "imm8/16/32",
            "imm8/16/32/64",
            };

        static string[] ModRMEncData = new string[ModRmEncCount]{
            S.ModRm_RmR,
            S.ModRm_RmW,
            S.ModRm_RmRW,
            S.ModRm_RegR,
            S.ModRm_RegW,
            S.ModRm_RegRW,
            S.ModRm_RmR11,
            S.ModRm_RmWNot11,
        };

        static readonly string[] VexEncData = new string[]{
            "VEX.vvvv",
            "VEX.vvvv (r, w)",
            "VEX.vvvv (r)",
            "VEX.1vvv (r)",
            };

        static string[] LegacyModeData = new string[]{
            "Valid",
            "N.E.",
        };

        static string[] Mode64Data = new string[]{
            "Valid",
            "N.E.",
            "V/N.E.",
        };

        static string[] Mode64x32Data = new string[]{
            "V/V",
            "V/N. E.",
            "V 1 /V",
            "V/I 2"
        };

        // static string[] OperandData = new string[]{
        //     "AL",
        //     "AX",
        //     "EAX",
        //     "RAX",
        //     "DX",

        //     "k1",
        //     "k2",
        //     "k3",

        //     "mm1",
        //     "mm2",

        //     "r8",
        //     "r16",
        //     "r32",
        //     "r64",


        //     "mm2/m64",

        // };

        // static readonly string[] RmOpData = new string[]{
        //     "r32/m8",
        //     "r32/m32",
        //     "r64/m64",
        //     "r/m8",
        //     "r/m16",
        //     "r/m32",
        //     "r/m64",
        // };

        // static readonly string[] RelOpData = new string[]{
        //     "rel8",
        //     "rel16",
        //     "rel32",
        // };

        // static readonly string[] ImmOpData = new string[]{
        //     "imm8",
        //     "imm16",
        //     "imm32",
        //     "imm64",
        // };

        // static readonly string[] MemOpData = new string[]{
        //     "m8",
        //     "m16",
        //     "m32",
        //     "m64",
        //     "m128",
        //     "m256",
        // };

        // static readonly string[] XmmOpData = new string[]{
        //     "xmm1",
        //     "xmm2",
        //     "xmm3",
        //     "xmm1{k1}{z}",
        //     "xmm2/m16",
        //     "xmm2/m32",
        //     "xmm2/m64",
        //     "xmm2/m128",
        //     "xmm2/m128/m32bcst",
        //     "xmm3/m128",
        //     "xmm3/m128/m32bcst",
        //     "xmm3/m128/m64bcst",
        // };

        // static readonly string[] YmmOpData = new string[]{
        //     "ymm1",
        //     "ymm2",
        //     "ymm3",
        //     "ymm1{k1}{z}",
        //     "ymm2/m256",
        //     "ymm2/m256/m32bcst",
        //     "ymm3/m256",
        //     "ymm3/m256/m32bcst",
        //     "ymm3/m256/m64bcst",
        // };

        // static readonly string[] ZmmOpData = new string[]{
        //     "zmm1",
        //     "zmm2",
        //     "zmm3",
        //     "zmm1{k1}{z}",
        //     "zmm2/m512/m32bcst",
        //     "zmm3/m512",
        //     "zmm3/m512/m32bcst",
        //     "zmm3/m512/m64bcst",
        // };

        // static readonly string[] EvexData = new string[]{
        //     "EVEX.vvvv",
        //     "EVEX.R",
        //     "EVEX.V'",
        //     "EVEX.R'",
        //     "EVEX.vvvv (r)",
        //     "EVEX.RC",
        //     "EVEX.RX",
        //     "EVEX.RXB",
        //     };

        // static readonly string[] OpCodeArithmeticData = new string[]{
        //     "opcode + rd (w)",
        //     "opcode + rd (r)",
        //     "opcode + rd (r, w)",
        //     };

        // static readonly string[] EncodingVersionData = new string[]
        // {
        //     "(128-bit Legacy SSE version)",
        //     "(128-bit load- and register-copy- form Legacy SSE version)",
        //     "(128-bit store-form version)",
        //     "(VEX.128 encoded version)",
        //     "(VEX.128 and EVEX.128 encoded version)",
        //     "(VEX.256 encoded version)",
        //     "(VEX.256 encoded version, load - and register copy)",
        //     "(VEX.256 encoded version, store-form)",
        //     "(VEX.256 and EVEX.256 encoded version)",
        //     "(EVEX encoded version)",
        //     "(EVEX and VEX.128 encoded version)",
        //     "(EVEX encoded versions, register-copy form)",
        //     "(EVEX encoded versions, load-form)",
        //     "(EVEX.U1.512 encoded version)",
        //     "(EVEX.512 encoded version)"
        // };
    }
}