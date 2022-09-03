//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        [DataWidth(Width)]
        public readonly record struct RuleCellType : IComparable<RuleCellType>
        {
            public const byte Width = num4.Width;

            public readonly RuleCellKind Kind;

            [MethodImpl(Inline)]
            public RuleCellType(RuleCellKind kind)
            {
                Kind = kind;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public bit IsKeyword
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Keyword;
            }

            public bit IsBitLit
            {
                [MethodImpl(Inline)]
                get => Kind == CK.BitLit;
            }

            public bit IsWidthVar
            {
                [MethodImpl(Inline)]
                get => Kind == CK.WidthVar;
            }

            public bit IsHexLit
            {
                [MethodImpl(Inline)]
                get => Kind == CK.HexLit;
            }

            public bit IsInt
            {
                [MethodImpl(Inline)]
                get => Kind == CK.IntVal;
            }

            public bit IsLiteral
            {
                [MethodImpl(Inline)]
                get => Kind == CK.BitLit || Kind == CK.HexLit || IsInt;
            }

            public bit IsExpr
            {
                [MethodImpl(Inline)]
                get => Kind == CK.EqExpr || Kind == CK.NeqExpr || Kind == CK.NtExpr;
            }

            public bit IsOperator
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Operator;
            }

            public bit IsNontermCall
            {
                [MethodImpl(Inline)]
                get => Kind == CK.NtCall;
            }

            public bit IsNontermExpr
            {
                [MethodImpl(Inline)]
                get => Kind == CK.NtExpr;
            }

            public bit IsNonterm
            {
                [MethodImpl(Inline)]
                get => IsNontermCall || IsNontermExpr;
            }

            public bit IsInstSeg
            {
                [MethodImpl(Inline)]
                get => Kind == CK.InstSeg;
            }

            public bit IsFieldSeg
            {
                [MethodImpl(Inline)]
                get => Kind == CK.FieldSeg;
            }

            [MethodImpl(Inline)]
            public int CompareTo(RuleCellType src)
                => ((byte)Kind).CompareTo((byte)src.Kind);

            public string Format()
                => XedRender.format(Kind);

            public override int GetHashCode()
                => (int)Kind;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator RuleCellType(RuleCellKind src)
                => new RuleCellType(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleCellKind(RuleCellType src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(RuleCellType src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator RuleCellType(byte src)
                => new RuleCellType((RuleCellKind)src);

            public static RuleCellType Empty => default;
        }
   }
}