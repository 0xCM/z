//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IInitialEvent<T> : IWfEvent<T>
        where T : IInitialEvent<T>, IWfEvent<T>, new()
    {

    }
}