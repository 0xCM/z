//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static XedPatterns;
using static XedRules;
using static MachineModes;
using static sys;

using C = DataFormatCode;
using K = XedRules.FieldKind;
using CK = XedRules.RuleCellKind;

public readonly partial struct XedCellRender
{
    public static void render(ReadOnlySeq<RuleCell> src, ITextEmitter dst)
    {
        var count = src.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var cell = ref src[i];
            if(i != 0)
                dst.Append(Chars.Space);
            if(i == count - 1 && cell.IsOperator)
                break;
            dst.Append(XedRender.format(cell.Value));
        }
    }

    public static void render(RowExpr src, ITextEmitter dst)
    {
        var count = src.Cells.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var cell = ref src.Cells[i];
            if(i != 0)
                dst.Append(Chars.Space);
            if(i == count - 1 && cell.IsOperator)
                break;
            dst.Append(XedRender.format(cell.Value));
        }
    }

    public static string format(in CellInfo src)
    {
        var dst = EmptyString;
        if(src.IsFieldExpr)
            dst = string.Format("{0}{1}{2}", XedRender.format(src.Field), XedRender.format(src.Operator), value(src));
        else if(src.IsOperator)
            dst = XedRender.format(src.Operator);
        else if(src.IsBitLit)
        {
            var result = LiteralBits.parse(src.Data, out var b);
            if(result.Fail)
                Errors.Throw(result.Message);
            dst = b.Format();
        }
        else if(src.IsHexLit)
        {
            if(XedParsers.parse(src.Data, out Hex8 x))
                dst = XedRender.format(x);
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCellKind.HexLit), src.Data));
        }
        else if(src.IsInt)
        {
            if(XedParsers.parse(src.Data, out ushort x))
                dst = XedRender.format(x);
        }
        else if(src.IsKeyword)
        {
            if(XedParsers.parse(src.Data, out RuleKeyword kw))
                dst = XedRender.format(kw);
        }
        else if(src.IsSeg)
        {
            XedParsers.segdata(src.Data, out var data);
            dst = string.Format("{0}[{1}]", XedRender.format(src.Field), data);
        }
        else if(src.IsNontermCall)
        {
            XedParsers.parse(src.Data, out Nonterminal x);
            dst = XedRender.format(x);
        }
        else if(src.IsWidthVar)
        {
            XedParsers.parse(src.Data, out WidthVar v);
            dst = v.Format();
        }
        else
        {
            XedParsers.parse(src.Data, out SegVar x);
            dst = x.Format();
        }
        return dst;
    }

    internal static string value(in CellInfo src)
    {
        var dst = EmptyString;
        if(src.IsFieldExpr)
        {
            switch(src.Operator.Kind)
            {
                case OperatorKind.Eq:
                {
                    var i = text.index(src.Data, Chars.Eq);
                    dst = text.right(src.Data,i);
                }
                break;
                case OperatorKind.Ne:
                {
                    var i = text.index(src.Data, Chars.Bang);
                    dst = text.right(src.Data,i+1);
                }
                break;
            }
        }
        return dst;
    }

    public static string expressions(in TableSpec src)
    {
        var dst = text.buffer();
        for(var j=0; j<src.RowCount; j++)
        {
            expression(src[j],dst);
            dst.AppendLine();
        }
        return dst.Emit();
    }

    public static string expression(in RowSpec src)
    {
        var dst = text.buffer();
        expression(src, dst);
        return dst.Emit();
    }

    public static void expression(in RowSpec src, ITextBuffer dst)
    {
        var count = src.ColCount;
        for(var k = z16; k<count; k++)
        {
            ref readonly var cell = ref src.Cell(k);
            if(k == count - 1 && cell.IsOperator)
                break;

            if(k != 0)
                dst.Append(Chars.Space);

            dst.Append(format(cell));
        }
    }

    public static string format(in CellTypeInfo src)
    {
        var dst = XedRender.format(src.Type.Kind);
        switch(src.Type.Kind)
        {
            case CK.InstSeg:
            case CK.NeqExpr:
            case CK.EqExpr:
            case CK.NtExpr:
                dst = string.Format("{0}:{1}", dst, src.TypeName);
            break;
        }
        return dst;
    }

    public static string format(in FieldValue src)
    {
        var dst = EmptyString;
        var data = bytes(src.Data);
        var code = fcode(src.Field);
        switch(src.Field)
        {
            case K.MASK:
            {
                var x = @as<MaskReg>(data);
                dst = XedRender.format(x,code);
                if(code == DataFormatCode.Expr)
                    dst = text.embrace(dst);
            }
            break;
            case K.EASZ:
            {
                var x = @as<EASZ>(data);
                dst = XedRender.format(x, code);
            }
            break;
            case K.EOSZ:
            {
                var x = @as<EOSZ>(data);
                dst = XedRender.format(x, code);
            }
            break;
            case K.MODE:
            {
                var x = @as<MachineModeClass>(data);
                dst = AsmRender.format(x, code);
            }
            break;
            case K.SMODE:
            {
                var x = @as<SMODE>(data);
                dst = XedRender.format(x, code);
            }
            break;
            case K.VEXVALID:
            {
                var x = @as<VexValid>(data);
                dst = XedRender.format(x, code);
            }
            break;
            case K.VEX_PREFIX:
            {
                var x = @as<XedVexKind>(data);
                dst = XedRender.format(x, code);
            }
            break;
        }

        if(nonempty(dst))
            return dst;

        switch(code)
        {
            case C.A8:
            {
                asci8 x = src.Data;
                dst = x.Format();
            }
            break;
            case C.Text:
                dst = ((NameResolver)((int)src.Data)).Format();
                break;
            case C.Bit:
            {
                bit x = first(data);
                dst = x.Format();
            }
            break;
            case C.B1:
            {
                uint1 x = first(data);
                dst = XedRender.format(x);
            }
            break;
            case C.B2:
            {
                uint2 x = first(data);
                dst = XedRender.format(x);
            }
            break;
            case C.B3:
            {
                num3 x = first(data);
                dst = XedRender.format(x);
            }
            break;
            case C.B4:
            {
                uint4 x = first(data);
                dst = XedRender.format(x);
            }
            break;
            case C.B5:
            {
                uint5 x = first(data);
                dst = XedRender.format(x);
            }
            break;
            case C.B6:
            {
                uint6 x = first(data);
                dst = XedRender.format(x);
            }
            break;
            case C.B7:
            {
                uint7 x = first(data);
                dst = XedRender.format(x);
            }
            break;
            case C.B8:
            {
                uint8b x = first(data);
                dst = XedRender.format(x);
            }
            break;

            case C.U1:
            {
                byte x = (byte)(first(data) & 0b1);
                dst = format(x);
            }
            break;

            case C.U2:
            {
                byte x = (byte)(first(data) & 0b11);
                dst = format(x);
            }
            break;

            case C.U3:
            {
                byte x = (byte)(first(data) & 0b111);
                dst = format(x);
            }
            break;

            case C.U4:
            {
                byte x = (byte)(first(data) & 0b1111);
                dst = format(x);
            }
            break;

            case C.U5:
            {
                byte x = (byte)(first(data) & 0b11111);
                dst = format(x);
            }
            break;

            case C.U8:
            {
                var x = first(data);
                dst = format(x);
            }
            break;
            case C.U16:
            {
                var x = @as<ushort>(data);
                dst = format(x);
            }
            break;
            case C.U32:
            {
                var x = @as<uint>(data);
                dst = format(x);
            }
            break;
            case C.U64:
            {
                var x = @as<ulong>(data);
                dst = format(x);
            }
            break;

            case C.I8:
            {
                var x = @as<sbyte>(data);
                dst = format(x);
            }
            break;
            case C.I16:
            {
                var x = @as<short>(data);
                dst = format(x);
            }
            break;
            case C.I32:
            {
                var x = @as<int>(data);
                dst = format(x);
            }
            break;
            case C.I64:
            {
                var x = @as<long>(data);
                dst = format(x);
            }
            break;

            case C.X2:
            {
                var x = first(data);
                dst = "0x" + ((byte)(x & 0b11)).ToString("X");
            }
            break;
            case C.X3:
            {
                var x = first(data);
                dst = "0x" + ((byte)(x & 0b111)).ToString("X");
            }
            break;
            case C.X4:
            {
                var x = first(data);
                dst = "0x" + ((byte)(x & 0b1111)).ToString("X");
            }
            break;
            case C.X5:
            {
                var x = first(data);
                dst = "0x" + ((byte)(x & 0b11111)).ToString("X");
            }
            break;
            case C.X6:
            {
                var x = first(data);
                dst = "0x" + ((byte)(x & 0b111111)).ToString("X");
            }
            break;
            case C.X7:
            {
                var x = first(data);
                dst = "0x" + ((byte)(x & 0b1111111)).ToString("X");
            }
            break;
            case C.X8:
            {
                Hex8 x = first(data);
                dst = XedRender.format(x);
            }
            break;
            case C.X16:
            {
                Hex16 x = @as<ushort>(data);
                dst = XedRender.format(x);
            }
            break;
            case C.X32:
            {
                Hex32 x = @as<uint>(data);
                dst = XedRender.format(x);
            }
            break;
            case C.X64:
            {
                Hex64 x = @as<ulong>(data);
                dst = XedRender.format(x);
            }
            break;

            case C.Disp:
            {
                Disp64 x = @as<long>(data);
                dst = x.Format();
            }
            break;

            case C.MemWidth:
            {
                var x = @as<ushort>(data);
                dst = x.ToString();
            }
            break;

            case C.Broadcast:
            {
                var x = @as<BroadcastKind>(data);
                dst = XedRender.format(x);
            }
            break;
            case C.Chip:
            {
                var x = @as<ChipCode>(data);
                dst = XedRender.format(x);
            }
            break;
            case C.Reg:
            {
                var x = @as<XedRegId>(data);
                dst = XedRender.format(x);
            }
            break;
            case C.InstClass:
            {
                var x = @as<XedInstKind>(data);
                dst = XedRender.format(x);
            }
            break;
            case C.VexClass:
            {
                var x = @as<VexValid>(data);
                dst = XedRender.format(x);
            }
            break;
        }
        return dst;
    }

    static string format(sbyte src)
        => src.ToString();

    static string format(short src)
        => src.ToString();

    static string format(int src)
        => src.ToString();

    static string format(long src)
        => src.ToString();

    static string format(byte src)
        => src.ToString();

    static string format(ushort src)
        => src.ToString();

    static string format(uint src)
        => src.ToString();

    static string format(ulong src)
        => src.ToString();

    [Op]
    public static DataFormatCode fcode(FieldKind src)
    {
        var dst = C.None;
        switch(src)
        {
            case K.AGEN:
            case K.AMD3DNOW:
            case K.ASZ:
            case K.BCRC:
            case K.CET:
            case K.CLDEMOTE:
            case K.DF32:
            case K.DF64:
            case K.DUMMY:
            case K.ENCODER_PREFERRED:
            case K.ENCODE_FORCE:
            case K.HAS_MODRM:
            case K.HAS_SIB:
            case K.ILD_F2:
            case K.ILD_F3:
            case K.IMM0:
            case K.IMM0SIGNED:
            case K.IMM1:
            case K.LOCK:
            case K.LZCNT:
            case K.MEM0:
            case K.MEM1:
            case K.MODE_FIRST_PREFIX:
            case K.MODE_SHORT_UD0:
            case K.MODEP5:
            case K.MODEP55C:
            case K.MPXMODE:
            case K.MUST_USE_EVEX:
            case K.NEEDREX:
            case K.NEED_MEMDISP:
            case K.NEED_SIB:
            case K.NOREX:
            case K.NO_RETURN:
            case K.NO_SCALE_DISP8:
            case K.REX:
            case K.REXW:
            case K.REXR:
            case K.REXX:
            case K.REXB:
            case K.OSZ:
            case K.OUT_OF_BYTES:
            case K.P4:
            case K.PREFIX66:
            case K.PTR:
            case K.REALMODE:
            case K.RELBR:
            case K.TZCNT:
            case K.UBIT:
            case K.USING_DEFAULT_SEGMENT0:
            case K.USING_DEFAULT_SEGMENT1:
            case K.VEX_C4:
            case K.ZEROING:
            case K.WBNOINVD:
            case K.REXRR:
            case K.SAE:
            case K.VEXDEST3:
            case K.VEXDEST4:
                dst = C.Bit;
            break;

            case K.SIBSCALE:
                dst = C.B2;
            break;

            case K.FIRST_F2F3:
            case K.LAST_F2F3:
            case K.LLRC:
            case K.DEFAULT_SEG:
            case K.REP:
            case K.VL:
                dst = C.U2;
            break;

            case K.HINT:
            case K.ROUNDC:
            case K.SEG_OVD:
                dst = C.U3;
            break;

            case K.ESRC:
                dst = C.X4;
            break;

            case K.MAP:
            case K.SCALE:
                dst = C.U4;
            break;

            case K.BCAST:
                dst = C.U5;
            break;

            case K.MOD:
            case K.BRDISP_WIDTH:
            case K.DISP_WIDTH:
            case K.ILD_SEG:
            case K.IMM1_BYTES:
            case K.IMM_WIDTH:
            case K.MAX_BYTES:
            case K.NPREFIXES:
            case K.NREXES:
            case K.NSEG_PREFIXES:
            case K.POS_DISP:
            case K.POS_IMM:
            case K.POS_IMM1:
            case K.POS_MODRM:
            case K.POS_NOMINAL_OPCODE:
            case K.POS_SIB:
            case K.UIMM1:
            case K.REG:
            case K.RM:
            case K.SRM:
            case K.SIBBASE:
            case K.SIBINDEX:
            case K.VEXDEST210:
            {
                dst = C.U8;
            }
            break;

            case K.NELEM:
            case K.ELEMENT_SIZE:
            case K.MEM_WIDTH:
            {
                dst = C.U16;
            }
            break;

            case K.MODRM_BYTE:
            case K.NOMINAL_OPCODE:
            {
                dst = C.X8;
            }
            break;

            case K.DISP:
                dst = C.Disp;
            break;

            case K.UIMM0:
                dst = C.U64;
            break;

            case K.BASE0:
            case K.BASE1:
            case K.INDEX:
            case K.OUTREG:
            case K.SEG0:
            case K.SEG1:
            case K.REG0:
            case K.REG1:
            case K.REG2:
            case K.REG3:
            case K.REG4:
            case K.REG5:
            case K.REG6:
            case K.REG7:
            case K.REG8:
            case K.REG9:
            {
                dst = C.Reg;
            }
            break;
            case K.CHIP:
            {
                dst = C.Chip;
            }
            break;

            case K.ERROR:
            {
                dst = C.Error;
            }
            break;

            case K.ICLASS:
                dst = C.InstClass;
            break;

            case K.MASK:
            case K.VEX_PREFIX:
            case K.VEXVALID:
                dst = C.UInt;
            break;

            case K.SMODE:
            case K.MODE:
                dst = C.UInt;
            break;

            case K.EASZ:
            case K.EOSZ:
                dst = C.UInt;
            break;

            default:
                break;
        }

        return dst;
    }
}

