//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        [MethodImpl(Inline), IdentityFunction, Closures(Integers)]
        public static T identity<T>(T a)
            where T : unmanaged
                => a;
    }
}