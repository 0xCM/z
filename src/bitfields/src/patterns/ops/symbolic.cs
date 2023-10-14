//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    public static string symbolic<P>(P src)
        where P : IBitPattern
    {
        var dst = text.emitter();
        symbolic(src,dst);
        return dst.Emit();
    }

    public static void symbolic<P>(P src, ITextEmitter dst)
        where P : IBitPattern
    {
        var segs = src.Segments();
        var count = (int)segs.Count;
        for(var i=count-1; i>=0; i--)
        {
            if(i!=count-1)
                dst.Append(Chars.Space);            
            ref readonly var seg = ref segs[i];
            dst.Append(seg.SegName);            
        }
    }
}