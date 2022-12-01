//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEtlService : IAppService
    {
        void RunEtl();
    }
        
    [Free]
    public interface IAppService : IService, IDisposable
    {
        IWfRuntime Wf {get;}

        IWfChannel Channel {get;}

        T Service<T>(Func<T> factory);

        void Init(IWfRuntime wf);


        void IDisposable.Dispose() {}
    }

    /// <summary>
    /// Characterizes a workflow service implementation
    /// </summary>
    /// <typeparam name="H">The reifying type</typeparam>
    [Free]
    public interface IAppService<H> : IAppService, IService<H>
        where H : IAppService<H>, new()
    {

    }
}