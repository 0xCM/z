//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static XedRules;
using static sys;

using M = XedModels;
using CK = XedRules.RuleCellKind;

public partial class XedFields
{
    [MethodImpl(Inline)]
    public static FieldAssign assign<T>(FieldKind field, T value)
        where T : unmanaged
            => new (new FieldValue(field, bw64(value)));

    [MethodImpl(Inline), Op]
    public static Field field<T>(FieldKind kind, T value)
        where T : unmanaged
            => init(kind, bw16(value));

    [MethodImpl(Inline)]
    public static ref readonly FieldDef def(FieldKind kind)
        => ref FieldDefs.Instance[kind];

    [MethodImpl(Inline)]
    public static Field init(FieldKind kind, bit value)
        => new ((ushort)value, kind, FieldDataKind.Bit);

    [MethodImpl(Inline)]
    public static Field init(FieldKind kind, byte value)
        => new ((ushort)value, kind, FieldDataKind.Byte);

    [MethodImpl(Inline)]
    public static Field init(FieldKind kind, ushort value)
        => new ((ushort)value, kind, FieldDataKind.Word);

    [MethodImpl(Inline)]
    public static Field init(FieldKind kind, RegExpr value)
        => new ((ushort)value, kind, FieldDataKind.Reg);

    [MethodImpl(Inline)]
    public static Field init(FieldKind kind, ChipCode value)
        => new ((ushort)value, kind, FieldDataKind.Chip);

    [MethodImpl(Inline)]
    public static Field init(FieldKind kind, XedInstClass value)
        => new ((ushort)value, kind, FieldDataKind.InstClass);

    public static Fields allocate()
        => new (sys.alloc<Field>(Fields.MaxCount));

    public static void convert(in FieldValue src, out Field dst)
    {
        dst = Field.Empty;
        var kind = src.Field;
        var size = XedFields.size(kind, src.CellKind);
        if(size.PackedWidth == 1)
            dst = init(kind, (bit)src.Data);
        else if(size.NativeWidth == 1)
            dst = init(kind, (byte)src.Data);
        else if(size.NativeWidth == 2)
            dst = init(kind, (ushort)src.Data);
        else
            Errors.Throw($"Unsupported size {size}");
    }

    public static DataSize size(FieldKind fk, CK ck)
    {
        var dst = def(fk).Size;
        switch(ck)
        {
            case CK.Keyword:
                dst = RuleKeyword.DataSize;
            break;
            case CK.NtCall:
                dst = Nonterminal.DataSize;
            break;
            case CK.Operator:
                dst = RuleOperator.DataSize;
            break;
        }
        return dst;
    }

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
    public static ref readonly SMODE smode(in XedFieldState src)
        => ref @as<SMODE>(src.EASZ);

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
