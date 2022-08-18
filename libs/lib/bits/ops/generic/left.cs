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
        [MethodImpl(Inline), LProject, Closures(Integers)]
        public static T left<T>(T a, T b)
            where T : unmanaged
                => a;
    }
}