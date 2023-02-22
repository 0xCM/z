//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        [MethodImpl(Inline), RNot, Closures(Integers)]
        public static T rnot<T>(T a, T b)
            where T : unmanaged
                => not(b);
    }
}