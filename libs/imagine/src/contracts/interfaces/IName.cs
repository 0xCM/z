//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IName : IDataString
    {

    }

    public interface IName<T> : IName, IDataString<T>
        where T : IDataType<T>, IExpr
    {

    }
}