//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Numeric;

    partial class gmath
    {
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static bit ispow2<T>(T src)
            where T : unmanaged
                => math.ispow2(force<T,ulong>(src));
    }
}