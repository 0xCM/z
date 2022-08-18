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
        [MethodImpl(Inline), Factory(EffWidth), Closures(UnsignedInts)]
        public static BvEffWidth<T> bveffwidth<T>()
            where T : unmanaged
                => SFx.sfunc<BvEffWidth<T>>();

        [MethodImpl(Inline), Factory, Closures(UnsignedInts)]
        public static BvGather<T> bvgather<T>()
            where T : unmanaged
                => SFx.sfunc<BvGather<T>>();
    }
}