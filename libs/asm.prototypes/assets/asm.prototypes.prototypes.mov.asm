# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov2x8u(byte* a, byte* b)::located://asm.prototypes/prototypes.mov?mov2x8u#mov2x8uヽ(8u~ptr,8u~ptr)
# 0x0f,0xb6,0x02,0x88,0x01,0x0f,0xb6,0x42,0x01,0x88,0x41,0x01,0x0f,0xb6,0x42,0x02,0x88,0x41,0x02,0x0f,0xb6,0x42,0x03,0x88,0x41,0x03,0x0f,0xb6,0x42,0x04,0x88,0x41,0x04,0x0f,0xb6,0x42,0x05,0x88,0x41,0x05,0x0f,0xb6,0x42,0x06,0x88,0x41,0x06,0x0f,0xb6,0x42,0x07,0x88,0x41,0x07,0xc3
# EntryAddress  :7ffb703e9a18h
# TargetAddress :7ffb723a72b0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movzx eax,byte ptr [rdx]                      # 0000h  | 3   | 0f b6 02                         | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],al                                  # 0003h  | 2   | 88 01                            | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+1]                    # 0005h  | 4   | 0f b6 42 01                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+1],al                                # 0009h  | 3   | 88 41 01                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+2]                    # 000ch  | 4   | 0f b6 42 02                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+2],al                                # 0010h  | 3   | 88 41 02                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+3]                    # 0013h  | 4   | 0f b6 42 03                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+3],al                                # 0017h  | 3   | 88 41 03                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+4]                    # 001ah  | 4   | 0f b6 42 04                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+4],al                                # 001eh  | 3   | 88 41 04                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+5]                    # 0021h  | 4   | 0f b6 42 05                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+5],al                                # 0025h  | 3   | 88 41 05                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+6]                    # 0028h  | 4   | 0f b6 42 06                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+6],al                                # 002ch  | 3   | 88 41 06                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+7]                    # 002fh  | 4   | 0f b6 42 07                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+7],al                                # 0033h  | 3   | 88 41 07                         | (MOV r/m8, r8) = 88 /r
ret                                           # 0036h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov2x16u(ushort* a, ushort* b)::located://asm.prototypes/prototypes.mov?mov2x16u#mov2x16uヽ(16u~ptr,16u~ptr)
# 0x0f,0xb7,0x02,0x66,0x89,0x01,0x0f,0xb7,0x42,0x02,0x66,0x89,0x41,0x02,0x0f,0xb7,0x42,0x04,0x66,0x89,0x41,0x04,0x0f,0xb7,0x42,0x06,0x66,0x89,0x41,0x06,0x0f,0xb7,0x42,0x08,0x66,0x89,0x41,0x08,0x0f,0xb7,0x42,0x0a,0x66,0x89,0x41,0x0a,0x0f,0xb7,0x42,0x0c,0x66,0x89,0x41,0x0c,0x0f,0xb7,0x42,0x0e,0x66,0x89,0x41,0x0e,0xc3
# EntryAddress  :7ffb703e9a20h
# TargetAddress :7ffb723a7300h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movzx eax,word ptr [rdx]                      # 0000h  | 3   | 0f b7 02                         | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],ax                                  # 0003h  | 3   | 66 89 01                         | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+2]                    # 0006h  | 4   | 0f b7 42 02                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+2],ax                                # 000ah  | 4   | 66 89 41 02                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+4]                    # 000eh  | 4   | 0f b7 42 04                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+4],ax                                # 0012h  | 4   | 66 89 41 04                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+6]                    # 0016h  | 4   | 0f b7 42 06                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+6],ax                                # 001ah  | 4   | 66 89 41 06                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+8]                    # 001eh  | 4   | 0f b7 42 08                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+8],ax                                # 0022h  | 4   | 66 89 41 08                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+0ah]                  # 0026h  | 4   | 0f b7 42 0a                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+0ah],ax                              # 002ah  | 4   | 66 89 41 0a                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+0ch]                  # 002eh  | 4   | 0f b7 42 0c                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+0ch],ax                              # 0032h  | 4   | 66 89 41 0c                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+0eh]                  # 0036h  | 4   | 0f b7 42 0e                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+0eh],ax                              # 003ah  | 4   | 66 89 41 0e                      | (MOV r/m16, r16) = 89 /r
ret                                           # 003eh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov2x32u(uint* a, uint* b)::located://asm.prototypes/prototypes.mov?mov2x32u#mov2x32uヽ(32u~ptr,32u~ptr)
# 0x8b,0x02,0x89,0x01,0x8b,0x42,0x04,0x89,0x41,0x04,0x8b,0x42,0x08,0x89,0x41,0x08,0x8b,0x42,0x0c,0x89,0x41,0x0c,0x8b,0x42,0x10,0x89,0x41,0x10,0x8b,0x42,0x14,0x89,0x41,0x14,0x8b,0x42,0x18,0x89,0x41,0x18,0x8b,0x42,0x1c,0x89,0x41,0x1c,0xc3
# EntryAddress  :7ffb703e9a28h
# TargetAddress :7ffb723a7350h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,[rdx]                                 # 0000h  | 2   | 8b 02                            | (MOV r32, r/m32) = 8B /r
mov [rcx],eax                                 # 0002h  | 2   | 89 01                            | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+4]                               # 0004h  | 3   | 8b 42 04                         | (MOV r32, r/m32) = 8B /r
mov [rcx+4],eax                               # 0007h  | 3   | 89 41 04                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+8]                               # 000ah  | 3   | 8b 42 08                         | (MOV r32, r/m32) = 8B /r
mov [rcx+8],eax                               # 000dh  | 3   | 89 41 08                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+0ch]                             # 0010h  | 3   | 8b 42 0c                         | (MOV r32, r/m32) = 8B /r
mov [rcx+0ch],eax                             # 0013h  | 3   | 89 41 0c                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+10h]                             # 0016h  | 3   | 8b 42 10                         | (MOV r32, r/m32) = 8B /r
mov [rcx+10h],eax                             # 0019h  | 3   | 89 41 10                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+14h]                             # 001ch  | 3   | 8b 42 14                         | (MOV r32, r/m32) = 8B /r
mov [rcx+14h],eax                             # 001fh  | 3   | 89 41 14                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+18h]                             # 0022h  | 3   | 8b 42 18                         | (MOV r32, r/m32) = 8B /r
mov [rcx+18h],eax                             # 0025h  | 3   | 89 41 18                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+1ch]                             # 0028h  | 3   | 8b 42 1c                         | (MOV r32, r/m32) = 8B /r
mov [rcx+1ch],eax                             # 002bh  | 3   | 89 41 1c                         | (MOV r/m32, r32) = 89 /r
ret                                           # 002eh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov2x64u(ulong* a, ulong* b)::located://asm.prototypes/prototypes.mov?mov2x64u#mov2x64uヽ(64u~ptr,64u~ptr)
# 0x48,0x8b,0x02,0x48,0x89,0x01,0x48,0x8b,0x42,0x08,0x48,0x89,0x41,0x08,0x48,0x8b,0x42,0x10,0x48,0x89,0x41,0x10,0x48,0x8b,0x42,0x18,0x48,0x89,0x41,0x18,0x48,0x8b,0x42,0x20,0x48,0x89,0x41,0x20,0x48,0x8b,0x42,0x28,0x48,0x89,0x41,0x28,0x48,0x8b,0x42,0x30,0x48,0x89,0x41,0x30,0x48,0x8b,0x42,0x38,0x48,0x89,0x41,0x38,0xc3
# EntryAddress  :7ffb703e9a30h
# TargetAddress :7ffb723a7390h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx],rax                                 # 0003h  | 3   | 48 89 01                         | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+8]                               # 0006h  | 4   | 48 8b 42 08                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+8],rax                               # 000ah  | 4   | 48 89 41 08                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+10h]                             # 000eh  | 4   | 48 8b 42 10                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+10h],rax                             # 0012h  | 4   | 48 89 41 10                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+18h]                             # 0016h  | 4   | 48 8b 42 18                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+18h],rax                             # 001ah  | 4   | 48 89 41 18                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+20h]                             # 001eh  | 4   | 48 8b 42 20                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+20h],rax                             # 0022h  | 4   | 48 89 41 20                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+28h]                             # 0026h  | 4   | 48 8b 42 28                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+28h],rax                             # 002ah  | 4   | 48 89 41 28                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+30h]                             # 002eh  | 4   | 48 8b 42 30                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+30h],rax                             # 0032h  | 4   | 48 89 41 30                      | (MOV r/m64, r64) = REX.W 89 /r
mov rax,[rdx+38h]                             # 0036h  | 4   | 48 8b 42 38                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rcx+38h],rax                             # 003ah  | 4   | 48 89 41 38                      | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 003eh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov2x128u(ByteBlock16* a, ByteBlock16* b)::located://asm.prototypes/prototypes.mov?mov2x128u#mov2x128uヽ(ByteBlock16~ptr,ByteBlock16~ptr)
# 0xc5,0xf8,0x77,0xc5,0xf9,0x10,0x02,0xc5,0xf9,0x11,0x01,0xc5,0xf9,0x10,0x42,0x10,0xc5,0xf9,0x11,0x41,0x10,0xc5,0xf9,0x10,0x42,0x20,0xc5,0xf9,0x11,0x41,0x20,0xc5,0xf9,0x10,0x42,0x30,0xc5,0xf9,0x11,0x41,0x30,0xc5,0xf9,0x10,0x42,0x40,0xc5,0xf9,0x11,0x41,0x40,0xc5,0xf9,0x10,0x42,0x50,0xc5,0xf9,0x11,0x41,0x50,0xc5,0xf9,0x10,0x42,0x60,0xc5,0xf9,0x11,0x41,0x60,0xc5,0xf9,0x10,0x42,0x70,0xc5,0xf9,0x11,0x41,0x70,0xc3
# EntryAddress  :7ffb703e9a38h
# TargetAddress :7ffb723a73e0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
vmovupd xmm0,[rdx]                            # 0003h  | 4   | c5 f9 10 02                      | (VMOVUPD xmm1, xmm2/m128) = VEX.128.66.0F.WIG 10 /r
vmovupd [rcx],xmm0                            # 0007h  | 4   | c5 f9 11 01                      | (VMOVUPD xmm2/m128, xmm1) = VEX.128.66.0F.WIG 11 /r
vmovupd xmm0,[rdx+10h]                        # 000bh  | 5   | c5 f9 10 42 10                   | (VMOVUPD xmm1, xmm2/m128) = VEX.128.66.0F.WIG 10 /r
vmovupd [rcx+10h],xmm0                        # 0010h  | 5   | c5 f9 11 41 10                   | (VMOVUPD xmm2/m128, xmm1) = VEX.128.66.0F.WIG 11 /r
vmovupd xmm0,[rdx+20h]                        # 0015h  | 5   | c5 f9 10 42 20                   | (VMOVUPD xmm1, xmm2/m128) = VEX.128.66.0F.WIG 10 /r
vmovupd [rcx+20h],xmm0                        # 001ah  | 5   | c5 f9 11 41 20                   | (VMOVUPD xmm2/m128, xmm1) = VEX.128.66.0F.WIG 11 /r
vmovupd xmm0,[rdx+30h]                        # 001fh  | 5   | c5 f9 10 42 30                   | (VMOVUPD xmm1, xmm2/m128) = VEX.128.66.0F.WIG 10 /r
vmovupd [rcx+30h],xmm0                        # 0024h  | 5   | c5 f9 11 41 30                   | (VMOVUPD xmm2/m128, xmm1) = VEX.128.66.0F.WIG 11 /r
vmovupd xmm0,[rdx+40h]                        # 0029h  | 5   | c5 f9 10 42 40                   | (VMOVUPD xmm1, xmm2/m128) = VEX.128.66.0F.WIG 10 /r
vmovupd [rcx+40h],xmm0                        # 002eh  | 5   | c5 f9 11 41 40                   | (VMOVUPD xmm2/m128, xmm1) = VEX.128.66.0F.WIG 11 /r
vmovupd xmm0,[rdx+50h]                        # 0033h  | 5   | c5 f9 10 42 50                   | (VMOVUPD xmm1, xmm2/m128) = VEX.128.66.0F.WIG 10 /r
vmovupd [rcx+50h],xmm0                        # 0038h  | 5   | c5 f9 11 41 50                   | (VMOVUPD xmm2/m128, xmm1) = VEX.128.66.0F.WIG 11 /r
vmovupd xmm0,[rdx+60h]                        # 003dh  | 5   | c5 f9 10 42 60                   | (VMOVUPD xmm1, xmm2/m128) = VEX.128.66.0F.WIG 10 /r
vmovupd [rcx+60h],xmm0                        # 0042h  | 5   | c5 f9 11 41 60                   | (VMOVUPD xmm2/m128, xmm1) = VEX.128.66.0F.WIG 11 /r
vmovupd xmm0,[rdx+70h]                        # 0047h  | 5   | c5 f9 10 42 70                   | (VMOVUPD xmm1, xmm2/m128) = VEX.128.66.0F.WIG 10 /r
vmovupd [rcx+70h],xmm0                        # 004ch  | 5   | c5 f9 11 41 70                   | (VMOVUPD xmm2/m128, xmm1) = VEX.128.66.0F.WIG 11 /r
ret                                           # 0051h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov2x256u(ByteBlock32* a, ByteBlock32* b)::located://asm.prototypes/prototypes.mov?mov2x256u#mov2x256uヽ(ByteBlock32~ptr,ByteBlock32~ptr)
# 0xc5,0xf8,0x77,0xc5,0xfa,0x6f,0x02,0xc5,0xfa,0x7f,0x01,0xc5,0xfa,0x6f,0x42,0x10,0xc5,0xfa,0x7f,0x41,0x10,0xc5,0xfa,0x6f,0x42,0x20,0xc5,0xfa,0x7f,0x41,0x20,0xc5,0xfa,0x6f,0x42,0x30,0xc5,0xfa,0x7f,0x41,0x30,0xc5,0xfa,0x6f,0x42,0x40,0xc5,0xfa,0x7f,0x41,0x40,0xc5,0xfa,0x6f,0x42,0x50,0xc5,0xfa,0x7f,0x41,0x50,0xc5,0xfa,0x6f,0x42,0x60,0xc5,0xfa,0x7f,0x41,0x60,0xc5,0xfa,0x6f,0x42,0x70,0xc5,0xfa,0x7f,0x41,0x70,0xc5,0xfa,0x6f,0x82,0x80,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x81,0x80,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x82,0x90,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x81,0x90,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x82,0xa0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x81,0xa0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x82,0xb0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x81,0xb0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x82,0xc0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x81,0xc0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x82,0xd0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x81,0xd0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x82,0xe0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x81,0xe0,0x00,0x00,0x00,0xc5,0xfa,0x6f,0x82,0xf0,0x00,0x00,0x00,0xc5,0xfa,0x7f,0x81,0xf0,0x00,0x00,0x00,0xc3
# EntryAddress  :7ffb703e9a40h
# TargetAddress :7ffb723a7460h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
vmovdqu xmm0,xmmword ptr [rdx]                # 0003h  | 4   | c5 fa 6f 02                      | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx],xmm0                # 0007h  | 4   | c5 fa 7f 01                      | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+10h]            # 000bh  | 5   | c5 fa 6f 42 10                   | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+10h],xmm0            # 0010h  | 5   | c5 fa 7f 41 10                   | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+20h]            # 0015h  | 5   | c5 fa 6f 42 20                   | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+20h],xmm0            # 001ah  | 5   | c5 fa 7f 41 20                   | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+30h]            # 001fh  | 5   | c5 fa 6f 42 30                   | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+30h],xmm0            # 0024h  | 5   | c5 fa 7f 41 30                   | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+40h]            # 0029h  | 5   | c5 fa 6f 42 40                   | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+40h],xmm0            # 002eh  | 5   | c5 fa 7f 41 40                   | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+50h]            # 0033h  | 5   | c5 fa 6f 42 50                   | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+50h],xmm0            # 0038h  | 5   | c5 fa 7f 41 50                   | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+60h]            # 003dh  | 5   | c5 fa 6f 42 60                   | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+60h],xmm0            # 0042h  | 5   | c5 fa 7f 41 60                   | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+70h]            # 0047h  | 5   | c5 fa 6f 42 70                   | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+70h],xmm0            # 004ch  | 5   | c5 fa 7f 41 70                   | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+80h]            # 0051h  | 8   | c5 fa 6f 82 80 00 00 00          | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+80h],xmm0            # 0059h  | 8   | c5 fa 7f 81 80 00 00 00          | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+90h]            # 0061h  | 8   | c5 fa 6f 82 90 00 00 00          | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+90h],xmm0            # 0069h  | 8   | c5 fa 7f 81 90 00 00 00          | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+0a0h]           # 0071h  | 8   | c5 fa 6f 82 a0 00 00 00          | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+0a0h],xmm0           # 0079h  | 8   | c5 fa 7f 81 a0 00 00 00          | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+0b0h]           # 0081h  | 8   | c5 fa 6f 82 b0 00 00 00          | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+0b0h],xmm0           # 0089h  | 8   | c5 fa 7f 81 b0 00 00 00          | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+0c0h]           # 0091h  | 8   | c5 fa 6f 82 c0 00 00 00          | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+0c0h],xmm0           # 0099h  | 8   | c5 fa 7f 81 c0 00 00 00          | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+0d0h]           # 00a1h  | 8   | c5 fa 6f 82 d0 00 00 00          | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+0d0h],xmm0           # 00a9h  | 8   | c5 fa 7f 81 d0 00 00 00          | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+0e0h]           # 00b1h  | 8   | c5 fa 6f 82 e0 00 00 00          | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+0e0h],xmm0           # 00b9h  | 8   | c5 fa 7f 81 e0 00 00 00          | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
vmovdqu xmm0,xmmword ptr [rdx+0f0h]           # 00c1h  | 8   | c5 fa 6f 82 f0 00 00 00          | (VMOVDQU xmm1, xmm2/m128) = VEX.128.F3.0F.WIG 6F /r
vmovdqu xmmword ptr [rcx+0f0h],xmm0           # 00c9h  | 8   | c5 fa 7f 81 f0 00 00 00          | (VMOVDQU xmm2/m128, xmm1) = VEX.128.F3.0F.WIG 7F /r
ret                                           # 00d1h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov2x512u(ByteBlock512* a, ByteBlock512* b)::located://asm.prototypes/prototypes.mov?mov2x512u#mov2x512uヽ(ByteBlock512~ptr,ByteBlock512~ptr)
# 0x57,0x56,0x48,0x8b,0xf1,0x48,0x8b,0xfa,0x48,0x8b,0xce,0x48,0x8b,0xd7,0x41,0xb8,0x00,0x02,0x00,0x00,0xe8,0xb7,0x2d,0x7e,0x5c,0x48,0x8d,0x97,0x00,0x02,0x00,0x00,0x48,0x8d,0x8e,0x00,0x02,0x00,0x00,0x41,0xb8,0x00,0x02,0x00,0x00,0xe8,0x9e,0x2d,0x7e,0x5c,0x48,0x8d,0x97,0x00,0x04,0x00,0x00,0x48,0x8d,0x8e,0x00,0x04,0x00,0x00,0x41,0xb8,0x00,0x02,0x00,0x00,0xe8,0x85,0x2d,0x7e,0x5c,0x48,0x8d,0x97,0x00,0x06,0x00,0x00,0x48,0x8d,0x8e,0x00,0x06,0x00,0x00,0x41,0xb8,0x00,0x02,0x00,0x00,0xe8,0x6c,0x2d,0x7e,0x5c,0x48,0x8d,0x97,0x00,0x08,0x00,0x00,0x48,0x8d,0x8e,0x00,0x08,0x00,0x00,0x41,0xb8,0x00,0x02,0x00,0x00,0xe8,0x53,0x2d,0x7e,0x5c,0x48,0x8d,0x97,0x00,0x0a,0x00,0x00,0x48,0x8d,0x8e,0x00,0x0a,0x00,0x00,0x41,0xb8,0x00,0x02,0x00,0x00,0xe8,0x3a,0x2d,0x7e,0x5c,0x48,0x8d,0x97,0x00,0x0c,0x00,0x00,0x48,0x8d,0x8e,0x00,0x0c,0x00,0x00,0x41,0xb8,0x00,0x02,0x00,0x00,0xe8,0x21,0x2d,0x7e,0x5c,0x48,0x8d,0x97,0x00,0x0e,0x00,0x00,0x48,0x8d,0x8e,0x00,0x0e,0x00,0x00,0x41,0xb8,0x00,0x02,0x00,0x00,0xe8,0x08,0x2d,0x7e,0x5c,0x90,0x5e,0x5f,0xc3
# EntryAddress  :7ffb703e9a48h
# TargetAddress :7ffb723a7570h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
push rdi                                      # 0000h  | 1   | 57                               | (PUSH r64) = 50 +ro
push rsi                                      # 0001h  | 1   | 56                               | (PUSH r64) = 50 +ro
mov rsi,rcx                                   # 0002h  | 3   | 48 8b f1                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdi,rdx                                   # 0005h  | 3   | 48 8b fa                         | (MOV r64, r/m64) = REX.W 8B /r
mov rcx,rsi                                   # 0008h  | 3   | 48 8b ce                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,rdi                                   # 000bh  | 3   | 48 8b d7                         | (MOV r64, r/m64) = REX.W 8B /r
mov r8d,200h                                  # 000eh  | 6   | 41 b8 00 02 00 00                | (MOV r32, imm32) = B8 +rd id
call 7ffbceb8a340h                            # 0014h  | 5   | e8 b7 2d 7e 5c                   | (CALL rel32) = E8 cd
lea rdx,[rdi+200h]                            # 0019h  | 7   | 48 8d 97 00 02 00 00             | (LEA r64, m) = REX.W 8D /r
lea rcx,[rsi+200h]                            # 0020h  | 7   | 48 8d 8e 00 02 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8d,200h                                  # 0027h  | 6   | 41 b8 00 02 00 00                | (MOV r32, imm32) = B8 +rd id
call 7ffbceb8a340h                            # 002dh  | 5   | e8 9e 2d 7e 5c                   | (CALL rel32) = E8 cd
lea rdx,[rdi+400h]                            # 0032h  | 7   | 48 8d 97 00 04 00 00             | (LEA r64, m) = REX.W 8D /r
lea rcx,[rsi+400h]                            # 0039h  | 7   | 48 8d 8e 00 04 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8d,200h                                  # 0040h  | 6   | 41 b8 00 02 00 00                | (MOV r32, imm32) = B8 +rd id
call 7ffbceb8a340h                            # 0046h  | 5   | e8 85 2d 7e 5c                   | (CALL rel32) = E8 cd
lea rdx,[rdi+600h]                            # 004bh  | 7   | 48 8d 97 00 06 00 00             | (LEA r64, m) = REX.W 8D /r
lea rcx,[rsi+600h]                            # 0052h  | 7   | 48 8d 8e 00 06 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8d,200h                                  # 0059h  | 6   | 41 b8 00 02 00 00                | (MOV r32, imm32) = B8 +rd id
call 7ffbceb8a340h                            # 005fh  | 5   | e8 6c 2d 7e 5c                   | (CALL rel32) = E8 cd
lea rdx,[rdi+800h]                            # 0064h  | 7   | 48 8d 97 00 08 00 00             | (LEA r64, m) = REX.W 8D /r
lea rcx,[rsi+800h]                            # 006bh  | 7   | 48 8d 8e 00 08 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8d,200h                                  # 0072h  | 6   | 41 b8 00 02 00 00                | (MOV r32, imm32) = B8 +rd id
call 7ffbceb8a340h                            # 0078h  | 5   | e8 53 2d 7e 5c                   | (CALL rel32) = E8 cd
lea rdx,[rdi+0a00h]                           # 007dh  | 7   | 48 8d 97 00 0a 00 00             | (LEA r64, m) = REX.W 8D /r
lea rcx,[rsi+0a00h]                           # 0084h  | 7   | 48 8d 8e 00 0a 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8d,200h                                  # 008bh  | 6   | 41 b8 00 02 00 00                | (MOV r32, imm32) = B8 +rd id
call 7ffbceb8a340h                            # 0091h  | 5   | e8 3a 2d 7e 5c                   | (CALL rel32) = E8 cd
lea rdx,[rdi+0c00h]                           # 0096h  | 7   | 48 8d 97 00 0c 00 00             | (LEA r64, m) = REX.W 8D /r
lea rcx,[rsi+0c00h]                           # 009dh  | 7   | 48 8d 8e 00 0c 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8d,200h                                  # 00a4h  | 6   | 41 b8 00 02 00 00                | (MOV r32, imm32) = B8 +rd id
call 7ffbceb8a340h                            # 00aah  | 5   | e8 21 2d 7e 5c                   | (CALL rel32) = E8 cd
lea rdx,[rdi+0e00h]                           # 00afh  | 7   | 48 8d 97 00 0e 00 00             | (LEA r64, m) = REX.W 8D /r
lea rcx,[rsi+0e00h]                           # 00b6h  | 7   | 48 8d 8e 00 0e 00 00             | (LEA r64, m) = REX.W 8D /r
mov r8d,200h                                  # 00bdh  | 6   | 41 b8 00 02 00 00                | (MOV r32, imm32) = B8 +rd id
call 7ffbceb8a340h                            # 00c3h  | 5   | e8 08 2d 7e 5c                   | (CALL rel32) = E8 cd
nop                                           # 00c8h  | 1   | 90                               | (NOP) = 90
pop rsi                                       # 00c9h  | 1   | 5e                               | (POP r64) = 58 +ro
pop rdi                                       # 00cah  | 1   | 5f                               | (POP r64) = 58 +ro
ret                                           # 00cbh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[byte](uint i, byte* pSrc, uint j, byte* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[8u](32u,8u~ptr,32u,8u~ptr)
# 0x41,0x8b,0xc0,0x41,0x0f,0xb6,0x04,0x01,0x8b,0xc9,0x88,0x04,0x0a,0xc3
# EntryAddress  :7ffb723a33e0h
# TargetAddress :7ffb723a7650h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,r8d                                   # 0000h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
movzx eax,byte ptr [r9+rax]                   # 0003h  | 5   | 41 0f b6 04 01                   | (MOVZX r32, r/m8) = 0F B6 /r
mov ecx,ecx                                   # 0008h  | 2   | 8b c9                            | (MOV r32, r/m32) = 8B /r
mov [rdx+rcx],al                              # 000ah  | 3   | 88 04 0a                         | (MOV r/m8, r8) = 88 /r
ret                                           # 000dh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[sbyte](uint i, sbyte* pSrc, uint j, sbyte* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[8i](32u,8i~ptr,32u,8i~ptr)
# 0x41,0x8b,0xc0,0x49,0x0f,0xbe,0x04,0x01,0x8b,0xc9,0x88,0x04,0x0a,0xc3
# EntryAddress  :7ffb723a33f0h
# TargetAddress :7ffb723a7670h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,r8d                                   # 0000h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
movsx rax,byte ptr [r9+rax]                   # 0003h  | 5   | 49 0f be 04 01                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov ecx,ecx                                   # 0008h  | 2   | 8b c9                            | (MOV r32, r/m32) = 8B /r
mov [rdx+rcx],al                              # 000ah  | 3   | 88 04 0a                         | (MOV r/m8, r8) = 88 /r
ret                                           # 000dh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[ushort](uint i, ushort* pSrc, uint j, ushort* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[16u](32u,16u~ptr,32u,16u~ptr)
# 0x41,0x8b,0xc0,0x41,0x0f,0xb7,0x04,0x41,0x8b,0xc9,0x66,0x89,0x04,0x4a,0xc3
# EntryAddress  :7ffb723a3400h
# TargetAddress :7ffb723a7690h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,r8d                                   # 0000h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
movzx eax,word ptr [r9+rax*2]                 # 0003h  | 5   | 41 0f b7 04 41                   | (MOVZX r32, r/m16) = 0F B7 /r
mov ecx,ecx                                   # 0008h  | 2   | 8b c9                            | (MOV r32, r/m32) = 8B /r
mov [rdx+rcx*2],ax                            # 000ah  | 4   | 66 89 04 4a                      | (MOV r/m16, r16) = 89 /r
ret                                           # 000eh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[short](uint i, short* pSrc, uint j, short* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[16i](32u,16i~ptr,32u,16i~ptr)
# 0x41,0x8b,0xc0,0x49,0x0f,0xbf,0x04,0x41,0x8b,0xc9,0x66,0x89,0x04,0x4a,0xc3
# EntryAddress  :7ffb723a76b0h
# TargetAddress :7ffb723a7ac0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,r8d                                   # 0000h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
movsx rax,word ptr [r9+rax*2]                 # 0003h  | 5   | 49 0f bf 04 41                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov ecx,ecx                                   # 0008h  | 2   | 8b c9                            | (MOV r32, r/m32) = 8B /r
mov [rdx+rcx*2],ax                            # 000ah  | 4   | 66 89 04 4a                      | (MOV r/m16, r16) = 89 /r
ret                                           # 000eh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[uint](uint i, uint* pSrc, uint j, uint* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32u](32u,32u~ptr,32u,32u~ptr)
# 0x41,0x8b,0xc0,0x41,0x8b,0x04,0x81,0x8b,0xc9,0x89,0x04,0x8a,0xc3
# EntryAddress  :7ffb723a76c0h
# TargetAddress :7ffb723a7ae0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,r8d                                   # 0000h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
mov eax,[r9+rax*4]                            # 0003h  | 4   | 41 8b 04 81                      | (MOV r32, r/m32) = 8B /r
mov ecx,ecx                                   # 0007h  | 2   | 8b c9                            | (MOV r32, r/m32) = 8B /r
mov [rdx+rcx*4],eax                           # 0009h  | 3   | 89 04 8a                         | (MOV r/m32, r32) = 89 /r
ret                                           # 000ch  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[int](uint i, int* pSrc, uint j, int* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32i](32u,32i~ptr,32u,32i~ptr)
# 0x41,0x8b,0xc0,0x41,0x8b,0x04,0x81,0x8b,0xc9,0x89,0x04,0x8a,0xc3
# EntryAddress  :7ffb723a76d0h
# TargetAddress :7ffb723a7b00h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,r8d                                   # 0000h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
mov eax,[r9+rax*4]                            # 0003h  | 4   | 41 8b 04 81                      | (MOV r32, r/m32) = 8B /r
mov ecx,ecx                                   # 0007h  | 2   | 8b c9                            | (MOV r32, r/m32) = 8B /r
mov [rdx+rcx*4],eax                           # 0009h  | 3   | 89 04 8a                         | (MOV r/m32, r32) = 89 /r
ret                                           # 000ch  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[ulong](uint i, ulong* pSrc, uint j, ulong* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64u](32u,64u~ptr,32u,64u~ptr)
# 0x41,0x8b,0xc0,0x49,0x8b,0x04,0xc1,0x8b,0xc9,0x48,0x89,0x04,0xca,0xc3
# EntryAddress  :7ffb723a76e0h
# TargetAddress :7ffb723a7b20h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,r8d                                   # 0000h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
mov rax,[r9+rax*8]                            # 0003h  | 4   | 49 8b 04 c1                      | (MOV r64, r/m64) = REX.W 8B /r
mov ecx,ecx                                   # 0007h  | 2   | 8b c9                            | (MOV r32, r/m32) = 8B /r
mov [rdx+rcx*8],rax                           # 0009h  | 4   | 48 89 04 ca                      | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 000dh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[long](uint i, long* pSrc, uint j, long* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64i](32u,64i~ptr,32u,64i~ptr)
# 0x41,0x8b,0xc0,0x49,0x8b,0x04,0xc1,0x8b,0xc9,0x48,0x89,0x04,0xca,0xc3
# EntryAddress  :7ffb723a76f0h
# TargetAddress :7ffb723a7b40h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,r8d                                   # 0000h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
mov rax,[r9+rax*8]                            # 0003h  | 4   | 49 8b 04 c1                      | (MOV r64, r/m64) = REX.W 8B /r
mov ecx,ecx                                   # 0007h  | 2   | 8b c9                            | (MOV r32, r/m32) = 8B /r
mov [rdx+rcx*8],rax                           # 0009h  | 4   | 48 89 04 ca                      | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 000dh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[float](uint i, float* pSrc, uint j, float* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32f](32u,32f~ptr,32u,32f~ptr)
# 0xc5,0xf8,0x77,0x41,0x8b,0xc0,0xc4,0xc1,0x7a,0x10,0x04,0x81,0x8b,0xc1,0xc5,0xfa,0x11,0x04,0x82,0xc3
# EntryAddress  :7ffb723a7700h
# TargetAddress :7ffb723a7b60h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov eax,r8d                                   # 0003h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
vmovss xmm0,dword ptr [r9+rax*4]              # 0006h  | 6   | c4 c1 7a 10 04 81                | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
mov eax,ecx                                   # 000ch  | 2   | 8b c1                            | (MOV r32, r/m32) = 8B /r
vmovss dword ptr [rdx+rax*4],xmm0             # 000eh  | 5   | c5 fa 11 04 82                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
ret                                           # 0013h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[double](uint i, double* pSrc, uint j, double* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64f](32u,64f~ptr,32u,64f~ptr)
# 0xc5,0xf8,0x77,0x41,0x8b,0xc0,0xc4,0xc1,0x7b,0x10,0x04,0xc1,0x8b,0xc1,0xc5,0xfb,0x11,0x04,0xc2,0xc3
# EntryAddress  :7ffb723a7710h
# TargetAddress :7ffb723a7b90h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov eax,r8d                                   # 0003h  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
vmovsd xmm0,qword ptr [r9+rax*8]              # 0006h  | 6   | c4 c1 7b 10 04 c1                | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
mov eax,ecx                                   # 000ch  | 2   | 8b c1                            | (MOV r32, r/m32) = 8B /r
vmovsd qword ptr [rdx+rax*8],xmm0             # 000eh  | 5   | c5 fb 11 04 c2                   | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
ret                                           # 0013h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[byte](uint i, ReadOnlySpan[byte] src, uint j, byte* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[8u](32u,rspan8u,32u,8u~ptr)
# 0x48,0x8b,0x02,0x48,0x63,0xd1,0x0f,0xb6,0x04,0x10,0x41,0x8b,0xd0,0x41,0x88,0x04,0x11,0xc3
# EntryAddress  :7ffb723a7720h
# TargetAddress :7ffb723a7bc0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0003h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
movzx eax,byte ptr [rax+rdx]                  # 0006h  | 4   | 0f b6 04 10                      | (MOVZX r32, r/m8) = 0F B6 /r
mov edx,r8d                                   # 000ah  | 3   | 41 8b d0                         | (MOV r32, r/m32) = 8B /r
mov [r9+rdx],al                               # 000dh  | 4   | 41 88 04 11                      | (MOV r/m8, r8) = 88 /r
ret                                           # 0011h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[sbyte](uint i, ReadOnlySpan[sbyte] src, uint j, sbyte* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[8i](32u,rspan8i,32u,8i~ptr)
# 0x48,0x8b,0x02,0x48,0x63,0xd1,0x48,0x0f,0xbe,0x04,0x10,0x41,0x8b,0xd0,0x41,0x88,0x04,0x11,0xc3
# EntryAddress  :7ffb723a7740h
# TargetAddress :7ffb723a7bf0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0003h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
movsx rax,byte ptr [rax+rdx]                  # 0006h  | 5   | 48 0f be 04 10                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov edx,r8d                                   # 000bh  | 3   | 41 8b d0                         | (MOV r32, r/m32) = 8B /r
mov [r9+rdx],al                               # 000eh  | 4   | 41 88 04 11                      | (MOV r/m8, r8) = 88 /r
ret                                           # 0012h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[ushort](uint i, ReadOnlySpan[ushort] src, uint j, ushort* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[16u](32u,rspan16u,32u,16u~ptr)
# 0x48,0x8b,0x02,0x48,0x63,0xd1,0x0f,0xb7,0x04,0x50,0x41,0x8b,0xd0,0x66,0x41,0x89,0x04,0x51,0xc3
# EntryAddress  :7ffb723a7770h
# TargetAddress :7ffb723a7c20h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0003h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
movzx eax,word ptr [rax+rdx*2]                # 0006h  | 4   | 0f b7 04 50                      | (MOVZX r32, r/m16) = 0F B7 /r
mov edx,r8d                                   # 000ah  | 3   | 41 8b d0                         | (MOV r32, r/m32) = 8B /r
mov [r9+rdx*2],ax                             # 000dh  | 5   | 66 41 89 04 51                   | (MOV r/m16, r16) = 89 /r
ret                                           # 0012h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[short](uint i, ReadOnlySpan[short] src, uint j, short* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[16i](32u,rspan16i,32u,16i~ptr)
# 0x48,0x8b,0x02,0x48,0x63,0xd1,0x48,0x0f,0xbf,0x04,0x50,0x41,0x8b,0xd0,0x66,0x41,0x89,0x04,0x51,0xc3
# EntryAddress  :7ffb723a77a0h
# TargetAddress :7ffb723a7c50h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0003h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
movsx rax,word ptr [rax+rdx*2]                # 0006h  | 5   | 48 0f bf 04 50                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov edx,r8d                                   # 000bh  | 3   | 41 8b d0                         | (MOV r32, r/m32) = 8B /r
mov [r9+rdx*2],ax                             # 000eh  | 5   | 66 41 89 04 51                   | (MOV r/m16, r16) = 89 /r
ret                                           # 0013h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[uint](uint i, ReadOnlySpan[uint] src, uint j, uint* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32u](32u,rspan32u,32u,32u~ptr)
# 0x48,0x8b,0x02,0x48,0x63,0xd1,0x8b,0x04,0x90,0x41,0x8b,0xd0,0x41,0x89,0x04,0x91,0xc3
# EntryAddress  :7ffb723a77d0h
# TargetAddress :7ffb723a7c80h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0003h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
mov eax,[rax+rdx*4]                           # 0006h  | 3   | 8b 04 90                         | (MOV r32, r/m32) = 8B /r
mov edx,r8d                                   # 0009h  | 3   | 41 8b d0                         | (MOV r32, r/m32) = 8B /r
mov [r9+rdx*4],eax                            # 000ch  | 4   | 41 89 04 91                      | (MOV r/m32, r32) = 89 /r
ret                                           # 0010h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[int](uint i, ReadOnlySpan[int] src, uint j, int* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32i](32u,rspan32i,32u,32i~ptr)
# 0x48,0x8b,0x02,0x48,0x63,0xd1,0x8b,0x04,0x90,0x41,0x8b,0xd0,0x41,0x89,0x04,0x91,0xc3
# EntryAddress  :7ffb723a7800h
# TargetAddress :7ffb723a7cb0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0003h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
mov eax,[rax+rdx*4]                           # 0006h  | 3   | 8b 04 90                         | (MOV r32, r/m32) = 8B /r
mov edx,r8d                                   # 0009h  | 3   | 41 8b d0                         | (MOV r32, r/m32) = 8B /r
mov [r9+rdx*4],eax                            # 000ch  | 4   | 41 89 04 91                      | (MOV r/m32, r32) = 89 /r
ret                                           # 0010h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[ulong](uint i, ReadOnlySpan[ulong] src, uint j, ulong* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64u](32u,rspan64u,32u,64u~ptr)
# 0x48,0x8b,0x02,0x48,0x63,0xd1,0x48,0x8b,0x04,0xd0,0x41,0x8b,0xd0,0x49,0x89,0x04,0xd1,0xc3
# EntryAddress  :7ffb723a7830h
# TargetAddress :7ffb723a7ce0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0003h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
mov rax,[rax+rdx*8]                           # 0006h  | 4   | 48 8b 04 d0                      | (MOV r64, r/m64) = REX.W 8B /r
mov edx,r8d                                   # 000ah  | 3   | 41 8b d0                         | (MOV r32, r/m32) = 8B /r
mov [r9+rdx*8],rax                            # 000dh  | 4   | 49 89 04 d1                      | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 0011h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[long](uint i, ReadOnlySpan[long] src, uint j, long* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64i](32u,rspan64i,32u,64i~ptr)
# 0x48,0x8b,0x02,0x48,0x63,0xd1,0x48,0x8b,0x04,0xd0,0x41,0x8b,0xd0,0x49,0x89,0x04,0xd1,0xc3
# EntryAddress  :7ffb723a7860h
# TargetAddress :7ffb723a7d10h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0003h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
mov rax,[rax+rdx*8]                           # 0006h  | 4   | 48 8b 04 d0                      | (MOV r64, r/m64) = REX.W 8B /r
mov edx,r8d                                   # 000ah  | 3   | 41 8b d0                         | (MOV r32, r/m32) = 8B /r
mov [r9+rdx*8],rax                            # 000dh  | 4   | 49 89 04 d1                      | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 0011h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[float](uint i, ReadOnlySpan[float] src, uint j, float* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32f](32u,rspan32f,32u,32f~ptr)
# 0xc5,0xf8,0x77,0x48,0x8b,0x02,0x48,0x63,0xd1,0xc5,0xfa,0x10,0x04,0x90,0x41,0x8b,0xc0,0xc4,0xc1,0x7a,0x11,0x04,0x81,0xc3
# EntryAddress  :7ffb723a7890h
# TargetAddress :7ffb723a7d40h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov rax,[rdx]                                 # 0003h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0006h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
vmovss xmm0,dword ptr [rax+rdx*4]             # 0009h  | 5   | c5 fa 10 04 90                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
mov eax,r8d                                   # 000eh  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
vmovss dword ptr [r9+rax*4],xmm0              # 0011h  | 6   | c4 c1 7a 11 04 81                | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
ret                                           # 0017h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[double](uint i, ReadOnlySpan[double] src, uint j, double* pDst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64f](32u,rspan64f,32u,64f~ptr)
# 0xc5,0xf8,0x77,0x48,0x8b,0x02,0x48,0x63,0xd1,0xc5,0xfb,0x10,0x04,0xd0,0x41,0x8b,0xc0,0xc4,0xc1,0x7b,0x11,0x04,0xc1,0xc3
# EntryAddress  :7ffb723a78c0h
# TargetAddress :7ffb723a7d70h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov rax,[rdx]                                 # 0003h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rdx,ecx                                # 0006h  | 3   | 48 63 d1                         | (MOVSXD r64, r/m32) = REX.W 63 /r
vmovsd xmm0,qword ptr [rax+rdx*8]             # 0009h  | 5   | c5 fb 10 04 d0                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
mov eax,r8d                                   # 000eh  | 3   | 41 8b c0                         | (MOV r32, r/m32) = 8B /r
vmovsd qword ptr [r9+rax*8],xmm0              # 0011h  | 6   | c4 c1 7b 11 04 c1                | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
ret                                           # 0017h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[byte](uint i, ReadOnlySpan[byte] src, uint j, Span[byte] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[8u](32u,rspan8u,32u,span8u)
# 0x49,0x8b,0x01,0x4d,0x63,0xc0,0x49,0x03,0xc0,0x48,0x8b,0x12,0x48,0x63,0xc9,0x0f,0xb6,0x14,0x0a,0x88,0x10,0xc3
# EntryAddress  :7ffb723a78f0h
# TargetAddress :7ffb723a7da0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[r9]                                  # 0000h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0003h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
add rax,r8                                    # 0006h  | 3   | 49 03 c0                         | (ADD r64, r/m64) = REX.W 03 /r
mov rdx,[rdx]                                 # 0009h  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 000ch  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
movzx edx,byte ptr [rdx+rcx]                  # 000fh  | 4   | 0f b6 14 0a                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rax],dl                                  # 0013h  | 2   | 88 10                            | (MOV r/m8, r8) = 88 /r
ret                                           # 0015h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[sbyte](uint i, ReadOnlySpan[sbyte] src, uint j, Span[sbyte] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[8i](32u,rspan8i,32u,span8i)
# 0x49,0x8b,0x01,0x4d,0x63,0xc0,0x49,0x03,0xc0,0x48,0x8b,0x12,0x48,0x63,0xc9,0x48,0x0f,0xbe,0x14,0x0a,0x88,0x10,0xc3
# EntryAddress  :7ffb723a7940h
# TargetAddress :7ffb723a7dd0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[r9]                                  # 0000h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0003h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
add rax,r8                                    # 0006h  | 3   | 49 03 c0                         | (ADD r64, r/m64) = REX.W 03 /r
mov rdx,[rdx]                                 # 0009h  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 000ch  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
movsx rdx,byte ptr [rdx+rcx]                  # 000fh  | 5   | 48 0f be 14 0a                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rax],dl                                  # 0014h  | 2   | 88 10                            | (MOV r/m8, r8) = 88 /r
ret                                           # 0016h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[ushort](uint i, ReadOnlySpan[ushort] src, uint j, Span[ushort] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[16u](32u,rspan16u,32u,span16u)
# 0x49,0x8b,0x01,0x4d,0x63,0xc0,0x4a,0x8d,0x04,0x40,0x48,0x8b,0x12,0x48,0x63,0xc9,0x0f,0xb7,0x14,0x4a,0x66,0x89,0x10,0xc3
# EntryAddress  :7ffb723a7970h
# TargetAddress :7ffb723a7e00h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[r9]                                  # 0000h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0003h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
lea rax,[rax+r8*2]                            # 0006h  | 4   | 4a 8d 04 40                      | (LEA r64, m) = REX.W 8D /r
mov rdx,[rdx]                                 # 000ah  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 000dh  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
movzx edx,word ptr [rdx+rcx*2]                # 0010h  | 4   | 0f b7 14 4a                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rax],dx                                  # 0014h  | 3   | 66 89 10                         | (MOV r/m16, r16) = 89 /r
ret                                           # 0017h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[short](uint i, ReadOnlySpan[short] src, uint j, Span[short] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[16i](32u,rspan16i,32u,span16i)
# 0x49,0x8b,0x01,0x4d,0x63,0xc0,0x4a,0x8d,0x04,0x40,0x48,0x8b,0x12,0x48,0x63,0xc9,0x48,0x0f,0xbf,0x14,0x4a,0x66,0x89,0x10,0xc3
# EntryAddress  :7ffb723a79a0h
# TargetAddress :7ffb723a7e30h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[r9]                                  # 0000h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0003h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
lea rax,[rax+r8*2]                            # 0006h  | 4   | 4a 8d 04 40                      | (LEA r64, m) = REX.W 8D /r
mov rdx,[rdx]                                 # 000ah  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 000dh  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
movsx rdx,word ptr [rdx+rcx*2]                # 0010h  | 5   | 48 0f bf 14 4a                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rax],dx                                  # 0015h  | 3   | 66 89 10                         | (MOV r/m16, r16) = 89 /r
ret                                           # 0018h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[uint](uint i, ReadOnlySpan[uint] src, uint j, Span[uint] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32u](32u,rspan32u,32u,span32u)
# 0x49,0x8b,0x01,0x4d,0x63,0xc0,0x4a,0x8d,0x04,0x80,0x48,0x8b,0x12,0x48,0x63,0xc9,0x8b,0x14,0x8a,0x89,0x10,0xc3
# EntryAddress  :7ffb723a79d0h
# TargetAddress :7ffb723a7e60h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[r9]                                  # 0000h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0003h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
lea rax,[rax+r8*4]                            # 0006h  | 4   | 4a 8d 04 80                      | (LEA r64, m) = REX.W 8D /r
mov rdx,[rdx]                                 # 000ah  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 000dh  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
mov edx,[rdx+rcx*4]                           # 0010h  | 3   | 8b 14 8a                         | (MOV r32, r/m32) = 8B /r
mov [rax],edx                                 # 0013h  | 2   | 89 10                            | (MOV r/m32, r32) = 89 /r
ret                                           # 0015h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[int](uint i, ReadOnlySpan[int] src, uint j, Span[int] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32i](32u,rspan32i,32u,span32i)
# 0x49,0x8b,0x01,0x4d,0x63,0xc0,0x4a,0x8d,0x04,0x80,0x48,0x8b,0x12,0x48,0x63,0xc9,0x8b,0x14,0x8a,0x89,0x10,0xc3
# EntryAddress  :7ffb723a7a00h
# TargetAddress :7ffb723a7e90h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[r9]                                  # 0000h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0003h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
lea rax,[rax+r8*4]                            # 0006h  | 4   | 4a 8d 04 80                      | (LEA r64, m) = REX.W 8D /r
mov rdx,[rdx]                                 # 000ah  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 000dh  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
mov edx,[rdx+rcx*4]                           # 0010h  | 3   | 8b 14 8a                         | (MOV r32, r/m32) = 8B /r
mov [rax],edx                                 # 0013h  | 2   | 89 10                            | (MOV r/m32, r32) = 89 /r
ret                                           # 0015h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[ulong](uint i, ReadOnlySpan[ulong] src, uint j, Span[ulong] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64u](32u,rspan64u,32u,span64u)
# 0x49,0x8b,0x01,0x4d,0x63,0xc0,0x4a,0x8d,0x04,0xc0,0x48,0x8b,0x12,0x48,0x63,0xc9,0x48,0x8b,0x14,0xca,0x48,0x89,0x10,0xc3
# EntryAddress  :7ffb723a7a30h
# TargetAddress :7ffb723a7ec0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[r9]                                  # 0000h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0003h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
lea rax,[rax+r8*8]                            # 0006h  | 4   | 4a 8d 04 c0                      | (LEA r64, m) = REX.W 8D /r
mov rdx,[rdx]                                 # 000ah  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 000dh  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
mov rdx,[rdx+rcx*8]                           # 0010h  | 4   | 48 8b 14 ca                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rax],rdx                                 # 0014h  | 3   | 48 89 10                         | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 0017h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[long](uint i, ReadOnlySpan[long] src, uint j, Span[long] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64i](32u,rspan64i,32u,span64i)
# 0x49,0x8b,0x01,0x4d,0x63,0xc0,0x4a,0x8d,0x04,0xc0,0x48,0x8b,0x12,0x48,0x63,0xc9,0x48,0x8b,0x14,0xca,0x48,0x89,0x10,0xc3
# EntryAddress  :7ffb723a7a60h
# TargetAddress :7ffb723a7ef0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[r9]                                  # 0000h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0003h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
lea rax,[rax+r8*8]                            # 0006h  | 4   | 4a 8d 04 c0                      | (LEA r64, m) = REX.W 8D /r
mov rdx,[rdx]                                 # 000ah  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 000dh  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
mov rdx,[rdx+rcx*8]                           # 0010h  | 4   | 48 8b 14 ca                      | (MOV r64, r/m64) = REX.W 8B /r
mov [rax],rdx                                 # 0014h  | 3   | 48 89 10                         | (MOV r/m64, r64) = REX.W 89 /r
ret                                           # 0017h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[float](uint i, ReadOnlySpan[float] src, uint j, Span[float] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[32f](32u,rspan32f,32u,span32f)
# 0xc5,0xf8,0x77,0x49,0x8b,0x01,0x4d,0x63,0xc0,0x4a,0x8d,0x04,0x80,0x48,0x8b,0x12,0x48,0x63,0xc9,0xc5,0xfa,0x10,0x04,0x8a,0xc5,0xfa,0x11,0x00,0xc3
# EntryAddress  :7ffb723a7a90h
# TargetAddress :7ffb723a8320h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov rax,[r9]                                  # 0003h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0006h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
lea rax,[rax+r8*4]                            # 0009h  | 4   | 4a 8d 04 80                      | (LEA r64, m) = REX.W 8D /r
mov rdx,[rdx]                                 # 000dh  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 0010h  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
vmovss xmm0,dword ptr [rdx+rcx*4]             # 0013h  | 5   | c5 fa 10 04 8a                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rax],xmm0                   # 0018h  | 4   | c5 fa 11 00                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
ret                                           # 001ch  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov[double](uint i, ReadOnlySpan[double] src, uint j, Span[double] dst)::located://asm.prototypes/prototypes.mov?mov#movヽg[64f](32u,rspan64f,32u,span64f)
# 0xc5,0xf8,0x77,0x49,0x8b,0x01,0x4d,0x63,0xc0,0x4a,0x8d,0x04,0xc0,0x48,0x8b,0x12,0x48,0x63,0xc9,0xc5,0xfb,0x10,0x04,0xca,0xc5,0xfb,0x11,0x00,0xc3
# EntryAddress  :7ffb723a7f38h
# TargetAddress :7ffb723a8350h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov rax,[r9]                                  # 0003h  | 3   | 49 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd r8,r8d                                 # 0006h  | 3   | 4d 63 c0                         | (MOVSXD r64, r/m32) = REX.W 63 /r
lea rax,[rax+r8*8]                            # 0009h  | 4   | 4a 8d 04 c0                      | (LEA r64, m) = REX.W 8D /r
mov rdx,[rdx]                                 # 000dh  | 3   | 48 8b 12                         | (MOV r64, r/m64) = REX.W 8B /r
movsxd rcx,ecx                                # 0010h  | 3   | 48 63 c9                         | (MOVSXD r64, r/m32) = REX.W 63 /r
vmovsd xmm0,qword ptr [rdx+rcx*8]             # 0013h  | 5   | c5 fb 10 04 ca                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rax],xmm0                   # 0018h  | 4   | c5 fb 11 00                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
ret                                           # 001ch  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8a[byte](byte* pSrc, byte* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[8u](8u~ptr,8u~ptr)
# 0x0f,0xb6,0x42,0x10,0x88,0x01,0x0f,0xb6,0x42,0x11,0x88,0x41,0x01,0x0f,0xb6,0x42,0x12,0x88,0x41,0x02,0x0f,0xb6,0x42,0x13,0x88,0x41,0x03,0x0f,0xb6,0x42,0x14,0x88,0x41,0x04,0x0f,0xb6,0x42,0x15,0x88,0x41,0x05,0x0f,0xb6,0x42,0x16,0x88,0x41,0x06,0x0f,0xb6,0x42,0x17,0x88,0x41,0x07,0xc3
# EntryAddress  :7ffb723a7f68h
# TargetAddress :7ffb723a8380h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movzx eax,byte ptr [rdx+10h]                  # 0000h  | 4   | 0f b6 42 10                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],al                                  # 0004h  | 2   | 88 01                            | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+11h]                  # 0006h  | 4   | 0f b6 42 11                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+1],al                                # 000ah  | 3   | 88 41 01                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+12h]                  # 000dh  | 4   | 0f b6 42 12                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+2],al                                # 0011h  | 3   | 88 41 02                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+13h]                  # 0014h  | 4   | 0f b6 42 13                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+3],al                                # 0018h  | 3   | 88 41 03                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+14h]                  # 001bh  | 4   | 0f b6 42 14                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+4],al                                # 001fh  | 3   | 88 41 04                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+15h]                  # 0022h  | 4   | 0f b6 42 15                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+5],al                                # 0026h  | 3   | 88 41 05                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+16h]                  # 0029h  | 4   | 0f b6 42 16                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+6],al                                # 002dh  | 3   | 88 41 06                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rdx+17h]                  # 0030h  | 4   | 0f b6 42 17                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx+7],al                                # 0034h  | 3   | 88 41 07                         | (MOV r/m8, r8) = 88 /r
ret                                           # 0037h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8a[sbyte](sbyte* pSrc, sbyte* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[8i](8i~ptr,8i~ptr)
# 0x48,0x0f,0xbe,0x42,0x10,0x88,0x01,0x48,0x0f,0xbe,0x42,0x11,0x88,0x41,0x01,0x48,0x0f,0xbe,0x42,0x12,0x88,0x41,0x02,0x48,0x0f,0xbe,0x42,0x13,0x88,0x41,0x03,0x48,0x0f,0xbe,0x42,0x14,0x88,0x41,0x04,0x48,0x0f,0xbe,0x42,0x15,0x88,0x41,0x05,0x48,0x0f,0xbe,0x42,0x16,0x88,0x41,0x06,0x48,0x0f,0xbe,0x42,0x17,0x88,0x41,0x07,0xc3
# EntryAddress  :7ffb723a7f88h
# TargetAddress :7ffb723a83d0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movsx rax,byte ptr [rdx+10h]                  # 0000h  | 5   | 48 0f be 42 10                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx],al                                  # 0005h  | 2   | 88 01                            | (MOV r/m8, r8) = 88 /r
movsx rax,byte ptr [rdx+11h]                  # 0007h  | 5   | 48 0f be 42 11                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx+1],al                                # 000ch  | 3   | 88 41 01                         | (MOV r/m8, r8) = 88 /r
movsx rax,byte ptr [rdx+12h]                  # 000fh  | 5   | 48 0f be 42 12                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx+2],al                                # 0014h  | 3   | 88 41 02                         | (MOV r/m8, r8) = 88 /r
movsx rax,byte ptr [rdx+13h]                  # 0017h  | 5   | 48 0f be 42 13                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx+3],al                                # 001ch  | 3   | 88 41 03                         | (MOV r/m8, r8) = 88 /r
movsx rax,byte ptr [rdx+14h]                  # 001fh  | 5   | 48 0f be 42 14                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx+4],al                                # 0024h  | 3   | 88 41 04                         | (MOV r/m8, r8) = 88 /r
movsx rax,byte ptr [rdx+15h]                  # 0027h  | 5   | 48 0f be 42 15                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx+5],al                                # 002ch  | 3   | 88 41 05                         | (MOV r/m8, r8) = 88 /r
movsx rax,byte ptr [rdx+16h]                  # 002fh  | 5   | 48 0f be 42 16                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx+6],al                                # 0034h  | 3   | 88 41 06                         | (MOV r/m8, r8) = 88 /r
movsx rax,byte ptr [rdx+17h]                  # 0037h  | 5   | 48 0f be 42 17                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx+7],al                                # 003ch  | 3   | 88 41 07                         | (MOV r/m8, r8) = 88 /r
ret                                           # 003fh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8a[ushort](ushort* pSrc, ushort* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[16u](16u~ptr,16u~ptr)
# 0x0f,0xb7,0x42,0x20,0x66,0x89,0x01,0x0f,0xb7,0x42,0x22,0x66,0x89,0x41,0x02,0x0f,0xb7,0x42,0x24,0x66,0x89,0x41,0x04,0x0f,0xb7,0x42,0x26,0x66,0x89,0x41,0x06,0x0f,0xb7,0x42,0x28,0x66,0x89,0x41,0x08,0x0f,0xb7,0x42,0x2a,0x66,0x89,0x41,0x0a,0x0f,0xb7,0x42,0x2c,0x66,0x89,0x41,0x0c,0x0f,0xb7,0x42,0x2e,0x66,0x89,0x41,0x0e,0xc3
# EntryAddress  :7ffb723a7f98h
# TargetAddress :7ffb723a8420h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movzx eax,word ptr [rdx+20h]                  # 0000h  | 4   | 0f b7 42 20                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],ax                                  # 0004h  | 3   | 66 89 01                         | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+22h]                  # 0007h  | 4   | 0f b7 42 22                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+2],ax                                # 000bh  | 4   | 66 89 41 02                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+24h]                  # 000fh  | 4   | 0f b7 42 24                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+4],ax                                # 0013h  | 4   | 66 89 41 04                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+26h]                  # 0017h  | 4   | 0f b7 42 26                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+6],ax                                # 001bh  | 4   | 66 89 41 06                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+28h]                  # 001fh  | 4   | 0f b7 42 28                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+8],ax                                # 0023h  | 4   | 66 89 41 08                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+2ah]                  # 0027h  | 4   | 0f b7 42 2a                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+0ah],ax                              # 002bh  | 4   | 66 89 41 0a                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+2ch]                  # 002fh  | 4   | 0f b7 42 2c                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+0ch],ax                              # 0033h  | 4   | 66 89 41 0c                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rdx+2eh]                  # 0037h  | 4   | 0f b7 42 2e                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx+0eh],ax                              # 003bh  | 4   | 66 89 41 0e                      | (MOV r/m16, r16) = 89 /r
ret                                           # 003fh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8a[short](short* pSrc, short* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[16i](16i~ptr,16i~ptr)
# 0x48,0x0f,0xbf,0x42,0x20,0x66,0x89,0x01,0x48,0x0f,0xbf,0x42,0x22,0x66,0x89,0x41,0x02,0x48,0x0f,0xbf,0x42,0x24,0x66,0x89,0x41,0x04,0x48,0x0f,0xbf,0x42,0x26,0x66,0x89,0x41,0x06,0x48,0x0f,0xbf,0x42,0x28,0x66,0x89,0x41,0x08,0x48,0x0f,0xbf,0x42,0x2a,0x66,0x89,0x41,0x0a,0x48,0x0f,0xbf,0x42,0x2c,0x66,0x89,0x41,0x0c,0x48,0x0f,0xbf,0x42,0x2e,0x66,0x89,0x41,0x0e,0xc3
# EntryAddress  :7ffb723a7fa8h
# TargetAddress :7ffb723a8470h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
movsx rax,word ptr [rdx+20h]                  # 0000h  | 5   | 48 0f bf 42 20                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx],ax                                  # 0005h  | 3   | 66 89 01                         | (MOV r/m16, r16) = 89 /r
movsx rax,word ptr [rdx+22h]                  # 0008h  | 5   | 48 0f bf 42 22                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx+2],ax                                # 000dh  | 4   | 66 89 41 02                      | (MOV r/m16, r16) = 89 /r
movsx rax,word ptr [rdx+24h]                  # 0011h  | 5   | 48 0f bf 42 24                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx+4],ax                                # 0016h  | 4   | 66 89 41 04                      | (MOV r/m16, r16) = 89 /r
movsx rax,word ptr [rdx+26h]                  # 001ah  | 5   | 48 0f bf 42 26                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx+6],ax                                # 001fh  | 4   | 66 89 41 06                      | (MOV r/m16, r16) = 89 /r
movsx rax,word ptr [rdx+28h]                  # 0023h  | 5   | 48 0f bf 42 28                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx+8],ax                                # 0028h  | 4   | 66 89 41 08                      | (MOV r/m16, r16) = 89 /r
movsx rax,word ptr [rdx+2ah]                  # 002ch  | 5   | 48 0f bf 42 2a                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx+0ah],ax                              # 0031h  | 4   | 66 89 41 0a                      | (MOV r/m16, r16) = 89 /r
movsx rax,word ptr [rdx+2ch]                  # 0035h  | 5   | 48 0f bf 42 2c                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx+0ch],ax                              # 003ah  | 4   | 66 89 41 0c                      | (MOV r/m16, r16) = 89 /r
movsx rax,word ptr [rdx+2eh]                  # 003eh  | 5   | 48 0f bf 42 2e                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx+0eh],ax                              # 0043h  | 4   | 66 89 41 0e                      | (MOV r/m16, r16) = 89 /r
ret                                           # 0047h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8a[uint](uint* pSrc, uint* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[32u](32u~ptr,32u~ptr)
# 0x8b,0x42,0x40,0x89,0x01,0x8b,0x42,0x44,0x89,0x41,0x04,0x8b,0x42,0x48,0x89,0x41,0x08,0x8b,0x42,0x4c,0x89,0x41,0x0c,0x8b,0x42,0x50,0x89,0x41,0x10,0x8b,0x42,0x54,0x89,0x41,0x14,0x8b,0x42,0x58,0x89,0x41,0x18,0x8b,0x42,0x5c,0x89,0x41,0x1c,0xc3
# EntryAddress  :7ffb723a7fb8h
# TargetAddress :7ffb723a84d0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,[rdx+40h]                             # 0000h  | 3   | 8b 42 40                         | (MOV r32, r/m32) = 8B /r
mov [rcx],eax                                 # 0003h  | 2   | 89 01                            | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+44h]                             # 0005h  | 3   | 8b 42 44                         | (MOV r32, r/m32) = 8B /r
mov [rcx+4],eax                               # 0008h  | 3   | 89 41 04                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+48h]                             # 000bh  | 3   | 8b 42 48                         | (MOV r32, r/m32) = 8B /r
mov [rcx+8],eax                               # 000eh  | 3   | 89 41 08                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+4ch]                             # 0011h  | 3   | 8b 42 4c                         | (MOV r32, r/m32) = 8B /r
mov [rcx+0ch],eax                             # 0014h  | 3   | 89 41 0c                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+50h]                             # 0017h  | 3   | 8b 42 50                         | (MOV r32, r/m32) = 8B /r
mov [rcx+10h],eax                             # 001ah  | 3   | 89 41 10                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+54h]                             # 001dh  | 3   | 8b 42 54                         | (MOV r32, r/m32) = 8B /r
mov [rcx+14h],eax                             # 0020h  | 3   | 89 41 14                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+58h]                             # 0023h  | 3   | 8b 42 58                         | (MOV r32, r/m32) = 8B /r
mov [rcx+18h],eax                             # 0026h  | 3   | 89 41 18                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+5ch]                             # 0029h  | 3   | 8b 42 5c                         | (MOV r32, r/m32) = 8B /r
mov [rcx+1ch],eax                             # 002ch  | 3   | 89 41 1c                         | (MOV r/m32, r32) = 89 /r
ret                                           # 002fh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8a[int](int* pSrc, int* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[32i](32i~ptr,32i~ptr)
# 0x8b,0x42,0x40,0x89,0x01,0x8b,0x42,0x44,0x89,0x41,0x04,0x8b,0x42,0x48,0x89,0x41,0x08,0x8b,0x42,0x4c,0x89,0x41,0x0c,0x8b,0x42,0x50,0x89,0x41,0x10,0x8b,0x42,0x54,0x89,0x41,0x14,0x8b,0x42,0x58,0x89,0x41,0x18,0x8b,0x42,0x5c,0x89,0x41,0x1c,0xc3
# EntryAddress  :7ffb723a7fc8h
# TargetAddress :7ffb723a8510h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov eax,[rdx+40h]                             # 0000h  | 3   | 8b 42 40                         | (MOV r32, r/m32) = 8B /r
mov [rcx],eax                                 # 0003h  | 2   | 89 01                            | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+44h]                             # 0005h  | 3   | 8b 42 44                         | (MOV r32, r/m32) = 8B /r
mov [rcx+4],eax                               # 0008h  | 3   | 89 41 04                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+48h]                             # 000bh  | 3   | 8b 42 48                         | (MOV r32, r/m32) = 8B /r
mov [rcx+8],eax                               # 000eh  | 3   | 89 41 08                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+4ch]                             # 0011h  | 3   | 8b 42 4c                         | (MOV r32, r/m32) = 8B /r
mov [rcx+0ch],eax                             # 0014h  | 3   | 89 41 0c                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+50h]                             # 0017h  | 3   | 8b 42 50                         | (MOV r32, r/m32) = 8B /r
mov [rcx+10h],eax                             # 001ah  | 3   | 89 41 10                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+54h]                             # 001dh  | 3   | 8b 42 54                         | (MOV r32, r/m32) = 8B /r
mov [rcx+14h],eax                             # 0020h  | 3   | 89 41 14                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+58h]                             # 0023h  | 3   | 8b 42 58                         | (MOV r32, r/m32) = 8B /r
mov [rcx+18h],eax                             # 0026h  | 3   | 89 41 18                         | (MOV r/m32, r32) = 89 /r
mov eax,[rdx+5ch]                             # 0029h  | 3   | 8b 42 5c                         | (MOV r32, r/m32) = 8B /r
mov [rcx+1ch],eax                             # 002ch  | 3   | 89 41 1c                         | (MOV r/m32, r32) = 89 /r
ret                                           # 002fh  | 1   | c3                               | (RET) = C3

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
# void mov8a[long](long* pSrc, long* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[64i](64i~ptr,64i~ptr)
# 0x48,0x8b,0x82,0x80,0x00,0x00,0x00,0x48,0x89,0x01,0x48,0x8b,0x82,0x88,0x00,0x00,0x00,0x48,0x89,0x41,0x08,0x48,0x8b,0x82,0x90,0x00,0x00,0x00,0x48,0x89,0x41,0x10,0x48,0x8b,0x82,0x98,0x00,0x00,0x00,0x48,0x89,0x41,0x18,0x48,0x8b,0x82,0xa0,0x00,0x00,0x00,0x48,0x89,0x41,0x20,0x48,0x8b,0x82,0xa8,0x00,0x00,0x00,0x48,0x89,0x41,0x28,0x48,0x8b,0x82,0xb0,0x00,0x00,0x00,0x48,0x89,0x41,0x30,0x48,0x8b,0x82,0xb8,0x00,0x00,0x00,0x48,0x89,0x41,0x38,0xc3
# EntryAddress  :7ffb723a7fe8h
# TargetAddress :7ffb723a85c0h
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
# void mov8a[float](float* pSrc, float* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[32f](32f~ptr,32f~ptr)
# 0xc5,0xf8,0x77,0xc5,0xfa,0x10,0x42,0x40,0xc5,0xfa,0x11,0x01,0xc5,0xfa,0x10,0x42,0x44,0xc5,0xfa,0x11,0x41,0x04,0xc5,0xfa,0x10,0x42,0x48,0xc5,0xfa,0x11,0x41,0x08,0xc5,0xfa,0x10,0x42,0x4c,0xc5,0xfa,0x11,0x41,0x0c,0xc5,0xfa,0x10,0x42,0x50,0xc5,0xfa,0x11,0x41,0x10,0xc5,0xfa,0x10,0x42,0x54,0xc5,0xfa,0x11,0x41,0x14,0xc5,0xfa,0x10,0x42,0x58,0xc5,0xfa,0x11,0x41,0x18,0xc5,0xfa,0x10,0x42,0x5c,0xc5,0xfa,0x11,0x41,0x1c,0xc3
# EntryAddress  :7ffb723a7ff8h
# TargetAddress :7ffb723a8630h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
vmovss xmm0,dword ptr [rdx+40h]               # 0003h  | 5   | c5 fa 10 42 40                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx],xmm0                   # 0008h  | 4   | c5 fa 11 01                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rdx+44h]               # 000ch  | 5   | c5 fa 10 42 44                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx+4],xmm0                 # 0011h  | 5   | c5 fa 11 41 04                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rdx+48h]               # 0016h  | 5   | c5 fa 10 42 48                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx+8],xmm0                 # 001bh  | 5   | c5 fa 11 41 08                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rdx+4ch]               # 0020h  | 5   | c5 fa 10 42 4c                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx+0ch],xmm0               # 0025h  | 5   | c5 fa 11 41 0c                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rdx+50h]               # 002ah  | 5   | c5 fa 10 42 50                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx+10h],xmm0               # 002fh  | 5   | c5 fa 11 41 10                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rdx+54h]               # 0034h  | 5   | c5 fa 10 42 54                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx+14h],xmm0               # 0039h  | 5   | c5 fa 11 41 14                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rdx+58h]               # 003eh  | 5   | c5 fa 10 42 58                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx+18h],xmm0               # 0043h  | 5   | c5 fa 11 41 18                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rdx+5ch]               # 0048h  | 5   | c5 fa 10 42 5c                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx+1ch],xmm0               # 004dh  | 5   | c5 fa 11 41 1c                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
ret                                           # 0052h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8a[double](double* pSrc, double* pDst)::located://asm.prototypes/prototypes.mov?mov8a#mov8aヽg[64f](64f~ptr,64f~ptr)
# 0xc5,0xf8,0x77,0xc5,0xfb,0x10,0x82,0x80,0x00,0x00,0x00,0xc5,0xfb,0x11,0x01,0xc5,0xfb,0x10,0x82,0x88,0x00,0x00,0x00,0xc5,0xfb,0x11,0x41,0x08,0xc5,0xfb,0x10,0x82,0x90,0x00,0x00,0x00,0xc5,0xfb,0x11,0x41,0x10,0xc5,0xfb,0x10,0x82,0x98,0x00,0x00,0x00,0xc5,0xfb,0x11,0x41,0x18,0xc5,0xfb,0x10,0x82,0xa0,0x00,0x00,0x00,0xc5,0xfb,0x11,0x41,0x20,0xc5,0xfb,0x10,0x82,0xa8,0x00,0x00,0x00,0xc5,0xfb,0x11,0x41,0x28,0xc5,0xfb,0x10,0x82,0xb0,0x00,0x00,0x00,0xc5,0xfb,0x11,0x41,0x30,0xc5,0xfb,0x10,0x82,0xb8,0x00,0x00,0x00,0xc5,0xfb,0x11,0x41,0x38,0xc3
# EntryAddress  :7ffb723a8008h
# TargetAddress :7ffb723a86b0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
vmovsd xmm0,qword ptr [rdx+80h]               # 0003h  | 8   | c5 fb 10 82 80 00 00 00          | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx],xmm0                   # 000bh  | 4   | c5 fb 11 01                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rdx+88h]               # 000fh  | 8   | c5 fb 10 82 88 00 00 00          | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx+8],xmm0                 # 0017h  | 5   | c5 fb 11 41 08                   | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rdx+90h]               # 001ch  | 8   | c5 fb 10 82 90 00 00 00          | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx+10h],xmm0               # 0024h  | 5   | c5 fb 11 41 10                   | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rdx+98h]               # 0029h  | 8   | c5 fb 10 82 98 00 00 00          | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx+18h],xmm0               # 0031h  | 5   | c5 fb 11 41 18                   | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rdx+0a0h]              # 0036h  | 8   | c5 fb 10 82 a0 00 00 00          | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx+20h],xmm0               # 003eh  | 5   | c5 fb 11 41 20                   | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rdx+0a8h]              # 0043h  | 8   | c5 fb 10 82 a8 00 00 00          | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx+28h],xmm0               # 004bh  | 5   | c5 fb 11 41 28                   | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rdx+0b0h]              # 0050h  | 8   | c5 fb 10 82 b0 00 00 00          | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx+30h],xmm0               # 0058h  | 5   | c5 fb 11 41 30                   | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rdx+0b8h]              # 005dh  | 8   | c5 fb 10 82 b8 00 00 00          | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx+38h],xmm0               # 0065h  | 5   | c5 fb 11 41 38                   | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
ret                                           # 006ah  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8b[byte](ReadOnlySpan[byte] src, byte* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[8u](rspan8u,8u~ptr)
# 0x48,0x8b,0x01,0x0f,0xb6,0x08,0x88,0x4a,0x10,0x0f,0xb6,0x48,0x01,0x88,0x4a,0x11,0x0f,0xb6,0x48,0x02,0x88,0x4a,0x12,0x0f,0xb6,0x48,0x03,0x88,0x4a,0x13,0x0f,0xb6,0x48,0x04,0x88,0x4a,0x14,0x0f,0xb6,0x48,0x05,0x88,0x4a,0x15,0x0f,0xb6,0x48,0x06,0x88,0x4a,0x16,0x0f,0xb6,0x40,0x07,0x88,0x42,0x17,0xc3
# EntryAddress  :7ffb723a8018h
# TargetAddress :7ffb723a8740h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rcx]                                 # 0000h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movzx ecx,byte ptr [rax]                      # 0003h  | 3   | 0f b6 08                         | (MOVZX r32, r/m8) = 0F B6 /r
mov [rdx+10h],cl                              # 0006h  | 3   | 88 4a 10                         | (MOV r/m8, r8) = 88 /r
movzx ecx,byte ptr [rax+1]                    # 0009h  | 4   | 0f b6 48 01                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rdx+11h],cl                              # 000dh  | 3   | 88 4a 11                         | (MOV r/m8, r8) = 88 /r
movzx ecx,byte ptr [rax+2]                    # 0010h  | 4   | 0f b6 48 02                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rdx+12h],cl                              # 0014h  | 3   | 88 4a 12                         | (MOV r/m8, r8) = 88 /r
movzx ecx,byte ptr [rax+3]                    # 0017h  | 4   | 0f b6 48 03                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rdx+13h],cl                              # 001bh  | 3   | 88 4a 13                         | (MOV r/m8, r8) = 88 /r
movzx ecx,byte ptr [rax+4]                    # 001eh  | 4   | 0f b6 48 04                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rdx+14h],cl                              # 0022h  | 3   | 88 4a 14                         | (MOV r/m8, r8) = 88 /r
movzx ecx,byte ptr [rax+5]                    # 0025h  | 4   | 0f b6 48 05                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rdx+15h],cl                              # 0029h  | 3   | 88 4a 15                         | (MOV r/m8, r8) = 88 /r
movzx ecx,byte ptr [rax+6]                    # 002ch  | 4   | 0f b6 48 06                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rdx+16h],cl                              # 0030h  | 3   | 88 4a 16                         | (MOV r/m8, r8) = 88 /r
movzx eax,byte ptr [rax+7]                    # 0033h  | 4   | 0f b6 40 07                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rdx+17h],al                              # 0037h  | 3   | 88 42 17                         | (MOV r/m8, r8) = 88 /r
ret                                           # 003ah  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8b[sbyte](ReadOnlySpan[sbyte] src, sbyte* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[8i](rspan8i,8i~ptr)
# 0x48,0x8b,0x01,0x48,0x0f,0xbe,0x08,0x88,0x4a,0x10,0x48,0x0f,0xbe,0x48,0x01,0x88,0x4a,0x11,0x48,0x0f,0xbe,0x48,0x02,0x88,0x4a,0x12,0x48,0x0f,0xbe,0x48,0x03,0x88,0x4a,0x13,0x48,0x0f,0xbe,0x48,0x04,0x88,0x4a,0x14,0x48,0x0f,0xbe,0x48,0x05,0x88,0x4a,0x15,0x48,0x0f,0xbe,0x48,0x06,0x88,0x4a,0x16,0x48,0x0f,0xbe,0x40,0x07,0x88,0x42,0x17,0xc3
# EntryAddress  :7ffb723a8038h
# TargetAddress :7ffb723a8790h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rcx]                                 # 0000h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsx rcx,byte ptr [rax]                      # 0003h  | 4   | 48 0f be 08                      | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rdx+10h],cl                              # 0007h  | 3   | 88 4a 10                         | (MOV r/m8, r8) = 88 /r
movsx rcx,byte ptr [rax+1]                    # 000ah  | 5   | 48 0f be 48 01                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rdx+11h],cl                              # 000fh  | 3   | 88 4a 11                         | (MOV r/m8, r8) = 88 /r
movsx rcx,byte ptr [rax+2]                    # 0012h  | 5   | 48 0f be 48 02                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rdx+12h],cl                              # 0017h  | 3   | 88 4a 12                         | (MOV r/m8, r8) = 88 /r
movsx rcx,byte ptr [rax+3]                    # 001ah  | 5   | 48 0f be 48 03                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rdx+13h],cl                              # 001fh  | 3   | 88 4a 13                         | (MOV r/m8, r8) = 88 /r
movsx rcx,byte ptr [rax+4]                    # 0022h  | 5   | 48 0f be 48 04                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rdx+14h],cl                              # 0027h  | 3   | 88 4a 14                         | (MOV r/m8, r8) = 88 /r
movsx rcx,byte ptr [rax+5]                    # 002ah  | 5   | 48 0f be 48 05                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rdx+15h],cl                              # 002fh  | 3   | 88 4a 15                         | (MOV r/m8, r8) = 88 /r
movsx rcx,byte ptr [rax+6]                    # 0032h  | 5   | 48 0f be 48 06                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rdx+16h],cl                              # 0037h  | 3   | 88 4a 16                         | (MOV r/m8, r8) = 88 /r
movsx rax,byte ptr [rax+7]                    # 003ah  | 5   | 48 0f be 40 07                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rdx+17h],al                              # 003fh  | 3   | 88 42 17                         | (MOV r/m8, r8) = 88 /r
ret                                           # 0042h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8b[ushort](ReadOnlySpan[ushort] src, ushort* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[16u](rspan16u,16u~ptr)
# 0x48,0x8b,0x01,0x0f,0xb7,0x08,0x66,0x89,0x4a,0x20,0x0f,0xb7,0x48,0x02,0x66,0x89,0x4a,0x22,0x0f,0xb7,0x48,0x04,0x66,0x89,0x4a,0x24,0x0f,0xb7,0x48,0x06,0x66,0x89,0x4a,0x26,0x0f,0xb7,0x48,0x08,0x66,0x89,0x4a,0x28,0x0f,0xb7,0x48,0x0a,0x66,0x89,0x4a,0x2a,0x0f,0xb7,0x48,0x0c,0x66,0x89,0x4a,0x2c,0x0f,0xb7,0x40,0x0e,0x66,0x89,0x42,0x2e,0xc3
# EntryAddress  :7ffb723a8048h
# TargetAddress :7ffb723a87f0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rcx]                                 # 0000h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movzx ecx,word ptr [rax]                      # 0003h  | 3   | 0f b7 08                         | (MOVZX r32, r/m16) = 0F B7 /r
mov [rdx+20h],cx                              # 0006h  | 4   | 66 89 4a 20                      | (MOV r/m16, r16) = 89 /r
movzx ecx,word ptr [rax+2]                    # 000ah  | 4   | 0f b7 48 02                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rdx+22h],cx                              # 000eh  | 4   | 66 89 4a 22                      | (MOV r/m16, r16) = 89 /r
movzx ecx,word ptr [rax+4]                    # 0012h  | 4   | 0f b7 48 04                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rdx+24h],cx                              # 0016h  | 4   | 66 89 4a 24                      | (MOV r/m16, r16) = 89 /r
movzx ecx,word ptr [rax+6]                    # 001ah  | 4   | 0f b7 48 06                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rdx+26h],cx                              # 001eh  | 4   | 66 89 4a 26                      | (MOV r/m16, r16) = 89 /r
movzx ecx,word ptr [rax+8]                    # 0022h  | 4   | 0f b7 48 08                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rdx+28h],cx                              # 0026h  | 4   | 66 89 4a 28                      | (MOV r/m16, r16) = 89 /r
movzx ecx,word ptr [rax+0ah]                  # 002ah  | 4   | 0f b7 48 0a                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rdx+2ah],cx                              # 002eh  | 4   | 66 89 4a 2a                      | (MOV r/m16, r16) = 89 /r
movzx ecx,word ptr [rax+0ch]                  # 0032h  | 4   | 0f b7 48 0c                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rdx+2ch],cx                              # 0036h  | 4   | 66 89 4a 2c                      | (MOV r/m16, r16) = 89 /r
movzx eax,word ptr [rax+0eh]                  # 003ah  | 4   | 0f b7 40 0e                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rdx+2eh],ax                              # 003eh  | 4   | 66 89 42 2e                      | (MOV r/m16, r16) = 89 /r
ret                                           # 0042h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8b[short](ReadOnlySpan[short] src, short* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[16i](rspan16i,16i~ptr)
# 0x48,0x8b,0x01,0x48,0x0f,0xbf,0x08,0x66,0x89,0x4a,0x20,0x48,0x0f,0xbf,0x48,0x02,0x66,0x89,0x4a,0x22,0x48,0x0f,0xbf,0x48,0x04,0x66,0x89,0x4a,0x24,0x48,0x0f,0xbf,0x48,0x06,0x66,0x89,0x4a,0x26,0x48,0x0f,0xbf,0x48,0x08,0x66,0x89,0x4a,0x28,0x48,0x0f,0xbf,0x48,0x0a,0x66,0x89,0x4a,0x2a,0x48,0x0f,0xbf,0x48,0x0c,0x66,0x89,0x4a,0x2c,0x48,0x0f,0xbf,0x40,0x0e,0x66,0x89,0x42,0x2e,0xc3
# EntryAddress  :7ffb723a8058h
# TargetAddress :7ffb723a8850h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rcx]                                 # 0000h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
movsx rcx,word ptr [rax]                      # 0003h  | 4   | 48 0f bf 08                      | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rdx+20h],cx                              # 0007h  | 4   | 66 89 4a 20                      | (MOV r/m16, r16) = 89 /r
movsx rcx,word ptr [rax+2]                    # 000bh  | 5   | 48 0f bf 48 02                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rdx+22h],cx                              # 0010h  | 4   | 66 89 4a 22                      | (MOV r/m16, r16) = 89 /r
movsx rcx,word ptr [rax+4]                    # 0014h  | 5   | 48 0f bf 48 04                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rdx+24h],cx                              # 0019h  | 4   | 66 89 4a 24                      | (MOV r/m16, r16) = 89 /r
movsx rcx,word ptr [rax+6]                    # 001dh  | 5   | 48 0f bf 48 06                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rdx+26h],cx                              # 0022h  | 4   | 66 89 4a 26                      | (MOV r/m16, r16) = 89 /r
movsx rcx,word ptr [rax+8]                    # 0026h  | 5   | 48 0f bf 48 08                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rdx+28h],cx                              # 002bh  | 4   | 66 89 4a 28                      | (MOV r/m16, r16) = 89 /r
movsx rcx,word ptr [rax+0ah]                  # 002fh  | 5   | 48 0f bf 48 0a                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rdx+2ah],cx                              # 0034h  | 4   | 66 89 4a 2a                      | (MOV r/m16, r16) = 89 /r
movsx rcx,word ptr [rax+0ch]                  # 0038h  | 5   | 48 0f bf 48 0c                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rdx+2ch],cx                              # 003dh  | 4   | 66 89 4a 2c                      | (MOV r/m16, r16) = 89 /r
movsx rax,word ptr [rax+0eh]                  # 0041h  | 5   | 48 0f bf 40 0e                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rdx+2eh],ax                              # 0046h  | 4   | 66 89 42 2e                      | (MOV r/m16, r16) = 89 /r
ret                                           # 004ah  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8b[uint](ReadOnlySpan[uint] src, uint* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[32u](rspan32u,32u~ptr)
# 0x48,0x8b,0x01,0x8b,0x08,0x89,0x4a,0x40,0x8b,0x48,0x04,0x89,0x4a,0x44,0x8b,0x48,0x08,0x89,0x4a,0x48,0x8b,0x48,0x0c,0x89,0x4a,0x4c,0x8b,0x48,0x10,0x89,0x4a,0x50,0x8b,0x48,0x14,0x89,0x4a,0x54,0x8b,0x48,0x18,0x89,0x4a,0x58,0x8b,0x40,0x1c,0x89,0x42,0x5c,0xc3
# EntryAddress  :7ffb723a8068h
# TargetAddress :7ffb723a88b0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rcx]                                 # 0000h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
mov ecx,[rax]                                 # 0003h  | 2   | 8b 08                            | (MOV r32, r/m32) = 8B /r
mov [rdx+40h],ecx                             # 0005h  | 3   | 89 4a 40                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+4]                               # 0008h  | 3   | 8b 48 04                         | (MOV r32, r/m32) = 8B /r
mov [rdx+44h],ecx                             # 000bh  | 3   | 89 4a 44                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+8]                               # 000eh  | 3   | 8b 48 08                         | (MOV r32, r/m32) = 8B /r
mov [rdx+48h],ecx                             # 0011h  | 3   | 89 4a 48                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+0ch]                             # 0014h  | 3   | 8b 48 0c                         | (MOV r32, r/m32) = 8B /r
mov [rdx+4ch],ecx                             # 0017h  | 3   | 89 4a 4c                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+10h]                             # 001ah  | 3   | 8b 48 10                         | (MOV r32, r/m32) = 8B /r
mov [rdx+50h],ecx                             # 001dh  | 3   | 89 4a 50                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+14h]                             # 0020h  | 3   | 8b 48 14                         | (MOV r32, r/m32) = 8B /r
mov [rdx+54h],ecx                             # 0023h  | 3   | 89 4a 54                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+18h]                             # 0026h  | 3   | 8b 48 18                         | (MOV r32, r/m32) = 8B /r
mov [rdx+58h],ecx                             # 0029h  | 3   | 89 4a 58                         | (MOV r/m32, r32) = 89 /r
mov eax,[rax+1ch]                             # 002ch  | 3   | 8b 40 1c                         | (MOV r32, r/m32) = 8B /r
mov [rdx+5ch],eax                             # 002fh  | 3   | 89 42 5c                         | (MOV r/m32, r32) = 89 /r
ret                                           # 0032h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8b[int](ReadOnlySpan[int] src, int* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[32i](rspan32i,32i~ptr)
# 0x48,0x8b,0x01,0x8b,0x08,0x89,0x4a,0x40,0x8b,0x48,0x04,0x89,0x4a,0x44,0x8b,0x48,0x08,0x89,0x4a,0x48,0x8b,0x48,0x0c,0x89,0x4a,0x4c,0x8b,0x48,0x10,0x89,0x4a,0x50,0x8b,0x48,0x14,0x89,0x4a,0x54,0x8b,0x48,0x18,0x89,0x4a,0x58,0x8b,0x40,0x1c,0x89,0x42,0x5c,0xc3
# EntryAddress  :7ffb723a8078h
# TargetAddress :7ffb723a8900h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rcx]                                 # 0000h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
mov ecx,[rax]                                 # 0003h  | 2   | 8b 08                            | (MOV r32, r/m32) = 8B /r
mov [rdx+40h],ecx                             # 0005h  | 3   | 89 4a 40                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+4]                               # 0008h  | 3   | 8b 48 04                         | (MOV r32, r/m32) = 8B /r
mov [rdx+44h],ecx                             # 000bh  | 3   | 89 4a 44                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+8]                               # 000eh  | 3   | 8b 48 08                         | (MOV r32, r/m32) = 8B /r
mov [rdx+48h],ecx                             # 0011h  | 3   | 89 4a 48                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+0ch]                             # 0014h  | 3   | 8b 48 0c                         | (MOV r32, r/m32) = 8B /r
mov [rdx+4ch],ecx                             # 0017h  | 3   | 89 4a 4c                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+10h]                             # 001ah  | 3   | 8b 48 10                         | (MOV r32, r/m32) = 8B /r
mov [rdx+50h],ecx                             # 001dh  | 3   | 89 4a 50                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+14h]                             # 0020h  | 3   | 8b 48 14                         | (MOV r32, r/m32) = 8B /r
mov [rdx+54h],ecx                             # 0023h  | 3   | 89 4a 54                         | (MOV r/m32, r32) = 89 /r
mov ecx,[rax+18h]                             # 0026h  | 3   | 8b 48 18                         | (MOV r32, r/m32) = 8B /r
mov [rdx+58h],ecx                             # 0029h  | 3   | 89 4a 58                         | (MOV r/m32, r32) = 89 /r
mov eax,[rax+1ch]                             # 002ch  | 3   | 8b 40 1c                         | (MOV r32, r/m32) = 8B /r
mov [rdx+5ch],eax                             # 002fh  | 3   | 89 42 5c                         | (MOV r/m32, r32) = 89 /r
ret                                           # 0032h  | 1   | c3                               | (RET) = C3

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
# void mov8b[long](ReadOnlySpan[long] src, long* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[64i](rspan64i,64i~ptr)
# 0x48,0x8b,0x01,0x48,0x8b,0x08,0x48,0x89,0x8a,0x80,0x00,0x00,0x00,0x48,0x8b,0x48,0x08,0x48,0x89,0x8a,0x88,0x00,0x00,0x00,0x48,0x8b,0x48,0x10,0x48,0x89,0x8a,0x90,0x00,0x00,0x00,0x48,0x8b,0x48,0x18,0x48,0x89,0x8a,0x98,0x00,0x00,0x00,0x48,0x8b,0x48,0x20,0x48,0x89,0x8a,0xa0,0x00,0x00,0x00,0x48,0x8b,0x48,0x28,0x48,0x89,0x8a,0xa8,0x00,0x00,0x00,0x48,0x8b,0x48,0x30,0x48,0x89,0x8a,0xb0,0x00,0x00,0x00,0x48,0x8b,0x40,0x38,0x48,0x89,0x82,0xb8,0x00,0x00,0x00,0xc3
# EntryAddress  :7ffb723a8098h
# TargetAddress :7ffb723a89c0h
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
# void mov8b[float](ReadOnlySpan[float] src, float* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[32f](rspan32f,32f~ptr)
# 0xc5,0xf8,0x77,0x48,0x8b,0x01,0xc5,0xfa,0x10,0x00,0xc5,0xfa,0x11,0x42,0x40,0xc5,0xfa,0x10,0x40,0x04,0xc5,0xfa,0x11,0x42,0x44,0xc5,0xfa,0x10,0x40,0x08,0xc5,0xfa,0x11,0x42,0x48,0xc5,0xfa,0x10,0x40,0x0c,0xc5,0xfa,0x11,0x42,0x4c,0xc5,0xfa,0x10,0x40,0x10,0xc5,0xfa,0x11,0x42,0x50,0xc5,0xfa,0x10,0x40,0x14,0xc5,0xfa,0x11,0x42,0x54,0xc5,0xfa,0x10,0x40,0x18,0xc5,0xfa,0x11,0x42,0x58,0xc5,0xfa,0x10,0x40,0x1c,0xc5,0xfa,0x11,0x42,0x5c,0xc3
# EntryAddress  :7ffb723a80a8h
# TargetAddress :7ffb723a8a30h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov rax,[rcx]                                 # 0003h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
vmovss xmm0,dword ptr [rax]                   # 0006h  | 4   | c5 fa 10 00                      | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rdx+40h],xmm0               # 000ah  | 5   | c5 fa 11 42 40                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rax+4]                 # 000fh  | 5   | c5 fa 10 40 04                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rdx+44h],xmm0               # 0014h  | 5   | c5 fa 11 42 44                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rax+8]                 # 0019h  | 5   | c5 fa 10 40 08                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rdx+48h],xmm0               # 001eh  | 5   | c5 fa 11 42 48                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rax+0ch]               # 0023h  | 5   | c5 fa 10 40 0c                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rdx+4ch],xmm0               # 0028h  | 5   | c5 fa 11 42 4c                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rax+10h]               # 002dh  | 5   | c5 fa 10 40 10                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rdx+50h],xmm0               # 0032h  | 5   | c5 fa 11 42 50                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rax+14h]               # 0037h  | 5   | c5 fa 10 40 14                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rdx+54h],xmm0               # 003ch  | 5   | c5 fa 11 42 54                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rax+18h]               # 0041h  | 5   | c5 fa 10 40 18                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rdx+58h],xmm0               # 0046h  | 5   | c5 fa 11 42 58                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
vmovss xmm0,dword ptr [rax+1ch]               # 004bh  | 5   | c5 fa 10 40 1c                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rdx+5ch],xmm0               # 0050h  | 5   | c5 fa 11 42 5c                   | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
ret                                           # 0055h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8b[double](ReadOnlySpan[double] src, double* pDst)::located://asm.prototypes/prototypes.mov?mov8b#mov8bヽg[64f](rspan64f,64f~ptr)
# 0xc5,0xf8,0x77,0x48,0x8b,0x01,0xc5,0xfb,0x10,0x00,0xc5,0xfb,0x11,0x82,0x80,0x00,0x00,0x00,0xc5,0xfb,0x10,0x40,0x08,0xc5,0xfb,0x11,0x82,0x88,0x00,0x00,0x00,0xc5,0xfb,0x10,0x40,0x10,0xc5,0xfb,0x11,0x82,0x90,0x00,0x00,0x00,0xc5,0xfb,0x10,0x40,0x18,0xc5,0xfb,0x11,0x82,0x98,0x00,0x00,0x00,0xc5,0xfb,0x10,0x40,0x20,0xc5,0xfb,0x11,0x82,0xa0,0x00,0x00,0x00,0xc5,0xfb,0x10,0x40,0x28,0xc5,0xfb,0x11,0x82,0xa8,0x00,0x00,0x00,0xc5,0xfb,0x10,0x40,0x30,0xc5,0xfb,0x11,0x82,0xb0,0x00,0x00,0x00,0xc5,0xfb,0x10,0x40,0x38,0xc5,0xfb,0x11,0x82,0xb8,0x00,0x00,0x00,0xc3
# EntryAddress  :7ffb723a80b8h
# TargetAddress :7ffb723a8ab0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov rax,[rcx]                                 # 0003h  | 3   | 48 8b 01                         | (MOV r64, r/m64) = REX.W 8B /r
vmovsd xmm0,qword ptr [rax]                   # 0006h  | 4   | c5 fb 10 00                      | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rdx+80h],xmm0               # 000ah  | 8   | c5 fb 11 82 80 00 00 00          | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rax+8]                 # 0012h  | 5   | c5 fb 10 40 08                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rdx+88h],xmm0               # 0017h  | 8   | c5 fb 11 82 88 00 00 00          | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rax+10h]               # 001fh  | 5   | c5 fb 10 40 10                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rdx+90h],xmm0               # 0024h  | 8   | c5 fb 11 82 90 00 00 00          | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rax+18h]               # 002ch  | 5   | c5 fb 10 40 18                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rdx+98h],xmm0               # 0031h  | 8   | c5 fb 11 82 98 00 00 00          | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rax+20h]               # 0039h  | 5   | c5 fb 10 40 20                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rdx+0a0h],xmm0              # 003eh  | 8   | c5 fb 11 82 a0 00 00 00          | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rax+28h]               # 0046h  | 5   | c5 fb 10 40 28                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rdx+0a8h],xmm0              # 004bh  | 8   | c5 fb 11 82 a8 00 00 00          | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rax+30h]               # 0053h  | 5   | c5 fb 10 40 30                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rdx+0b0h],xmm0              # 0058h  | 8   | c5 fb 11 82 b0 00 00 00          | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
vmovsd xmm0,qword ptr [rax+38h]               # 0060h  | 5   | c5 fb 10 40 38                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rdx+0b8h],xmm0              # 0065h  | 8   | c5 fb 11 82 b8 00 00 00          | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
ret                                           # 006dh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[byte](ReadOnlySpan[byte] src, Span[byte] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[8u](rspan8u,span8u)
# 0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x48,0x10,0x44,0x0f,0xb6,0x02,0x44,0x88,0x01,0x48,0x8d,0x48,0x11,0x44,0x0f,0xb6,0x42,0x01,0x44,0x88,0x01,0x48,0x8d,0x48,0x12,0x44,0x0f,0xb6,0x42,0x02,0x44,0x88,0x01,0x48,0x8d,0x48,0x13,0x44,0x0f,0xb6,0x42,0x03,0x44,0x88,0x01,0x48,0x8d,0x48,0x14,0x44,0x0f,0xb6,0x42,0x04,0x44,0x88,0x01,0x48,0x8d,0x48,0x15,0x44,0x0f,0xb6,0x42,0x05,0x44,0x88,0x01,0x48,0x8d,0x48,0x16,0x44,0x0f,0xb6,0x42,0x06,0x44,0x88,0x01,0x48,0x83,0xc0,0x17,0x0f,0xb6,0x52,0x07,0x88,0x10,0xc3
# EntryAddress  :7ffb723a80c8h
# TargetAddress :7ffb723a8b40h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0003h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+10h]                             # 0006h  | 4   | 48 8d 48 10                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,byte ptr [rdx]                      # 000ah  | 4   | 44 0f b6 02                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],r8b                                 # 000eh  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+11h]                             # 0011h  | 4   | 48 8d 48 11                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,byte ptr [rdx+1]                    # 0015h  | 5   | 44 0f b6 42 01                   | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],r8b                                 # 001ah  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+12h]                             # 001dh  | 4   | 48 8d 48 12                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,byte ptr [rdx+2]                    # 0021h  | 5   | 44 0f b6 42 02                   | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],r8b                                 # 0026h  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+13h]                             # 0029h  | 4   | 48 8d 48 13                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,byte ptr [rdx+3]                    # 002dh  | 5   | 44 0f b6 42 03                   | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],r8b                                 # 0032h  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+14h]                             # 0035h  | 4   | 48 8d 48 14                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,byte ptr [rdx+4]                    # 0039h  | 5   | 44 0f b6 42 04                   | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],r8b                                 # 003eh  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+15h]                             # 0041h  | 4   | 48 8d 48 15                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,byte ptr [rdx+5]                    # 0045h  | 5   | 44 0f b6 42 05                   | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],r8b                                 # 004ah  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+16h]                             # 004dh  | 4   | 48 8d 48 16                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,byte ptr [rdx+6]                    # 0051h  | 5   | 44 0f b6 42 06                   | (MOVZX r32, r/m8) = 0F B6 /r
mov [rcx],r8b                                 # 0056h  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
add rax,17h                                   # 0059h  | 4   | 48 83 c0 17                      | (ADD r/m64, imm8) = REX.W 83 /0 ib
movzx edx,byte ptr [rdx+7]                    # 005dh  | 4   | 0f b6 52 07                      | (MOVZX r32, r/m8) = 0F B6 /r
mov [rax],dl                                  # 0061h  | 2   | 88 10                            | (MOV r/m8, r8) = 88 /r
ret                                           # 0063h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[sbyte](ReadOnlySpan[sbyte] src, Span[sbyte] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[8i](rspan8i,span8i)
# 0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x48,0x10,0x4c,0x0f,0xbe,0x02,0x44,0x88,0x01,0x48,0x8d,0x48,0x11,0x4c,0x0f,0xbe,0x42,0x01,0x44,0x88,0x01,0x48,0x8d,0x48,0x12,0x4c,0x0f,0xbe,0x42,0x02,0x44,0x88,0x01,0x48,0x8d,0x48,0x13,0x4c,0x0f,0xbe,0x42,0x03,0x44,0x88,0x01,0x48,0x8d,0x48,0x14,0x4c,0x0f,0xbe,0x42,0x04,0x44,0x88,0x01,0x48,0x8d,0x48,0x15,0x4c,0x0f,0xbe,0x42,0x05,0x44,0x88,0x01,0x48,0x8d,0x48,0x16,0x4c,0x0f,0xbe,0x42,0x06,0x44,0x88,0x01,0x48,0x83,0xc0,0x17,0x48,0x0f,0xbe,0x52,0x07,0x88,0x10,0xc3
# EntryAddress  :7ffb723a80e8h
# TargetAddress :7ffb723a8bc0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0003h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+10h]                             # 0006h  | 4   | 48 8d 48 10                      | (LEA r64, m) = REX.W 8D /r
movsx r8,byte ptr [rdx]                       # 000ah  | 4   | 4c 0f be 02                      | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx],r8b                                 # 000eh  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+11h]                             # 0011h  | 4   | 48 8d 48 11                      | (LEA r64, m) = REX.W 8D /r
movsx r8,byte ptr [rdx+1]                     # 0015h  | 5   | 4c 0f be 42 01                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx],r8b                                 # 001ah  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+12h]                             # 001dh  | 4   | 48 8d 48 12                      | (LEA r64, m) = REX.W 8D /r
movsx r8,byte ptr [rdx+2]                     # 0021h  | 5   | 4c 0f be 42 02                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx],r8b                                 # 0026h  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+13h]                             # 0029h  | 4   | 48 8d 48 13                      | (LEA r64, m) = REX.W 8D /r
movsx r8,byte ptr [rdx+3]                     # 002dh  | 5   | 4c 0f be 42 03                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx],r8b                                 # 0032h  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+14h]                             # 0035h  | 4   | 48 8d 48 14                      | (LEA r64, m) = REX.W 8D /r
movsx r8,byte ptr [rdx+4]                     # 0039h  | 5   | 4c 0f be 42 04                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx],r8b                                 # 003eh  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+15h]                             # 0041h  | 4   | 48 8d 48 15                      | (LEA r64, m) = REX.W 8D /r
movsx r8,byte ptr [rdx+5]                     # 0045h  | 5   | 4c 0f be 42 05                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx],r8b                                 # 004ah  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
lea rcx,[rax+16h]                             # 004dh  | 4   | 48 8d 48 16                      | (LEA r64, m) = REX.W 8D /r
movsx r8,byte ptr [rdx+6]                     # 0051h  | 5   | 4c 0f be 42 06                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rcx],r8b                                 # 0056h  | 3   | 44 88 01                         | (MOV r/m8, r8) = 88 /r
add rax,17h                                   # 0059h  | 4   | 48 83 c0 17                      | (ADD r/m64, imm8) = REX.W 83 /0 ib
movsx rdx,byte ptr [rdx+7]                    # 005dh  | 5   | 48 0f be 52 07                   | (MOVSX r64, r/m8) = REX.W 0F BE /r
mov [rax],dl                                  # 0062h  | 2   | 88 10                            | (MOV r/m8, r8) = 88 /r
ret                                           # 0064h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[ushort](ReadOnlySpan[ushort] src, Span[ushort] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[16u](rspan16u,span16u)
# 0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x48,0x20,0x44,0x0f,0xb7,0x02,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x22,0x44,0x0f,0xb7,0x42,0x02,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x24,0x44,0x0f,0xb7,0x42,0x04,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x26,0x44,0x0f,0xb7,0x42,0x06,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x28,0x44,0x0f,0xb7,0x42,0x08,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x2a,0x44,0x0f,0xb7,0x42,0x0a,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x2c,0x44,0x0f,0xb7,0x42,0x0c,0x66,0x44,0x89,0x01,0x48,0x83,0xc0,0x2e,0x0f,0xb7,0x52,0x0e,0x66,0x89,0x10,0xc3
# EntryAddress  :7ffb723a80f8h
# TargetAddress :7ffb723a8c40h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0003h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+20h]                             # 0006h  | 4   | 48 8d 48 20                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,word ptr [rdx]                      # 000ah  | 4   | 44 0f b7 02                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],r8w                                 # 000eh  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+22h]                             # 0012h  | 4   | 48 8d 48 22                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,word ptr [rdx+2]                    # 0016h  | 5   | 44 0f b7 42 02                   | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],r8w                                 # 001bh  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+24h]                             # 001fh  | 4   | 48 8d 48 24                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,word ptr [rdx+4]                    # 0023h  | 5   | 44 0f b7 42 04                   | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],r8w                                 # 0028h  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+26h]                             # 002ch  | 4   | 48 8d 48 26                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,word ptr [rdx+6]                    # 0030h  | 5   | 44 0f b7 42 06                   | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],r8w                                 # 0035h  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+28h]                             # 0039h  | 4   | 48 8d 48 28                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,word ptr [rdx+8]                    # 003dh  | 5   | 44 0f b7 42 08                   | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],r8w                                 # 0042h  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+2ah]                             # 0046h  | 4   | 48 8d 48 2a                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,word ptr [rdx+0ah]                  # 004ah  | 5   | 44 0f b7 42 0a                   | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],r8w                                 # 004fh  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+2ch]                             # 0053h  | 4   | 48 8d 48 2c                      | (LEA r64, m) = REX.W 8D /r
movzx r8d,word ptr [rdx+0ch]                  # 0057h  | 5   | 44 0f b7 42 0c                   | (MOVZX r32, r/m16) = 0F B7 /r
mov [rcx],r8w                                 # 005ch  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
add rax,2eh                                   # 0060h  | 4   | 48 83 c0 2e                      | (ADD r/m64, imm8) = REX.W 83 /0 ib
movzx edx,word ptr [rdx+0eh]                  # 0064h  | 4   | 0f b7 52 0e                      | (MOVZX r32, r/m16) = 0F B7 /r
mov [rax],dx                                  # 0068h  | 3   | 66 89 10                         | (MOV r/m16, r16) = 89 /r
ret                                           # 006bh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[short](ReadOnlySpan[short] src, Span[short] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[16i](rspan16i,span16i)
# 0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x48,0x20,0x4c,0x0f,0xbf,0x02,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x22,0x4c,0x0f,0xbf,0x42,0x02,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x24,0x4c,0x0f,0xbf,0x42,0x04,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x26,0x4c,0x0f,0xbf,0x42,0x06,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x28,0x4c,0x0f,0xbf,0x42,0x08,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x2a,0x4c,0x0f,0xbf,0x42,0x0a,0x66,0x44,0x89,0x01,0x48,0x8d,0x48,0x2c,0x4c,0x0f,0xbf,0x42,0x0c,0x66,0x44,0x89,0x01,0x48,0x83,0xc0,0x2e,0x48,0x0f,0xbf,0x52,0x0e,0x66,0x89,0x10,0xc3
# EntryAddress  :7ffb723a8108h
# TargetAddress :7ffb723a8cc0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0003h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+20h]                             # 0006h  | 4   | 48 8d 48 20                      | (LEA r64, m) = REX.W 8D /r
movsx r8,word ptr [rdx]                       # 000ah  | 4   | 4c 0f bf 02                      | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx],r8w                                 # 000eh  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+22h]                             # 0012h  | 4   | 48 8d 48 22                      | (LEA r64, m) = REX.W 8D /r
movsx r8,word ptr [rdx+2]                     # 0016h  | 5   | 4c 0f bf 42 02                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx],r8w                                 # 001bh  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+24h]                             # 001fh  | 4   | 48 8d 48 24                      | (LEA r64, m) = REX.W 8D /r
movsx r8,word ptr [rdx+4]                     # 0023h  | 5   | 4c 0f bf 42 04                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx],r8w                                 # 0028h  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+26h]                             # 002ch  | 4   | 48 8d 48 26                      | (LEA r64, m) = REX.W 8D /r
movsx r8,word ptr [rdx+6]                     # 0030h  | 5   | 4c 0f bf 42 06                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx],r8w                                 # 0035h  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+28h]                             # 0039h  | 4   | 48 8d 48 28                      | (LEA r64, m) = REX.W 8D /r
movsx r8,word ptr [rdx+8]                     # 003dh  | 5   | 4c 0f bf 42 08                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx],r8w                                 # 0042h  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+2ah]                             # 0046h  | 4   | 48 8d 48 2a                      | (LEA r64, m) = REX.W 8D /r
movsx r8,word ptr [rdx+0ah]                   # 004ah  | 5   | 4c 0f bf 42 0a                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx],r8w                                 # 004fh  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
lea rcx,[rax+2ch]                             # 0053h  | 4   | 48 8d 48 2c                      | (LEA r64, m) = REX.W 8D /r
movsx r8,word ptr [rdx+0ch]                   # 0057h  | 5   | 4c 0f bf 42 0c                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rcx],r8w                                 # 005ch  | 4   | 66 44 89 01                      | (MOV r/m16, r16) = 89 /r
add rax,2eh                                   # 0060h  | 4   | 48 83 c0 2e                      | (ADD r/m64, imm8) = REX.W 83 /0 ib
movsx rdx,word ptr [rdx+0eh]                  # 0064h  | 5   | 48 0f bf 52 0e                   | (MOVSX r64, r/m16) = REX.W 0F BF /r
mov [rax],dx                                  # 0069h  | 3   | 66 89 10                         | (MOV r/m16, r16) = 89 /r
ret                                           # 006ch  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[uint](ReadOnlySpan[uint] src, Span[uint] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[32u](rspan32u,span32u)
# 0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x48,0x40,0x44,0x8b,0x02,0x44,0x89,0x01,0x48,0x8d,0x48,0x44,0x44,0x8b,0x42,0x04,0x44,0x89,0x01,0x48,0x8d,0x48,0x48,0x44,0x8b,0x42,0x08,0x44,0x89,0x01,0x48,0x8d,0x48,0x4c,0x44,0x8b,0x42,0x0c,0x44,0x89,0x01,0x48,0x8d,0x48,0x50,0x44,0x8b,0x42,0x10,0x44,0x89,0x01,0x48,0x8d,0x48,0x54,0x44,0x8b,0x42,0x14,0x44,0x89,0x01,0x48,0x8d,0x48,0x58,0x44,0x8b,0x42,0x18,0x44,0x89,0x01,0x48,0x83,0xc0,0x5c,0x8b,0x52,0x1c,0x89,0x10,0xc3
# EntryAddress  :7ffb723a8118h
# TargetAddress :7ffb723a8d40h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0003h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+40h]                             # 0006h  | 4   | 48 8d 48 40                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx]                                 # 000ah  | 3   | 44 8b 02                         | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 000dh  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+44h]                             # 0010h  | 4   | 48 8d 48 44                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+4]                               # 0014h  | 4   | 44 8b 42 04                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 0018h  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+48h]                             # 001bh  | 4   | 48 8d 48 48                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+8]                               # 001fh  | 4   | 44 8b 42 08                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 0023h  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+4ch]                             # 0026h  | 4   | 48 8d 48 4c                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+0ch]                             # 002ah  | 4   | 44 8b 42 0c                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 002eh  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+50h]                             # 0031h  | 4   | 48 8d 48 50                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+10h]                             # 0035h  | 4   | 44 8b 42 10                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 0039h  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+54h]                             # 003ch  | 4   | 48 8d 48 54                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+14h]                             # 0040h  | 4   | 44 8b 42 14                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 0044h  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+58h]                             # 0047h  | 4   | 48 8d 48 58                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+18h]                             # 004bh  | 4   | 44 8b 42 18                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 004fh  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
add rax,5ch                                   # 0052h  | 4   | 48 83 c0 5c                      | (ADD r/m64, imm8) = REX.W 83 /0 ib
mov edx,[rdx+1ch]                             # 0056h  | 3   | 8b 52 1c                         | (MOV r32, r/m32) = 8B /r
mov [rax],edx                                 # 0059h  | 2   | 89 10                            | (MOV r/m32, r32) = 89 /r
ret                                           # 005bh  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[int](ReadOnlySpan[int] src, Span[int] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[32i](rspan32i,span32i)
# 0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x48,0x40,0x44,0x8b,0x02,0x44,0x89,0x01,0x48,0x8d,0x48,0x44,0x44,0x8b,0x42,0x04,0x44,0x89,0x01,0x48,0x8d,0x48,0x48,0x44,0x8b,0x42,0x08,0x44,0x89,0x01,0x48,0x8d,0x48,0x4c,0x44,0x8b,0x42,0x0c,0x44,0x89,0x01,0x48,0x8d,0x48,0x50,0x44,0x8b,0x42,0x10,0x44,0x89,0x01,0x48,0x8d,0x48,0x54,0x44,0x8b,0x42,0x14,0x44,0x89,0x01,0x48,0x8d,0x48,0x58,0x44,0x8b,0x42,0x18,0x44,0x89,0x01,0x48,0x83,0xc0,0x5c,0x8b,0x52,0x1c,0x89,0x10,0xc3
# EntryAddress  :7ffb723a8128h
# TargetAddress :7ffb723a8db0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
mov rax,[rdx]                                 # 0000h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0003h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+40h]                             # 0006h  | 4   | 48 8d 48 40                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx]                                 # 000ah  | 3   | 44 8b 02                         | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 000dh  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+44h]                             # 0010h  | 4   | 48 8d 48 44                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+4]                               # 0014h  | 4   | 44 8b 42 04                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 0018h  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+48h]                             # 001bh  | 4   | 48 8d 48 48                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+8]                               # 001fh  | 4   | 44 8b 42 08                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 0023h  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+4ch]                             # 0026h  | 4   | 48 8d 48 4c                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+0ch]                             # 002ah  | 4   | 44 8b 42 0c                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 002eh  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+50h]                             # 0031h  | 4   | 48 8d 48 50                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+10h]                             # 0035h  | 4   | 44 8b 42 10                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 0039h  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+54h]                             # 003ch  | 4   | 48 8d 48 54                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+14h]                             # 0040h  | 4   | 44 8b 42 14                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 0044h  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
lea rcx,[rax+58h]                             # 0047h  | 4   | 48 8d 48 58                      | (LEA r64, m) = REX.W 8D /r
mov r8d,[rdx+18h]                             # 004bh  | 4   | 44 8b 42 18                      | (MOV r32, r/m32) = 8B /r
mov [rcx],r8d                                 # 004fh  | 3   | 44 89 01                         | (MOV r/m32, r32) = 89 /r
add rax,5ch                                   # 0052h  | 4   | 48 83 c0 5c                      | (ADD r/m64, imm8) = REX.W 83 /0 ib
mov edx,[rdx+1ch]                             # 0056h  | 3   | 8b 52 1c                         | (MOV r32, r/m32) = 8B /r
mov [rax],edx                                 # 0059h  | 2   | 89 10                            | (MOV r/m32, r32) = 89 /r
ret                                           # 005bh  | 1   | c3                               | (RET) = C3

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

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[long](ReadOnlySpan[long] src, Span[long] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[64i](rspan64i,span64i)
# 0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x88,0x80,0x00,0x00,0x00,0x4c,0x8b,0x02,0x4c,0x89,0x01,0x48,0x8d,0x88,0x88,0x00,0x00,0x00,0x4c,0x8b,0x42,0x08,0x4c,0x89,0x01,0x48,0x8d,0x88,0x90,0x00,0x00,0x00,0x4c,0x8b,0x42,0x10,0x4c,0x89,0x01,0x48,0x8d,0x88,0x98,0x00,0x00,0x00,0x4c,0x8b,0x42,0x18,0x4c,0x89,0x01,0x48,0x8d,0x88,0xa0,0x00,0x00,0x00,0x4c,0x8b,0x42,0x20,0x4c,0x89,0x01,0x48,0x8d,0x88,0xa8,0x00,0x00,0x00,0x4c,0x8b,0x42,0x28,0x4c,0x89,0x01,0x48,0x8d,0x88,0xb0,0x00,0x00,0x00,0x4c,0x8b,0x42,0x30,0x4c,0x89,0x01,0x48,0x05,0xb8,0x00,0x00,0x00,0x48,0x8b,0x52,0x38,0x48,0x89,0x10,0xc3
# EntryAddress  :7ffb723a8148h
# TargetAddress :7ffb723a8eb0h
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

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[float](ReadOnlySpan[float] src, Span[float] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[32f](rspan32f,span32f)
# 0xc5,0xf8,0x77,0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x48,0x40,0xc5,0xfa,0x10,0x02,0xc5,0xfa,0x11,0x01,0x48,0x8d,0x48,0x44,0xc5,0xfa,0x10,0x42,0x04,0xc5,0xfa,0x11,0x01,0x48,0x8d,0x48,0x48,0xc5,0xfa,0x10,0x42,0x08,0xc5,0xfa,0x11,0x01,0x48,0x8d,0x48,0x4c,0xc5,0xfa,0x10,0x42,0x0c,0xc5,0xfa,0x11,0x01,0x48,0x8d,0x48,0x50,0xc5,0xfa,0x10,0x42,0x10,0xc5,0xfa,0x11,0x01,0x48,0x8d,0x48,0x54,0xc5,0xfa,0x10,0x42,0x14,0xc5,0xfa,0x11,0x01,0x48,0x8d,0x48,0x58,0xc5,0xfa,0x10,0x42,0x18,0xc5,0xfa,0x11,0x01,0x48,0x83,0xc0,0x5c,0xc5,0xfa,0x10,0x42,0x1c,0xc5,0xfa,0x11,0x00,0xc3
# EntryAddress  :7ffb723a8158h
# TargetAddress :7ffb723a8f40h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov rax,[rdx]                                 # 0003h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0006h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+40h]                             # 0009h  | 4   | 48 8d 48 40                      | (LEA r64, m) = REX.W 8D /r
vmovss xmm0,dword ptr [rdx]                   # 000dh  | 4   | c5 fa 10 02                      | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx],xmm0                   # 0011h  | 4   | c5 fa 11 01                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
lea rcx,[rax+44h]                             # 0015h  | 4   | 48 8d 48 44                      | (LEA r64, m) = REX.W 8D /r
vmovss xmm0,dword ptr [rdx+4]                 # 0019h  | 5   | c5 fa 10 42 04                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx],xmm0                   # 001eh  | 4   | c5 fa 11 01                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
lea rcx,[rax+48h]                             # 0022h  | 4   | 48 8d 48 48                      | (LEA r64, m) = REX.W 8D /r
vmovss xmm0,dword ptr [rdx+8]                 # 0026h  | 5   | c5 fa 10 42 08                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx],xmm0                   # 002bh  | 4   | c5 fa 11 01                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
lea rcx,[rax+4ch]                             # 002fh  | 4   | 48 8d 48 4c                      | (LEA r64, m) = REX.W 8D /r
vmovss xmm0,dword ptr [rdx+0ch]               # 0033h  | 5   | c5 fa 10 42 0c                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx],xmm0                   # 0038h  | 4   | c5 fa 11 01                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
lea rcx,[rax+50h]                             # 003ch  | 4   | 48 8d 48 50                      | (LEA r64, m) = REX.W 8D /r
vmovss xmm0,dword ptr [rdx+10h]               # 0040h  | 5   | c5 fa 10 42 10                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx],xmm0                   # 0045h  | 4   | c5 fa 11 01                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
lea rcx,[rax+54h]                             # 0049h  | 4   | 48 8d 48 54                      | (LEA r64, m) = REX.W 8D /r
vmovss xmm0,dword ptr [rdx+14h]               # 004dh  | 5   | c5 fa 10 42 14                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx],xmm0                   # 0052h  | 4   | c5 fa 11 01                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
lea rcx,[rax+58h]                             # 0056h  | 4   | 48 8d 48 58                      | (LEA r64, m) = REX.W 8D /r
vmovss xmm0,dword ptr [rdx+18h]               # 005ah  | 5   | c5 fa 10 42 18                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rcx],xmm0                   # 005fh  | 4   | c5 fa 11 01                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
add rax,5ch                                   # 0063h  | 4   | 48 83 c0 5c                      | (ADD r/m64, imm8) = REX.W 83 /0 ib
vmovss xmm0,dword ptr [rdx+1ch]               # 0067h  | 5   | c5 fa 10 42 1c                   | (VMOVSS xmm1, m32) = VEX.LIG.F3.0F.WIG 10 /r
vmovss dword ptr [rax],xmm0                   # 006ch  | 4   | c5 fa 11 00                      | (VMOVSS m32, xmm1) = VEX.LIG.F3.0F.WIG 11 /r
ret                                           # 0070h  | 1   | c3                               | (RET) = C3

# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# void mov8c[double](ReadOnlySpan[double] src, Span[double] dst)::located://asm.prototypes/prototypes.mov?mov8c#mov8cヽg[64f](rspan64f,span64f)
# 0xc5,0xf8,0x77,0x48,0x8b,0x02,0x48,0x8b,0x11,0x48,0x8d,0x88,0x80,0x00,0x00,0x00,0xc5,0xfb,0x10,0x02,0xc5,0xfb,0x11,0x01,0x48,0x8d,0x88,0x88,0x00,0x00,0x00,0xc5,0xfb,0x10,0x42,0x08,0xc5,0xfb,0x11,0x01,0x48,0x8d,0x88,0x90,0x00,0x00,0x00,0xc5,0xfb,0x10,0x42,0x10,0xc5,0xfb,0x11,0x01,0x48,0x8d,0x88,0x98,0x00,0x00,0x00,0xc5,0xfb,0x10,0x42,0x18,0xc5,0xfb,0x11,0x01,0x48,0x8d,0x88,0xa0,0x00,0x00,0x00,0xc5,0xfb,0x10,0x42,0x20,0xc5,0xfb,0x11,0x01,0x48,0x8d,0x88,0xa8,0x00,0x00,0x00,0xc5,0xfb,0x10,0x42,0x28,0xc5,0xfb,0x11,0x01,0x48,0x8d,0x88,0xb0,0x00,0x00,0x00,0xc5,0xfb,0x10,0x42,0x30,0xc5,0xfb,0x11,0x01,0x48,0x05,0xb8,0x00,0x00,0x00,0xc5,0xfb,0x10,0x42,0x38,0xc5,0xfb,0x11,0x00,0xc3
# EntryAddress  :7ffb723a8168h
# TargetAddress :7ffb723a8fe0h
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
vzeroupper                                    # 0000h  | 3   | c5 f8 77                         | (VZEROUPPER) = VEX.128.0F.WIG 77
mov rax,[rdx]                                 # 0003h  | 3   | 48 8b 02                         | (MOV r64, r/m64) = REX.W 8B /r
mov rdx,[rcx]                                 # 0006h  | 3   | 48 8b 11                         | (MOV r64, r/m64) = REX.W 8B /r
lea rcx,[rax+80h]                             # 0009h  | 7   | 48 8d 88 80 00 00 00             | (LEA r64, m) = REX.W 8D /r
vmovsd xmm0,qword ptr [rdx]                   # 0010h  | 4   | c5 fb 10 02                      | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx],xmm0                   # 0014h  | 4   | c5 fb 11 01                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
lea rcx,[rax+88h]                             # 0018h  | 7   | 48 8d 88 88 00 00 00             | (LEA r64, m) = REX.W 8D /r
vmovsd xmm0,qword ptr [rdx+8]                 # 001fh  | 5   | c5 fb 10 42 08                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx],xmm0                   # 0024h  | 4   | c5 fb 11 01                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
lea rcx,[rax+90h]                             # 0028h  | 7   | 48 8d 88 90 00 00 00             | (LEA r64, m) = REX.W 8D /r
vmovsd xmm0,qword ptr [rdx+10h]               # 002fh  | 5   | c5 fb 10 42 10                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx],xmm0                   # 0034h  | 4   | c5 fb 11 01                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
lea rcx,[rax+98h]                             # 0038h  | 7   | 48 8d 88 98 00 00 00             | (LEA r64, m) = REX.W 8D /r
vmovsd xmm0,qword ptr [rdx+18h]               # 003fh  | 5   | c5 fb 10 42 18                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx],xmm0                   # 0044h  | 4   | c5 fb 11 01                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
lea rcx,[rax+0a0h]                            # 0048h  | 7   | 48 8d 88 a0 00 00 00             | (LEA r64, m) = REX.W 8D /r
vmovsd xmm0,qword ptr [rdx+20h]               # 004fh  | 5   | c5 fb 10 42 20                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx],xmm0                   # 0054h  | 4   | c5 fb 11 01                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
lea rcx,[rax+0a8h]                            # 0058h  | 7   | 48 8d 88 a8 00 00 00             | (LEA r64, m) = REX.W 8D /r
vmovsd xmm0,qword ptr [rdx+28h]               # 005fh  | 5   | c5 fb 10 42 28                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx],xmm0                   # 0064h  | 4   | c5 fb 11 01                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
lea rcx,[rax+0b0h]                            # 0068h  | 7   | 48 8d 88 b0 00 00 00             | (LEA r64, m) = REX.W 8D /r
vmovsd xmm0,qword ptr [rdx+30h]               # 006fh  | 5   | c5 fb 10 42 30                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rcx],xmm0                   # 0074h  | 4   | c5 fb 11 01                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
add rax,0b8h                                  # 0078h  | 6   | 48 05 b8 00 00 00                | (ADD RAX, imm32) = REX.W 05 id
vmovsd xmm0,qword ptr [rdx+38h]               # 007eh  | 5   | c5 fb 10 42 38                   | (VMOVSD xmm1, m64) = VEX.LIG.F2.0F.WIG 10 /r
vmovsd qword ptr [rax],xmm0                   # 0083h  | 4   | c5 fb 11 00                      | (VMOVSD m64, xmm1) = VEX.LIG.F2.0F.WIG 11 /r
ret                                           # 0087h  | 1   | c3                               | (RET) = C3

