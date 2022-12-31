//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IJsonParameter : INamed<@string>
    {

    }

    public interface IJsonParameter<T> : IJsonParameter, IDataType<T>
        where T : IJsonParameter<T>,new()
    {

    }
}
