//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static AsmOpCodes;
using static XedModels;

partial class XedCells
{
    public static OpCodeValue ocvalue(in InstCells src)
    {
        var count = src.Count;
        var storage = ByteBlock4.Empty;
        var dst = storage.Bytes;
        var j=0;
        for(var i=0; i<count; i++)
        {
            ref readonly var seg = ref src[i];
            if(seg.CellKind == RuleCellKind.HexLit)
                seek(dst,j++) = seg.AsHexLit();
        }
        return new OpCodeValue(slice(dst,0,j));
    }    
}
