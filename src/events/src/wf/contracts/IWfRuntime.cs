//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static Events;

public interface IWfRuntime : IDisposable, ITextual
{
    PartName AppName {get;}

    IEventBroker EventBroker {get;}

    IEventSink EventSink {get;}
    
    LogLevel Verbosity {get;}

    ExecToken NextExecToken();

    ExecToken Completed(ExecFlow src, bool success = true);

    ExecToken Completed(FileEmission src);

    ExecToken Completed<T>(ExecFlow<T> src, bool success = true);

    IEmissionLog Emissions {get;}

    IWfChannel Channel {get;}

    void Disposed()
    {
        if(Verbosity.IsBabble())
            Raise(disposed(EventSink.Host));
    }

    string ITextual.Format()
        => AppName.Format();

    EventId Raise<E>(in E e)
        where E : IEvent
    {
        EventSink.Deposit(e);
        return e.EventId;
    }
}
