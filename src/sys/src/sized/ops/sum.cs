//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static ScalarCast;
    using static sys;

    partial class Sized
    {
        [MethodImpl(Inline), Op]
        public static DataSize sum(ReadOnlySpan<DataSize> src)
        {
            var dst = DataSize.Zero;
            for(var i=0; i<src.Length; i++)
                dst += skip(src,i);
            return dst;
        }


        [MethodImpl(Inline), Op]
        public static DataSize sum(params DataSize[] src)
            => sum(@readonly(src));
    }
}