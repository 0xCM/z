//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;
    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + "mov")]
        public readonly struct Mov
        {
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static unsafe void mov<T>(uint i, T* pSrc, uint j, T* pDst)
                where T : unmanaged
            {
                pSrc[i] = pDst[j];
            }

            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static unsafe void mov<T>(uint i, ReadOnlySpan<T> src, uint j, T* pDst)
                where T : unmanaged
            {
                pDst[j] = skip(src,i);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="i">rcx</param>
            /// <param name="src">rdx</param>
            /// <param name="j">r8</param>
            /// <param name="dst">r9</param>
            /// <typeparam name="T"></typeparam>
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static unsafe void mov<T>(uint i, ReadOnlySpan<T> src, uint j, Span<T> dst)
                where T : unmanaged
            {
                seek(dst,j) = skip(src,i);
            }

            // mov rax,[rdx+80h]                             # 0000h  | 7   | 48 8b 82 80 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
            // mov [rcx],rax                                 # 0007h  | 3   | 48 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
            // mov rax,[rdx+88h]                             # 000ah  | 7   | 48 8b 82 88 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
            // mov [rcx+8],rax                               # 0011h  | 4   | 48 89 41 08                      | (MOV r/m64, r64) = REX.W 89 /r
            // mov rax,[rdx+90h]                             # 0015h  | 7   | 48 8b 82 90 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
            // mov [rcx+10h],rax                             # 001ch  | 4   | 48 89 41 10                      | (MOV r/m64, r64) = REX.W 89 /r
            // mov rax,[rdx+98h]                             # 0020h  | 7   | 48 8b 82 98 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
            // mov [rcx+18h],rax                             # 0027h  | 4   | 48 89 41 18                      | (MOV r/m64, r64) = REX.W 89 /r
            // mov rax,[rdx+0a0h]                            # 002bh  | 7   | 48 8b 82 a0 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
            // mov [rcx+20h],rax                             # 0032h  | 4   | 48 89 41 20                      | (MOV r/m64, r64) = REX.W 89 /r
            // mov rax,[rdx+0a8h]                            # 0036h  | 7   | 48 8b 82 a8 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
            // mov [rcx+28h],rax                             # 003dh  | 4   | 48 89 41 28                      | (MOV r/m64, r64) = REX.W 89 /r
            // mov rax,[rdx+0b0h]                            # 0041h  | 7   | 48 8b 82 b0 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
            // mov [rcx+30h],rax                             # 0048h  | 4   | 48 89 41 30                      | (MOV r/m64, r64) = REX.W 89 /r
            // mov rax,[rdx+0b8h]                            # 004ch  | 7   | 48 8b 82 b8 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
            // mov [rcx+38h],rax                             # 0053h  | 4   | 48 89 41 38                      | (MOV r/m64, r64) = REX.W 89 /r
            // ret                                           # 0057h  | 1   | c3                               | (RET) = C3

            /// <summary>
            /// [rcx + 0*8h] -> [rdx+16*8h]
            /// [rcx + 1*8h] -> [rdx+17*8h]
            /// [rcx + 2*8h] -> [rdx+18*h]
            ///
            ///
            /// mov rax, [rdx+80h]          # (MOV r64, r/m64) = REX.W 8B /r  | RM  | 7   | 48 8b 82 80 00 00 00
            /// mov [rcx], rax              # (MOV r/m64, r64) = REX.W 89 /r  | MR  | 3   | 48 89 01
            /// mov rax, [rdx+88h]          # (MOV r64, r/m64) = REX.W 8B /r  | RM  | 7   | 48 8b 82 88 00 00 00
            /// mov [rcx + 8h], rax         # (MOV r/m64, r64) = REX.W 89 /r  | MR  | 4   | 48 89 41 08
            /// mov rax, [rdx+90h]          # (MOV r64, r/m64) = REX.W 8B /r  | RM  | 7   | 48 8b 82 90 00 00 00
            /// mov [rcx + 10h], rax        # (MOV r/m64, r64) = REX.W 89 /r  | MR  | 4   | 48 89 41 10
            /// | MR    | ModRM:r/m (w)   | ModRM:reg (r) | NA        | NA        |
            /// | RM    | ModRM:reg (w)   | ModRM:r/m (r) | NA        | NA        |
            /// </summary>
            /// <param name="pSrc">rcx</param>
            /// <param name="pDst">rdx</param>
            /// <typeparam name="T"></typeparam>
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static unsafe void mov8a<T>(T* pSrc, T* pDst)
                where T : unmanaged
            {
                mov(0,pSrc,16,pDst);
                mov(1,pSrc,17,pDst);
                mov(2,pSrc,18,pDst);
                mov(3,pSrc,19,pDst);
                mov(4,pSrc,20,pDst);
                mov(5,pSrc,21,pDst);
                mov(6,pSrc,22,pDst);
                mov(7,pSrc,23,pDst);
            }

            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static unsafe void mov8b<T>(ReadOnlySpan<T> src, T* pDst)
                where T : unmanaged
            {
                mov(0,src,16,pDst);
                mov(1,src,17,pDst);
                mov(2,src,18,pDst);
                mov(3,src,19,pDst);
                mov(4,src,20,pDst);
                mov(5,src,21,pDst);
                mov(6,src,22,pDst);
                mov(7,src,23,pDst);
            }

            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static unsafe void mov8c<T>(ReadOnlySpan<T> src, Span<T> dst)
                where T : unmanaged
            {
                mov(0,src,16,dst);
                mov(1,src,17,dst);
                mov(2,src,18,dst);
                mov(3,src,19,dst);
                mov(4,src,20,dst);
                mov(5,src,21,dst);
                mov(6,src,22,dst);
                mov(7,src,23,dst);
            }

            [Op]
            public static unsafe void mov2x8u(byte* a, byte* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }


            [Op]
            public static unsafe void mov2x16u(ushort* a, ushort* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x32u(uint* a, uint* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x64u(ulong* a, ulong* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x128u(ByteBlock16* a, ByteBlock16* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x256u(ByteBlock32* a, ByteBlock32* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x512u(ByteBlock512* a, ByteBlock512* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }
        }
    }
}