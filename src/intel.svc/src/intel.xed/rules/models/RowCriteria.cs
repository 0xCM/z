//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public readonly struct RowCriteria
    {
        public readonly ReadOnlySeq<CellInfo> Antecedant;

        public readonly ReadOnlySeq<CellInfo> Consequent;

        [MethodImpl(Inline)]
        public RowCriteria(CellInfo[] p, CellInfo[] c)
        {
            Antecedant = p;
            Consequent = c;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Antecedant.Count == 0 && Consequent.Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        public static RowCriteria Empty => new (sys.empty<CellInfo>(), sys.empty<CellInfo>());
    }
}
