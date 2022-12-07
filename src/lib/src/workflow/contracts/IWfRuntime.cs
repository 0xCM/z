//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Events;

    public interface IWfRuntime : IDisposable, ITextual
    {
        PartName AppName {get;}

        ReadOnlySeq<string> Args {get;}

        IApiCatalog ApiCatalog {get;}

        IEventBroker EventBroker {get;}

        IEventSink EventSink {get;}
        
        LogLevel Verbosity {get;}

        ExecToken NextExecToken();

        ExecToken Completed(ExecFlow src, bool success = true);

        ExecToken Completed(FileEmission src);

        ExecToken Completed<T>(ExecFlow<T> src, bool success = true);

        IWfEmissions Emissions {get;}

        void RedirectEmissions(IWfEmissions dst);

        WfEmit Emitter {get;}
        
        IWfChannel Channel 
            => Emitter;

        void Disposed()
        {
            if(Verbosity.IsBabble())
                Raise(Events.disposed(EventSink.Host));
        }

        ExecFlow<T> Running<T>(T data)
        {
            signal(EventSink).Running(data);
            return Flow(data);
        }

        ExecFlow<T> Running<T>(AppEventSource host, T msg)
        {
            signal(EventSink, host).Running(msg);
            return Flow(msg);
        }

        ExecFlow<string> Running(AppEventSource host, [CallerName] string caller = null)
        {
            signal(EventSink, host).Running(caller);
            return Flow(caller);
        }

        ExecToken Ran(ExecFlow src)        
        {
            var token = Completed(src);
            signal(EventSink).Ran(src);
            return token;
        }

        ExecToken Ran<T>(ExecFlow<T> src)
        {
            var token = Completed(src);
            signal(EventSink).Ran(src.Data);
            return token;
        }

        ExecToken Ran<T>(AppEventSource host, ExecFlow<T> src, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            signal(EventSink, host).Ran(src.Data);
            return token;
        }

        ExecToken Ran<T,D>(ExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            signal(EventSink).Ran(data);
            return token;
        }

        string ITextual.Format()
            => AppName.Format();

        ExecFlow<T> Flow<T>(T data)
            => new ExecFlow<T>(Channel, data, NextExecToken());

        TableFlow<T> TableFlow<T>(FilePath dst)
            where T : struct
                => new TableFlow<T>(Channel, dst, NextExecToken());

        FileEmission Flow(FilePath dst)
            => new FileEmission(NextExecToken(), dst, 0);

        EventId Raise<E>(in E e)
            where E : IEvent
        {
            EventSink.Deposit(e);
            return e.EventId;
        }

        void Babble<T>(T data)
            => signal(EventSink).Babble(data);

        void Babble<T>(AppEventSource host, T data)
            => signal(EventSink, host).Babble(data);

        void Status<T>(T data, FlairKind flair = FlairKind.Status)
            => signal(EventSink).Status(data, flair);

        void Status<T>(AppEventSource host,T data, FlairKind flair = FlairKind.Status)
            => signal(EventSink, host).Status(data, flair);

        void Warn<T>(T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => signal(EventSink).Warn(msg, originate(this.GetType(), caller, file, line));

        void Error(Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => signal(EventSink).Error(e, Events.originate("WorkflowError", caller, file, line));

        void Error<T>(T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
            => signal(EventSink).Error(msg, Events.originate("WorkflowError", caller, file, line));

        void Error<T>(AppEventSource host, T data, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
            => signal(EventSink, host).Error(data, Events.originate("WorkflowError", caller, file, line));

        ExecFlow<Type> Creating(Type host)
        {
            signal(EventSink, host).Creating(host);
            return Flow(host);
        }

        ExecToken Created(ExecFlow<Type> flow)
        {
            signal(EventSink).Created(flow.Data);
            return Completed(flow);
        }

        ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
        {
            signal(EventSink, host).Raise(Events.error(host, e, caller,file,line));
            return Completed(flow);
        }

        ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, EventOrigin origin)
        {
            signal(EventSink, host).Raise(Events.error(host, e, origin));
            return Completed(flow);
        }

        TableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
        {
            signal(EventSink).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        TableFlow<T> EmittingTable<T>(AppEventSource host, FilePath dst)
            where T : struct
        {
            signal(EventSink, host).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedTable<T>(AppEventSource host, TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink, host).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        FileEmission EmittingFile(FilePath dst)
        {
            signal(EventSink).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        FileEmission EmittingFile(AppEventSource host, FilePath dst)
        {
            signal(EventSink, host).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        ExecToken EmittedFile(FileEmission flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedFile(FileEmission flow)
        {
            var completed = Completed(flow);
            signal(EventSink).EmittedFile(flow.WithToken(completed));
            return completed;
        }
        
        ExecToken EmittedFile(FileEmission flow, int count)
            => EmittedFile(flow, (Count)count);

        ExecToken EmittedFile(FileEmission flow, uint count)
            => EmittedFile(flow, (Count)count);

        ExecToken EmittedFile<T>(FileEmission flow, T msg)
        {
            var completed = Completed(flow);
            var counted = flow.WithToken(completed);
            signal(EventSink).EmittedFile(counted.Target, msg);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedFile(AppEventSource host, FileEmission flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(EventSink, host).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        void Data<T>(T data)
            => signal(EventSink).Data(data);

        void Data<T>(AppEventSource host, T data)
            => signal(EventSink).Data(data);

        void Data<T>(AppEventSource host, T data, FlairKind flair)
            => signal(EventSink).Data(data, flair);

        void Row<T>(T data)
            => signal(EventSink).Row(data);

        void Row<T>(T data, FlairKind flair)
            => signal(EventSink).Row(data, flair);
    }
}