//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        [MethodImpl(Inline), RProject, Closures(Integers)]
        public static T right<T>(T a, T b)
            where T : unmanaged
                => b;
    }
}