//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public readonly record struct RuleExpr : IComparable<RuleExpr>
    {
        public const string TableId = "xed.rules.expr";

        [Render(6)]
        public readonly num12 Seq;

        [Render(6)]
        public readonly RuleTableKind Kind;

        [Render(6)]
        public readonly byte Row;

        [Render(28)]
        public readonly RuleName Name;

        [Render(1)]
        public readonly string Body;

        [MethodImpl(Inline)]
        public RuleExpr(ushort seq, RuleIdentity sig, byte row, string body)
        {
            Seq = seq;
            Name = sig.TableName;
            Kind = sig.TableKind;
            Row = row;
            Body = body;
        }

        public RuleIdentity Sig
        {
            [MethodImpl(Inline)]
            get => (Kind,Name);
        }

        public int CompareTo(RuleExpr src)
            => Sig.CompareTo(src.Sig);
    }
}
