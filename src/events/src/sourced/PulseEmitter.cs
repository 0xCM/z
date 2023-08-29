//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Timers;

    /// <summary>
    /// Produces a periodic pulse event
    /// </summary>
    public class PulseEmitter : EventEmitter<PulseEvent>
    {
        public PulseEmitter(IAgentContext context, AgentIdentity identity, PulseEmitterConfig config)
            : base(context,identity)
        {
            Timer = sys.timer(config.Frequency.TotalMilliseconds);
            Timer.AutoReset = true;
            Timer.Elapsed += OnPulse;
        }

        void OnPulse(object sender, ElapsedEventArgs args)
            => Context.Sink.Receive(SourcedEvents.pulse(Part, HostId, Time.timestamp()));

        readonly System.Timers.Timer Timer;

        protected override async Task Starting()
        {
            await sys.start(() => Timer.Start());
        }

        protected override async Task Stopping()
        {
            await sys.start(() => {
                Timer.Stop();
                Timer.Dispose();
            });
        }

    }
}