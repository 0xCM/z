//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VLoadSpan128<T> vloadspan<T>(W128 w)
            where T : unmanaged
                => default(VLoadSpan128<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VLoadSpan256<T> vloadspan<T>(W256 w)
            where T : unmanaged
                => default(VLoadSpan256<T>);
    }
}