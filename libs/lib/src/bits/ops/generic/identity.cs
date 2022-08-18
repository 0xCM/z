//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class gbits
    {
        [MethodImpl(Inline), IdentityFunction, Closures(Integers)]
        public static T identity<T>(T a)
            where T : unmanaged
                => a;
    }
}