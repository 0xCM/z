//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiShell<S> : AppShell<S>
        where S : ApiShell<S>, new()
    {
        protected IApiService Commander;

        protected override void Disposing()
        {
            Commander?.Dispose();
        }

        protected override void Run(string[] args)
            => CmdLoop.start(Channel).Wait();

        protected override void Init(IWfRuntime wf, IApiContext context)
        {
            base.Init(wf);
            Commander = context.Commander;            
        }        
    }

    public class ApiShell
    {
        readonly IWfChannel Channel;

        readonly ICmdDispatcher Dispatcher;

        public ApiShell(IWfChannel channel, ICmdDispatcher disp)
        {
            Channel = channel;
            Dispatcher = disp;
        }

        public void Run()
            => CmdLoop.start(Channel, Dispatcher).Wait();
    }
}