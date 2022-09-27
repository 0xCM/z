//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEventSink<E> : ISink<E>
        where E : IWfEvent
    {

    }

    [Free]
    public interface IEventSink : IEventSink<IWfEvent>, IDisposable
    {

    }
}