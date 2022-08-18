//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Quad<T> quad<T>(T a, T b, T c, T d)
            => new Quad<T>(a, b, c, d);
    }
}