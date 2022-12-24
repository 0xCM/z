//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedRules
    {
        public Index<InstOpClass> CalcOpClasses(Index<InstOpDetail> src)
        {
            return Data(nameof(CalcOpClasses), Calc);

            Index<InstOpClass> Calc()
            {
                var buffer = sys.bag<InstOpClass>();
                iter(src, op => buffer.Add(XedOps.opclass(op)), true);
                var dst = buffer.Array().Distinct().Sort();
                for(var i=0u; i<dst.Length; i++)
                    seek(dst,i).Seq = i;
                return dst;
            }
        }
    }
}