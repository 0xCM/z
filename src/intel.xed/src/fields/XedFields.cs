//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static sys;

using M = XedModels;

public partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly XedInstClass iclass(in XedFieldState src)
        => ref @as<XedInstKind,XedInstClass>(src.ICLASS);
            
    [MethodImpl(Inline), Op]
    public static ref readonly Hex8 opcode(in XedFieldState src)
        => ref @as<Hex8>(src.NOMINAL_OPCODE);

    [MethodImpl(Inline), Op]
    public static AsmBroadcast broadcast(in XedFieldState src)
        => asm.broadcast(src.BCAST);

    [MethodImpl(Inline), Op]
    public static ref readonly EASZ easz(in XedFieldState src)
        => ref @as<EASZ>(src.EASZ);

    [MethodImpl(Inline), Op]
    public static ref readonly EOSZ eosz(in XedFieldState src)
        => ref @as<EOSZ>(src.EOSZ);

    [MethodImpl(Inline), Op]
    public static ref readonly MachineMode mode(in XedFieldState src)
        => ref @as<MachineMode>(src.MODE);

    [MethodImpl(Inline), Op]
    public static ref readonly ModRm modrm(in XedFieldState src)
        => ref @as<Hex8,ModRm>(src.MODRM_BYTE);

    [MethodImpl(Inline), Op]
    public static ref readonly M.RepPrefix rep(in XedFieldState src)
        => ref @as<M.RepPrefix>(src.REP);

    [MethodImpl(Inline), Op]
    public static ref readonly RoundingKind rounding(in XedFieldState src)
        => ref @as<RoundingKind>(src.ROUNDC);

    [MethodImpl(Inline), Op]
    public static ref readonly AsmVL vl(in XedFieldState src)
        => ref @as<AsmVL>(src.VL);

    [MethodImpl(Inline), Op]
    public static RexPrefix rex(in XedFieldState src)
        => new (Numbers.pack(src.REXB, src.REXX, src.REXR, src.REXW,0b100));

    [MethodImpl(Inline), Op]
    public static ref readonly VexValid vexvalid(in XedFieldState src)
        => ref @as<VexValid>(src.VEXVALID);

    [MethodImpl(Inline), Op]
    public static ref readonly XedVexKind vexkind(in XedFieldState src)
        => ref @as<XedVexKind>(src.VEX_PREFIX);

    [MethodImpl(Inline), Op]
    public static Sib sib(in XedFieldState src)
        => new (src.SIBBASE, src.SIBINDEX, src.SIBSCALE);

    [MethodImpl(Inline), Op]
    public static ref readonly HintKind hint(in XedFieldState src)
        => ref @as<HintKind>(src.HINT);

    [Op]
    public static Imm imm0(in XedFieldState state, in AsmHexCode code)
    {
        var dst = Imm.Empty;
        if(state.IMM0)
            dst = asm.imm(code, state.POS_IMM, state.IMM0SIGNED, Sizes.native(state.IMM_WIDTH));
        return dst;
    }

    [Op]
    public static Imm imm1(in XedFieldState state, in AsmHexCode code)
    {
        var dst = Imm.Empty;
        if(state.IMM1)
            dst = asm.imm(code, state.POS_IMM1, false, Sizes.native(state.IMM1_BYTES/8));
        return dst;
    }        
}
