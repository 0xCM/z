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

        public ReadOnlySeq<string> Args {get;}

        public ApiShell(IWfRuntime wf, ICmdDispatcher dispatcher, params string[] args)
        {
            Wf = wf;
            Args = args;
            Dispatcher = dispatcher;
        }

        public void Dispose()
            => Wf.Dispose();

        public void Run()
            => CmdLoop.start(Wf.Channel, Dispatcher).Wait();
    }
}