//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Storage
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref T src, int index)
            where T : unmanaged, IStorageBlock<T>
                => ref seek(recover<T>(src.Bytes),index);
    }
}