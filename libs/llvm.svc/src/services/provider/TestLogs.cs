//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<TestResult> TestResults(string name)
            => (Index<TestResult>)DataSets.GetOrAdd(name + "-test-logs", _
                => LlvmTests.logs(LlvmPaths.TestResultSources().Path(name + "-tests-detail", FileKind.Json)));
    }
}