//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;

    partial struct Calcs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VRotlx128<T> vrotlx<T>(W128 w)
            where T : unmanaged
                => default(VRotlx128<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VRotlx256<T> vrotlx<T>(W256 w)
            where T : unmanaged
                => default(VRotlx256<T>);
    }
}