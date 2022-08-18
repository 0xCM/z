//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppRes
    {
        string Name {get;}
    }

    public interface IAppRes<T> : IAppRes
    {
        T Content {get;}
    }
}