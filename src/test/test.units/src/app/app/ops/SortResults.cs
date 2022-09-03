//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    partial class TestApp<A>
    {
        public TestCaseRecord[] SortResults()
        {
            var results = TestResultQueue.OrderBy(x => x.CaseName).Where(x => !x.Passed).Concat(TestResultQueue.Where(x => x.Passed)).Array();
            TestResultQueue.Clear();
            return results;
        }

        public BenchmarkRecord[] SortBenchmarks()
        {
            var records = BenchmarkQueue.ToArray();
            BenchmarkQueue.Clear();
            Array.Sort(records);
            return records;
        }
    }
}