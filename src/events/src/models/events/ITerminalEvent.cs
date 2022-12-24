//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITerminalEvent<T> : IEvent<T>
        where T : ITerminalEvent<T>, IEvent<T>, new()
    {

    }   
}