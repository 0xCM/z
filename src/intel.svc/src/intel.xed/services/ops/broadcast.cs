//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;
using Asm;

partial class Xed
{
    [MethodImpl(Inline), Op]
    public static bool broadcast(in PatternOp src, out BroadcastKind dst)
    {
        dst = 0;
        if(src.Kind == OpKind.Bcast)
            if(XedParsers.parse(src.SourceExpr, out dst))
                return true;
        return false;
    }

    public static Index<AsmBroadcast> broadcasts(ReadOnlySpan<BroadcastKind> src)
    {
        var dst = alloc<AsmBroadcast>(src.Length);
        for(var j=0; j<src.Length; j++)
            seek(dst,j) = asm.broadcast(skip(src,j));
        return dst;
    }
}
