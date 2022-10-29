//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [MethodImpl(Inline), Op]
        public static PropertyInfo[] Properties(this Assembly a)
            => a.GetTypes().SelectMany(x => x.DeclaredProperties()).Array();
    }
}