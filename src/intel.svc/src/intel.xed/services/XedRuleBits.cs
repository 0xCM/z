//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedModels;

using CK = XedRules.RuleCellKind;

public class XedRuleBits
{
    public static XedRuleBits create()
        => new (
            PolyBits.dataset<Segment,RuleFieldBits>("Rules", RuleFieldBits.NativeSize,
            FieldKindWidth,
            OperatorWidth,
            DataKindWidth,
            ValueWidth)
            );

    /// <summary>
    /// Value[28:13] DataKind[12:9] Operator[8:6] FieldKind[5:0]
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1,Size=4)]
    public readonly record struct RuleFieldBits
    {
        public const NativeSizeCode NativeSize = NativeSizeCode.W32;

        [MethodImpl(Inline)]
        public static implicit operator uint(RuleFieldBits src)
            => @as<RuleFieldBits,uint>(src);

        [MethodImpl(Inline)]
        public static explicit operator RuleFieldBits(uint src)
            => @as<RuleFieldBits>(src);

        public static RuleFieldBits Empty => default;
    }

    public readonly BfDataset<Segment,RuleFieldBits> Dataset;

    [MethodImpl(Inline)]
    XedRuleBits(BfDataset<Segment,RuleFieldBits> src)
    {
        Dataset = src;
    }

    const byte FieldKindWidth = 6;

    const byte OperatorWidth = 3;

    const byte DataKindWidth = 4;

    const byte ValueWidth = 16;

    public enum Segment : byte
    {
        Field,

        Operator,

        DataKind,

        Value,
    }

    public string Format()
        => Dataset.Intervals.Format();

    public override string ToString()
        => Format();

    public string Format(RuleFieldBits src)
        => string.Format("{0,-16} {1, -4} {2}",
            ExtractField(src),
            ExtractOperator(src),
            (num4)(byte)ExtractDataKind(src),
            ExtractValue(src)
            );

    [MethodImpl(Inline)]
    RuleFieldBits Define<T>(FieldKind field, RuleOperator op, RuleCellKind kind, T value)
        where T : unmanaged
    {
        var dst = 0u;
        dst |= (uint)field << (int)Dataset.Offset(Segment.Field);
        dst |= (uint)op << (int)Dataset.Offset(Segment.Operator);
        dst |= (uint)kind << (int)Dataset.Offset(Segment.DataKind);
        dst |= (uint)sys.@as<T,ushort>(value) << (int)Dataset.Offset(Segment.Value);
        return (RuleFieldBits)dst;
    }

    [MethodImpl(Inline)]
    RuleFieldBits Define<T>(FieldKind field, RuleCellKind kind, T value)
        where T : unmanaged
            => Define(field, OperatorKind.None, kind, value);

    [MethodImpl(Inline)]
    public FieldKind ExtractField(RuleFieldBits src)
        => Dataset.Extract<FieldKind>(Segment.Field, src);

    [MethodImpl(Inline)]
    public RuleOperator ExtractOperator(RuleFieldBits src)
        => Dataset.Extract<RuleOperator>(Segment.Field, src);

    [MethodImpl(Inline)]
    public RuleCellKind ExtractDataKind(RuleFieldBits src)
        => Dataset.Extract<RuleCellKind>(Segment.Field, src);

    [MethodImpl(Inline)]
    public bit ExtractValue(W1 w, RuleFieldBits src)
        => Dataset.Extract<bit>(Segment.Field, src);

    [MethodImpl(Inline)]
    public byte ExtractValue(W8 w, RuleFieldBits src)
        => Dataset.Extract<byte>(Segment.Field, src);

    [MethodImpl(Inline)]
    public ushort ExtractValue(W16 w, RuleFieldBits src)
        => Dataset.Extract<ushort>(Segment.Field, src);

    [MethodImpl(Inline)]
    public ushort ExtractValue(RuleFieldBits src)
        => Dataset.Extract<ushort>(Segment.Field, src);

    [MethodImpl(Inline)]
    public RuleFieldBits Bits(in CellKey key, in CellExpr src)
        => Bits(key.Logic, src.Field, src.Operator, src.Value);

    [MethodImpl(Inline)]
    public RuleFieldBits Bits(RuleKeyword src)
        => Define(FieldKind.INVALID, CK.Keyword, src);

    [MethodImpl(Inline)]
    public RuleFieldBits Bits(uint5 src)
        => Define(FieldKind.INVALID, CK.BitLit, src);

    [MethodImpl(Inline)]
    public RuleFieldBits Bits(FieldSeg src)
        => Define(src.Field, CK.FieldSeg, src);

    [MethodImpl(Inline)]
    public RuleFieldBits Bits(SegVar src)
        => Define(FieldKind.INVALID, CK.SegVar, src);

    [MethodImpl(Inline)]
    public RuleFieldBits Bits(WidthVar src)
        => Define(FieldKind.INVALID, CK.WidthVar, src);

    [MethodImpl(Inline)]
    public RuleFieldBits Bits(Nonterminal src)
        => Define(FieldKind.INVALID, CK.NtCall, src);

    [MethodImpl(Inline)]
    public RuleFieldBits Bits(Hex8 src)
        => Define(FieldKind.INVALID, CK.HexLit, src);

    public RuleFieldBits Bits(in RuleCell src)
    {
        var dst = RuleFieldBits.Empty;
        if(src.IsOperator)
            dst = Define(FieldKind.INVALID, src.Operator(), RuleCellKind.Operator, src.Operator());
        else if(src.IsCellExpr)
            dst = Bits(src.Key, src.Value.ToCellExpr());
        else
        {
            switch(src.Key.CellType.Kind)
            {
                case CK.BitLit:
                    dst = Bits(src.Value.AsBitLit());
                break;
                case CK.Keyword:
                    dst = Bits(src.Value.ToKeyword());
                break;
                case CK.HexLit:
                    dst = Bits(src.Value.AsHexLit());
                break;
                case CK.NtCall:
                    dst = Bits(src.Value.AsNonterm());
                break;
                case CK.SegVar:
                    dst = Bits(src.Value.AsSegVar());
                break;
                case CK.WidthVar:
                    dst = Bits(src.Value.AsWidthVar());
                break;
                case CK.FieldSeg:
                case CK.InstSeg:
                    dst = Bits(src.Value.ToFieldSeg());
                break;
                default:
                    term.error("Unhandled ");
                    break;
            }
        }
        return dst;
    }

    public uint Bits(in CellRow src, ref uint seq, Span<RuleFieldBits> dst)
    {
        var s0 = seq;
        for(var k=0; k<src.CellCount; k++, seq++)
            seek(dst, seq) = Bits(src[k]);
        return seq - s0;
    }

    public uint Bits(in CellTable src, ref uint seq, Span<RuleFieldBits> dst)
    {
        var s0 = seq;
        for(var j=0; j<src.RowCount; j++)
            Bits(src[j], ref seq, dst);
        return seq - s0;
    }

    public Index<RuleFieldBits> Bits(CellTables src)
    {
        var dst = alloc<RuleFieldBits>(src.CellCount);
        var seq = 0u;
        for(var i=0; i<src.TableCount; i++)
            Bits(src[i], ref seq, dst);
        return dst;
    }

    public RuleFieldBits Bits(LogicKind logic, FieldKind field, RuleOperator op, FieldValue value)
    {
        var dst = RuleFieldBits.Empty;
        switch(value.CellKind)
        {
            case CK.BitVal:
                dst = Define(field, op, value.CellKind, (bit)value.Data);
            break;
            case CK.IntVal:
                dst = Define(field, op, value.CellKind, (ushort)value.Data);
            break;
            case CK.HexVal:
                dst = Define(field, op, value.CellKind, (Hex8)value.Data);
            break;
            case CK.WidthVar:
                dst = Define(field, op, value.CellKind, (WidthVar)value.Data);
            break;
            case CK.BitLit:
                dst = Define(field, op, value.CellKind, (uint5)value.Data);
            break;
            case CK.HexLit:
                dst = Define(field, op, value.CellKind, (Hex8)value.Data);
            break;
            case CK.NtCall:
                dst = Define(field, op, value.CellKind, (Nonterminal)value.Data);
            break;
            case CK.Keyword:
                dst = Define(field, op, value.CellKind, (KeywordKind)value.Data);
            break;
            case CK.EqExpr:
                dst = Define(field, op, value.CellKind, (ushort)value.Data);
            break;
            case CK.NeqExpr:
                dst = Define(field, op, value.CellKind, (ushort)value.Data);
            break;
            case CK.NtExpr:
                dst = Define(field, op, value.CellKind, (Nonterminal)value.Data);
            break;
            default:
                term.warn(value.CellKind);
            break;
        }
        return dst;
    }

    const string RowPattern = "{0,-6} | {1:D3} | {2,-6} | {3,-32} | {4,-92}";

    static string[] RowCells = new string[]{"Table", "Row", "Kind", "Name", "Expr"};

    public string RowHeader()
        => string.Format(RowPattern,RowCells);

    public void Format(CellTables src, ITextEmitter dst)
    {
        for(var i=0; i<src.Count; i++)
            Format(src[i],dst);
    }

    public void Format(in CellTable src, ITextEmitter dst)
    {
        for(var j=0; j<src.RowCount; j++)
            Format(src[j],dst);
    }

    public void Format(in CellRow src, ITextEmitter dst)
    {
        Span<RuleFieldBits> fields = stackalloc RuleFieldBits[32];
        var count = Demand.lteq(src.CellCount, 32u);
        var bitfield = text.buffer();
        var counter = 0u;
        for(var k=0; k<count; k++)
        {
            var field = Bits(src[k]);
            bitfield.AppendFormat(" | {0:X8}", (uint)field);
            ref readonly var cell = ref src[k];
            seek(fields,k) = field;
            var fk = ExtractField(field);
            var cv = ExtractValue(w16,field);
            var type = cell.CellType;
            var ck = type.Kind;
            if(type.IsExpr)
            {
                switch(ck)
                {
                    case CK.EqExpr:
                        counter++;
                    break;
                    case CK.NeqExpr:
                        counter++;
                    break;
                    case CK.NtExpr:
                        var rule = (RuleName)cv;
                        counter++;
                    break;
                }
            }
            else
            {
                switch(ck)
                {
                    case CK.BitLit:
                        var bits = (uint5)cv;
                        counter++;
                    break;
                    case CK.HexVal:
                    case CK.HexLit:
                        var hex = (Hex8)cv;
                        counter++;
                    break;
                    case CK.IntVal:
                        var @int = cv;
                        counter++;
                    break;
                    case CK.Keyword:
                        var kw = (KeywordKind)cv;
                        counter++;
                    break;
                    case CK.NtCall:
                        var rule = (RuleName)cv;
                        counter++;
                    break;
                    case CK.SegVar:
                        counter++;
                    break;
                    case CK.FieldSeg:
                    break;
                    case CK.InstSeg:
                        counter++;
                    break;
                }
            }
        }

        dst.AppendFormat(RowPattern,
            src.TableIndex,
            src.RowIndex,
            src.TableSig.TableKind,
            src.TableSig.TableName,
            src.Expression);
        dst.AppendLine(bitfield.Emit());
    }
}
