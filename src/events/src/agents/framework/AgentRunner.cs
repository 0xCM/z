//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AgentRunner : IDisposable
    {
        public static AgentRunner create(IEventSink dst)
            => new (Events.signal(dst), new AgentContext(SystemEventWriter.Log));

        public static AgentRunner create(EventSignal dst)
            => new (dst, new AgentContext(SystemEventWriter.Log));

        readonly AgentContext Context;

        readonly EventSignal Signal;

        AgentComplex Complex;

        internal AgentRunner(EventSignal signal, AgentContext context)
        {
            Signal = signal;
            Context = context;
        }

        async Task StartRun()
        {
            var control = Agents.control(Context);
            await Agents.complex(Context).ContinueWith(complex =>
                {
                    Complex = complex.Result;
                    Signal.Status("Server complex started");
                });

            await control.Configure(Context).ContinueWith(_ =>
            {
                Signal.Raise(Events.status(GetType(), $"There are {control.SummaryStats.AgentCount} agents in play"));
            });

            term.readKey("Press any key to terminate the application");
        }

        public async Task Run()
        {
            Signal.Status("Starting server complex");
            await StartRun();
            Terminate();
        }

        async void Terminate()
        {
            if(Complex != null)
            {
                Signal.Status("Shutting down server complex");
                await Complex.Stop();
                Signal.Status("Server complex shut down complete");
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}