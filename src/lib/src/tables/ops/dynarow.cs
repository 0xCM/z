//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static DynamicRow<T> dynarow<T>(ClrTableCells fields)
            where T : struct
                => new DynamicRow<T>(fields, new object[fields.Length]);

        [Op, Closures(Closure)]
        public static DynamicRow dynarow(ClrTableCells fields)
            => new DynamicRow(fields, new object[fields.Length]);
    }
}