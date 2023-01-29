//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppService<H> : AppService, IAppService<H>
        where H : AppService<H>, new()
    {
        [MethodImpl(Inline)]
        protected static H @new() => new H();

        /// <summary>
        /// Creates and initializes the service
        /// </summary>
        /// <param name="wf">The source workflow</param>
        public static H create(IWfRuntime wf)
        {
            var service = @new();
            service.Init(wf);
            return service;
        }

        protected AppEventSource Host 
            => HostType;

        public override Type HostType
            => typeof(H);

        protected void Babble(string pattern, params object[] args)
            => Channel.Babble(pattern, args);

        protected void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Channel.Status(content, flair);

        protected void Warn(string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Channel.Warn(msg, caller, file, line);

        protected virtual void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Channel.Error(content, caller, file, line);

        protected ExecFlow<string> Running([CallerName] string msg = null)
            => Channel.Running(msg);

        protected ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null)
            => Channel.Ran(flow, msg);

        protected void Write<T>(T content)
            => Channel.Write(content);

        protected FileEmission EmittingFile(FilePath dst)
            => Channel.EmittingFile(dst);

        public ExecToken EmittedFile(FileEmission flow, Count count)
            => Channel.EmittedFile(flow,count);

        protected TableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
                => Channel.EmittingTable<T>(dst);

        protected ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
                => Channel.EmittedTable(flow,count, dst);

        Action<IEvent> EventLogger
            => e => Emitter.Raise(e);

        protected IEventTarget EventLog
            => new EventTarget(EventLogger);
    }
}