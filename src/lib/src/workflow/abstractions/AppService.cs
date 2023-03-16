//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [WfService]
    public abstract class AppService : IAppService
    {
        public IWfRuntime Wf {get; private set;}

        public IWfChannel Channel {get; private set;}

        public abstract Type HostType {get;}

        public WfChannel Emitter {get; private set;}

        void IChanneled.Connect(Z0.IWfChannel channel)
        {
            
        }

        public virtual T Service<T>(Func<T> factory)
        {
            lock(ServiceLock)
                return (T)ServiceCache.GetOrAdd(typeof(T), key => factory());
        }


        public void Init(IWfRuntime wf)
        {
            Wf = wf;
            Emitter = WfChannel.create(wf, HostType);  
            Channel = Emitter;          
            var flow = Channel.Creating(HostType);
            OnInit();
            Initialized();
            Channel.Created(flow);
        }

        Files _Files;

        protected Files Files()
            => _Files;

        protected Files Files(Files src, bool write = true)
        {
            _Files = src;
            if(write)
                iter(src, path => Emitter.Write(path.ToUri()));
            return Files();
        }

        protected virtual void OnInit()
        {

        }

        protected virtual void Initialized() { }

        protected virtual void Disposing() { }

        public void Dispose()
        {
            Disposing();
            Wf.Disposed();
        }

        public static ref readonly AppData AppData
        {
            [MethodImpl(Inline)]
            get => ref _AppData;
        }

        protected static bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        protected static CmdArg arg(in CmdArgs src, int index)
            => CmdArgs.arg(src, index);

        protected static T arg<T>(in CmdArgs src, int index, out T dst)
        {
            var data = CmdArgs.arg(src,index).Value;
            if(typeof(T) == typeof(bit))
                dst = @as<bit,T>(bit.parse(data));
            else
                dst = @throw<T>();
            return dst;
        }

        static AppData  _AppData;

        static readonly Dictionary<string,string> ContextValues;

        static AppService()
        {
            _AppData = Z0.AppData.get();
            ContextValues = new();
        }

        protected static void ContextValue(string name, string value)
            => ContextValues[name] = value;

        protected static string ContextValue(string name)
        {
            var result = EmptyString;
            ContextValues.TryGetValue(name, out result);
            return result;
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
        protected static D update<D>(object key, Func<D> factory)
        {
            lock(DataLock)
                return (D)_Data.AddOrUpdate(key, o => factory(), (a,b) => factory());
        }

        [MethodImpl(Inline)]
        protected void ClearCache()
        {
            lock(DataLock)
                _Data.Clear();
        }

        static ConcurrentDictionary<Type,object> ServiceCache {get;}
            = new();

        static object ServiceLock = new();
    }
}