//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

using CK = XedRules.RuleCellKind;

partial class XedRules
{
    public struct CellValue : IEquatable<CellValue>, IComparable<CellValue>
    {
        readonly ByteBlock16 Data;

        const byte OpIndex = 11;

        const byte PosIndex = 12;

        const byte FieldIndex = 14;

        const byte ClassIndex = 15;

        [MethodImpl(Inline)]
        public CellValue(byte src)
        {
            var data = ByteBlock16.Empty;
            data.First = src;
            data[ClassIndex] = (byte)CK.IntVal;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(ushort src)
        {
            var data = ByteBlock16.Empty;
            data.Cell<ushort>(0) = src;
            data[ClassIndex] = (byte)CK.IntVal;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(uint5 src)
        {
            var data = ByteBlock16.Empty;
            data.First = src;
            data[ClassIndex] = (byte)CK.BitLit;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(Hex8 src)
        {
            var data = ByteBlock16.Empty;
            data[0] = src;
            data[ClassIndex] = (byte)CK.HexLit;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(RuleKeyword src)
        {
            var data = ByteBlock16.Empty;
            data[0] = (byte)src.KeywordKind;
            data[ClassIndex] = (byte)CK.Keyword;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(RuleOperator src)
        {
            var data = ByteBlock16.Empty;
            data[0] = (byte)src.Kind;
            data[ClassIndex] = (byte)CK.Operator;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(InstFieldSeg src)
        {
            var data = ByteBlock16.Empty;
            sys.@as<InstFieldSeg>(data.First) = src;
            data[FieldIndex] = (byte)src.Field;
            data[ClassIndex] = (byte)CK.InstSeg;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(SegVar src)
        {
            var data = ByteBlock16.Empty;
            data.A = (ulong)src;
            data[ClassIndex] = (byte)CK.SegVar;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(WidthVar src)
        {
            var data = ByteBlock16.Empty;
            data.A = (ulong)src;
            data[ClassIndex] = (byte)CK.WidthVar;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(FieldSeg src)
        {
            var data = ByteBlock16.Empty;
            data.A = (ulong)src.Seg;
            data[FieldIndex] = (byte)src.Field;
            data[ClassIndex] = (byte)CK.FieldSeg;
            Data = data;
        }

        [MethodImpl(Inline)]
        public CellValue(CellExpr src)
        {
            var dst = ByteBlock16.Empty;
            if(src.IsNonterm)
            {
                @as<RuleName>(dst.First) = src.Value.ToRuleName();
                dst[ClassIndex] = (byte)CK.NtExpr;
                dst[OpIndex] = (byte)src.Operator;
                dst[FieldIndex] = (byte)src.Field;
            }
            else
            {
                @as<ulong>(dst.First) = src.Value.Data;
                dst[OpIndex] = (byte)src.Operator;
                dst[FieldIndex] = (byte)src.Field;
                switch(src.Operator.Kind)
                {
                    case OperatorKind.Eq:
                        dst[ClassIndex] = (byte)CK.EqExpr;
                    break;
                    case OperatorKind.Ne:
                        dst[ClassIndex] = (byte)CK.NeqExpr;
                    break;
                    case OperatorKind.Impl:
                        dst[ClassIndex] = (byte)CK.Operator;
                    break;
                }
            }
            Data = dst;
        }

        [MethodImpl(Inline)]
        public CellValue(Nonterminal src)
        {
            var data = ByteBlock16.Empty;
            data = (uint)src;
            data[ClassIndex] = (byte)CK.NtCall;
            Data = data;
        }

        [MethodImpl(Inline)]
        CellValue(ByteBlock16 data)
        {
            Data = data;
        }

        public CK CellKind
        {
            [MethodImpl(Inline), UnscopedRef]
            get => @as<CK>(Data[ClassIndex]);
        }

        public RuleCellType CellType
        {
            [MethodImpl(Inline), UnscopedRef]
            get => @as<RuleCellType>(Data[ClassIndex]);
        }

        public FieldKind Field
        {
            [MethodImpl(Inline), UnscopedRef]
            get => @as<FieldKind>(Data[FieldIndex]);
        }

        public bit IsExpr
        {
            [MethodImpl(Inline)]
            get => CellType.IsExpr;
        }

        public bit IsOperator
        {
            [MethodImpl(Inline)]
            get => CellType.IsOperator;
        }

        public bit IsLiteral
        {
            [MethodImpl(Inline)]
            get => CellType.IsLiteral;
        }

        public bit IsBitLit
        {
            [MethodImpl(Inline)]
            get => CellType.IsBitLit;
        }

        public bit IsHexLit
        {
            [MethodImpl(Inline)]
            get => CellType.IsHexLit;
        }

        public bit IsNontermCall
        {
            [MethodImpl(Inline)]
            get => CellType.IsNontermCall;
        }

        public bit IsNontermExpr
        {
            [MethodImpl(Inline)]
            get => CellType.IsNontermExpr;
        }

        public bit IsNonterm
        {
            [MethodImpl(Inline)]
            get => CellType.IsNonterm;
        }

        public byte Position
        {
            [MethodImpl(Inline), UnscopedRef]
            get => Data[PosIndex];
        }

        [MethodImpl(Inline)]
        public CellValue WithPosition(byte pos)
        {
            var dst = CellValue.Empty;
            var data = Data;
            data[PosIndex] = pos;
            return new(data);
        }

        [MethodImpl(Inline)]
        public bool Equals(CellValue src)
            => Data.Equals(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is CellValue p && Equals(p);

        [MethodImpl(Inline), UnscopedRef]
        public ref readonly Hex8 AsHexLit()
            => ref @as<Hex8>(sys.bytes(this));

        [MethodImpl(Inline), UnscopedRef]
        public MachineMode AsMode()
            => @as<MachineMode>(Data.First);

        [MethodImpl(Inline), UnscopedRef]
        public SegVar AsSegVar()
            => @as<SegVar>(Data.First);

        [MethodImpl(Inline)]
        public WidthVar AsWidthVar()
            => @as<WidthVar>(Data.First);

        [MethodImpl(Inline)]
        public byte AsByte()
            => @as<byte>(Data.First);

        [MethodImpl(Inline)]
        public ushort AsWord()
            => @as<ushort>(Data.First);

        [MethodImpl(Inline)]
        public Nonterminal AsNonterm()
            => @as<Nonterminal>(sys.bytes(Data));

        [MethodImpl(Inline)]
        public CellExpr ToCellExpr()
            => new ((OperatorKind)Data[OpIndex], new FieldValue(Field, @as<ulong>(Data.First), CellKind));

        [MethodImpl(Inline), UnscopedRef]
        public uint5 AsBitLit()
            => @as<uint5>(Data.First);

        [MethodImpl(Inline), UnscopedRef]
        public Hex16 AsHex16()
            => @as<Hex16>(Data.First);

        [MethodImpl(Inline), UnscopedRef]
        public RuleOperator AsOperator()
            => @as<RuleOperator>(Data.First);

        [MethodImpl(Inline)]
        public RuleKeyword ToKeyword()
            => RuleKeyword.from(@as<KeywordKind>(Data.First));

        [MethodImpl(Inline)]
        public InstFieldSeg AsInstSeg()
            => @as<InstFieldSeg>(Data.First);

        [MethodImpl(Inline)]
        public FieldSeg ToFieldSeg()
            => new (SegVar.parse(AsInstSeg().Type.Format()), Field);

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(CellValue src)
            => Position.CompareTo(src.Position);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(byte src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(ushort src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(Hex8 src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(uint5 src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(RuleKeyword src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(RuleOperator src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(CellExpr src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(FieldSeg src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(InstFieldSeg src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(SegVar src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(WidthVar src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator CellValue(Nonterminal src)
            => new (src);

        public static CellValue Empty => default;
    }
}
