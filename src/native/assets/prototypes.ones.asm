# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# byte ones(W8 w, byte i0, byte i1)::located://lib/bits?ones#onesヽ(W8,8u,8u)
# 0x41,0x0f,0xb6,0xc8,0x0f,0xb6,0xc2,0x2b,0xc8,0xff,0xc1,0x0f,0xb6,0xc9,0xba,0xff,0x00,0x00,0x00,0xc4,0xe2,0x70,0xf5,0xca,0x0f,0xb6,0xd1,0x8b,0xc8,0xd3,0xe2,0x0f,0xb6,0xc2,0xc3
# EntryAddress  :7ffd292ac1b0h
# TargetAddress :7ffd2adebd30h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movzx ecx,r8b                                 # 0000h  | 4   | 41 0f b6 c8                      | (MOVZX r32, r/m8) = 0F B6 /r
movzx eax,dl                                  # 0004h  | 3   | 0f b6 c2                         | (MOVZX r32, r/m8) = 0F B6 /r
sub ecx,eax                                   # 0007h  | 2   | 2b c8                            | (SUB r32, r/m32) = 2B /r
inc ecx                                       # 0009h  | 2   | ff c1                            | (INC r/m32) = FF /0
movzx ecx,cl                                  # 000bh  | 3   | 0f b6 c9                         | (MOVZX r32, r/m8) = 0F B6 /r
mov edx,0ffh                                  # 000eh  | 5   | ba ff 00 00 00                   | (MOV r32, imm32) = B8 +rd id
bzhi ecx,edx,ecx                              # 0013h  | 5   | c4 e2 70 f5 ca                   | (BZHI r32a, r/m32, r32b) = VEX.LZ.0F38.W0 F5 /r
movzx edx,cl                                  # 0018h  | 3   | 0f b6 d1                         | (MOVZX r32, r/m8) = 0F B6 /r
mov ecx,eax                                   # 001bh  | 2   | 8b c8                            | (MOV r32, r/m32) = 8B /r
shl edx,cl                                    # 001dh  | 2   | d3 e2                            | (SHL r/m32, CL) = D3 /4
movzx eax,dl                                  # 001fh  | 3   | 0f b6 c2                         | (MOVZX r32, r/m8) = 0F B6 /r
ret                                           # 0022h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# byte ones(W8 w, uint i0, uint i1)::located://lib/bits?ones#onesヽ(W8,32u,32u)
# 0x44,0x2b,0xc2,0x41,0xff,0xc0,0x41,0x8b,0xc8,0x48,0xb8,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xc4,0xe2,0xf0,0xf5,0xc0,0x8b,0xca,0x48,0xd3,0xe0,0x0f,0xb6,0xc0,0xc3
# EntryAddress  :7ffd292ac1d0h
# TargetAddress :7ffd2adebe70h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
sub r8d,edx                                   # 0000h  | 3   | 44 2b c2                         | (SUB r32, r/m32) = 2B /r
inc r8d                                       # 0003h  | 3   | 41 ff c0                         | (INC r/m32) = FF /0
mov ecx,r8d                                   # 0006h  | 3   | 41 8b c8                         | (MOV r32, r/m32) = 8B /r
mov rax,0ffffffffffffffffh                    # 0009h  | 10  | 48 b8 ff ff ff ff ff ff ff ff    | (MOV r64, imm64) = REX.W B8 +ro io
bzhi rax,rax,rcx                              # 0013h  | 5   | c4 e2 f0 f5 c0                   | (BZHI r64a, r/m64, r64b) = VEX.LZ.0F38.W1 F5 /r
mov ecx,edx                                   # 0018h  | 2   | 8b ca                            | (MOV r32, r/m32) = 8B /r
shl rax,cl                                    # 001ah  | 3   | 48 d3 e0                         | (SHL r/m64, CL) = REX.W D3 /4
movzx eax,al                                  # 001dh  | 3   | 0f b6 c0                         | (MOVZX r32, r/m8) = 0F B6 /r
ret                                           # 0020h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# ushort ones(W16 w, byte i0, byte i1)::located://lib/bits?ones#onesヽ(W16,8u,8u)
# 0x41,0x0f,0xb6,0xc8,0x0f,0xb6,0xc2,0x2b,0xc8,0xff,0xc1,0x0f,0xb6,0xc9,0xba,0xff,0xff,0x00,0x00,0xc4,0xe2,0x70,0xf5,0xca,0x0f,0xb7,0xd1,0x8b,0xc8,0xd3,0xe2,0x0f,0xb7,0xc2,0xc3
# EntryAddress  :7ffd292ac1b8h
# TargetAddress :7ffd2adebdc0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movzx ecx,r8b                                 # 0000h  | 4   | 41 0f b6 c8                      | (MOVZX r32, r/m8) = 0F B6 /r
movzx eax,dl                                  # 0004h  | 3   | 0f b6 c2                         | (MOVZX r32, r/m8) = 0F B6 /r
sub ecx,eax                                   # 0007h  | 2   | 2b c8                            | (SUB r32, r/m32) = 2B /r
inc ecx                                       # 0009h  | 2   | ff c1                            | (INC r/m32) = FF /0
movzx ecx,cl                                  # 000bh  | 3   | 0f b6 c9                         | (MOVZX r32, r/m8) = 0F B6 /r
mov edx,0ffffh                                # 000eh  | 5   | ba ff ff 00 00                   | (MOV r32, imm32) = B8 +rd id
bzhi ecx,edx,ecx                              # 0013h  | 5   | c4 e2 70 f5 ca                   | (BZHI r32a, r/m32, r32b) = VEX.LZ.0F38.W0 F5 /r
movzx edx,cx                                  # 0018h  | 3   | 0f b7 d1                         | (MOVZX r32, r/m16) = 0F B7 /r
mov ecx,eax                                   # 001bh  | 2   | 8b c8                            | (MOV r32, r/m32) = 8B /r
shl edx,cl                                    # 001dh  | 2   | d3 e2                            | (SHL r/m32, CL) = D3 /4
movzx eax,dx                                  # 001fh  | 3   | 0f b7 c2                         | (MOVZX r32, r/m16) = 0F B7 /r
ret                                           # 0022h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# ushort ones(W16 w, uint i0, uint i1)::located://lib/bits?ones#onesヽ(W16,32u,32u)
# 0x44,0x2b,0xc2,0x41,0xff,0xc0,0x41,0x8b,0xc8,0x48,0xb8,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xc4,0xe2,0xf0,0xf5,0xc0,0x8b,0xca,0x48,0xd3,0xe0,0x0f,0xb7,0xc0,0xc3
# EntryAddress  :7ffd292ac1d8h
# TargetAddress :7ffd2adebeb0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
sub r8d,edx                                   # 0000h  | 3   | 44 2b c2                         | (SUB r32, r/m32) = 2B /r
inc r8d                                       # 0003h  | 3   | 41 ff c0                         | (INC r/m32) = FF /0
mov ecx,r8d                                   # 0006h  | 3   | 41 8b c8                         | (MOV r32, r/m32) = 8B /r
mov rax,0ffffffffffffffffh                    # 0009h  | 10  | 48 b8 ff ff ff ff ff ff ff ff    | (MOV r64, imm64) = REX.W B8 +ro io
bzhi rax,rax,rcx                              # 0013h  | 5   | c4 e2 f0 f5 c0                   | (BZHI r64a, r/m64, r64b) = VEX.LZ.0F38.W1 F5 /r
mov ecx,edx                                   # 0018h  | 2   | 8b ca                            | (MOV r32, r/m32) = 8B /r
shl rax,cl                                    # 001ah  | 3   | 48 d3 e0                         | (SHL r/m64, CL) = REX.W D3 /4
movzx eax,ax                                  # 001dh  | 3   | 0f b7 c0                         | (MOVZX r32, r/m16) = 0F B7 /r
ret                                           # 0020h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# uint ones(W32 w, byte i0, byte i1)::located://lib/bits?ones#onesヽ(W32,8u,8u)
# 0x41,0x0f,0xb6,0xc8,0x0f,0xb6,0xc2,0x2b,0xc8,0xff,0xc1,0x0f,0xb6,0xc9,0xba,0xff,0xff,0xff,0xff,0xc4,0xe2,0x70,0xf5,0xd2,0x8b,0xc8,0xd3,0xe2,0x8b,0xc2,0xc3
# EntryAddress  :7ffd292ac1c0h
# TargetAddress :7ffd2adebe00h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movzx ecx,r8b                                 # 0000h  | 4   | 41 0f b6 c8                      | (MOVZX r32, r/m8) = 0F B6 /r
movzx eax,dl                                  # 0004h  | 3   | 0f b6 c2                         | (MOVZX r32, r/m8) = 0F B6 /r
sub ecx,eax                                   # 0007h  | 2   | 2b c8                            | (SUB r32, r/m32) = 2B /r
inc ecx                                       # 0009h  | 2   | ff c1                            | (INC r/m32) = FF /0
movzx ecx,cl                                  # 000bh  | 3   | 0f b6 c9                         | (MOVZX r32, r/m8) = 0F B6 /r
mov edx,0ffffffffh                            # 000eh  | 5   | ba ff ff ff ff                   | (MOV r32, imm32) = B8 +rd id
bzhi edx,edx,ecx                              # 0013h  | 5   | c4 e2 70 f5 d2                   | (BZHI r32a, r/m32, r32b) = VEX.LZ.0F38.W0 F5 /r
mov ecx,eax                                   # 0018h  | 2   | 8b c8                            | (MOV r32, r/m32) = 8B /r
shl edx,cl                                    # 001ah  | 2   | d3 e2                            | (SHL r/m32, CL) = D3 /4
mov eax,edx                                   # 001ch  | 2   | 8b c2                            | (MOV r32, r/m32) = 8B /r
ret                                           # 001eh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# uint ones(W32 w, uint i0, uint i1)::located://lib/bits?ones#onesヽ(W32,32u,32u)
# 0x44,0x2b,0xc2,0x41,0xff,0xc0,0x41,0x8b,0xc8,0x48,0xb8,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xc4,0xe2,0xf0,0xf5,0xc0,0x8b,0xca,0x48,0xd3,0xe0,0xc3
# EntryAddress  :7ffd292ac1e0h
# TargetAddress :7ffd2adebef0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
sub r8d,edx                                   # 0000h  | 3   | 44 2b c2                         | (SUB r32, r/m32) = 2B /r
inc r8d                                       # 0003h  | 3   | 41 ff c0                         | (INC r/m32) = FF /0
mov ecx,r8d                                   # 0006h  | 3   | 41 8b c8                         | (MOV r32, r/m32) = 8B /r
mov rax,0ffffffffffffffffh                    # 0009h  | 10  | 48 b8 ff ff ff ff ff ff ff ff    | (MOV r64, imm64) = REX.W B8 +ro io
bzhi rax,rax,rcx                              # 0013h  | 5   | c4 e2 f0 f5 c0                   | (BZHI r64a, r/m64, r64b) = VEX.LZ.0F38.W1 F5 /r
mov ecx,edx                                   # 0018h  | 2   | 8b ca                            | (MOV r32, r/m32) = 8B /r
shl rax,cl                                    # 001ah  | 3   | 48 d3 e0                         | (SHL r/m64, CL) = REX.W D3 /4
ret                                           # 001dh  | 1   | c3                               | (RET) = C3


# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# ulong ones(W64 w, byte i0, byte i1)::located://lib/bits?ones#onesヽ(W64,8u,8u)
# 0x41,0x0f,0xb6,0xc8,0x0f,0xb6,0xc2,0x2b,0xc8,0xff,0xc1,0x0f,0xb6,0xc9,0x48,0xba,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xc4,0xe2,0xf0,0xf5,0xd2,0x8b,0xc8,0x48,0xd3,0xe2,0x48,0x8b,0xc2,0xc3
# EntryAddress  :7ffd292ac1c8h
# TargetAddress :7ffd2adebe30h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movzx ecx,r8b                                 # 0000h  | 4   | 41 0f b6 c8                      | (MOVZX r32, r/m8) = 0F B6 /r
movzx eax,dl                                  # 0004h  | 3   | 0f b6 c2                         | (MOVZX r32, r/m8) = 0F B6 /r
sub ecx,eax                                   # 0007h  | 2   | 2b c8                            | (SUB r32, r/m32) = 2B /r
inc ecx                                       # 0009h  | 2   | ff c1                            | (INC r/m32) = FF /0
movzx ecx,cl                                  # 000bh  | 3   | 0f b6 c9                         | (MOVZX r32, r/m8) = 0F B6 /r
mov rdx,0ffffffffffffffffh                    # 000eh  | 10  | 48 ba ff ff ff ff ff ff ff ff    | (MOV r64, imm64) = REX.W B8 +ro io
bzhi rdx,rdx,rcx                              # 0018h  | 5   | c4 e2 f0 f5 d2                   | (BZHI r64a, r/m64, r64b) = VEX.LZ.0F38.W1 F5 /r
mov ecx,eax                                   # 001dh  | 2   | 8b c8                            | (MOV r32, r/m32) = 8B /r
shl rdx,cl                                    # 001fh  | 3   | 48 d3 e2                         | (SHL r/m64, CL) = REX.W D3 /4
mov rax,rdx                                   # 0022h  | 3   | 48 8b c2                         | (MOV r64, r/m64) = REX.W 8B /r
ret                                           # 0025h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# ulong ones(W64 w, uint i0, uint i1)::located://lib/bits?ones#onesヽ(W64,32u,32u)
# 0x44,0x2b,0xc2,0x41,0xff,0xc0,0x41,0x8b,0xc8,0x48,0xb8,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xc4,0xe2,0xf0,0xf5,0xc0,0x8b,0xca,0x48,0xd3,0xe0,0xc3
# EntryAddress  :7ffd292ac1e8h
# TargetAddress :7ffd2adebf20h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
sub r8d,edx                                   # 0000h  | 3   | 44 2b c2                         | (SUB r32, r/m32) = 2B /r
inc r8d                                       # 0003h  | 3   | 41 ff c0                         | (INC r/m32) = FF /0
mov ecx,r8d                                   # 0006h  | 3   | 41 8b c8                         | (MOV r32, r/m32) = 8B /r
mov rax,0ffffffffffffffffh                    # 0009h  | 10  | 48 b8 ff ff ff ff ff ff ff ff    | (MOV r64, imm64) = REX.W B8 +ro io
bzhi rax,rax,rcx                              # 0013h  | 5   | c4 e2 f0 f5 c0                   | (BZHI r64a, r/m64, r64b) = VEX.LZ.0F38.W1 F5 /r
mov ecx,edx                                   # 0018h  | 2   | 8b ca                            | (MOV r32, r/m32) = 8B /r
shl rax,cl                                    # 001ah  | 3   | 48 d3 e0                         | (SHL r/m64, CL) = REX.W D3 /4
ret                                           # 001dh  | 1   | c3                               | (RET) = C3
