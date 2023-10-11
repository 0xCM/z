//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly struct PatternOrder : IComparer<XedInstOpCode>, IComparer<InstOpDetail>, IComparer<InstGroupSeq>
    {
        public readonly bit OpCodeFirst;

        public PatternOrder(bit ocfirst = default)
        {
            OpCodeFirst = ocfirst;
        }

        public int Compare(InstOpDetail x, InstOpDetail y)
        {
            var a = new PatternSort(x, OpCodeFirst);
            var b = new PatternSort(y, OpCodeFirst);
            var result = a.CompareTo(b);
            if(result == 0)
            {
                result = x.Pattern.CompareTo(y.Pattern);
                if(result == 0)
                    result = x.Index.CompareTo(y.Index);
            }

            return result;
        }

        public int Compare(InstGroupSeq x, InstGroupSeq y)
        {
            var a = new PatternSort(x, OpCodeFirst);
            var b = new PatternSort(y, OpCodeFirst);
            var result = a.CompareTo(b);
            if(result == 0)
            {
                result = x.PatternId.CompareTo(y.PatternId);
                if(result == 0)
                    result = x.Index.CompareTo(y.Index);
            }

            return result;
        }

        public int Compare(XedInstOpCode x, XedInstOpCode y)
            => new PatternSort(x, OpCodeFirst).CompareTo(new PatternSort(y, OpCodeFirst));
    }
}
