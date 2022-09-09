//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TableSource<T> : ITableSource<T>
        where T : struct
    {

    }
    public abstract class TableSource<H,T> : TableSource<T>
        where H : TableSource<H,T>
        where T : struct
    {

    }
}