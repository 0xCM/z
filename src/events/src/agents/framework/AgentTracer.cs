//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Diagnostics.Tracing.Session;

    using api = SourcedEvents;

    public sealed class AgentTracer : AgentMachine
    {
        TraceEventSession Session;

        readonly ConcurrentQueue<AgentEventKey> TargetQueue = new ();

        bool _Stopping;

        internal AgentTracer(IAgentContext Context, AgentIdentity Identity)
            : base(Context, Identity)
        {
            _Stopping = false;
        }

        public async IAsyncEnumerable<AgentEventKey> Receipts()
        {
            while(!_Stopping && TargetQueue.TryDequeue(out var key))
            {
                yield return key;
                await Task.Delay(1000);
            }

        }
        void OnPulse(TraceEvent data)
        {
            var key = Agents.key(data);
            term.magenta($"Received event {key}");
            TargetQueue.Enqueue(key);
        }

        void OnAgentTransitioned(TraceEvent data)
        {
            var adapter = api.adapter<AgentTransitioned>(data);
            term.magenta($"Received transition event: {adapter.Body}");
        }

        void OnUnhandled(TraceEvent data)
        {
            if ((int)data.ID != 0xFFFE)         // The EventSource manifest events show up as unhanded, filter them out.
                term.babble("GOT UNHANDLED EVENT: " + data.Dump());
        }

        void ConfigureSession()
        {
            Session = new TraceEventSession(nameof(AgentTracer));
            var restarted = Session.EnableProvider(SystemEventWriter.SourceName);
            if(restarted)
                term.warn($"Session was already in progress");

            Session.Source.UnhandledEvents += OnUnhandled;
            Session.Source.Dynamic.AddCallbackForProviderEvent(SystemEventWriter.SourceName, "Pulse", OnPulse);
            Session.Source.Dynamic.AddCallbackForProviderEvent(SystemEventWriter.SourceName, "AgentTransitioned", OnAgentTransitioned);
        }

        protected override async Task Starting()
        {
            await sys.start(() => {
            ConfigureSession();
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) { Stopping().Wait(); };
            });
        }

        protected override async Task Running()
        {
            await sys.start(() =>
            {
                term.babble("Processing events");
                Session.Source.Process();
                term.babble("Finished processing events");
            });
        }

        protected override async Task Stopping()
        {
            _Stopping = true;
            await sys.start(() => {
            Session?.Source.Dispose();
            Session?.Dispose();
            });
        }
    }
}