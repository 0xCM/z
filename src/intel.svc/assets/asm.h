#pragma once

#define not_inline __declspec(noinline)

enum class R8 : unsigned char  {al, cl,   dl,  bl,  bpl, spl, dil, sil, r8b, r9b, r10b, r11b, r12b, r13b, r14b, r15b, ah, ch, dh, bh, };

enum class R8L : unsigned char {al,  cl,  dl,  bl,  spl, bpl, sil, dil, r8b, r9b, r10b, r11b, r12b, r13b, r14b, r15b};

enum class R16 : unsigned char {ax,  cx,  dx,  bx,  sp,  bp,  si,  di,  r8w, r9w, r10w, r11w, r12w, r13w, r14w, r15w};

enum class R32 : unsigned char {eax, ecx, edx, ebx, esp, ebp, esi, edi, r8d, r9d, r10d, r11d, r12d, r13d, r14d, r15d};

enum class R64 : unsigned char {rax, rcx, rdx, rbx, rsp, rbp, rsi, rdi, r8,  r9,  r10,  r11,  r12,  r13,  r14,  r15};

typedef unsigned char u8;
typedef unsigned short u16;
typedef unsigned int u32;
typedef unsigned long long u64;

typedef char i8;
typedef short i16;
typedef int i32;
typedef long long i64;
typedef unsigned __int128 u128;
typedef __int128 i128;

typedef float f32;
typedef double f64;

// void f(int8_t a)
typedef void (*effect_8i)(i8 a);

// void f(u8 a)
typedef void (*effect_8u)(u8 a);

// void f(int16_t a)
typedef void (*effect_16i)(i16 a);

// void f(u16 a)
typedef void (*effect_16u)(u16 a);

// void f(int32_t a)
typedef void (*effect_32i)(i32 a);

// void f(u32 a)
typedef void (*effect_32u)(u32 a);

// void f(int32_t a)
typedef void (*effect_64i)(i64 a);

// void f(u32 a)
typedef void (*effect_64u)(u64 a);

// u8 f(u8 a)
typedef u8 (*func_8u_8u)(u8 a);

// u16 f(u16 a)
typedef u16 (*func_16u_16u)(u16 a);

// bool f(u8 a, u8 b)
typedef bool (*cmp_pred_8u)(u8 a, u8 b);

// bool f(int8_t a, int8_t b)
typedef bool (*cmp_pred_8i)(i8 a, i8 b);

// bool f(u16 a, u16 b)
typedef bool (*cmp_pred_16u)(u16 a, u16 b);

// bool f(int16_t a, int16_t b)
typedef bool (*cmp_pred_16i)(i16 a, i16 b);


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

typedef struct __declspec(align(16)) v128x8u {
    u8 u8[16];
} v128x8u;

typedef struct __declspec(align(16)) v128x8i {
    i8 i8[16];
} v128x8i;

typedef struct __declspec(align(16)) v128x16u {
    u16 u16[8];
} v128x16u;

typedef struct __declspec(align(16)) v128x16i {
    i16 i16[8];
} v128x16i;
