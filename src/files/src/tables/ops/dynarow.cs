//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static DynamicRow<T> dynarow<T>(ClrTableCols fields)
            => new DynamicRow<T>(fields, new object[fields.Length]);

        [Op, Closures(Closure)]
        public static DynamicRow dynarow(ClrTableCols fields)
            => new DynamicRow(fields, new object[fields.Length]);
    }
}