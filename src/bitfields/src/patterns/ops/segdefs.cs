//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    public static Seq<BfSegDef> segdefs(BpExpr src)
    {
        var names = symbols(src);
        var count = names.Length;
        var dst = alloc<BfSegDef>(count);
        var offset = z8;
        var size = packedsize(src);
        if(size.Width <= 8)
        {
            for(var i=count-1; i>=0; i--)
            {
                ref readonly var name = ref names[i];
                var width = (byte)name.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                seek(dst,i) = Bitfields.segdef(name, min, max, Bitfields.mask(size, min, max));
                offset += width;
            }
        }
        else
        {
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref names[i];
                var width = (byte)name.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                seek(dst,i) = Bitfields.segdef(name, min, max, Bitfields.mask(size, min, max));
                offset += width;
            }
        }

        return dst;
    }
}
