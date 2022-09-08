//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        [MethodImpl(Inline), LNot, Closures(Integers)]
        public static T lnot<T>(T a, T b)
            where T : unmanaged
                => not(a);
    }
}