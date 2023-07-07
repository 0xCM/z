//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + pointers)]
        public unsafe readonly struct Pointers
        {
            public static ReadOnlySpan<byte> and_ᐤ8uㆍ8uᐤ => new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x23,0xc2,0x0f,0xb6,0xc0,0xc3};

            public static ReadOnlySpan<byte> or_ᐤ8uㆍ8uᐤ => new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x0b,0xc2,0x0f,0xb6,0xc0,0xc3};

            public static ReadOnlySpan<byte> xor_ᐤ8uㆍ8uᐤ => new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x33,0xc2,0x0f,0xb6,0xc0,0xc3};

            public static ReadOnlySpan<byte> div_ᐤ8uㆍ8uᐤ => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xca,0x99,0xf7,0xf9,0x0f,0xb6,0xc0,0xc3};

            public static ReadOnlySpan<byte> mul_ᐤ8uㆍ8uᐤ => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x0f,0xaf,0xc2,0x0f,0xb6,0xc0,0xc3};

            public static ReadOnlySpan<byte> mod_ᐤ8uㆍ8uᐤ => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xca,0x99,0xf7,0xf9,0x0f,0xb6,0xc2,0xc3};

            [Op, MethodImpl(NotInline)]
            public static byte and(byte a, byte b)
                => math.and(a,b);

            [Op, MethodImpl(NotInline)]
            public static byte or(byte a, byte b)
                => math.or(a,b);

            [Op, MethodImpl(NotInline)]
            public static byte xor(byte a, byte b)
                => math.xor(a,b);

            [Op, MethodImpl(NotInline)]
            public static byte div(byte a, byte b)
                => math.div(a,b);

            [Op, MethodImpl(NotInline)]
            public static byte mul(byte a, byte b)
                => math.mul(a,b);

            [Op, MethodImpl(NotInline)]
            public static byte mod(byte a, byte b)
                => math.mod(a,b);


            [MethodImpl(Inline), Op]
            public static unsafe void copy16x8i(sbyte* pSrc, sbyte* pDst)
            {
                byte i=0,j=0;
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
            }

            [MethodImpl(Inline), Op]
            public static unsafe void copy16x64u(ulong* pSrc, ulong* pDst)
            {
                byte i=0,j=0;
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];

            }

            [MethodImpl(Inline), Op]
            public static unsafe void copy16x32u(uint* pSrc, uint* pDst)
            {
                byte i=0,j=0;
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
                pDst[i++] = pSrc[j++];
            }

            [Op]
            public static void f_32u_p8u_p8u_p8u_void(byte* pA, byte* pB, byte* pDst)
            {
                var i=0u;
                pDst[i++] = math.and(pA[i], pB[i]);
                pDst[i++] = math.or(pA[i], pB[i]);
                pDst[i++] = math.xor(pA[i], pB[i]);
                pDst[i++] = math.mul(pA[i], pB[i]);
                pDst[i++] = math.div(pA[i], pB[i]);
                pDst[i++] = math.mod(pA[i], pB[i]);
            }

            [Op]
            public static void f_p8u_p8u_p8u(byte* pA, byte* pB, byte* pDst)
            {
                var i=0u;
                pDst[i++] = and(pA[i], pB[i]);
                pDst[i++] = or(pA[i], pB[i]);
                pDst[i++] = xor(pA[i], pB[i]);
                pDst[i++] = mul(pA[i], pB[i]);
                pDst[i++] = div(pA[i], pB[i]);
                pDst[i++] = mod(pA[i], pB[i]);
            }

            [Op]
            public static void f_p8i_p8i_p8i(sbyte* pA, sbyte* pB, sbyte* pDst)
            {
                var i=0u;
                pDst[i++] = math.and(pA[i], pB[i]);
                pDst[i++] = math.or(pA[i], pB[i]);
                pDst[i++] = math.xor(pA[i], pB[i]);
                pDst[i++] = math.mul(pA[i], pB[i]);
                pDst[i++] = math.div(pA[i], pB[i]);
                pDst[i++] = math.mod(pA[i], pB[i]);
            }

            [Op]
            public static void f_32u_p16u_p16u_p16u(uint count, ushort* pA, ushort* pB, ushort* pDst)
            {
                for(var i=0u; i<count; i++)
                {
                    pDst[i] = math.and(pA[i], pB[i]);
                    pDst[i] = math.or(pA[i], pB[i]);
                    pDst[i] = math.xor(pA[i], pB[i]);
                    pDst[i] = math.mul(pA[i], pB[i]);
                    pDst[i] = math.div(pA[i], pB[i]);
                    pDst[i] = math.mod(pA[i], pB[i]);
                }
            }

            [Op]
            public static void f_32u_p16i_p16i_p16i_void(short* pA, short* pB, short* pDst)
            {
                var i=0u;
                pDst[i++] = math.and(pA[i], pB[i]);
                pDst[i++] = math.or(pA[i], pB[i]);
                pDst[i++] = math.xor(pA[i], pB[i]);
                pDst[i++] = math.mul(pA[i], pB[i]);
                pDst[i++] = math.div(pA[i], pB[i]);
                pDst[i++] = math.mod(pA[i], pB[i]);
            }

            [Op]
            public static void f_32u_p32i_p32i_p32i_void(int* pA, int* pB, int* pDst)
            {
                var i=0u;
                pDst[i++] = math.and(pA[i], pB[i]);
                pDst[i++] = math.or(pA[i], pB[i]);
                pDst[i++] = math.xor(pA[i], pB[i]);
                pDst[i++] = math.mul(pA[i], pB[i]);
                pDst[i++] = math.div(pA[i], pB[i]);
                pDst[i++] = math.mod(pA[i], pB[i]);
            }

            [Op]
            public static void f_32u_p32u_p32u_p32u_void(uint* pA, uint* pB, uint* pDst)
            {
                var i=0u;
                pDst[i++] = math.and(pA[i], pB[i]);
                pDst[i++] = math.or(pA[i], pB[i]);
                pDst[i++] = math.xor(pA[i], pB[i]);
                pDst[i++] = math.mul(pA[i], pB[i]);
                pDst[i++] = math.div(pA[i], pB[i]);
                pDst[i++] = math.mod(pA[i], pB[i]);
            }

            [Op]
            public static void f_32u_p64u_p64u_p64u_void(ulong* pA, ulong* pB, ulong* pDst)
            {
                var i=0u;
                pDst[i++] = math.and(pA[i], pB[i]);
                pDst[i++] = math.or(pA[i], pB[i]);
                pDst[i++] = math.xor(pA[i], pB[i]);
                pDst[i++] = math.mul(pA[i], pB[i]);
                pDst[i++] = math.div(pA[i], pB[i]);
                pDst[i++] = math.mod(pA[i], pB[i]);
            }

            [Op]
            public static void f_pc128u_pc128u_pc128u_void(Cell128* pA, Cell128* pB, Cell128* pDst)
            {
                // 0000h sub rsp,58h
                // 0004h vzeroupper
                var i=0u;

                // 0007h vmovupd xmm0,[rcx+10h]
                // 000ch vmovupd xmm1,[rdx+10h]
                // 0011h vpand xmm0,xmm0,xmm1
                // 0015h vmovapd [rsp+40h],xmm0
                // 001bh vmovdqu xmm0,xmmword ptr [rsp+40h]
                // 0021h vmovdqu xmmword ptr [r8],xmm0
                pDst[i++] = gcpu.vand<byte>(pA[i], pB[i]);
                // 0026h vmovupd xmm0,[rcx+20h]
                // 002bh vmovupd xmm1,[rdx+20h]
                // 0030h vpor xmm0,xmm0,xmm1
                // 0034h vmovapd [rsp+30h],xmm0
                // 003ah lea rax,[r8+10h]
                // 003eh vmovdqu xmm0,xmmword ptr [rsp+30h]
                // 0044h vmovdqu xmmword ptr [rax],xmm0
                pDst[i++] = gcpu.vor<byte>(pA[i], pB[i]);
                // 0048h vmovupd xmm0,[rcx+30h]
                // 004dh vmovupd xmm1,[rdx+30h]
                // 0052h vpxor xmm0,xmm0,xmm1
                // 0056h vmovapd [rsp+20h],xmm0
                // 005ch lea rax,[r8+20h]
                // 0060h vmovdqu xmm0,xmmword ptr [rsp+20h]
                // 0066h vmovdqu xmmword ptr [rax],xmm0
                pDst[i++] = gcpu.vxor<byte>(pA[i], pB[i]);
                // 006ah vmovupd xmm0,[rcx+40h]
                // 006fh vmovupd xmm1,[rdx+40h]
                // 0074h vpsubb xmm0,xmm0,xmm1
                // 0078h vmovapd [rsp+10h],xmm0
                // 007eh lea rax,[r8+30h]
                // 0082h vmovdqu xmm0,xmmword ptr [rsp+10h]
                // 0088h vmovdqu xmmword ptr [rax],xmm0
                pDst[i++] = gcpu.vsub<byte>(pA[i], pB[i]);
                // 008ch vmovupd xmm0,[rcx+50h]
                // 0091h vmovupd xmm1,[rdx+50h]
                // 0096h vpaddb xmm0,xmm0,xmm1
                // 009ah vmovapd [rsp],xmm0
                // 009fh add r8,40h
                // 00a3h vmovdqu xmm0,xmmword ptr [rsp]
                // 00a8h vmovdqu xmmword ptr [r8],xmm0
                pDst[i++] = gcpu.vadd<byte>(pA[i], pB[i]);
                // 00adh add rsp,58h
                // 00b1h ret
            }

            [Op]
            public static void f_pc256u_pc256u_pc256u_void(Cell256* pA, Cell256* pB, Cell256* pDst)
            {
                // 0000h vzeroupper                                    ; VZEROUPPER                       | VEX.128.0F.WIG 77                | 3   | c5 f8 77
                // 0003h xchg ax,ax                                    ; NOP                              | 90                               | 2   | 66 90
                var i=0u;
                // 0005h vmovupd ymm0,[rcx+20h]                        ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 5   | c5 fd 10 41 20
                // 000ah vmovupd ymm1,[rdx+20h]                        ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 5   | c5 fd 10 4a 20
                // 000fh vpand ymm0,ymm0,ymm1                          ; VPAND ymm1, ymm2, ymm3/m256      | VEX.256.66.0F.WIG DB /r          | 4   | c5 fd db c1
                // 0013h vmovupd [r8],ymm0                             ; VMOVUPD ymm2/m256, ymm1          | VEX.256.66.0F.WIG 11 /r          | 5   | c4 c1 7d 11 00
                pDst[i++] = gcpu.vand<byte>(pA[i], pB[i]);
                // 0018h vmovupd ymm0,[rcx+40h]                        ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 5   | c5 fd 10 41 40
                // 001dh vmovupd ymm1,[rdx+40h]                        ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 5   | c5 fd 10 4a 40
                // 0022h vpor ymm0,ymm0,ymm1                           ; VPOR ymm1, ymm2, ymm3/m256       | VEX.256.66.0F.WIG EB /r          | 4   | c5 fd eb c1
                // 0026h vmovupd [r8+20h],ymm0                         ; VMOVUPD ymm2/m256, ymm1          | VEX.256.66.0F.WIG 11 /r          | 6   | c4 c1 7d 11 40 20
                pDst[i++] = gcpu.vor<byte>(pA[i], pB[i]);
                // 002ch vmovupd ymm0,[rcx+60h]                        ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 5   | c5 fd 10 41 60
                // 0031h vmovupd ymm1,[rdx+60h]                        ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 5   | c5 fd 10 4a 60
                // 0036h vpxor ymm0,ymm0,ymm1                          ; VPXOR ymm1, ymm2, ymm3/m256      | VEX.256.66.0F.WIG EF /r          | 4   | c5 fd ef c1
                // 003ah vmovupd [r8+40h],ymm0                         ; VMOVUPD ymm2/m256, ymm1          | VEX.256.66.0F.WIG 11 /r          | 6   | c4 c1 7d 11 40 40
                pDst[i++] = gcpu.vxor<byte>(pA[i], pB[i]);
                // 0040h vmovupd ymm0,[rcx+80h]                        ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 8   | c5 fd 10 81 80 00 00 00
                // 0048h vmovupd ymm1,[rdx+80h]                        ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 8   | c5 fd 10 8a 80 00 00 00
                // 0050h vpsubb ymm0,ymm0,ymm1                         ; VPSUBB ymm1, ymm2, ymm3/m256     | VEX.256.66.0F.WIG F8 /r          | 4   | c5 fd f8 c1
                // 0054h vmovupd [r8+60h],ymm0                         ; VMOVUPD ymm2/m256, ymm1          | VEX.256.66.0F.WIG 11 /r          | 6   | c4 c1 7d 11 40 60
                pDst[i++] = gcpu.vsub<byte>(pA[i], pB[i]);
                // 005ah vmovupd ymm0,[rcx+0a0h]                       ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 8   | c5 fd 10 81 a0 00 00 00
                // 0062h vmovupd ymm1,[rdx+0a0h]                       ; VMOVUPD ymm1, ymm2/m256          | VEX.256.66.0F.WIG 10 /r          | 8   | c5 fd 10 8a a0 00 00 00
                // 006ah vpaddb ymm0,ymm0,ymm1                         ; VPADDB ymm1, ymm2, ymm3/m256     | VEX.256.66.0F.WIG FC /r          | 4   | c5 fd fc c1
                // 006eh vmovupd [r8+80h],ymm0                         ; VMOVUPD ymm2/m256, ymm1          | VEX.256.66.0F.WIG 11 /r          | 9   | c4 c1 7d 11 80 80 00 00 00
                pDst[i++] = gcpu.vadd<byte>(pA[i], pB[i]);
                // 0077h vzeroupper                                    ; VZEROUPPER                       | VEX.128.0F.WIG 77                | 3   | c5 f8 77
                // 007ah ret                                           ; RET                              | C3                               | 1   | c3
            }
        }
    }
}