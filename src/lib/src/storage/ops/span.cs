//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Storage
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(ref T src)
            where T : unmanaged, IStorageBlock<T>
                => recover<T>(src.Bytes);
    }
}