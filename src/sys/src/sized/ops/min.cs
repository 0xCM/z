//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Sized
    {
        [MethodImpl(Inline), Op]
        public static DataSize min(ReadOnlySpan<DataSize> src)
        {
            var dst = DataSize.Zero;
            var count = src.Length;
            if(count == 0)
                return dst;

            dst = first(src);
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                if(x < dst)
                    dst = x;
            }
            return dst;
        }
    }
}