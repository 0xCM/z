//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IIdentity : IDataType
    {

    }

    [Free]
    public interface IIdentity<T> : IIdentity, IDataType<T>
        where T : IIdentity<T>
    {

    }
}