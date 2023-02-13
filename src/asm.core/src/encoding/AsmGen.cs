//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;
    using static AsmSigTokens;
    using static AsmSigTokens.RegLiteralToken;
    using static AsmRegOps;

    using GpRT = AsmSigTokens.GpRegToken;
    using VRT = AsmSigTokens.VRegToken;
    using TK = AsmSigTokenKind;
    using MT = AsmSigTokens.MemToken;
    using ImmT = AsmSigTokens.ImmToken;
    using SZ = NativeSizeCode;

    public class AsmGen
    {
        public static AsmGen generator()
            => new AsmGen(new AsmGenContext());

        AsmRegSets RegSets;

        AsmGenContext Context;

        Index<AsmOperand> _OpsBuffer;

        AsmGen(AsmGenContext context)
        {
            RegSets = AsmRegSets.create();
            Context = context;
            _OpsBuffer = alloc<AsmOperand>(2048);
        }

        Span<AsmOperand> OpBuffer()
            => _OpsBuffer.Clear();

        public Index<AsmInstruction> Concretize(in SdmForm form)
        {
            var dst = list<AsmInstruction>();
            ref readonly var sigops = ref form.Sig.Operands;
            var opcount = sigops.OpCount;
            var lookup = alloc<Index<AsmOperand>>(5);
            for(byte i=0; i<opcount; i++)
            {
                var buffer = OpBuffer();
                var count = Concretize(sigops[i], buffer);
                lookup[i] = slice(buffer,0, count).ToArray();
            }

            switch(opcount)
            {
                case 0:
                {
                    dst.Add(AsmSpecs.inst(form.Mnemonic, form.OpCode, AsmOperands.Empty));
                }
                break;
                case 1:
                {
                    var ops0 = skip(lookup,0);
                    for(var a=0; a<ops0.Count; a++)
                    {
                        dst.Add(AsmSpecs.inst(form.Mnemonic, form.OpCode, ops0[a], out _));
                    }

                }
                break;
                case 2:
                {
                    var ops0 = skip(lookup,0);
                    var ops1 = skip(lookup,1);
                    for(var a=0; a<ops0.Count; a++)
                    for(var b=0; b<ops1.Count; b++)
                    {
                        dst.Add(AsmSpecs.inst(form.Mnemonic, form.OpCode, ops0[a], ops1[b], out _));
                    }
                }
                break;
                case 3:
                {
                    var ops0 = skip(lookup,0);
                    var ops1 = skip(lookup,1);
                    var ops2 = skip(lookup,2);
                    for(var a=0; a<ops0.Count; a++)
                    for(var b=0; b<ops1.Count; b++)
                    for(var c=0; c<ops1.Count; c++)
                    {
                        dst.Add(AsmSpecs.inst(form.Mnemonic, form.OpCode, ops0[a], ops1[b], ops2[c], out _));
                    }
                }
                break;
                case 4:
                {
                    var ops0 = skip(lookup,0);
                    var ops1 = skip(lookup,1);
                    var ops2 = skip(lookup,2);
                    var ops3 = skip(lookup,3);
                    for(var a=0; a<ops0.Count; a++)
                    for(var b=0; b<ops1.Count; b++)
                    for(var c=0; c<ops2.Count; c++)
                    for(var d=0; d<ops3.Count; d++)
                    {
                        dst.Add(AsmSpecs.inst(form.Mnemonic, form.OpCode, ops0[a], ops1[b], ops2[c], ops3[d], out _));
                    }
                }
                break;
            }

            return dst.ToArray();
        }

        public uint Concretize(in AsmSigOp src, Span<AsmOperand> dst)
        {
            var i=0u;
            return Concretize(src, ref i, dst);
        }

        public uint Concretize(in AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var kind = src.Kind;
            switch(kind)
            {
                case TK.GpReg:
                    GpRegs(src, ref i, dst);
                    break;
                case TK.VReg:
                    VRegs(src, ref i, dst);
                    break;
                case TK.MmxReg:
                    MmxRegs(src, ref i, dst);
                    break;
                case TK.KReg:
                    KRegs(src, ref i, dst);
                    break;
                case TK.Imm:
                    ImmValues(src, ref i, dst);
                    break;
                case TK.Mem:
                    MemValues(src, ref i, dst);
                    break;
                case TK.RegLiteral:
                    RegLiterals(src, ref i, dst);
                    break;
            }

            return i-i0;
        }

        uint GpRegs(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var set = Regs((GpRegToken)src.Value);
            convert(set, ref i, dst);
            return i-i0;
        }

        uint KRegs(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var regs = RegSets.MaskRegs();
            if(src.IsMasked)
                Apply(MaskKind(src.Modifier), regs, ref i, dst);
            else
                convert(regs, ref i, dst);
            return i-i0;
        }

        uint VRegs(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var token = (VRegToken)src.Value;
            var regs = Regs(token);
            if(src.IsMasked)
                Apply(MaskKind(src.Modifier), regs, ref i, dst);
            else
                convert(regs, ref i, dst);
            return i-i0;
        }

        uint RegLiterals(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var token = (RegLiteralToken)src.Value;
            switch(token)
            {
                case AL:
                    seek(dst, i++) = AsmRegOps.al;
                break;
                case CL:
                    seek(dst, i++) = AsmRegOps.cl;
                break;
                case AX:
                    seek(dst, i++) = AsmRegOps.ax;
                break;
                case DX:
                    seek(dst, i++) = AsmRegOps.dx;
                break;
                case EAX:
                    seek(dst, i++) = AsmRegOps.eax;
                break;
                case EDX:
                    seek(dst, i++) = AsmRegOps.edx;
                break;
                case RAX:
                    seek(dst, i++) = AsmRegOps.rax;
                break;
                case CS:
                    seek(dst, i++) = AsmRegOps.cs;
                break;
                case DS:
                    seek(dst, i++) = AsmRegOps.ds;
                break;
                case SS:
                    seek(dst, i++) = AsmRegOps.ss;
                break;
                case ES:
                    seek(dst, i++) = AsmRegOps.es;
                break;
                case FS:
                    seek(dst, i++) = AsmRegOps.fs;
                break;
                case GS:
                    seek(dst, i++) = AsmRegOps.gs;
                break;
            }

            return i-i0;
        }

        uint ImmValues(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            switch((ImmToken)src.Value)
            {
                case ImmT.imm8:
                    seek(dst,i++) = asm.imm8(0x73);
                break;
                case ImmT.imm16:
                    seek(dst,i++) = asm.imm16(0x7373);
                break;
                case ImmT.imm32:
                    seek(dst,i++) = asm.imm32(0x73737373);
                break;
                case ImmT.imm64:
                    seek(dst,i++) = asm.imm64(0x7373737373737373);
                break;
            }

            return i-i0;
        }

        uint MemValues(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var bases = array<RegOp>(r8,r9);
            var indices = array<RegOp>(rcx,rdx);
            var count = 2;
            switch((MemToken)src.Value)
            {
                case MT.m8:
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var @base = ref skip(bases,j);
                        seek(dst,i++) = asm.mem8(@base);
                        for(var k=0; k<count; k++)
                        {
                            seek(dst,i++) = asm.mem8(@base, skip(indices,k));
                        }
                    }
                break;
                case MT.m16:
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var @base = ref skip(bases,j);
                        seek(dst,i++) = asm.mem16(@base);
                        for(var k=0; k<count; k++)
                        {
                            seek(dst,i++) = asm.mem16(@base, skip(indices,k));
                        }
                    }
                break;
                case MT.m32:
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var @base = ref skip(bases,j);
                        seek(dst,i++) = asm.mem(SZ.W32, @base);
                        for(var k=0; k<count; k++)
                        {
                            ref readonly var index = ref skip(indices,k);
                            seek(dst,i++) = asm.mem(SZ.W32, @base, index);
                            seek(dst,i++) = asm.mem(SZ.W32, @base, index, asm.disp8(-0x73));
                            seek(dst,i++) = asm.mem(SZ.W32, @base, index, asm.disp8(0x73));
                        }
                    }
                break;
                case MT.m64:
                    for(var j=0; j<count; j++)
                        seek(dst,i++) = asm.mem64(skip(bases,j));
                break;
                case MT.m128:
                    for(var j=0; j<count; j++)
                        seek(dst,i++) = asm.mem128(skip(bases,j));
                break;
                case MT.m256:
                    for(var j=0; j<count; j++)
                        seek(dst,i++) = asm.mem256(skip(bases,j));
                break;
                case MT.m512:
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var @base = ref skip(bases,j);
                        seek(dst,i++) = asm.mem(SZ.W512, @base);
                        for(var k=0; k<count; k++)
                        {
                            seek(dst,i++) = asm.mem(SZ.W512, @base, skip(indices,k));
                        }
                    }
                break;
            }

            return 0;
        }

        uint MmxRegs(AsmSigOp src, ref uint i,Span<AsmOperand> dst)
        {
            var i0 = i;
            var sets = AsmRegSets.create();
            var set = sets.MmxRegs();
            convert(set, ref i, dst);
            return i-i0;
        }

        RegOpSeq Regs(GpRegToken src)
        {
            var set = RegOpSeq.Empty;
            switch(src)
            {
                case GpRT.r8:
                    set = RegSets.Gp8LoRegs();
                break;
                case GpRT.r16:
                    set = RegSets.Gp16Regs();
                break;
                case GpRT.r32:
                    set = RegSets.Gp32Regs();
                break;
                case GpRT.r64:
                    set = RegSets.Gp64Regs();
                break;
            }
            return set;
        }

        RegOpSeq Regs(VRegToken src)
        {
            var set = RegOpSeq.Empty;
            switch(src)
            {
                case VRT.xmm:
                    set = RegSets.XmmRegs();
                break;
                case VRT.ymm:
                    set = RegSets.YmmRegs();
                break;
                case VRT.zmm:
                    set = RegSets.ZmmRegs();
                break;
            }
            return set;
        }

        void Apply(RegMaskKind mask, RegOpSeq regs, ref uint i, Span<AsmOperand> dst)
        {
            var kregs = RegSets.MaskRegs();
            for(var j=0; j<regs.Count; j++)
            {
                ref readonly var target = ref regs[j];
                for(var k=0; k<kregs.Count; k++)
                    seek(dst,i++) = asm.regmask(target, kregs[k].Index, mask);
            }
        }

        static RegMaskKind MaskKind(AsmModifierKind src)
        {
            var dst = RegMaskKind.None;
            switch(src)
            {
                case AsmModifierKind.k1:
                    dst = RegMaskKind.k1;
                break;
                case AsmModifierKind.k1z:
                    dst = RegMaskKind.k1z;
                break;
                case AsmModifierKind.z:
                    dst = RegMaskKind.z;
                break;
                case AsmModifierKind.k2:
                    dst = RegMaskKind.k2;
                break;
            }
            return dst;
        }

        static void convert(RegOpSeq src, ref uint i, Span<AsmOperand> dst)
        {
            var count = src.Count;
            for(var j=0; j<count; j++)
                seek(dst,i++) = src[j];
        }
    }
}