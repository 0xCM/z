
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiLoop<C> : IApiLoop
        where C : ICmd, new()
    {
        protected abstract ICmdDispatcher<C> Dispatcher {get;}

        readonly IWfChannel Channel;

        protected abstract ICmdEmitter<C> Emitter {get;}

        protected ApiLoop(IWfChannel channel)
        {
            Channel = channel;
        }

        public void Run()
        {
            while(Emitter.Next(out var cmd))
            {
                RunCmd(cmd);
            }
        }
            
        void RunCmd(C cmd)
        {
            try
            {
                Dispatcher.Dispatch(cmd).Wait();
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }
    }
}