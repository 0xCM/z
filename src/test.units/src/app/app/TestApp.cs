//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

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

    static TestApp()
    {
        _App = new();
        UnitHosts = (from t in _App.TargetComponent.Types().Realize<IUnitTest>()
            where t.IsConcrete() && t.Untagged<IgnoreAttribute>()
            orderby t.Name
            select t).Array();
        UnitIndex = UnitHosts.Map(x => (x.Name,x)).ToDictionary();
        _App.InjectShell(ApiServer.runtime());
        _App.SetMode(InDiagnosticMode);
    }

    public static ref readonly A App => ref _App;

    static readonly A _App;

    static readonly Type[] UnitHosts;

    static readonly Dictionary<string,Type> UnitIndex;
}
