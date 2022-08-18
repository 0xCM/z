//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class TestApp<A>
    {
        public Duration RunCase(IUnitTest unit, MethodInfo method, List<TestCaseRecord> cases)
        {
            var exectime = Duration.Zero;
            var casename = TestCaseIdentity.from(method);
            var clock = Time.counter(false);
            var messages = list<IAppMsg>();
            var outcomes = list<TestCaseRecord>();

            if(DiagnosticMode)
                term.print($"Executing case {unit.HostType.Name}/{method.Name}");

            var started = now();
            var finished = started;
            try
            {
                messages.Add(PreCase(casename, started));

                clock.Start();
                method.Invoke(unit,null);
                clock.Stop();
                finished = now();

                messages.AddRange(unit.Dequeue());
                messages.Add(PostCase(casename, clock.Span(), started, finished));
                outcomes.AddRange(unit.TakeOutcomes().Array());

                if(outcomes.Count == 0)
                    outcomes.Add(TestCaseRecord.define(casename, true, started, finished, clock.Span()));

                if(DiagnosticMode)
                    term.print($"Executed case {unit.HostType.Name}/{method.Name}");

            }
            catch(Exception e)
            {
                clock.Stop();
                finished = now();
                var message = format(e);
                messages.AddRange(unit.Dequeue());
                messages.AddRange(FormatErrors(e, method));
                outcomes.Add(TestCaseRecord.define(casename, false, started, finished, clock.Span(), message));
            }
            finally
            {
                iter(messages, term.print);
                cases.AddRange(outcomes);
            }

            return exectime;
        }

        static string format(Exception e)
            => e switch {
                TargetInvocationException ie => format(e.InnerException),
                ClaimException ce => ce.Message,
                _ => e.ToString()
            };
    }
}