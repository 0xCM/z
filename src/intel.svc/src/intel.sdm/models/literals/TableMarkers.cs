//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public readonly struct TableMarkers
        {
            public static string[] OcHeader0 = new string[9]{
                "Opcode",
                "Instruction",
                "Op/",
                "En",
                "64-Bit",
                "Mode",
                "Compat/",
                "Leg Mode",
                "Description"
                };

            public static string[] OcHeader1 = new string[11]{
                "Opcode/",
                "Instruction",
                "Op/",
                "En",
                "64/32",
                "-bit",
                "Mode",
                "CPUID",
                "Feature",
                "Flag",
                "Description"
                };

            public static string[] OpCodeHeader2 = new string[12]{
                "Opcode/",
                "Instruction",
                "Op /",
                "En",
                "64/32",
                "bit",
                "Mode",
                "Support",
                "CPUID",
                "Feature",
                "Flag",
                "Description"
                };

            public static string[] EncodingHeader0 = new string[5]{
                "Op/En",
                "Operand 1",
                "Operand 2",
                "Operand 3",
                "Operand 4"
                };
        }
    }
}