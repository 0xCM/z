//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IJsonDataType
    {
        @string Name {get;}
    }

    public interface IJsonDataType<T> : IJsonDataType
        where T : IJsonDataType<T>, new()
    {
    }
}
