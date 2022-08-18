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
        public static DataSize max(ReadOnlySpan<DataSize> src)
        {
            var dst = DataSize.Zero;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src,i);
                if(x > dst)
                    dst = x;
            }
            return dst;
        }


        [MethodImpl(Inline), Op]
        public static DataSize max(params DataSize[] src)
            => max(@readonly(src));
    }
}