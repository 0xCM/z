//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Hex
    {
        [Op, Closures(Closure)]
        public static string format<T>(UpperCased @case, T value)
            where T : unmanaged
                => new string(render<T>(@case, value));
    }
}