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
        
        KillMe Host {get;}

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
                Raise(Events.disposed(Host.Type));
        }

        ExecFlow<T> Running<T>(T data)
        {
            signal(this).Running(data);
            return Flow(data);
        }

        ExecFlow<T> Running<T>(KillMe host, T msg)
        {
            signal(this, host).Running(msg);
            return Flow(msg);
        }

        ExecFlow<string> Running(KillMe host, [CallerName] string caller = null)
        {
            signal(this, host).Running(caller);
            return Flow(caller);
        }

        ExecToken Ran<T>(ExecFlow<T> src)
        {
            var token = Completed(src);
            signal(this).Ran(src.Data);
            return token;
        }

        ExecToken Ran<T>(KillMe host, ExecFlow<T> src, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            signal(this, host).Ran(src.Data);
            return token;
        }

        ExecToken Ran<T,D>(ExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            signal(this).Ran(data);
            return token;
        }

        // Assembly[] Components
        //     => ApiCatalog.Assemblies;

        string ITextual.Format()
            => AppName.Format();

        ExecFlow<T> Flow<T>(T data)
            => new ExecFlow<T>(this, data, NextExecToken());

        TableFlow<T> TableFlow<T>(FilePath dst)
            where T : struct
                => new TableFlow<T>(this, dst, NextExecToken());

        FileEmission Flow(FilePath dst)
            => new FileEmission(NextExecToken(), dst, 0);

        EventId Raise<E>(in E e)
            where E : IEvent
        {
            EventSink.Deposit(e);
            return e.EventId;
        }

        void Babble<T>(T data)
            => signal(this).Babble(data);

        void Babble<T>(KillMe host, T data)
            => signal(this, host).Babble(data);

        void Status<T>(T data, FlairKind flair = FlairKind.Status)
            => signal(this).Status(data, flair);

        void Status<T>(KillMe host,T data, FlairKind flair = FlairKind.Status)
            => signal(this, host).Status(data, flair);

        void Warn<T>(T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => signal(this).Warn(msg, originate(this.GetType(), caller, file, line));

        void Error(Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => signal(this).Error(e, Events.originate("WorkflowError", caller, file, line));

        void Error<T>(T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
            => signal(this).Error(msg, Events.originate("WorkflowError", caller, file, line));

        void Error<T>(KillMe host, T data, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
            => signal(this, host).Error(data, Events.originate("WorkflowError", caller, file, line));

        ExecFlow<Type> Creating(Type host)
        {
            signal(this, host).Creating(host);
            return Flow(host);
        }

        ExecToken Created(ExecFlow<Type> flow)
        {
            signal(this, flow.Data).Created(flow.Data);
            return Completed(flow);
        }

        ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
        {
            signal(this).Raise(Events.error(host, e, caller,file,line));
            return Completed(flow);
        }

        ExecToken Completed<T>(ExecFlow<T> flow, Type host, Exception e, EventOrigin origin)
        {
            signal(this).Raise(Events.error(host, e, origin));
            return Completed(flow);
        }

        TableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
        {
            signal(this).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        TableFlow<T> EmittingTable<T>(KillMe host, FilePath dst)
            where T : struct
        {
            signal(this, host).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedTable<T>(KillMe host, TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this, host).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        FileEmission EmittingFile(FilePath dst)
        {
            signal(this).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        FileEmission EmittingFile(KillMe host, FilePath dst)
        {
            signal(this, host).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        ExecToken EmittedFile(FileEmission flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedFile(FileEmission flow)
        {
            var completed = Completed(flow);
            signal(this).EmittedFile(flow.WithToken(completed));
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
            signal(this).EmittedFile(counted.Target, msg);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedFile(KillMe host, FileEmission flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this, host).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        void Data<T>(T data)
            => signal(this).Data(data);

        void Data<T>(T data, FlairKind flair)
            => signal(this).Data(data, flair);

        void Data<T>(KillMe host, T data)
            => signal(this).Data(data);

        void Data<T>(KillMe host, T data, FlairKind flair)
            => signal(this).Data(data, flair);

        void Row<T>(T data)
            => signal(this).Row(data);

        void Row<T>(T data, FlairKind flair)
            => signal(this).Row(data, flair);
    }
}