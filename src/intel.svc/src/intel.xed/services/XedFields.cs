//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static AsmOpCodes;
using static XedRules;

using static sys;

using M = XedModels;
using K = XedRules.FieldKind;

public partial class XedFields
{
    public static bool reg(K field, string value, out FieldValue dst)
    {
        var result = false;
        dst = FieldValue.Empty;
        if(XedParsers.IsNonterm(value))
        {
            result = XedParsers.parse(value, out RuleName name);
            dst = new(field, name);
        }
        else if(XedParsers.parse(value, out XedRegId reg))
        {
            dst = new (field, reg);
            result = true;
        }
        else if(XedParsers.parse(value, out RuleKeyword kw))
        {
            dst = new(kw);
            result = true;
        }
        return result;
    }    
    [MethodImpl(Inline), Op]
    public static ref readonly XedVexKind vexkind(in XedFieldState src)
        => ref @as<XedVexKind>(src.VEX_PREFIX);

    [MethodImpl(Inline), Op]
    public static ref readonly XedVexClass vexclass(in XedFieldState src)
        => ref @as<XedVexClass>(src.VEXVALID);

    [MethodImpl(Inline), Op]
    public static ref readonly XedInstClass iclass(in XedFieldState src)
        => ref @as<XedInstKind,XedInstClass>(src.ICLASS);

    [MethodImpl(Inline), Op]
    public static AsmBroadcast broadcast(in XedFieldState src)
        => asm.broadcast(@as<BroadcastKind>(src.BCAST));

    [MethodImpl(Inline), Op]
    public static ref readonly Hex8 ocbyte(in XedFieldState src)
        => ref @as<Hex8>(src.NOMINAL_OPCODE);

    [MethodImpl(Inline), Op]
    public static ref readonly AsmVL vl(in XedFieldState src)
        => ref @as<AsmVL>(src.VL);

    [MethodImpl(Inline), Op]
    public static AsmOpCodeIndex ocindex(in XedFieldState state)
    {
        var dst = AsmOpCodeIndex.Amd3dNow;
        ref readonly var map = ref state.MAP;
        ref readonly var vc = ref vexclass(state);
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

    [Op]
    public static XedRegs regs(in XedFieldState src)
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
    public static ref readonly RoundingKind rounding(in XedFieldState src)
        => ref @as<RoundingKind>(src.ROUNDC);

    [MethodImpl(Inline), Op]
    public static Sib sib(in XedFieldState src)
        => new (src.SIBBASE, src.SIBINDEX, src.SIBSCALE);

    [MethodImpl(Inline), Op]
    public static ref readonly ModRm modrm(in XedFieldState src)
        => ref @as<Hex8,ModRm>(src.MODRM_BYTE);

    [MethodImpl(Inline), Op]
    public static RexPrefix rex(in XedFieldState src)
        => new (src.REXB, src.REXX, src.REXR, src.REXW);

    [MethodImpl(Inline), Op]
    public static ref readonly HintKind hint(in XedFieldState src)
        => ref @as<HintKind>(src.HINT);

    [MethodImpl(Inline), Op]
    public static ref readonly M.RepPrefix rep(in XedFieldState src)
        => ref @as<M.RepPrefix>(src.REP);

    [MethodImpl(Inline), Op]
    public static ref readonly EASZ easz(in XedFieldState src)
        => ref @as<EASZ>(src.EASZ);

    [MethodImpl(Inline), Op]
    public static ref readonly EOSZ eosz(in XedFieldState src)
        => ref @as<EOSZ>(src.EOSZ);

    [MethodImpl(Inline), Op]
    public static ref readonly MachineMode mode(in XedFieldState src)
        => ref @as<MachineMode>(src.MODE);        


    [Op]
    public static FieldValue extract(in XedFieldState src, FieldKind kind)
    {
        var dst = FieldValue.Empty;
        switch(kind)
        {
            case K.AMD3DNOW:
                dst = new (kind, src.AMD3DNOW);
            break;

            case K.ASZ:
                dst = new (kind, src.ASZ);
            break;

            case K.BASE0:
                dst = new (kind, src.BASE0);
            break;

            case K.BASE1:
                dst = new (kind, src.BASE1);
            break;

            case K.BCAST:
                dst = new (kind, src.BCAST);
            break;

            case K.BCRC:
                dst = new (kind, src.BCRC);
            break;

            case K.RELBR:
                dst = new (kind, src.RELBR);
            break;

            case K.BRDISP_WIDTH:
                dst = new (kind, src.BRDISP_WIDTH);
            break;

            case K.CET:
                dst = new (kind, src.CET);
            break;

            case K.CHIP:
                dst = new (kind, src.CHIP);
            break;

            case K.CLDEMOTE:
                dst = new (kind, src.CLDEMOTE);
            break;

            case K.DEFAULT_SEG:
                dst = new (kind, src.DEFAULT_SEG);
            break;

            case K.DF32:
                dst = new (kind, src.DF32);
            break;

            case K.DF64:
                dst = new (kind, src.DF64);
            break;

            case K.DISP:
                dst = new (kind, src.DISP);
            break;

            case K.DISP_WIDTH:
                dst = new (kind, src.DISP_WIDTH);
            break;

            case K.DUMMY:
                dst = new (kind, src.DUMMY);
            break;

            case K.EASZ:
                dst = new (kind, src.EASZ);
            break;

            case K.ELEMENT_SIZE:
                dst = new (kind, src.ELEMENT_SIZE);
            break;

            case K.ENCODER_PREFERRED:
                dst = new (kind, src.ENCODER_PREFERRED);
            break;

            case K.ENCODE_FORCE:
                dst = new (kind, src.ENCODE_FORCE);
            break;

            case K.EOSZ:
                dst = new (kind, src.EOSZ);
            break;

            case K.ESRC:
                dst = new (kind, src.ESRC);
            break;

            case K.FIRST_F2F3:
                dst = new (kind, src.FIRST_F2F3);
            break;

            case K.HAS_MODRM:
                dst = new (kind, src.HAS_MODRM);
            break;

            case K.HAS_SIB:
                dst = new (kind, src.HAS_SIB);
            break;

            case K.HINT:
                dst = new (kind, src.HINT);
            break;

            case K.ICLASS:
                dst = new (kind, src.ICLASS);
            break;

            case K.ILD_F2:
                dst = new (kind, src.ILD_F2);
            break;

            case K.ILD_F3:
                dst = new (kind, src.ILD_F3);
            break;

            case K.ILD_SEG:
                dst = new (kind, src.ILD_SEG);
            break;

            case K.IMM0:
                dst = new (kind, src.IMM0);
            break;

            case K.IMM0SIGNED:
                dst = new (kind, src.IMM0SIGNED);
            break;

            case K.IMM1:
                dst = new (kind, src.IMM1);
            break;

            case K.IMM1_BYTES:
                dst = new (kind, src.IMM1_BYTES);
            break;

            case K.IMM_WIDTH:
                dst = new (kind, src.IMM_WIDTH);
            break;

            case K.INDEX:
                dst = new (kind, src.INDEX);
            break;

            case K.LAST_F2F3:
                dst = new (kind, src.LAST_F2F3);
            break;

            case K.LLRC:
                dst = new (kind, src.LLRC);
            break;

            case K.LOCK:
                dst = new (kind, src.LOCK);
            break;

            case K.LZCNT:
                dst = new (kind, src.LZCNT);
            break;

            case K.MAP:
                dst = new (kind, src.MAP);
            break;

            case K.MASK:
                dst = new (kind, src.MASK);
            break;

            case K.MAX_BYTES:
                dst = new (kind, src.MAX_BYTES);
            break;

            case K.MEM_WIDTH:
                dst = new (kind, src.MEM_WIDTH);
            break;

            case K.MOD:
                dst = new (kind, src.MOD);
            break;

            case K.REG:
                dst = new (kind, src.REG);
            break;

            case K.MODRM_BYTE:
                dst = new (kind, src.MODRM_BYTE);
            break;

            case K.MODE:
                dst = new (kind, src.MODE);
            break;

            case K.MODEP5:
                dst = new (kind, src.MODEP5);
            break;

            case K.MODEP55C:
                dst = new (kind, src.MODEP55C);
            break;

            case K.MODE_FIRST_PREFIX:
                dst = new (kind, src.MODE_FIRST_PREFIX);
            break;

            case K.MPXMODE:
                dst = new (kind, src.MPXMODE);
            break;

            case K.MUST_USE_EVEX:
                dst = new (kind, src.MUST_USE_EVEX);
            break;

            case K.NEEDREX:
                dst = new (kind, src.NEEDREX);
            break;

            case K.NEED_MEMDISP:
                dst = new (kind, src.NEED_MEMDISP);
            break;

            case K.NEED_SIB:
                dst = new (kind, src.NEED_SIB);
            break;

            case K.NELEM:
                dst = new (kind, src.NELEM);
            break;

            case K.NOMINAL_OPCODE:
                dst = new (kind, src.NOMINAL_OPCODE);
            break;

            case K.NOREX:
                dst = new (kind, src.NOREX);
            break;

            case K.NO_SCALE_DISP8:
                dst = new (kind, src.NO_SCALE_DISP8);
            break;

            case K.NPREFIXES:
                dst = new (kind, src.NPREFIXES);
            break;

            case K.NREXES:
                dst = new (kind, src.NREXES);
            break;

            case K.NSEG_PREFIXES:
                dst = new (kind, src.NSEG_PREFIXES);
            break;

            case K.OSZ:
                dst = new (kind, src.OSZ);
            break;

            case K.OUT_OF_BYTES:
                dst = new (kind, src.OUT_OF_BYTES);
            break;

            case K.P4:
                dst = new (kind, src.P4);
            break;

            case K.POS_DISP:
                dst = new (kind, src.POS_DISP);
            break;

            case K.POS_IMM:
                dst = new (kind, src.POS_IMM);
            break;

            case K.POS_IMM1:
                dst = new (kind, src.POS_IMM1);
            break;

            case K.POS_MODRM:
                dst = new (kind, src.POS_MODRM);
            break;

            case K.POS_NOMINAL_OPCODE:
                dst = new (kind, src.POS_NOMINAL_OPCODE);
            break;

            case K.POS_SIB:
                dst = new (kind, src.POS_SIB);
            break;

            case K.PREFIX66:
                dst = new (kind, src.PREFIX66);
            break;

            case K.PTR:
                dst = new (kind, src.PTR);
            break;

            case K.REALMODE:
                dst = new (kind, src.REALMODE);
            break;

            case K.OUTREG:
                dst = new (kind, src.OUTREG);
            break;

            case K.REG0:
                dst = new (kind, src.REG0);
            break;

            case K.REG1:
                dst = new (kind, src.REG1);
            break;

            case K.REG2:
                dst = new (kind, src.REG2);
            break;

            case K.REG3:
                dst = new (kind, src.REG3);
            break;

            case K.REG4:
                dst = new (kind, src.REG4);
            break;

            case K.REG5:
                dst = new (kind, src.REG5);
            break;

            case K.REG6:
                dst = new (kind, src.REG6);
            break;

            case K.REG7:
                dst = new (kind, src.REG7);
            break;

            case K.REG8:
                dst = new (kind, src.REG8);
            break;

            case K.REG9:
                dst = new (kind, src.REG9);
            break;

            case K.REP:
                dst = new (kind, src.REP);
            break;

            case K.REX:
                dst = new (kind, src.REX);
            break;

            case K.REXB:
                dst = new (kind, src.REXB);
            break;

            case K.REXR:
                dst = new (kind, src.REXR);
            break;

            case K.REXRR:
                dst = new (kind, src.REXRR);
            break;

            case K.REXW:
                dst = new (kind, src.REXW);
            break;

            case K.REXX:
                dst = new (kind, src.REXX);
            break;

            case K.RM:
                dst = new (kind, src.RM);
            break;

            case K.ROUNDC:
                dst = new (kind, src.ROUNDC);
            break;

            case K.SAE:
                dst = new (kind, src.SAE);
            break;

            case K.SCALE:
                dst = new (kind, src.SCALE);
            break;

            case K.SEG0:
                dst = new (kind, src.SEG0);
            break;

            case K.SEG1:
                dst = new (kind, src.SEG1);
            break;

            case K.SEG_OVD:
                dst = new (kind, src.SEG_OVD);
            break;

            case K.SIBBASE:
                dst = new (kind, src.SIBBASE);
            break;

            case K.SIBINDEX:
                dst = new (kind, src.SIBINDEX);
            break;

            case K.SIBSCALE:
                dst = new (kind, src.SIBSCALE);
            break;

            case K.SMODE:
                dst = new (kind, src.SMODE);
                break;

            case K.SRM:
                dst = new (kind, src.SRM);
            break;

            case K.TZCNT:
                dst = new (kind, src.TZCNT);
            break;

            case K.UBIT:
                dst = new (kind, src.UBIT);
            break;

            case K.UIMM0:
                dst = new (kind, src.UIMM0);
            break;

            case K.UIMM1:
                dst = new (kind, src.UIMM1);
            break;

            case K.USING_DEFAULT_SEGMENT0:
                dst = new (kind, src.USING_DEFAULT_SEGMENT0);
            break;

            case K.USING_DEFAULT_SEGMENT1:
                dst = new (kind, src.USING_DEFAULT_SEGMENT1);
            break;

            case K.VEXDEST210:
                dst = new (kind, src.VEXDEST210);
            break;

            case K.VEXDEST3:
                dst = new (kind, src.VEXDEST3);
            break;

            case K.VEXDEST4:
                dst = new (kind, src.VEXDEST4);
            break;

            case K.VEXVALID:
                dst = new (kind, src.VEXVALID);
            break;

            case K.VEX_C4:
                dst = new (kind, src.VEX_C4);
            break;

            case K.VEX_PREFIX:
                dst = new (kind, src.VEX_PREFIX);
            break;

            case K.VL:
                dst = new (kind, src.VL);
            break;

            case K.WBNOINVD:
                dst = new (kind, src.WBNOINVD);
            break;

            case K.ZEROING:
                dst = new (kind, src.ZEROING);
            break;

            case K.MEM0:
                dst = new (kind, src.MEM0);
            break;

            case K.MEM1:
                dst = new (kind, src.MEM1);
            break;

            case K.AGEN:
                dst = new (kind, src.AGEN);
            break;
        }

        return dst;
    }
}
