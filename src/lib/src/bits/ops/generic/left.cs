//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        [MethodImpl(Inline), LProject, Closures(Integers)]
        public static T left<T>(T a, T b)
            where T : unmanaged
                => a;
    }
}