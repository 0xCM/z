//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedModels;

    partial class XedOps
    {
        public Index<InstOpSpec> CalcSpecs(Index<InstOpDetail> src)
        {
            return Data("InstOpSpec", Calc);
            Index<InstOpSpec> Calc()
            {
                var dst = alloc<InstOpSpec>(src.Count);
                for(var i=0; i<src.Count; i++)
                    seek(dst,i) = XedOps.spec(src[i]);
                return dst;
            }
        }
    }
}