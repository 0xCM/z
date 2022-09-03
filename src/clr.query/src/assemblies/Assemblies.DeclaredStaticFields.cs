//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static FieldInfo[] DeclaredStaticFields(this Assembly[] src)
            => src.SelectMany(x => x.DeclaredStaticFields());
    }
}