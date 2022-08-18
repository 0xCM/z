//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEventBroker : ISink<IWfEvent> , ISink<IAppEvent>, ISink<IAppMsg>,  IDisposable
    {
        Outcome Subscribe<E>(Action<E> receiver, E model = default)
            where E : IAppEvent;

        void Raise(IWfEvent e);

        void Raise(IAppEvent e);

        IEventSink Sink {get;}
    }
}