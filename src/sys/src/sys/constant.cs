//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T constant<T>(FieldInfo src)
            => (T)src.GetRawConstantValue();

        [MethodImpl(Options), Op]
        public static object constant(FieldInfo src)
            => src.GetRawConstantValue();
    }
}