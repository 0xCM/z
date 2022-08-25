//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static Type[] NestedTypes(this Assembly a)
            => a.Types().Nested();
    }
}