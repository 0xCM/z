//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cast<T>(object src)
            => (T)src;
    }
}