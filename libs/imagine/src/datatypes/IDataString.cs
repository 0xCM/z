//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDataString : IDataType, IExpr
    {

    }

    [Free]
    public interface IDataString<K> : IDataString
        where K : IExpr
    {

    }
}