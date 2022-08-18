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
        [MethodImpl(Inline), Factory(Lo), Closures(Closure)]
        public static VLo128<T> vlo<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VLo128<T>);

        [MethodImpl(Inline), Factory(Lo), Closures(Closure)]
        public static VLo256<T> vlo<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VLo256<T>);
    }
}