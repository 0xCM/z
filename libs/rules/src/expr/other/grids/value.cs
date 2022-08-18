//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct expr
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Value<T> value<T>(T src)
            => src;
    }
}