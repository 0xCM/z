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
        [MethodImpl(Inline), Factory(Positive), Closures(Closure)]
        public static PositiveOp<T> positive<T>()
            where T : unmanaged
                => default(PositiveOp<T>);
    }
}