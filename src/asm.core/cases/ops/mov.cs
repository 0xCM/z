//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCases
    {
        public static Index<AsmEncodingCase> mov()
        {
            Index<AsmEncodingCase> dst = alloc<AsmEncodingCase>(3);
            var k = 0u;
            dst[k++] = @case(k,
                "mov",
                "REX.W + B8 +rd io",
                "MOV r64,imm64",
                "mov rax,1f6d13cb5e4h",
                "48 b8 e4 b5 3c d1 f6 01 00 00"
                );
            dst[k++] = @case(k,
                "mov",
                "REX.W + B8 +rd io",
                "MOV r64,imm64",
                "mov rax,1f6d12f2f4ch",
                "48 b8 4c 2f 2f d1 f6 01 00 00"
                );
            dst[k++] = @case(k,
                "vmovupd",
                "VEX.128.66.0F.WIG 10 /r",
                "vmovupd xmm, m128",
                "vmovupd xmm0, [rdx]",
                "c5 f9 10 02"
                );
            return dst;
        }
    }
}