//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [Op]
        public static asci8 trim(in asci8 src)
        {
            var data = sys.bytes(src);
            var l0 = (int)src.Length;
            var i0 = 0;
            var i1 = l0 - 1;
            for(var i=0; i<l0; i++)
            {
                ref readonly var b = ref skip(data,i);
                if(SQ.whitespace((AsciCode)b))
                    i0++;
                else
                    break;
            }
            for(var i=l0-1; i>=0; i--)
            {
                ref readonly var b = ref skip(data,i);
                if(SQ.whitespace((AsciCode)b))
                    i1--;
                else
                    break;
            }

            var l1 = i1 - i0;
            if(l0 != l1)
                return asci(n8, segment(data, i0, i1));
            else
                return src;
        }
    }
}