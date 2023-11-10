//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct CellInfo
    {
        public readonly CellTypeInfo TypeInfo;

        public readonly LogicClass Logic;

        public readonly string Data;

        public CellInfo(in CellTypeInfo type, LogicClass logic, string data)
        {
            TypeInfo = type;
            Data = text.ifempty(data, EmptyString);
            Logic = logic;
        }

        [MethodImpl(Inline)]
        public CellInfo(RuleOperator op)
        {
            TypeInfo = CellTypeInfo.@operator(op);
            Data = EmptyString;
            Logic = LogicKind.Operator;
        }

        public RuleCellType Type
        {
            [MethodImpl(Inline)]
            get => TypeInfo.Type;
        }

        public RuleCellKind Kind
        {
            [MethodImpl(Inline)]
            get => TypeInfo.Type.Kind;
        }

        public bool IsKeyword
        {
            [MethodImpl(Inline)]
            get => Type.IsKeyword;
        }

        public bool IsInt
        {
            [MethodImpl(Inline)]
            get => Type.IsInt;
        }

        public bool IsBitLit
        {
            [MethodImpl(Inline)]
            get => Type.IsBitLit;
        }

        public bool IsWidthVar
        {
            [MethodImpl(Inline)]
            get => Type.IsWidthVar;
        }

        public bool IsHexLit
        {
            [MethodImpl(Inline)]
            get => Type.IsHexLit;
        }

        public readonly FieldKind Field
        {
            [MethodImpl(Inline)]
            get => TypeInfo.Field;
        }

        public readonly RuleOperator Operator
        {
            [MethodImpl(Inline)]
            get => TypeInfo.Operator;
        }

        public bool IsOperator
        {
            [MethodImpl(Inline)]
            get => Field == 0 && Operator.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Data) && Operator.IsEmpty && Field == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool IsFieldExpr
        {
            [MethodImpl(Inline)]
            get => Field != 0 && Operator.IsNonEmpty;
        }

        public bool IsSeg
        {
            [MethodImpl(Inline)]
            get => XedParsers.IsSeg(Data);
        }

        public bool IsNontermCall
        {
            [MethodImpl(Inline)]
            get => XedParsers.IsNonterm(Data);
        }

        public string Format()
            => XedCellRender.format(this);

        public override string ToString()
            => Format();
    }
}
