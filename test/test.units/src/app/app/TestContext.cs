//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Diagnostics;

    public abstract class TestContext<U> : ITestContext<U>
        where U : TestContext<U>
    {
        public bool DiagnosticMode {get; private set;}

        protected IWfRuntime Wf {get; private set;}

        protected AppDb AppDb => AppDb.Service;

        public void SetMode(bool diagnostic)
            => DiagnosticMode = diagnostic;

        public void InjectShell(IWfRuntime wf)
        {
            Wf = wf;
            OnShellInjected(wf);
        }

        protected virtual void OnShellInjected(IWfRuntime wf) { }

        public ITestContext Context {get;}

        public virtual IPolyrand Random {get;}
            = Rng.wyhash64(PolySeed64.Seed00);

        public event Action<IAppMsg> Next;

        protected readonly IMessageQueue Queue;

        System.Collections.Generic.Queue<TestCaseRecord> TestResults {get;}
            = new System.Collections.Generic.Queue<TestCaseRecord>();

        System.Collections.Generic.Queue<BenchmarkRecord> Benchmarks {get;}
            = new System.Collections.Generic.Queue<BenchmarkRecord>();

        protected TestContext()
        {
            void Relay(IAppMsg msg) => Next(msg);
            Context = this;
            Next += x => {};
            Queue = AppMsgExchange.Create();
            Queue.Next += Relay;
            OnDispose += () => {};
        }

        public void Dispose()
        {
            OnDispose();
        }

        protected event Action OnDispose;

        void ISink<IAppMsg>.Deposit(IAppMsg msg)
            => Queue.Deposit(msg);

        void IMessageSink.NotifyConsole(IAppMsg msg)
            => Queue.NotifyConsole(msg);

        public IEnumerable<TestCaseRecord> TakeOutcomes()
        {
            while(TestResults.Any())
                yield return TestResults.Dequeue();
        }

        public IEnumerable<BenchmarkRecord> TakeBenchmarks()
        {
            while(Benchmarks.Any())
                yield return Benchmarks.Dequeue();
        }

        public void Deposit(TestCaseRecord result)
            => TestResults.Enqueue(result);

        public void Deposit(BenchmarkRecord record)
            => Benchmarks.Enqueue(record);

        public IReadOnlyList<IAppMsg> Dequeue()
            => Queue.Dequeue();

        public IReadOnlyList<IAppMsg> Flush(Exception e)
            => Queue.Flush(e);

        public void Flush(Exception e, IMessageSink target)
            => Queue.Flush(e, target);

        public void Emit(FilePath dst)
            => Queue.Emit(dst);

        /// <summary>
        /// The number of elements to be selected from some sort of stream
        /// </summary>
        protected virtual int RepCount
            => Context.RepCount;

        /// <summary>
        /// The number times to repeat an action
        /// </summary>
        protected virtual int CycleCount
            => Context.CycleCount;

        /// <summary>
        /// The number of times to repeat a cycle
        /// </summary>
        protected virtual int RoundCount
            => Context.RoundCount;

        /// <summary>
        /// The number of operations performed in a benchmarking exercise
        /// </summary>
        protected virtual int OpCount
            => RoundCount*CycleCount;

        public virtual bool Enabled
            => true;

        protected virtual bool TraceDetailEnabled
            => false;

        protected IChecks Claim
            => Checks.Checker;

        protected ICheckPrimal ClaimPrimal
            => Claim;

        protected ICheckPrimalSeq ClaimPrimalSeq
            => Claim;

        protected ICheckNumeric ClaimNumeric
            => NumericClaims.Checker;

        protected PartId TestedPart
            => (PartId)((ulong)Assembly.GetEntryAssembly().Id() & 0xFFFFul);

        protected PartName TestApp
            => (PartId)((ulong)Assembly.GetEntryAssembly().Id());

        protected virtual FolderPath UnitDataDir
            => AppDb.Logs($"test/{GetType().Name}").Root;

        protected static FileExt LogExt => FS.Log;

        protected string CaseName<C>(string root, C t = default)
            where C : unmanaged
                => Context.name<C>(root);

        protected string CaseName(OpIdentity id)
            => Context.name(id);

        protected string CaseName<W,C>([CallerName] string label = null, W w = default, C t = default, bool generic = true)
            where W : unmanaged, ITypeWidth
            where C : unmanaged
                => Context.name<W,C>(label, generic);

        protected string CaseName(IFunc f)
            => SFxIdentity.name(f);

        CasePaths GetCasePaths()
            => new CasePaths(UnitDataDir, TestApp, GetType());

        public CasePaths Paths
            => GetCasePaths();

        [MethodImpl(Inline)]
        protected FilePath UnitPath(FileName name)
            => UnitDataDir + name;

        protected StreamWriter UnitWriter(FileName filename, bool append = false)
            => UnitPath(filename).Writer(append);

        [MethodImpl(Inline)]
        protected FilePath CasePath(FileExt ext, [CallerName] string caller = null, bool append = false)
            => UnitPath(FS.file(caller, ext));

        [MethodImpl(Inline)]
        protected FilePath CasePath(string CaseName, FileExt? ext = null)
            => UnitPath(FS.file(CaseName, ext ?? FS.ext("csv")));

        protected StreamWriter CaseWriter(FileExt ext, [CallerName] string caller = null, bool append = false)
            => CasePath(caller, ext).Writer(append);

        protected StreamWriter CaseWriter(string CaseName, FileExt? ext = null, bool append = false)
            => CasePath(CaseName, ext).Writer(append);

        protected BenchmarkRecord Benchmark(long opcount, Duration time, [CallerName] string label = null)
            => Context.Benchmark(opcount, time, label);

        protected BenchmarkRecord ReportBenchmark(string name, long opcount, TimeSpan duration)
            => Context.ReportBenchmark(name,opcount, duration);

        protected BenchmarkRecord ReportBenchmark<W,T>(IFunc f, int ops, Duration time, W w = default, T t = default)
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => Context.ReportBenchmark<W,T>(f,ops,time);

        protected void CheckAction(Action f, string name)
            => Context.CheckAction(f, name);

        protected void Notify(string msg, LogLevel? severity = null)
            => Queue.Notify(msg, severity);

        protected void Trace(object msg, [CallerName] string caller = null)
            => Queue.Deposit(msg, GetType(), caller);

        protected void Trace(string title, object msg, FlairKind color, [CallerName] string caller = null)
            => Queue.Deposit(title, msg, color, GetType(), caller);

        protected void Trace(string title, string msg, [CallerName] string caller = null)
            => Queue.Deposit(title, msg, GetType(), caller);

        protected void Trace(IAppMsg msg)
            => Queue.Deposit(msg);

        protected void Trace(ITextual msg)
            => Notify(msg.Format());

        const string TypeCasePattern = "{0}/{1}<{2}> {3}";

        string TypeCaseFormat<C>(string caller, string action)
            => string.Format(TypeCasePattern, GetType().DisplayName(), caller, typeof(C).DisplayName(), action);

        protected void TypeCaseStart<C>([CallerName] string caller = null)
            => Trace(AppMsg.define(TypeCaseFormat<C>(caller, "running"), LogLevel.Status));

        protected void TypeCaseEnd<C>([CallerName] string caller = null)
            => Trace(AppMsg.define(TypeCaseFormat<C>(caller, "ran"), LogLevel.Status));

        /// <summary>
        /// Allocates and optionally starts a system counter
        /// </summary>
        [MethodImpl(Inline)]
        public SystemCounter counter(bool start = false)
            => SystemCounters.counter(start);

        /// <summary>
        /// Creates a new stopwatch and optionally start it
        /// </summary>
        /// <param name="start">Whether to start the new stopwatch</param>
        [MethodImpl(Inline)]
        public Stopwatch stopwatch(bool start = true)
            => start ? Stopwatch.StartNew() : new Stopwatch();

        /// <summary>
        /// Captures a stopwatch duration
        /// </summary>
        /// <param name="sw">A running/stopped stopwatch</param>
        [MethodImpl(Inline)]
        public Duration snapshot(Stopwatch sw)
            => Duration.init(sw.ElapsedTicks);
    }
}