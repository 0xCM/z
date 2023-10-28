//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using static sys;

    partial class TestApp<A>
    {
        protected virtual Assembly TargetComponent {get;} = typeof(A).Assembly;

        public static IEnumerable<string> UnitNames => UnitIndex.Keys;

        static Type UnitHost(string name)
            => UnitIndex[name];

        void RunUnits(ReadOnlySeq<string> src, bool pll)
            => iter(src.IsEmpty ? UnitHosts : FindHosts(src), h => RunUnit(h), pll);

        Type[] FindHosts(ReadOnlySeq<string> names)
            => (from t in TargetComponent.Types().Realize<IUnitTest>()
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
    }
}