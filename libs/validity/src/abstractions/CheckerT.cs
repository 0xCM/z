//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Checker]
    public abstract class Checker<T> : AppCmdService<T>, IChecker
        where T : Checker<T>, new()
    {
        readonly ConstLookup<string,MethodInfo> Methods;

        public readonly Index<string> CheckSpecs;

        protected IPolySource Random;

        readonly EventQueue Queue;

        readonly string SvcName;

        protected Checker()
        {
            SvcName = Checkers.name(typeof(T));
            var methods = cdict<string,MethodInfo>();
            Checkers.methods(HostType,methods);
            Methods = methods;
            CheckSpecs = Methods.Keys.ToArray();
            Queue = EventQueue.allocate(GetType(), EventRaised);
        }

        FS.FileName FileName(string suffix, FileKind kind)
            => FS.file(string.Format("{0}.{1}",SvcName, suffix), kind.Ext());

        FS.FilePath EventLogPath
            => AppDb.Logs("checks").Path(FileName("logs", FileKind.Log));

        FS.FilePath TablePath<R>()
            where R : struct
                => AppDb.Logs("checks").PrefixedTable<R>(SvcName);

        FS.FilePath TablePath<R>(string label)
            where R : struct
                => AppDb.Logs("checks").PrefixedTable<R>(SvcName + $".{label}");

        protected new void Write<X>(X src, FlairKind flair = FlairKind.Data)
            => Raise(Events.data(src, flair));

        protected Action<object> Log
            => msg => Write(msg);

        ref readonly Index<string> IChecker.Specs
            => ref CheckSpecs;

        protected void Raise(IWfEvent e)
            => Queue.Deposit(e);

        void EventRaised(IWfEvent e)
        {

        }

        protected void TableEmit<R>(string label, ReadOnlySpan<R> src)
            where R : struct
                => TableEmit(src, TablePath<R>(label));

        protected void TableEmit<R>(ReadOnlySpan<R> src)
            where R : struct
                => TableEmit(src, TablePath<R>());

        protected override sealed void Disposing()
        {
            Queue.Dispose();
        }

        protected sealed override void OnInit()
        {
            Random =  Rng.@default();
        }

        protected static EqualityClaim<C> Eq<C>(C actual, C expect)
            where C : IEquatable<C>
                => EqualityClaim.define(actual,expect);

        protected static void RequireEq<C>(C actual, C expect)
            where C : IEquatable<C>
        {
            require(Eq(actual,expect));
        }

        protected static void require<C>(EqualityClaim<C> claim)
            where C : IEquatable<C>
        {
            if(!claim.Actual.Equals(claim.Expect))
                Throw.message(claim.Format());
        }

        void Run(MethodInfo method, IWfEventTarget log)
        {
            var args = sys.empty<object>();
            var result = Outcome.Success;
            var name = method.DisplayName();
            var host = method.DeclaringType;
            log.Deposit(Events.running(host));
            var error = Z0.Error<Exception>.Empty;
            try
            {
                if(method.ReturnType == typeof(Outcome))
                {
                    if(method.IsStatic)
                        result = (Outcome)method.Invoke(null, args);
                    else
                        result = (Outcome)method.Invoke(this, args);
                }
                else if(method.ReturnType == typeof(bool))
                {
                    if(method.IsStatic)
                        result = (bool)method.Invoke(null, args);
                    else
                        result = (bool)method.Invoke(this, args);
                }
                else
                {
                    if(method.IsStatic)
                        method.Invoke(null, args);
                    else
                        method.Invoke(this, args);
                }
            }
            catch(Exception e)
            {
                result = e;
                error = e;
            }

            if(result)
                log.Deposit(Events.ran(host, string.Format("{0,-32} | Pass", name)));
            else
            {
                var msg = EmptyString;
                if(error.IsNonEmpty)
                    msg = string.Format("{0,-32} | Fail | {1}", name, error);
                else
                    msg = string.Format("{0,-32} | Fail | {1}", name, result.Message);
                log.Deposit(Events.error(method, msg));
            }
        }

        protected virtual void Prepare()
        {

        }

        protected virtual void Finish()
        {

        }


        protected virtual void Execute(IWfEventTarget log)
            => Execute(log, true);

        void Execute(IWfEventTarget log, bool pll)
        {
            try
            {
                iter(Methods.Values, m => Run(m,log), pll);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }


        void EmitLog()
        {
            var emitter = text.emitter();
            var counter = 0u;
            while(Queue.Next(out var e))
            {
                emitter.AppendLine(e.Format());
                counter++;
            }

            if(counter != 0)
                FileEmit(emitter.Emit(), counter, EventLogPath);
        }

        public void Run(IWfEventTarget log, bool pll)
        {
            var flow = Running($"Running {SvcName} checks");
            EventLogPath.Delete();
            Prepare();
            Execute(log, pll);
            EmitLog();
            Finish();
            Ran(flow);
        }

        public new void Run()
            => Run(EventLog, true);
    }
}