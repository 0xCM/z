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

        public static void methods(Type src, ConcurrentDictionary<string,MethodInfo> dst)
            => iter(src.DeclaredMethods().WithArity(0), m => dst.TryAdd(name(m), m));

        public static void methods(Type src, ConcurrentBag<MethodInfo> dst)
            => iter(src.DeclaredMethods().WithArity(0), m => dst.Add(m));

        public static IEventTarget target(IWfChannel channel)
            => CheckEventTarget.create(channel);

        public static ConstLookup<Type,Func<IChecker>> factories(IWfRuntime wf, params Assembly[] src)
        {
            IChecker create(MethodInfo m)
                => (IChecker)m.Invoke(null, new object[]{wf});

            var services = 
                from m in src.Types().Concrete().Tagged<CheckerAttribute>().StaticMethods()
                where m.Name == "create" && m.Parameters().Length == 1
                where first(m.ParameterTypes()) == typeof(IWfRuntime)
                select (service:m.DeclaringType, factory:m);            
            var dst = dict<Type,Func<IChecker>>();
            iter(services, f => dst.TryAdd(f.service, (() => create(f.factory))));
            return dst;
        }

        public static void run(ReadOnlySpan<IChecker> checks, IEventTarget log, bool pll = true)
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

        public static void run(Type host, string name, Action<IEventTarget> f, IEventTarget dst)
        {
            try
            {
                f(dst);
            }
            catch(Exception e)
            {
                dst.Deposit(Events.error(host,e));
            }
        }

        public static void run(bool pll, Type host, IEventTarget log, params (string name, Action<IEventTarget> f)[] checks)
        {
            iter(checks, x => run(host, x.name, x.f, log), pll);
        }

        static IEvent @event(Type host, string data, Exception e = null)
        {
            if(e != null)
                return Events.error(host, e);
            else
                return Events.row(data, FlairKind.Babble);
        }

    }
}