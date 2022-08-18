//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [MethodImpl(Inline), Op]
        public static bool IsStatic(this PropertyInfo p)
            => p.GetGetMethod()?.IsStatic == true
            || p.GetSetMethod()?.IsStatic == true;
    }
}