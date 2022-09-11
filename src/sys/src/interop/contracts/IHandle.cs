//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IHandle : IDisposable
    {
        MemoryAddress Address {get;}
    }

    [Free]
    public interface IHandle<H> : IHandle
        where H : IHandle<H>, new()
    {

    }
}