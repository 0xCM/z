//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppService<H> : AppService, IAppService<H>
        where H : AppService<H>, new()
    {
        [MethodImpl(Inline)]
        protected static H @new() => new H();

        /// <summary>
        /// Creates and initializes the service
        /// </summary>
        /// <param name="wf">The source workflow</param>
        public static H create(IWfRuntime wf)
        {
            var service = @new();
            service.Init(wf);
            return service;
        }

        protected AppEventSource Host 
            => GetType();


        Action<IEvent> EventLogger
            => e => Emitter.Raise(e);

        protected IEventTarget EventLog
            => new EventTarget(EventLogger);
    }
}