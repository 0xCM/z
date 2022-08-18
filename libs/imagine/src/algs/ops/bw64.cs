//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline)]
        public static uint bw32<T>(T src)
            where T : unmanaged
                => Sized.bw32(src);

        [MethodImpl(Inline)]
        public static ulong bw64<T>(T src)
            where T : unmanaged
                => Sized.bw64(src);

        [MethodImpl(Inline)]
        public static long bw64i<T>(T src)
            where T : unmanaged
                => Sized.bw64i(src);
    }
}