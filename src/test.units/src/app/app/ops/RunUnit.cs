//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class TestApp<A>
    {
        public void RunUnit(IUnitTest unit)
        {
            if(DiagnosticMode)
                term.print($"Executing {unit.Host} cases");

            var results = new List<TestCaseRecord>();
            try
            {
                var execTime = Duration.Zero;
                var clock = Time.counter(true);
                var tsStart = Time.now();

                // if(unit is IExplicitTest et)
                //     ExecExplicit(et, results);
                // else
                // {
                    iter(FindTests(unit.HostType), t =>  execTime += RunCase(unit, t, results));
                    BenchmarkQueue.Enqueue(unit.TakeBenchmarks().Array());
                //}

                clock.Stop();
                term.print(PostUnit(unit.Host, clock.Span(), tsStart, Time.now()));

            }
            catch(Exception e)
            {
                Wf.Error(e, $"Harness execution failed while running {unit.GetType().Name}");
            }
            finally
            {
                TestResultQueue.Enqueue(results);
            }
        }

        public void RunUnit(Type host)
        {
            Require.invariant(Wf != null, () => "Wf must not be null");
            using var unit = host.Activate<IUnitTest>();
            if(unit.Enabled)
            {
                unit.SetMode(DiagnosticMode);
                unit.InjectShell(Wf);
                RunUnit(unit);
            }
        }
    }
}