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
            Timer = new Timer(config.Frequency.TotalMilliseconds);
            Timer.AutoReset = true;
            Timer.Elapsed += OnPulse;
        }

        void OnPulse(object sender, ElapsedEventArgs args)
            => Context.EventLog.Receive(SourcedEvents.pulse(PartId, HostId, Time.timestamp()));

        Timer Timer {get;}

        protected override void OnStart()
        {
            Timer.Start();
        }

        protected override void OnStop()
        {
            Timer.Stop();
        }

        protected override void OnTerminate()
            => Timer.Dispose();
    }
}