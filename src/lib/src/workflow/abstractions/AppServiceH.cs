//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppService<H> : AppService, IAppService<H>
        where H : AppService<H>, new()
    {
        public static string ServiceName => typeof(H).DisplayName();
        
        static ConcurrentDictionary<Type,object> ServiceCache {get;}
            = new();

        static ConcurrentDictionary<object,object> _Data {get;}
            = new();

        static object ServiceLock = new();

        static object DataLock = new();

        [MethodImpl(Inline)]
        protected D Data<D>(object key, Func<D> factory)
        {
            lock(DataLock)
                return (D)_Data.GetOrAdd(key, k => factory());
        }

        [MethodImpl(Inline)]
        protected static D data<D>(object key, Func<D> factory)
        {
            lock(DataLock)
                return (D)_Data.GetOrAdd(key, k => factory());
        }

        [MethodImpl(Inline)]
        protected static D update<D>(object key, Func<D> factory)
        {
            lock(DataLock)
                return (D)_Data.AddOrUpdate(key, o => factory(), (a,b) => factory());
        }

        /// <summary>
        /// Instantites the serice without initialization
        /// </summary>
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

        public override T Service<T>(Func<T> factory)
        {
            lock(ServiceLock)
                return (T)ServiceCache.GetOrAdd(typeof(T), key => factory());
        }

        [MethodImpl(Inline)]
        protected void ClearCache()
        {
            lock(DataLock)
                _Data.Clear();
        }
        protected WfHost Host 
            => HostType;

        public override Type HostType
            => typeof(H);

        protected void Babble(string pattern, params object[] args)
            => Emitter.Babble(pattern, args);

        protected void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Emitter.Status(content, flair);

        protected void Warn(string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Emitter.Warn(msg, caller, file, line);

        protected virtual void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Emitter.Error(content, caller, file, line);

        protected WfExecFlow<string> Running([CallerName] string msg = null)
            => Emitter.Running(msg);

        protected ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => Emitter.Ran(flow, msg);

        protected void Write<T>(T content)
            => Emitter.Write(content);

        protected FileWritten EmittingFile(FilePath dst)
            => Emitter.EmittingFile(dst);

        public ExecToken EmittedFile(FileWritten flow, Count count)
            => Emitter.EmittedFile(flow,count);

        protected WfTableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
                => Emitter.EmittingTable<T>(dst);

        protected ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
                => Emitter.EmittedTable(flow,count, dst);

        WfEventLogger EventLogger
            => e => Emitter.Raise(e);

        protected IWfEventTarget EventLog
            => EventLogger.ToTarget(GetType());
    }
}