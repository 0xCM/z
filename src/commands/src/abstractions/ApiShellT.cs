//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiShell<S> : AppShell<S>, IApiShell
        where S : ApiShell<S>, new()
    {
        protected ICmdDispatcher Dispatcher;
        
        public void Init(IWfRuntime wf, ReadOnlySeq<string> args, ICmdDispatcher dispatcher)
        {
            base.Init(wf, args);
            Dispatcher = dispatcher;
        }

        protected override void Disposing()
        {
            
        }

        protected override void Run()
            => CmdLoop.start(Channel).Wait();
    }
}