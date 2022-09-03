//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAppService : IService, IDisposable
    {
        IWfRuntime Wf {get;}

        void InstallChannel(WfEmit channel);

        T Service<T>(Func<T> factory);

        //IWfMsg WfMsg {get;}

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