//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;
    using static XedModels;
    using static XedLiterals;

    using M = XedModels;

    partial class XedOps
    {
        public readonly struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref AsmInstClass iclass(ref OperandState src)
                => ref @as<AsmInstKind,AsmInstClass>(src.ICLASS);

            [MethodImpl(Inline), Op]
            public static ref AsmVL vl(ref OperandState src)
                => ref @as<AsmVL>(src.VL);

            [MethodImpl(Inline), Op]
            public static ref XedVexKind vexkind(ref OperandState src)
                => ref @as<XedVexKind>(src.VEX_PREFIX);

            [MethodImpl(Inline), Op]
            public static ref RoundingKind rounding(ref OperandState src)
                => ref @as<RoundingKind>(src.ROUNDC);

            [MethodImpl(Inline), Op]
            public static ref MachineMode mode(ref OperandState src)
                => ref @as<MachineMode>(src.MODE);

            [MethodImpl(Inline), Op]
            public static ref XedVexClass vexclass(ref OperandState src)
                => ref @as<XedVexClass>(src.VEXVALID);

            [MethodImpl(Inline), Op]
            public static ref bit rexb(ref OperandState src)
                => ref src.REXB;

            [MethodImpl(Inline), Op]
            public static ref bit rexr(ref OperandState src)
                => ref src.REXR;

            [MethodImpl(Inline), Op]
            public static ref bit rexx(ref OperandState src)
                => ref src.REXX;

            [MethodImpl(Inline), Op]
            public static ref bit rexw(ref OperandState src)
                => ref src.REXW;

            [MethodImpl(Inline), Op]
            public static ref readonly RexPrefix rex(in RexPrefix src, ref OperandState dst)
            {
                dst.REX = bit.On;
                dst.REXW = src.W;
                dst.REXR = src.R;
                dst.REXX = src.X;
                dst.REXB = src.B;
                return ref src;
            }

            public static ref Register reg(byte n, ref OperandState dst)
            {
                switch(n)
                {
                    default:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 1:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 2:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 3:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 4:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 5:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 6:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 7:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 8:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 9:
                        return ref @as<XedRegId,Register>(dst.REG9);
                }
            }

            [Op]
            public static ref readonly XedRegs regs(in XedRegs src, ref OperandState dst)
            {
                for(byte i=0; i<src.Count; i++)
                    reg(i, ref dst) = @as<XedRegId,Register>(src[i]);
                return ref src;
            }

            [MethodImpl(Inline), Op]
            public static ref HintKind hint(ref OperandState src)
                => ref @as<HintKind>(src.HINT);

            [MethodImpl(Inline), Op]
            public static ref ModRm modrm(ref OperandState dst)
                => ref @as<Hex8,ModRm>(dst.MODRM_BYTE);

            [MethodImpl(Inline), Op]
            public static ref M.RepPrefix rep(ref OperandState src)
                => ref @as<M.RepPrefix>(src.REP);

            [MethodImpl(Inline), Op]
            public static ref BCastKind broadcast(ref OperandState src)
                => ref @as<BCastKind>(src.BCAST);

            [MethodImpl(Inline), Op]
            public static ref EASZ easz(ref OperandState src)
                => ref @as<EASZ>(src.EASZ);

            [MethodImpl(Inline), Op]
            public static ref EOSZ eosz(ref OperandState src)
                => ref @as<EOSZ>(src.EOSZ);

            [MethodImpl(Inline), Op]
            public static ref ESRC esrc(ref OperandState src)
                => ref @as<ESRC>(src.ESRC);

            [MethodImpl(Inline), Op]
            public static ref bit mask(ref OperandState src)
                => ref src.MASK;

            [MethodImpl(Inline), Op]
            public static ref byte ocbyte(ref OperandState src)
                => ref src.NOMINAL_OPCODE;

            [MethodImpl(Inline), Op]
            public static ref XedMapNumber ocmap(ref OperandState src)
                => ref @as<XedMapNumber>(src.MAP);

            [MethodImpl(Inline), Op]
            public static ref SegDefaultKind segdefault(ref OperandState src)
                => ref @as<SegDefaultKind>(src.DEFAULT_SEG);

            [MethodImpl(Inline), Op]
            public static ref MemoryScale scale(ref OperandState src)
                => ref @as<MemoryScale>(src.SCALE);

            [MethodImpl(Inline), Op]
            public static ref Register outreg(ref OperandState src)
                => ref @as<XedRegId,Register>(src.OUTREG);

            [MethodImpl(Inline), Op]
            public static ref readonly Sib sib(in Sib src, ref OperandState dst)
            {
                dst.HAS_SIB = bit.On;
                dst.SIBSCALE = src.Scale;
                dst.SIBINDEX = src.Index;
                dst.SIBBASE = src.Base;
                return ref src;
            }

            [MethodImpl(Inline), Op]
            public static ref OperandState set(AsmOpCodeIndex src, ref OperandState dst)
            {
                AsmOpCodeMaps.map(src, out var map);
                dst.MAP = (byte)map;
                dst.VEXVALID = (byte)AsmOpCodeMaps.vexclass(src);
                return ref dst;
            }
        }
    }
}