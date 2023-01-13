//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public static DbGrid<T> grid<T>(Dim2<uint> shape)
            => new DbGrid<T>(new DbRowGrid<T>(shape), new DbColGrid<T>(shape));
    }
}