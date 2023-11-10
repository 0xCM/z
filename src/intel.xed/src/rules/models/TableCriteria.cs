//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

partial class XedRules
{
    public readonly struct TableCriteria : IComparable<TableCriteria>
    {
        public readonly uint TableId;

        public readonly RuleIdentity Rule;

        public readonly ReadOnlySeq<RowCriteria> Rows;

        public TableCriteria(RuleIdentity rule, ReadOnlySeq<RowCriteria> rows)
        {
            TableId = 0u;
            Require.invariant(rule.IsNonEmpty);
            Require.invariant(rows.Length != 0);
            Rule = rule;
            Rows = rows;
        }

        public TableCriteria(uint id, RuleIdentity rule, ReadOnlySeq<RowCriteria> rows)
        {
            TableId = id;
            Require.invariant(rule.IsNonEmpty);
            Require.invariant(rows.Length != 0);
            Rule = rule;
            Rows = rows;
        }

        [MethodImpl(Inline)]
        TableCriteria(uint id)
        {
            TableId = id;
            Rule = RuleIdentity.Empty;
            Rows = sys.empty<RowCriteria>();
        }

        public RuleIdentity SigKey
        {
            [MethodImpl(Inline)]
            get => Rule;
        }

        public RuleTableKind TableKind
        {
            [MethodImpl(Inline)]
            get => Rule.TableKind;
        }

        public RuleName TableName
        {
            [MethodImpl(Inline)]
            get => SigKey.TableName;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => Rows.Count;
        }

        public ref readonly RowCriteria this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public ref readonly RowCriteria this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Rule.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Rule.IsNonEmpty;
        }

        public uint RenderLines(ITextEmitter dst)
        {
            var src = ToLines();
            for(var i=0; i<src.Length; i++)
                dst.AppendLineFormat("# {0}", skip(src,i).Content);
            return (uint)src.Length;
        }

        public TableCriteria Merge(in TableCriteria src)
            => new (Require.equal(Rule, src.Rule), Rows.Append(src.Rows));

        [MethodImpl(Inline)]
        public TableCriteria WithId(uint id)
            => new (id, Rule, Rows);

        public ReadOnlySpan<TextLine> ToLines()
            => Lines.read(Format(), trim:false);

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        public int CompareTo(TableCriteria src)
            => Rule.CompareTo(src.Rule);

        public static TableCriteria Empty => new TableCriteria(0);
    }
}
