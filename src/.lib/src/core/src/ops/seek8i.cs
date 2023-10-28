//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte seek8i<T>(in T src, ulong count)
            => ref add(@as<T,sbyte>(edit(src)), (int)count);
    }
}