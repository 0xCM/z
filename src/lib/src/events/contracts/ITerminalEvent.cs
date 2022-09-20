//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITerminalEvent<T> : IWfEvent<T>
        where T : ITerminalEvent<T>, IWfEvent<T>, new()
    {

    }   
}