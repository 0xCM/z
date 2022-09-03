//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong vhi64<T>(Vector128<T> src)
            where T : unmanaged
                => cpu.vcell(v64u(src),1);
    }
}