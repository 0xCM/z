//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Concat), Closures(Closure)]
        public static VConcat2x128<T> vconcat<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VConcat2x128<T>);
    }
}