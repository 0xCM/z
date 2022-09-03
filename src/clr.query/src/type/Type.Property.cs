//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System.Linq;

    using static ReflectionFlags;

    partial class ClrQuery
    {
        [Op]
        public static Option<PropertyInfo> Property(this Type src, string name)
            => src.GetProperties(BF_All).Where(p => p.Name == name).FirstOrDefault();
    }
}