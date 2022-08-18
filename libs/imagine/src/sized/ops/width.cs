//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Sized
    {
        [MethodImpl(Inline), Op]
        public static BitWidth width(NativeSizeCode src)
            => bits(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint width<T>()
            => (uint)sys.size<T>()*8;
    }
}