//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static AsmSigTokens;
using static AsmSigTokens.BCastComposite;
using static AsmSigTokens.KRmToken;
using static AsmSigTokens.GpRmToken;
using static AsmSigTokens.VecRmToken;
using static AsmSigTokens.GpRegTriple;
using static AsmSigTokens.GpRmTriple;
using static AsmSigTokens.MemToken;
using static AsmSigTokens.KRegToken;
using static AsmSigTokens.GpRegToken;
using static AsmSigTokens.VRegToken;
using static AsmSigTokens.BCastMem;

using K = AsmSigTokenKind;

// public class AsmSigDatasets
// {
//     [MethodImpl(Inline)]
//     public static AsmSigToken token<T>(K kind, T value)
//         where T : unmanaged
//             => new (kind, u8(value));


//     public Index<AsmSigOp> Tokens {get; private set;}

//     public ConstLookup<uint,string> Expressions {get; private set;}

//     public ConstLookup<uint,string> Names {get; private set;}

//     public ConstLookup<string,AsmSigOp> OpsByExpression {get; private set;}

//     public Symbols<AsmModifierKind> Modifers {get; private set;}

//     public ConstLookup<Type,AsmSigTokenKind> TypeKinds {get; private set;}

//     public ConstLookup<uint,AsmSigNonterminal> Nonterminals {get; private set;}

//     public Index<AsmTokenRecord> Records {get; private set;}

//     AsmSigDatasets()
//     {
//     }


//     public static uint nonterminals(Span<AsmSigNonterminal> buffer)
//     {
//         var i=0u;
//         var dst = new AsmSigNonterminal();
//         dst.Source = token(K.BCastComposite, x128x32bcst);
//         dst.Term1 = token(K.VReg, xmm);
//         dst.Term2 = token(K.Mem, m128);
//         dst.Term3 = token(K.BCastMem, m32bcst);
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.BCastComposite, x128x64bcst);
//         dst.Term1 = token(K.VReg, xmm);
//         dst.Term2 = token(K.Mem, m128);
//         dst.Term3 = token(K.BCastMem, m64bcst);
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.BCastComposite, y256x32bcst);
//         dst.Term1 = token(K.VReg, ymm);
//         dst.Term2 = token(K.Mem, m256);
//         dst.Term3 = token(K.BCastMem, m32bcst);
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.BCastComposite, y256x64bcst);
//         dst.Term1 = token(K.VReg, ymm);
//         dst.Term2 = token(K.Mem, m256);
//         dst.Term3 = token(K.BCastMem, m64bcst);
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.BCastComposite, z512x32bcst);
//         dst.Term1 = token(K.VReg, zmm);
//         dst.Term2 = token(K.Mem, m512);
//         dst.Term3 = token(K.BCastMem, m32bcst);
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.BCastComposite, z512x64bcst);
//         dst.Term1 = token(K.VReg, zmm);
//         dst.Term2 = token(K.Mem, m512);
//         dst.Term3 = token(K.BCastMem, m64bcst);
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, rm8);
//         dst.Term1 = token(K.GpReg, r8);
//         dst.Term2 = token(K.Mem, m8);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, rm16);
//         dst.Term1 = token(K.GpReg, r16);
//         dst.Term2 = token(K.Mem, m16);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, rm32);
//         dst.Term1 = token(K.GpReg, r32);
//         dst.Term2 = token(K.Mem, m32);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, rm64);
//         dst.Term1 = token(K.GpReg, r64);
//         dst.Term2 = token(K.Mem, m64);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, r16m16);
//         dst.Term1 = token(K.GpReg, r16);
//         dst.Term2 = token(K.Mem, m16);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, r32m8);
//         dst.Term1 = token(K.GpReg, r32);
//         dst.Term2 = token(K.Mem, m8);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, r32m16);
//         dst.Term1 = token(K.GpReg, r32);
//         dst.Term2 = token(K.Mem, m16);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, r32m32);
//         dst.Term1 = token(K.GpReg, r32);
//         dst.Term2 = token(K.Mem, m32);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, r64m16);
//         dst.Term1 = token(K.GpReg, r64);
//         dst.Term2 = token(K.Mem, m16);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, r64m32);
//         dst.Term1 = token(K.GpReg, r64);
//         dst.Term2 = token(K.Mem, m32);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, r64m64);
//         dst.Term1 = token(K.GpReg, r64);
//         dst.Term2 = token(K.Mem, m64);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, regm8);
//         dst.Term1 = token(K.GpReg, r8);
//         dst.Term2 = token(K.Mem, m8);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRm, regm16);
//         dst.Term1 = token(K.GpReg, r16);
//         dst.Term2 = token(K.Mem, m16);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.KRm, km8);
//         dst.Term1 = token(K.GpReg, k1);
//         dst.Term2 = token(K.Mem, m8);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.KRm, km16);
//         dst.Term1 = token(K.GpReg, k1);
//         dst.Term2 = token(K.Mem, m16);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.KRm, km32);
//         dst.Term1 = token(K.GpReg, k1);
//         dst.Term2 = token(K.Mem, m32);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.KRm, km64);
//         dst.Term1 = token(K.GpReg, k1);
//         dst.Term2 = token(K.Mem, m64);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.VecRm, xmm8);
//         dst.Term1 = token(K.GpReg, xmm);
//         dst.Term2 = token(K.Mem, m8);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.VecRm, xmm16);
//         dst.Term1 = token(K.GpReg, xmm);
//         dst.Term2 = token(K.Mem, m16);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.VecRm, xmm32);
//         dst.Term1 = token(K.GpReg, xmm);
//         dst.Term2 = token(K.Mem, m32);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.VecRm, xmm64);
//         dst.Term1 = token(K.GpReg, xmm);
//         dst.Term2 = token(K.Mem, m64);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.VecRm, xmm128);
//         dst.Term1 = token(K.GpReg, xmm);
//         dst.Term2 = token(K.Mem, m128);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.VecRm, ymm256);
//         dst.Term1 = token(K.GpReg, ymm);
//         dst.Term2 = token(K.Mem, m256);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.VecRm, zmm512);
//         dst.Term1 = token(K.GpReg, zmm);
//         dst.Term2 = token(K.Mem, m512);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRegTriple, r16r32r64);
//         dst.Term1 = token(K.GpReg, r16);
//         dst.Term2 = token(K.Mem, r32);
//         dst.Term3 = token(K.Mem, r64);
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.GpRmTriple, r16r32m16);
//         dst.Term1 = token(K.GpReg, r16);
//         dst.Term2 = token(K.Mem, r32);
//         dst.Term3 = token(K.Mem, m16);
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.MmxRm, MmxRmToken.mm32);
//         dst.Term1 = token(K.GpReg, MmxRegToken.mm);
//         dst.Term2 = token(K.Mem, m32);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         dst.Source = token(K.MmxRm, MmxRmToken.mm64);
//         dst.Term1 = token(K.GpReg, MmxRegToken.mm);
//         dst.Term2 = token(K.Mem, m64);
//         dst.Term3 = AsmSigToken.Empty;
//         seek(buffer,i++) = dst;

//         return i;
//     }
// }
