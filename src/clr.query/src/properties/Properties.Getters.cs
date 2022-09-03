//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static MethodInfo[] Getters(this PropertyInfo[] src)
            => src.WithGet().Select(x => x.GetGetMethod());
    }
}