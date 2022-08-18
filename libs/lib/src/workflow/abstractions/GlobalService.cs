//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [WfService]
    public abstract class GlobalService<H,S> : AppService<H>, IAppService<H>
        where H : GlobalService<H,S>, new()
    {
        static H Service;

        protected static S State;

        protected new static IWfRuntime Wf;

        IWfRuntime IAppService.Wf
            => Wf;

        protected abstract H Init(out S state);

        /// <summary>
        /// Creates and initializes the service
        /// </summary>
        /// <param name="wf">The source workflow</param>
        public static new H create(IWfRuntime wf)
        {
            if(Wf == null)
            {
                Wf = wf;
                Service = AppService<H>.create(wf);
                Service.Init(out State);
            }
            return Service;
        }

        public new void Init(IWfRuntime wf)
            => create(wf);
    }
}