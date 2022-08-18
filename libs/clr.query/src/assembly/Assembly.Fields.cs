//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static FieldInfo[] Fields(this Assembly a)
            => a.GetTypes().SelectMany(x => x.Fields());
    }
}