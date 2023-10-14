//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1,Size =4)]
    public readonly record struct ColType
    {
        [MethodImpl(Inline)]
        public ColType(KeywordKind src)
            => this = Bitfields.join((byte)ColKind.Keyword, (ushort)src);

        [MethodImpl(Inline)]
        public ColType(FieldKind src)
            => this = Bitfields.join((byte)ColKind.Field, (ushort)src);

        [MethodImpl(Inline)]
        public ColType(ColKind kind, FieldKind field)
            => this = Bitfields.join((byte)kind, (ushort)field);

        [MethodImpl(Inline)]
        public ColType(FieldKind field, OperatorKind op)
            => this = Bitfields.join((byte)ColKind.Expr, Bitfields.join((byte)field, (byte)op));

        [MethodImpl(Inline)]
        public ColType(FieldKind field, OperatorKind op, RuleName rule)
            => this = Bitfields.join((byte)ColKind.RuleExpr, (byte)field, (ushort)PolyBits.pack(num3.force(op),num9.force(rule)));

        [MethodImpl(Inline)]
        public ColType(FieldKind field, OperatorKind op, byte width)
            => this = Bitfields.join((byte)ColKind.RuleExpr, (byte)field, (ushort)PolyBits.pack(num3.force(op), (num8)width));

        [MethodImpl(Inline)]
        public ColType(RuleName src)
            => this = Bitfields.join((byte)ColKind.Rule, (ushort)src);

        [MethodImpl(Inline)]
        public ColType(OperatorKind src)
            => this = Bitfields.join((byte)ColKind.Operator, (ushort)src);

        [MethodImpl(Inline)]
        public ColType(ColKind k)
            => this = (ushort)k;

        [MethodImpl(Inline)]
        public ColType(ColKind k, byte width)
            => this = Bitfields.join((byte)k,width);

        [MethodImpl(Inline)]
        public static ColType field(FieldKind field)
            => new ColType(ColKind.Field, field);

        [MethodImpl(Inline)]
        public static ColType seg(FieldKind field)
            => new ColType(ColKind.FieldSeg, field);

        [MethodImpl(Inline)]
        public static ColType segvar(FieldKind field)
            => new (ColKind.SegVar);

        [MethodImpl(Inline)]
        public static ColType segval(byte width)
            => new (ColKind.SegVal, width);

        [MethodImpl(Inline)]
        public static ColType bitlit()
            => new (ColKind.BitLiteral);

        [MethodImpl(Inline)]
        public static ColType hexlit()
            => new (ColKind.HexLiteral);

        [MethodImpl(Inline)]
        public static ColType rule()
            => new (ColKind.Rule);

        [MethodImpl(Inline)]
        public static ColType expr(FieldKind field, OperatorKind op)
            => new (field, op);

        [MethodImpl(Inline)]
        public static ColType expr(FieldKind left, OperatorKind op, byte width)
            => new (left, op, width);

        [MethodImpl(Inline)]
        public static ColType nonterm(RuleName rule)
            => new ColType(rule);

        [MethodImpl(Inline)]
        public static ColType expr(FieldKind field, OperatorKind op, RuleName rule)
            => new ColType(field, op, rule);

        [MethodImpl(Inline)]
        RuleKeyword Keyword()
            => (KeywordKind)Upper;

        [MethodImpl(Inline)]
        public FieldKind Field()
            => (FieldKind)(Upper & uint7.MaxValue);

        [MethodImpl(Inline)]
        public RuleName ToRule()
            => (RuleName)Upper;

        [MethodImpl(Inline)]
        RuleOperator Op()
            => (RuleOperator)Upper;

        public ColKind Kind
        {
            [MethodImpl(Inline)]
            get => (ColKind)(byte)this;
        }

        public bool IsFieldSeg
        {
            [MethodImpl(Inline)]
            get => Kind == ColKind.FieldSeg;
        }

        public bool IsNontermCall
        {
            [MethodImpl(Inline)]
            get => Kind == ColKind.Rule;
        }

        public bool IsNontermExpr
        {
            [MethodImpl(Inline)]
            get => Kind == ColKind.RuleExpr;
        }

        public bool IsNonterm
        {
            [MethodImpl(Inline)]
            get => IsNontermCall || IsNontermExpr;
        }

        uint Upper
        {
            [MethodImpl(Inline)]
            get => (uint)this >> 24;
        }

        [MethodImpl(Inline)]
        public static implicit operator uint(ColType src)
            => @as<ColType,uint>(src);

        [MethodImpl(Inline)]
        public static implicit operator ColType(uint src)
            => @as<uint,ColType>(src);

        [MethodImpl(Inline)]
        public static implicit operator ColType(FieldKind src)
            => new (src);

        [MethodImpl(Inline)]
        public static explicit operator FieldKind(ColType src)
            => src.Field();

        [MethodImpl(Inline)]
        public static implicit operator ColType(RuleName src)
            => new (src);

        [MethodImpl(Inline)]
        public static explicit operator RuleName(ColType src)
            => src.ToRule();

        [MethodImpl(Inline)]
        public static implicit operator ColType(OperatorKind src)
            => new (src);

        [MethodImpl(Inline)]
        public static explicit operator RuleOperator(ColType src)
            => src.Op();

        [MethodImpl(Inline)]
        public static implicit operator ColType(RuleOperator src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator ColType(KeywordKind src)
            => new (src);

        [MethodImpl(Inline)]
        public static explicit operator RuleKeyword(ColType src)
            => src.Keyword();

        [MethodImpl(Inline)]
        public static implicit operator ColType(RuleKeyword src)
            => new (src.KeywordKind);

        public static ColType Empty => default;
    }
}
