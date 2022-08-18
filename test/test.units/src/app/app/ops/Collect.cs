//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TestApp<A>
    {
        static IAppMsg[] CollectMessages(IUnitTest unit, string testName, Duration runtime, Exception e = null)
        {
            var messages = new List<IAppMsg>();
            var control = unit as ITestQueue;
            messages.AddRange(unit.Dequeue());

            if(e != null)
                messages.AddRange(FormatErrors(testName ?? EmptyString, e));
            else
                messages.Add(AppMsg.info($"{testName} executed. {runtime}"));

            return messages.ToArray();
        }

        static TestCaseRecord[] CollectResults(IExplicitTest unit, string casename, Duration runtime, Exception e = null)
        {
            var control = unit as ITestQueue;
            var outcomes = new List<TestCaseRecord>();
            if(e!= null)
                outcomes.Add(TestCaseRecord.define(casename ?? EmptyString, false,runtime));
            else
            {
                outcomes.AddRange(control.TakeOutcomes());
                if(outcomes.Count == 0)
                    outcomes.Add(TestCaseRecord.define(casename ?? EmptyString, true,runtime));
            }
            return outcomes.ToArray();
        }
    }
}