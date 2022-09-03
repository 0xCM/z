//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Base type for test applications
    /// </summary>
    /// <typeparam name="A">The concrete subtype</typeparam>
    public abstract partial class TestApp<A> : TestContext<A>
        where A : TestApp<A>, new()
    {
        const bool InDiagnosticMode = false;

        protected virtual string AppName {get;}

        protected TestApp()
        {
            AppName = GetType().Assembly.GetSimpleName();
        }

        ConcurrentQueue<TestCaseRecord> TestResultQueue {get;}
            = new ConcurrentQueue<TestCaseRecord>();

        ConcurrentQueue<BenchmarkRecord> BenchmarkQueue {get;}
            = new ConcurrentQueue<BenchmarkRecord>();
    }
}