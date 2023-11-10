//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public readonly struct RowSpec : IComparable<RowSpec>
    {
        public readonly ushort TableId;

        public readonly RuleIdentity Sig;

        public readonly ushort RowIndex;

        public readonly Seq<CellKey> Keys;

        public readonly Seq<CellInfo> CellInfo;

        public readonly ushort ColCount;

        readonly byte AntecedantCount;

        readonly byte OperatorIndex;
        
        readonly byte ConsequentCount;

        public RowSpec(RuleIdentity sig, ushort tid, ushort rix, CellKey[] keys, CellInfo[] cells)
        {
            Sig = sig;
            TableId = tid;
            RowIndex = rix;
            Keys = keys;
            CellInfo = cells;
            ColCount = (ushort)Require.equal(keys.Length, cells.Length);
            var a = z8;
            var o = z8;
            var c = z8;
            for(var i=z8; i<ColCount; i++)
            {
                ref readonly var key = ref Keys[i];
                if(key.Logic == LogicClass.Antecedant)
                    a++;
                else if(key.Logic == LogicClass.Operator)
                    o=i;
                else if(key.Logic == LogicClass.Consequent)
                    c++;                
            }
            AntecedantCount = a;
            OperatorIndex = o;
            ConsequentCount = c;
        }

        public ReadOnlySpan<CellKey> Antecedants
        {
            [MethodImpl(Inline)]
            get => sys.slice(Keys.View,0,AntecedantCount);
        }

        public ref readonly CellKey Operator
        {
            [MethodImpl(Inline)]
            get => ref Keys[OperatorIndex];
        }

        public ReadOnlySpan<CellKey> Consequents
        {
            [MethodImpl(Inline)]
            get => ConsequentCount != 0 ? sys.slice(Keys.View,OperatorIndex + 1,ConsequentCount) : sys.empty<CellKey>();
        }

        [MethodImpl(Inline)]
        public ref readonly CellInfo Cell(ushort i)
            => ref CellInfo[i];

        [MethodImpl(Inline)]
        public ref readonly CellKey Key(ushort i)
            => ref Keys[i];

        public string Format()
            => XedCellRender.expression(this);

        public override string ToString()
            => Format();

        public int CompareTo(RowSpec src)
            => Sig.CompareTo(src.Sig);
    }
}
