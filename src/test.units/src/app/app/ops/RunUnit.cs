//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using static sys;

    partial class TestApp<A>
    {
        public static void RunMatches(IEnumerable<string> matches)
        {
            piter(UnitNames.AsParallel(), name => {
                iter(matches, match => {
                    if(name.Contains(match))
                        App.RunUnit(UnitHost(match));
                });
            });            
        }

        public static void RunUnits(IEnumerable<string> names)
        {
            piter(names.AsParallel(), name => {
                App.RunUnit(UnitHost(name));
            });            
        }

        public static void Run(params string[] units)
        {
            //var app = new A();
            // var shell = ApiServer.runtime();
            // App.InjectShell(shell);
            //App.SetMode(InDiagnosticMode);
            App.RunUnits(units);
        }
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
                iter(FindTests(unit.HostType), t =>  execTime += RunCase(unit, t, results));
                BenchmarkQueue.Enqueue(unit.TakeBenchmarks().Array());
                clock.Stop();
                term.print(PostUnit(unit.Host, clock.Span(), tsStart, Time.now()));

            }
            catch(Exception e)
            {
                Wf.Channel.Error(e, $"Harness execution failed while running {unit.GetType().Name}");
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