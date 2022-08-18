//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static AsmOpCodeMaps;
    using static XedLiterals;
    using static core;

    using M = XedModels;

    partial class XedOps
    {
        public readonly struct View
        {
            [MethodImpl(Inline), Op]
            public static AsmOpCodeIndex ocindex(in OperandState state)
            {
                var dst = AsmOpCodeIndex.Amd3dNow;
                ref readonly var map = ref state.MAP;
                ref readonly var vc = ref XedOps.View.vexclass(state);
                switch(vc)
                {
                    case XedVexClass.VV1:
                        dst = index((VexMapKind)map);
                        break;
                    case XedVexClass.EVV:
                        dst = index((EvexMapKind)map);
                        break;
                    case XedVexClass.XOPV:
                        dst = index((XopMapKind)map);
                        break;
                    default:
                        dst = (AsmOpCodeIndex)map;
                        break;
                }

                return dst;
            }

            [MethodImpl(Inline), Op]
            public static ref readonly XedVexKind vexkind(in OperandState src)
                => ref @as<XedVexKind>(src.VEX_PREFIX);

            [MethodImpl(Inline), Op]
            public static ref readonly XedVexClass vexclass(in OperandState src)
                => ref @as<XedVexClass>(src.VEXVALID);

            [MethodImpl(Inline), Op]
            public static ref readonly AsmInstClass iclass(in OperandState src)
                => ref @as<InstClassType,AsmInstClass>(src.ICLASS);

            [MethodImpl(Inline), Op]
            public static ref readonly BCastKind broadcast(in OperandState src)
                => ref @as<BCastKind>(src.BCAST);

            [MethodImpl(Inline), Op]
            public static ref readonly Hex8 ocbyte(in OperandState src)
                => ref @as<Hex8>(src.NOMINAL_OPCODE);

            [MethodImpl(Inline), Op]
            public static ref readonly AsmVL vl(in OperandState src)
                => ref @as<AsmVL>(src.VL);
            [Op]
            public static XedRegs regs(in OperandState src)
            {
                var storage = ByteBlock32.Empty;
                var dst = recover<XedRegId>(storage.Bytes);
                var count = z8;
                if(src.REG0 != 0)
                    seek(dst,count++) = src.REG0;
                if(src.REG1 != 0)
                    seek(dst,count++) = src.REG1;
                if(src.REG2 != 0)
                    seek(dst,count++) = src.REG2;
                if(src.REG3 != 0)
                    seek(dst,count++) = src.REG3;
                if(src.REG4 != 0)
                    seek(dst,count++) = src.REG4;
                if(src.REG5 != 0)
                    seek(dst,count++) = src.REG5;
                if(src.REG6 != 0)
                    seek(dst,count++) = src.REG6;
                if(src.REG7 != 0)
                    seek(dst,count++) = src.REG7;
                if(src.REG8 != 0)
                    seek(dst,count++) = src.REG8;
                if(src.REG9 != 0)
                    seek(dst,count++) = src.REG9;
                storage[31] = count;
                return @as<XedRegs>(storage.Bytes);
            }

            [MethodImpl(Inline), Op]
            public static ref readonly RoundingKind rounding(in OperandState src)
                => ref @as<RoundingKind>(src.ROUNDC);

            [MethodImpl(Inline), Op]
            public static Sib sib(in OperandState src)
                => new Sib(src.SIBBASE, src.SIBINDEX, src.SIBSCALE);

            [MethodImpl(Inline), Op]
            public static ref readonly ModRm modrm(in OperandState src)
                => ref @as<Hex8,ModRm>(src.MODRM_BYTE);

            [MethodImpl(Inline), Op]
            public static RexPrefix rex(in OperandState src)
                => new RexPrefix(src.REXB, src.REXX, src.REXR, src.REXW);

            [MethodImpl(Inline), Op]
            public static ref readonly HintKind hint(in OperandState src)
                => ref @as<HintKind>(src.HINT);

            [MethodImpl(Inline), Op]
            public static ref readonly M.RepPrefix rep(in OperandState src)
                => ref @as<M.RepPrefix>(src.REP);

            [MethodImpl(Inline), Op]
            public static ref readonly EASZ easz(in OperandState src)
                => ref @as<EASZ>(src.EASZ);

            [MethodImpl(Inline), Op]
            public static ref readonly EOSZ eosz(in OperandState src)
                => ref @as<EOSZ>(src.EOSZ);
            [MethodImpl(Inline), Op]
            public static ref readonly MachineMode mode(in OperandState src)
                => ref @as<MachineMode>(src.MODE);
        }
    }
}