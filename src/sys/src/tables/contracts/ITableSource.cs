//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITableSource
    {

    }

    public interface ITableSource<T> : ITableSource
        where T : struct
    {

    }
}