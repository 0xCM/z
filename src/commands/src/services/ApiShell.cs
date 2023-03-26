//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiShell : IApiShell
    {
        ICmdDispatcher Dispatcher;

        IWfRuntime Wf;

        public ApiShell(IWfRuntime wf, ICmdDispatcher dispatcher)
        {
            Wf = wf;
            Dispatcher = dispatcher;
        }

        public void Dispose()
            => Wf.Dispose();

        public void Run()
            => CmdLoop.start(Wf.Channel, Dispatcher).Wait();
    }
}