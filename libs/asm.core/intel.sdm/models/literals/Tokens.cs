//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public const string tokens = "intel.sdm";

        [SymSource(tokens)]
        public enum Mode64Support : byte
        {
            None,

            [Symbol("V", "Supported")]
            V,

            [Symbol("I", "Not Supported")]
            I,

            [Symbol("N.E.", "Indicates an instruction syntax is not encodable in 64-bit mode")]
            NE,

            [Symbol("N.P.", "Indicates the REX prefix does not affect the legacy instruction in 64-bit mode")]
            NP,

            [Symbol("N.I.", "Indicates the opcode is treated as a new instruction in 64-bit mode")]
            NI,

            [Symbol("N.S.", "Indicates an instruction syntax that requires an address override prefix in 64-bit mode and is not suported")]
            NS
        }

        [SymSource(tokens)]
        public enum SdmTableKind : byte
        {
            None = 0,

            [Symbol("OpCodes")]
            OpCodes,

            [Symbol("Encoding")]
            EncodingRule,

            [Symbol("BinaryFormat")]
            BinaryFormat,

            [Symbol("Intrinsics")]
            Intrinsics,

            [Symbol("Notes")]
            Notes,

            [Symbol("Numbered")]
            Numbered,
        }

        [SymSource(tokens)]
        public enum SdmColumnKind : byte
        {
            None = 0,

            OpCode,

            Signature,

            EncodingRef,

            Cpuid,

            Mode64,

            Mode32,

            Mode64x32,

            Description,

            Op1,

            Op2,

            Op3,

            Op4
        }

        [SymSource(tokens)]
        public enum VolDigit : byte
        {
            V1 = 1,

            V2 = 2,

            V3 = 3,

            V4 = 4
        }
    }
}