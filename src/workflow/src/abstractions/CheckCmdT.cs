//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [Checker]
    public abstract class CheckCmd<T> : WfAppCmd<T>
        where T : CheckCmd<T>, new()
    {
        ConstLookup<Type,IChecker> Services;

        ConstLookup<Type,Func<IChecker>> Factories;

        protected CheckCmd()
        {
            Pll = true;
        }

        protected override void Initialized()        
        {
            Factories = Checkers.factories(Wf, ApiRuntime.colocated(ExecutingPart.Assembly));
        }

        protected virtual bool Pll {get;}

        public override sealed void Loop()
        {
            Status($"Running {Services.EntryCount} checkers");
            iter(Services.Values, svc => svc.Run(EventLog, Pll), Pll);
        }

        public void Run(ReadOnlySpan<IChecker> checks, bool pll = true)
        {
            iter(checks, checker => checker.Run(EventLog,pll), pll);
        }

        public void Run(bool pll)
        {
            iter(Services.Values, svc => svc.Run(EventLog, pll), pll);
        }

        public Index<string> ListChecks()
        {
            var dst = list<string>();
            foreach(var svc in Services.Values)
                foreach(var c in svc.Specs)
                    dst.Add(c);
            iter(dst, cmd => Write(cmd));
            return dst.ToArray();
        }

        public void Run(CmdArgs args)
        {
            if(args.Count == 0)
                ApiLoop.start(Channel).Wait();
            else
            {
                var count = args.Count;
                for(var i=0; i<count; i++)
                {
                    var match = args[0].Value;
                    var keys = Services.Keys.Where(t => t.Name == match);
                    foreach(var key in keys)
                        Services[key].Run(EventLog,true);
                }
            }
        }
    }
}