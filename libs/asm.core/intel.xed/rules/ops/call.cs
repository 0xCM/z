//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static NontermCall<T> call<T>(T src, RuleSig dst)
            where T : unmanaged, IComparable<T>
                => new NontermCall<T>(src,dst);
    }
}