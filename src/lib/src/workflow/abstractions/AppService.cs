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

        public IWfChannel Channel => Emitter;

        public abstract Type HostType {get;}

        public WfEmit Emitter {get; private set;}

        public abstract T Service<T>(Func<T> factory);

        public void Init(IWfRuntime wf)
        {
            Wf = wf;
            Emitter = WfEmit.create(wf, HostType);            
            var flow = Emitter.Creating(HostType);
            OnInit();
            Initialized();
            Emitter.Created(flow);
        }

        Files _Files;

        protected IApiCatalog ApiCatalog => Wf.ApiCatalog;

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

        protected static AppSettings AppSettings => AppSettings.Default;

        protected static void ContextValue(string name, string value)
            => ContextValues[name] = value;

        protected static string ContextValue(string name)
        {
            var result = EmptyString;
            ContextValues.TryGetValue(name, out result);
            return result;
        }
    }
}