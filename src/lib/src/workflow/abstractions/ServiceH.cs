//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Service<H> : IService<H>
        where H : Service<H>, new()
    {
        /// <summary>
        /// Instantites the serice without initialization
        /// </summary>
        [MethodImpl(Inline)]
        protected static H create() => new H();

        /// <summary>
        /// Creates and initializes the service
        /// </summary>
        /// <param name="wf">The source workflow</param>
        public static H create(IEventSink ctx)
        {
            var service = create();
            service.Init(ctx);
            return service;
        }

        public Type HostType => typeof(H);

        WfEventSignal Signal;

        public void Init(IEventSink sink)
        {
            Signal = Events.signal(sink, typeof(H));
            Initializer((H)this);
            Initialized();
        }

        protected virtual void Initialized() {}

        protected Service()
        {
            Initializer = (svc) => {};
        }

        Action<H> Initializer;

        protected Service(Action<H> init)
        {
            Initializer = init;
        }

        protected BabbleEvent<T> Babble<T>(T src)
            => Signal.Babble(src);

        protected StatusEvent<T> Status<T>(T src)
            => Signal.Status(src);

        protected WarnEvent<T> Warn<T>(T src, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Signal.Warn(src, Events.originate(GetType(), caller, file, line));

        protected ErrorEvent<string> Error(Type source, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Signal.Error(e, Events.originate(source.Name, caller, file, line));

        protected RunningEvent Running()
            => Signal.Running();

        protected RunningEvent<T> Running<T>(T msg)
            => Signal.Running(msg);

        protected RanEvent<T> Ran<T>(T msg)
            => Signal.Ran(msg);

        protected RanEvent<T> Ran<T>(RunningEvent<T> e, T msg)
            => Signal.Ran(e, msg);

        protected RanEvent<RunningEvent> Ran(RunningEvent e)
            => Signal.Ran(e);

        protected EmittingFileEvent Emitting(FilePath src)
            => Signal.EmittingFile(src);

        protected EmittedFileEvent Emitted(EmittingFileEvent e, Count metric)
            => Signal.EmittedFile(metric, e.Target);

        protected DataEvent<T> Write<T>(in T src)
            => Signal.Data(src);

        protected DataEvent<T> Write<T>(in T src, FlairKind flair)
            => Signal.Data(src, flair);

        protected void Write<T>(string name, T value, FlairKind flair)
            => Signal.Data(RpOps.attrib(name, value), flair);
    }
}