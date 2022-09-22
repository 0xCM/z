//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Checkers
    {
        public static string name(Type host)
            => string.Format("{0}.{1}", host.Assembly.Id().Format(), host.Name);

        public static string name(MethodInfo src)
            => string.Format("{0}.{1}", name(src.DeclaringType), src.Name);

        public static Type[] hosts(params Assembly[] src)
            => src.Types().Tagged<CheckerAttribute>().Concrete();

        public static ConstLookup<Type,IChecker> discover(IWfRuntime wf, params Assembly[] src)
        {
            var dst = cdict<Type,IChecker>();
            foreach(var type in hosts(src))
                discover(wf, type, dst);
            return dst;
        }

        public static ConstLookup<Type,IChecker> discover(IWfRuntime wf, Type src)
        {
            var dst = cdict<Type,IChecker>();
            discover(wf, src, dst);
            return dst;
        }

        public static void discover(IWfRuntime wf, Type src, ConcurrentDictionary<Type,IChecker> dst)
        {
            var factories = src.StaticMethods().Where(x => x.Name == "create");
            if(factories.Length == 1)
            {
                ref readonly var factory = ref first(factories);
                var service = (IChecker)factory.Invoke(null, new object[]{wf});
                dst.TryAdd(service.GetType(), service);
            }
        }

        public static void methods(Type src, ConcurrentDictionary<string,MethodInfo> dst)
            => iter(src.DeclaredMethods().WithArity(0), m => dst.TryAdd(name(m), m));

        public static void methods(Type src, ConcurrentBag<MethodInfo> dst)
            => iter(src.DeclaredMethods().WithArity(0), m => dst.Add(m));

        public static void run(ReadOnlySpan<IChecker> checks, IWfEventTarget log, bool pll = true)
        {
            iter(checks, checker => {
                var host = checker.GetType();
                try
                {
                    checker.Run(log,pll);
                }
                catch(Exception e)
                {
                    log.Deposit(@event(host,EmptyString,e));
                }

            }, pll);
        }

        public static void run(string name, Action<ITextEmitter> f, bool show = true)
        {
            var log = text.emitter();
            run(name, f, log, show);
        }

        public static void run(Type host, string name, Action<IWfEventTarget> f, IWfEventTarget log)
        {
            try
            {
                f(log);
            }
            catch(Exception e)
            {
                log.Deposit(Events.error(host,e));
            }
        }

        public static void run(bool pll, params (string name, Action<ITextEmitter> f)[] checks)
        {
            iter(checks, x => run(x.name, x.f), pll);
        }

        public static void run(bool pll, Type host, IWfEventTarget log, params (string name, Action<IWfEventTarget> f)[] checks)
        {
            iter(checks, x => run(host, x.name, x.f, log), pll);
        }

        static void run(string name, Action<ITextEmitter> f, ITextEmitter log, bool show)
        {
            Run();

            void Run()
            {
                try
                {
                    f(log);
                    if(show)
                        ShowCheckResult(name, log.Emit(false));
                }
                catch(Exception e)
                {
                    if(show)
                        ShowCheckResult(name, log.Emit(false), e);
                }
            }
        }

        static IWfEvent @event(Type host, string data, Exception e = null)
        {
            if(e != null)
                return Events.error(host, e);
            else
                return Events.row(data, FlairKind.Babble);
        }

        static void ShowCheckResult(string name, string data, Exception e = null)
        {
            term.print(
                (Eol, FlairKind.Data),
                (name, FlairKind.StatusData),
                (RpOps.PageBreak120, FlairKind.StatusData),
                (Eol, FlairKind.Data),
                (data + (e == null ? EmptyString :  Eol + e.ToString()), e == null ? FlairKind.Data : FlairKind.Error)
                );
        }
    }
}