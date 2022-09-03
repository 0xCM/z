//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T value<T>(FieldInfo f)
            => (T)f.GetRawConstantValue();

        [MethodImpl(Inline), Op]
        public static object value(FieldInfo f)
            => f.GetRawConstantValue();
    }
}