//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public delegate void WfEventLogger(IWfEvent e);

    [WfService]
    public abstract class AppService<H> : IAppService<H>
        where H : AppService<H>, new()
    {
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

        public virtual Type EffectiveHost {get;}

        static ConcurrentDictionary<Type,object> ServiceCache {get;}
            = new();

        static object ServiceLock = new();

        public T Service<T>(Func<T> factory)
        {
            lock(ServiceLock)
                return (T)ServiceCache.GetOrAdd(typeof(T), key => factory());
        }

        protected static T service<T>(Func<T> factory)
        {
            lock(ServiceLock)
                return (T)ServiceCache.GetOrAdd(typeof(T), key => factory());
        }

        static ConcurrentDictionary<string,object> _ServiceState {get;}
            = new();

        [MethodImpl(Inline)]
        protected static D state<D>(string key, Func<D> factory)
            => (D)_ServiceState.GetOrAdd(key, k => factory());

        [MethodImpl(Inline)]
        protected static ref readonly D state<D>(string key, out D dst)
        {
            dst = (D)_ServiceState[key];
            return ref dst;
        }

        static ConcurrentDictionary<object,object> _Data {get;}
            = new();

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
        protected void ClearCache()
        {
            lock(DataLock)
                _Data.Clear();
        }

        public IWfRuntime Wf {get; private set;}

        protected WfHost Host {get; private set;}

        protected Type HostType
            => typeof(H);

        FS.Files _Files;

        public IWfMsg WfMsg {get; private set;}

        public void Init(IWfRuntime wf)
        {
            Wf = wf;
            WfMsg = new WfMsgSvc(Wf, EffectiveHost);
            var flow = WfMsg.Creating(EffectiveHost);
            OnInit();
            Initialized();
            WfMsg.Created(flow);
        }

        public void AppInit(IWfRuntime wf)
        {
            Wf = wf;
            WfMsg = new WfMsgSvc(Wf, EffectiveHost);
            var flow = WfMsg.Creating(EffectiveHost);
            wf.Babble($"Initializing {typeof(H).AssemblyQualifiedName}");
            OnInit();
            wf.Babble($"Initialized {typeof(H).AssemblyQualifiedName}");
            Initialized();
            WfMsg.Created(flow);
        }

        protected AppService()
        {
            Host = new WfHost(typeof(H));
            EffectiveHost = typeof(H);
        }

        protected AppService(IWfRuntime wf)
            : this()
        {
            Wf = wf;
        }

        protected FS.Files Files()
            => _Files;

        protected FS.Files Files(FS.Files src, bool write = true)
        {
            _Files = src;
            if(write)
                iter(src, path => Write(path.ToUri()));
            return Files();
        }

        protected IApiCatalog ApiCatalog => Wf.ApiCatalog;

        protected void Babble(string pattern, params object[] args)
            => WfMsg.Babble(pattern, args);

        protected void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => WfMsg.Status(content, flair);

        protected void Warn(string pattern, params object[] args)
            => WfMsg.Warn(pattern, args);

        protected virtual void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => WfMsg.Error(content, caller, file, line);

        protected WfExecFlow<string> Running([CallerName] string msg = null)
            => WfMsg.Running(msg);

        protected ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => WfMsg.Ran(flow, msg);

        protected void Write<T>(T content)
            => WfMsg.Write(content);

        protected FileWritten EmittingFile(FS.FilePath dst)
            => WfMsg.EmittingFile(dst);

        public ExecToken EmittedFile(FileWritten flow, Count count)
            => WfMsg.EmittedFile(flow,count);

        protected WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => WfMsg.EmittingTable<T>(dst);

        protected ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => WfMsg.EmittedTable(flow,count, dst);

        protected WfEventLogger EventLogger
            => x => WfMsg.Raise(x);

        protected IWfEventTarget EventLog
            => EventLogger.ToTarget(GetType());

        protected virtual void OnInit()
        {

        }

        protected virtual void Initialized()
        {

        }

        protected virtual void Disposing() { }

        public void Dispose()
        {
            Disposing();
            Wf.Disposed();
        }
    }
}