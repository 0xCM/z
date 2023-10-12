//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedCells
{
    [MethodImpl(Inline), Op]
    public static InstCells sort(in InstCells src)
    {
        var data = src.Data;
        var count = (byte)data.Count;
        var eCount = z8;
        var lCount = z8;
        for(var i=z8; i<count; i++)
        {
            ref var field = ref data[i];
            if(field.IsExpr)
                eCount++;
            else
                lCount++;
        }

        var lIx = z8;
        var eIx = lCount;
        for(var i=z8; i<count; i++)
        {
            ref var field = ref data[i];
            if(field.IsExpr)
                field = field.WithPosition(eIx++);
            else
                field = field.WithPosition(lIx++);
        }

        return new (data.Sort(), lCount);
    }
}

