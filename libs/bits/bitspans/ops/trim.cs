//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static BitSpan trim(in BitSpan src)
        {
            var pos = msb(src);
            if(pos != 0 && pos != src.Length - 1)
                return load(core.slice(src.Storage,0, pos + 1));
            else
                return src;
        }
    }
}