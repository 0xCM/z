//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;

    partial class vgcpu
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Pair<Vector128<T>> vsplit<T>(Vector256<T> src)
            where T : unmanaged
                => (vlo(src), vhi(src));

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Pair<Vector256<T>> vsplit<T>(Vector512<T> src)
            where T : unmanaged
                => (vlo(src), vhi(src));
    }
}