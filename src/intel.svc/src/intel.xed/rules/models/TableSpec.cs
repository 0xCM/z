//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    public readonly struct TableSpec : IComparable<TableSpec>
    {
        public readonly ushort TableId;

        public readonly RuleIdentity Identity;

        public readonly ReadOnlySeq<RowSpec> Rows;

        [MethodImpl(Inline)]
        public TableSpec(ushort id, RuleIdentity key, RowSpec[] rows)
        {
            TableId = id;
            Identity = key;
            Rows = rows;
        }

        public RuleName Name
        {
            [MethodImpl(Inline)]
            get => Identity.TableName;
        }

        public RuleTableKind TableKind
        {
            [MethodImpl(Inline)]
            get => Identity.TableKind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Rows.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Rows.IsNonEmpty;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => Rows.Count;
        }

        public ref readonly RowSpec this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public ref readonly RowSpec this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public string Format()
            => XedCellRender.expressions(this);

        public override string ToString()
            => Format();

        public int CompareTo(TableSpec src)
            => Identity.CompareTo(src.Identity);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySeq<RowSpec>(TableSpec src)
            => src.Rows;

        public static TableSpec Empty => new TableSpec(z16, RuleIdentity.Empty, sys.empty<RowSpec>());
    }
}
