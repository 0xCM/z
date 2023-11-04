//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;

partial class XedCells
{
    [MethodImpl(Inline), Op]
    public static FieldSet usage(in InstCells src)
    {
        var dst = FieldSet.create();
        for(var j=0; j<src.Count; j++)
            dst = dst.Include(src[j].Field);
        return dst;
    }    
}
