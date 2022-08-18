//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Pointers
    {
        /// <summary>
        /// Retrieves a <see cref='string'/> pointer
        /// </summary>
        /// <param name="src">The source string</param>
        /// <remarks>
        /// 0000h nop dword ptr [rax+rax]                 ; NOP r/m32                        | 0F 1F /0                         | 5   | 0f 1f 44 00 00
        /// 0005h test rcx,rcx                            ; TEST r/m64, r64                  | REX.W 85 /r                      | 3   | 48 85 c9
        /// 0008h jne short 000eh                         ; JNE rel8                         | 75 cb                            | 2   | 75 04
        /// 000ah xor eax,eax                             ; XOR r32, r/m32                   | 33 /r                            | 2   | 33 c0
        /// 000ch jmp short 0015h                         ; JMP rel8                         | EB cb                            | 2   | eb 07
        /// 000eh lea rax,[rcx+0ch]                       ; LEA r64, m                       | REX.W 8D /r                      | 4   | 48 8d 41 0c
        /// 0012h mov edx,[rcx+8]                         ; MOV r32, r/m32                   | 8B /r                            | 3   | 8b 51 08
        /// 0015h ret                                     ; RET                              | C3                               | 1   | c3
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static unsafe char* pchar(string src)
            => gptr(Spans.first(Spans.span(src)));
    }
}