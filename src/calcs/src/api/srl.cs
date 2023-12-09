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
        [MethodImpl(Inline), Factory(Srl), Closures(Closure)]
        public static Srl<T> srl<T>()
            where T : unmanaged
                => default(Srl<T>);

        [MethodImpl(Inline), Factory(Srl), Closures(Closure)]
        public static VSrl128<T> vsrl<T>(W128 w)
            where T : unmanaged
                => default(VSrl128<T>);

        [MethodImpl(Inline), Factory(Srl), Closures(Closure)]
        public static VSrl256<T> vsrl<T>(W256 w)
            where T : unmanaged
                => default(VSrl256<T>);

    }
}