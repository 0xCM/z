//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static SFx;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Dot), Closures(Closure)]
        public static DotProduct<T> dot<T>()
            where T : unmanaged
                => sfunc<DotProduct<T>>();

        [MethodImpl(Inline), Factory, Closures(UnsignedInts)]
        public static BvDotProduct<T> bvdot<T>()
            where T : unmanaged
                => sfunc<BvDotProduct<T>>();
    }
}