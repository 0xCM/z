//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

partial class XedPatterns
{
    [MethodImpl(Inline), Op]
    public static uint where(in OpAttribs src, OpAttribKind @class, Span<OpAttrib> dst)
    {
        var j=0u;
        var count = min(src.Count, dst.Length);
        for(var i=0; i<count; i++)
        {
            ref readonly var a = ref src[i];
            if(a.Kind == @class)
                seek(dst,j++) = a;
        }
        return j;
    }

    [MethodImpl(Inline), Op]
    public static uint where(PatternOps src, OpAttribKind @class, Span<PatternOp> dst)
    {
        var j=0u;
        Span<OpAttrib> buffer = stackalloc OpAttrib[12];
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var op = ref src[i];
            if(exists(op.Attribs, @class))
                seek(dst,j++) = op;
        }
        return j;
    }
}
