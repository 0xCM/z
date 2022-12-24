//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static sys;

    partial class XedRules
    {
        public Index<OpName> CalcOpNames()
        {
            return Data(nameof(CalcOpNames), Calc);
            Index<OpName> Calc()
            {
                var src = Symbols.index<OpNameKind>().Kinds;
                var count = src.Length;
                var dst = alloc<OpName>(count);
                for(var i=0; i<count; i++)
                    seek(dst,i) = new (src[i]);
                return dst;
            }
        }
    }
}