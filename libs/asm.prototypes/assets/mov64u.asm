# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8a[ulong](ulong* pSrc, ulong* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[64u](64u~ptr,64u~ptr)
# 0x48,0x8b,0x82,0x80,0x00,0x00,0x00,0x48,0x89,0x01,0x48,0x8b,0x82,0x88,0x00,0x00,0x00,0x48,0x89,0x41,0x08,0x48,0x8b,0x82,0x90,0x00,0x00,0x00,0x48,0x89,0x41,0x10,0x48,0x8b,0x82,0x98,0x00,0x00,0x00,0x48,0x89,0x41,0x18,0x48,0x8b,0x82,0xa0,0x00,0x00,0x00,0x48,0x89,0x41,0x20,0x48,0x8b,0x82,0xa8,0x00,0x00,0x00,0x48,0x89,0x41,0x28,0x48,0x8b,0x82,0xb0,0x00,0x00,0x00,0x48,0x89,0x41,0x30,0x48,0x8b,0x82,0xb8,0x00,0x00,0x00,0x48,0x89,0x41,0x38,0xc3
# EntryAddress  :7ffb723a7fd8h
# TargetAddress :7ffb723a8550h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx+80h]                             # 0000h  | 7   | 48 8b 82 80 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],rax                                 # 0007h  | 3   | 48 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+88h]                             # 000ah  | 7   | 48 8b 82 88 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+8],rax                               # 0011h  | 4   | 48 89 41 08                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+90h]                             # 0015h  | 7   | 48 8b 82 90 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+10h],rax                             # 001ch  | 4   | 48 89 41 10                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+98h]                             # 0020h  | 7   | 48 8b 82 98 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+18h],rax                             # 0027h  | 4   | 48 89 41 18                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+0a0h]                            # 002bh  | 7   | 48 8b 82 a0 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+20h],rax                             # 0032h  | 4   | 48 89 41 20                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+0a8h]                            # 0036h  | 7   | 48 8b 82 a8 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+28h],rax                             # 003dh  | 4   | 48 89 41 28                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+0b0h]                            # 0041h  | 7   | 48 8b 82 b0 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+30h],rax                             # 0048h  | 4   | 48 89 41 30                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+0b8h]                            # 004ch  | 7   | 48 8b 82 b8 00 00 00             | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+38h],rax                             # 0053h  | 4   | 48 89 41 38                      | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 0057h  | 1   | c3                               | (RET) = C3
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8b[ulong](ReadOnlySpan[ulong] src, ulong* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[64u](rspan64u,64u~ptr)
# 0x48,0x8b,0x01,0x48,0x8b,0x08,0x48,0x89,0x8a,0x80,0x00,0x00,0x00,0x48,0x8b,0x48,0x08,0x48,0x89,0x8a,0x88,0x00,0x00,0x00,0x48,0x8b,0x48,0x10,0x48,0x89,0x8a,0x90,0x00,0x00,0x00,0x48,0x8b,0x48,0x18,0x48,0x89,0x8a,0x98,0x00,0x00,0x00,0x48,0x8b,0x48,0x20,0x48,0x89,0x8a,0xa0,0x00,0x00,0x00,0x48,0x8b,0x48,0x28,0x48,0x89,0x8a,0xa8,0x00,0x00,0x00,0x48,0x8b,0x48,0x30,0x48,0x89,0x8a,0xb0,0x00,0x00,0x00,0x48,0x8b,0x40,0x38,0x48,0x89,0x82,0xb8,0x00,0x00,0x00,0xc3
# EntryAddress  :7ffb723a8088h
# TargetAddress :7ffb723a8950h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rcx]                                 # 0000h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
mov rcx,[rax]                                 # 0003h  | 3   | 48 8b 08                         | (MOV r64, r/m64) = REX.W 8B /r
mov [rdx+80h],rcx                             # 0006h  | 7   | 48 89 8a 80 00 00 00             | (MOV r/m64, r64) = REX.W 89 /r
mov rcx,[rax+8]                               # 000dh  | 4   | 48 8b 48 08                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rdx+88h],rcx                             # 0011h  | 7   | 48 89 8a 88 00 00 00             | (MOV r/m64, r64) = REX.W 89 /r
mov rcx,[rax+10h]                             # 0018h  | 4   | 48 8b 48 10                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rdx+90h],rcx                             # 001ch  | 7   | 48 89 8a 90 00 00 00             | (MOV r/m64, r64) = REX.W 89 /r
mov rcx,[rax+18h]                             # 0023h  | 4   | 48 8b 48 18                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rdx+98h],rcx                             # 0027h  | 7   | 48 89 8a 98 00 00 00             | (MOV r/m64, r64) = REX.W 89 /r
mov rcx,[rax+20h]                             # 002eh  | 4   | 48 8b 48 20                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rdx+0a0h],rcx                            # 0032h  | 7   | 48 89 8a a0 00 00 00             | (MOV r/m64, r64) = REX.W 89 /r
mov rcx,[rax+28h]                             # 0039h  | 4   | 48 8b 48 28                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rdx+0a8h],rcx                            # 003dh  | 7   | 48 89 8a a8 00 00 00             | (MOV r/m64, r64) = REX.W 89 /r
mov rcx,[rax+30h]                             # 0044h  | 4   | 48 8b 48 30                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rdx+0b0h],rcx                            # 0048h  | 7   | 48 89 8a b0 00 00 00             | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rax+38h]                             # 004fh  | 4   | 48 8b 40 38                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rdx+0b8h],rax                            # 0053h  | 7   | 48 89 82 b8 00 00 00             | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 005ah  | 1   | c3                               | (RET) = C3
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[ulong](ReadOnlySpan[ulong] src, Span[ulong] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[64u](rspan64u,span64u)
# 0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x88,0x80,0x00,0x00,0x00,0x4c,0x8b,0x02,0x4c,0x89,0x01,0x48,0x8d,0x88,0x88,0x00,0x00,0x00,0x4c,0x8b,0x42,0x08,0x4c,0x89,0x01,0x48,0x8d,0x88,0x90,0x00,0x00,0x00,0x4c,0x8b,0x42,0x10,0x4c,0x89,0x01,0x48,0x8d,0x88,0x98,0x00,0x00,0x00,0x4c,0x8b,0x42,0x18,0x4c,0x89,0x01,0x48,0x8d,0x88,0xa0,0x00,0x00,0x00,0x4c,0x8b,0x42,0x20,0x4c,0x89,0x01,0x48,0x8d,0x88,0xa8,0x00,0x00,0x00,0x4c,0x8b,0x42,0x28,0x4c,0x89,0x01,0x48,0x8d,0x88,0xb0,0x00,0x00,0x00,0x4c,0x8b,0x42,0x30,0x4c,0x89,0x01,0x48,0x05,0xb8,0x00,0x00,0x00,0x48,0x8b,0x52,0x38,0x48,0x89,0x10,0xc3
# EntryAddress  :7ffb723a8138h
# TargetAddress :7ffb723a8e20h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0003h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+80h]                             # 0006h  | 7   | 48 8d 88 80 00 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8,[rdx]                                  # 000dh  | 3   | 4c 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],r8                                  # 0010h  | 3   | 4c 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
lea rcx,[rax+88h]                             # 0013h  | 7   | 48 8d 88 88 00 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8,[rdx+8]                                # 001ah  | 4   | 4c 8b 42 08                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],r8                                  # 001eh  | 3   | 4c 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
lea rcx,[rax+90h]                             # 0021h  | 7   | 48 8d 88 90 00 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8,[rdx+10h]                              # 0028h  | 4   | 4c 8b 42 10                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],r8                                  # 002ch  | 3   | 4c 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
lea rcx,[rax+98h]                             # 002fh  | 7   | 48 8d 88 98 00 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8,[rdx+18h]                              # 0036h  | 4   | 4c 8b 42 18                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],r8                                  # 003ah  | 3   | 4c 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
lea rcx,[rax+0a0h]                            # 003dh  | 7   | 48 8d 88 a0 00 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8,[rdx+20h]                              # 0044h  | 4   | 4c 8b 42 20                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],r8                                  # 0048h  | 3   | 4c 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
lea rcx,[rax+0a8h]                            # 004bh  | 7   | 48 8d 88 a8 00 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8,[rdx+28h]                              # 0052h  | 4   | 4c 8b 42 28                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],r8                                  # 0056h  | 3   | 4c 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
lea rcx,[rax+0b0h]                            # 0059h  | 7   | 48 8d 88 b0 00 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8,[rdx+30h]                              # 0060h  | 4   | 4c 8b 42 30                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],r8                                  # 0064h  | 3   | 4c 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
add rax,0b8h                                  # 0067h  | 6   | 48 05 b8 00 00 00                | (ADD RAX, imm32) = REX.W 05 id
mov rdx,[rdx+38h]                             # 006dh  | 4   | 48 8b 52 38                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rax],rdx                                 # 0071h  | 3   | 48 89 10                         | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 0074h  | 1   | c3                               | (RET) = C3
