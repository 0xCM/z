//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit readbit<T>(in T src, uint bitpos)
            where T : unmanaged
                => gbits.test(skip(src, bitpos / width<T>()), (byte)(bitpos % sys.width<T>()));
    }
}