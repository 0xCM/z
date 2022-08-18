//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppServices<T> : Services<T>
        where T : AppServices<T>, new()
    {
        public IAppService Service(IWfRuntime wf, Type host, string name)
            => service(wf, host, name);

        public S Service<S>(IWfRuntime wf, string name)
            where S : IAppService, new()
                => service<S>(wf, name);

        public S Service<S>(IWfRuntime wf)
            where S : IAppService, new()
                => service<S>(wf);

        public S Service<S>(IWfRuntime wf, string name, Func<IWfRuntime,S> factory)
            where S : IAppService, new()
                => service(wf,name,factory);
   }
}