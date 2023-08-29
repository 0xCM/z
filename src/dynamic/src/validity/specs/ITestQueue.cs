//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITestQueue : ITestResultSink, IMessageQueue, ISink<BenchmarkRecord>
    {
        IEnumerable<BenchmarkRecord> TakeBenchmarks();

        IEnumerable<TestCaseRecord> TakeOutcomes();

        BenchmarkRecord ReportBenchmark(string name, long opcount, TimeSpan duration)
        {
            var record = BenchmarkRecord.Define(opcount, duration, name);
            Deposit(record);
            return record;
        }

        BenchmarkRecord ReportBenchmark<W,T>(IFunc f, int ops, Duration time, W w = default, T t = default)
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => ReportBenchmark(SFxIdentity.name<W,T>(GetType(), f), ops, time);

        /// <summary>
        /// Captures a duration and the number of operations executed within the period
        /// </summary>
        /// <param name="time">The running time</param>
        /// <param name="opcount">The operation count</param>
        /// <param name="label">The label associated with the measure, if specified</param>
        BenchmarkRecord Benchmark(long opcount, Duration time, [CallerName] string label = null)
            => BenchmarkRecord.Define(opcount, time, label);
    }
}