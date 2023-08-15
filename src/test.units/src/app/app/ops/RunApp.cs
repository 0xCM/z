//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class TestApp<A>
    {
        protected virtual Assembly TargetComponent {get;} = typeof(A).Assembly;

        void RunUnits(ReadOnlySeq<string> src, bool pll)
            => iter(src.IsEmpty ? FindHosts() : FindHosts(src), h => RunUnit(h), pll);

        Type[] FindHosts()
            =>  (from t in TargetComponent.Types().Realize<IUnitTest>()
                where t.IsConcrete() && t.Untagged<IgnoreAttribute>()
                orderby t.Name
                select t).Array();

        Type[] FindHosts(ReadOnlySeq<string> names)
            =>
             (from t in TargetComponent.Types().Realize<IUnitTest>()
                where t.IsConcrete() && t.Untagged<IgnoreAttribute>() && names.Contains(t.Name)
                orderby t.Name
                select t).Array();

        protected void RunUnits(ReadOnlySeq<string> units)
        {
            try
            {
                var clock = counter(true);
                var flow = Wf.Channel.Running(typeof(A).Name + " tests");
                RunUnits(units, false);
                EmitLogs();
                var runtime = clock.Stop();
                Wf.Channel.Ran(flow, $"Test run required {runtime.TimeSpan.TotalSeconds} seconds");
            }
            catch (Exception e)
            {
                term.error(e);
            }
        }

        public static void Run(Index<PartId> parts, params string[] units)
        {
            var app = new A();
            var shell = ApiServer.runtime();
            app.InjectShell(shell);
            app.SetMode(InDiagnosticMode);
            app.RunUnits(units);
        }
    }
}