//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IAppService : IChanneled, IDisposable
{
    IWfRuntime Wf {get;}

    T Service<T>(Func<T> factory);

    void Init(IWfRuntime wf);

    void IDisposable.Dispose() {}

    void IChanneled.Init(IWfChannel channel)
    {

    }
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
