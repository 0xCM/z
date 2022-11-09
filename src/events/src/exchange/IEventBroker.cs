//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEventBroker : IEventTarget, ISink<IAppMsg>,  IDisposable
    {
        Outcome Subscribe<E>(Action<E> receiver, E model = default)
            where E : IEvent;

        IEventSink Sink {get;}
    }
}