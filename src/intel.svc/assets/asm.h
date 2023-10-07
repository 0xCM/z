#pragma once

#include <stdint.h>

void printf(const char*, ...);

enum class R8 : unsigned char  {al, cl,   dl,  bl,  bpl, spl, dil, sil, r8b, r9b, r10b, r11b, r12b, r13b, r14b, r15b, ah, ch, dh, bh, };
enum class R8L : unsigned char {al,  cl,  dl,  bl,  spl, bpl, sil, dil, r8b, r9b, r10b, r11b, r12b, r13b, r14b, r15b};
enum class R16 : unsigned char {ax,  cx,  dx,  bx,  sp,  bp,  si,  di,  r8w, r9w, r10w, r11w, r12w, r13w, r14w, r15w};
enum class R32 : unsigned char {eax, ecx, edx, ebx, esp, ebp, esi, edi, r8d, r9d, r10d, r11d, r12d, r13d, r14d, r15d};
enum class R64 : unsigned char {rax, rcx, rdx, rbx, rsp, rbp, rsi, rdi, r8,  r9,  r10,  r11,  r12,  r13,  r14,  r15};
enum class Xmm : unsigned char {xmm0, xmm1, xmm2, xmm3, xmm4, xmm5, xmm6, xmm7, xmm8, xmm9, xmm10, xmm11, xmm12, xmm13, xmm14, xmm15, xmm16, xmm17, xmm18, xmm19, xmm20, xmm21, xmm22, xmm23, xmm24, xmm25, xmm26, xmm27, xmm28, xmm29, xmm30, xmm31};
enum class Ymm : unsigned char {ymm0, ymm1, ymm2, ymm3, ymm4, ymm5, ymm6, ymm7, ymm8, ymm9, ymm10, ymm11, ymm12, ymm13, ymm14, ymm15, ymm16, ymm17, ymm18, ymm19, ymm20, ymm21, ymm22, ymm23, ymm24, ymm25, ymm26, ymm27, ymm28, ymm29, ymm30, ymm31};
enum class Zmm : unsigned char {zmm0, zmm1, zmm2, zmm3, zmm4, zmm5, zmm6, zmm7, zmm8, zmm9, zmm10, zmm11, zmm12, zmm13, zmm14, zmm15, zmm16, zmm17, zmm18, zmm19, zmm20, zmm21, zmm22, zmm23, zmm24, zmm25, zmm26, zmm27, zmm28, zmm29, zmm30, zmm31};
enum class KReg : unsigned char {k0, k1, k2, k3, k4, k5, k6, k7};
enum class ControlReg : unsigned char {cr0, cr1, cr2, cr3, cr4, cr5, cr6, cr7};
enum class DebugReg : unsigned char {dr0, dr1, dr2, dr3, dr4, dr5, dr6, dr7};
enum class MmxReg : unsigned char {mmx0, mmx1, mmx2, mmx3, mmx4, mmx5, mmx6, mmx7};
enum class SegReg : unsigned char {cs, ds, ss, es, fs, gs};

#define alignment(n) __declspec(align(n))
#define notinline __declspec(noinline)

typedef unsigned char u8;
typedef unsigned short u16;
typedef unsigned int u32;
typedef unsigned long long u64;
typedef unsigned __int128 u128;

typedef char i8;
typedef short i16;
typedef int i32;
typedef long long i64;
typedef __int128 i128;

typedef float f32;
typedef double f64;

typedef struct u8x16 {
    u8 u8[16];
} u8x16;

typedef struct i8x16 {
    i8 i8[16];
} i8x16;

typedef struct u16x8 {
    u16 u16[8];
} u16x8;

typedef struct i16x8 {
    i16 i16[8];
} i16x8;

typedef struct u32x4 {
    u32 u32[4];
} u32x4;

typedef struct i32x4 {
    i32 i32[4];
} i32x4;

typedef struct u64x2 {
    u64 u64[2];
} u64x2;

typedef struct i64x2 {
    i64 i64[2];
} i64x2;

typedef struct f32x4 {
    f32 f32[4];
} f32x4;

typedef struct f64x2 {
    f64 f64[2];
} f64x4;

// v256

typedef struct u8x32 {
    u8 u8[32];
} u8x32;

typedef struct i8x32 {
    i8 i8[32];
} i8x32;

typedef struct u16x16 {
    u16 u16[16];
} u16x16;

typedef struct i16x16 {
    i16 i16[16];
} i16x16;

typedef struct u32x8 {
    u32 u32[8];
} u32x8;

typedef struct i32x8 {
    i32 i32[8];
} i32x8;

typedef struct u64x4 {
    u64 u64[4];
} u64x4;

typedef struct i64x4 {
    i64 i64[4];
} i64x4;

// v512

typedef struct u8x64 {
    u8 u8[64];
} u8x64;

typedef struct i8x64 {
    i8 i8[64];
} i8x64;

typedef struct u16x32 {
    u16 u16[32];
} u16x32;

typedef struct i16x32 {
    i16 i16[32];
} i16x32;

typedef struct u32x16 {
    u32 u32[16];
} u32x16;

typedef struct i32x16 {
    i32 i32[16];
} i32x16;

typedef struct u64x8 {
    u64 u64[8];
} u64x8;

typedef struct i64x8 {
    i64 i64[8];
} i64x8;

typedef union __declspec(align(16)) v128 {
    i8 i8[16];
    i16 i16[8];
    i32 i32[4];
    i64 i64[2];
    u8 u8[16];
    u16 u16[8];
    u32 u32[4];
    u64 u64[2];
    f32 f32[4];
    f64 f64[2];
} v128;

typedef union __declspec(align(32)) v256 {
    i8 i8[32];
    i16 i16[16];
    i32 i32[8];
    i64 i64[4];
    u8 u8[32];
    u16 u16[16];
    u32 u32[8];
    u64 u64[4];
    f32 f32[8];
    f64 f64[4];
} v256;

typedef union __declspec(align(32)) v512 {
    i8 i8[64];
    i16 i16[32];
    i32 i32[16];
    i64 i64[8];
    u8 u8[64];
    u16 u16[32];
    u32 u32[16];
    u64 u64[8];
    f32 f32[16];
    f64 f64[8];
} v512;

u64 read_rip();
u64 read_tsc();

u8 xor8rr(u8 a, u8 b);
u16 xor16rr(u16 a, u16);
uint32_t xor32rr(uint32_t a, uint32_t b);
u64 xor64rr(u64 a, u64 b);

u8 sub8rr(u8 a, u8 b);
u16 sub16rr(u16 a, u16 b);
uint32_t sub32rr(uint32_t a, uint32_t b);
u64 sub64rr(u64 a, u64 b);

u64 read_flags();

u64 asm_read_r8();
u64 asm_read_r9();
u64 asm_read_r10();
u64 asm_read_r11();
u64 asm_read_r12();
u64 asm_read_r13();
u64 asm_read_r14();
u64 asm_read_r15();
u64 asm_read_rax();
u64 asm_read_rcx();
u64 asm_read_rdx();
u64 asm_read_rbx();
u64 asm_read_rsp();
u64 asm_read_rbp();
u64 asm_read_rsi();
u64 asm_read_rdi();

u8 asm_read_al();
u8 asm_read_cl();
u8 asm_read_dl();
u8 asm_read_bl();

u8 asm_read_ah();
u8 asm_read_ch();
u8 asm_read_dh();
u8 asm_read_bh();

u8 asm_read_spl();
u8 asm_read_bpl();
u8 asm_read_sil();
u8 asm_read_dil();
u8 asm_read_r8b();
u8 asm_read_r9b();
u8 asm_read_r10b();
u8 asm_read_r11b();
u8 asm_read_r12b();
u8 asm_read_r13b();
u8 asm_read_r14b();
u8 asm_read_r15b();

void asm_write_r8(u64 src);
void asm_write_r9(u64 src);
void asm_write_r10(u64 src);
void asm_write_r11(u64 src);
void asm_write_r12(u64 src);
void asm_write_r13(u64 src);
void asm_write_r14(u64 src);
void asm_write_r15(u64 src);
