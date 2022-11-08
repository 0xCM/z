//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AgentRunner : IDisposable
    {
        public static void run(WfEventSignal dst)
        {
            var runner = new AgentRunner(dst, new AgentContext(SystemEventWriter.Log));
            runner.Run();
        }

        AgentContext Context;

        WfEventSignal Signal;

        AgentComplex Complex;

        IAgentControl Control;

        internal AgentRunner(WfEventSignal signal, AgentContext context)
        {
            Signal = signal;
            Context = context;
            Control = Agents.control(context);
        }

        public void Run()
        {
            Signal.Status("Starting server complex");
            Agents.complex(Context).ContinueWith(complex =>
                {
                    Complex = complex.Result;
                    Signal.Status("Server complex started");
                });

            Control.Configure(Context).ContinueWith(_ =>
            {
                Signal.Raise(Events.status(GetType(), $"There are {Control.SummaryStats.AgentCount.ToString()} agents in play"));
            });

            term.readKey("Press any key to terminate the application");
            Terminate();
        }

        void Terminate()
        {
            if(Complex != null)
            {
                Signal.Status("Shutting down server complex");
                Complex.Stop().Wait();
                Signal.Status("Server complex shut down complete");
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}