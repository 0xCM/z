//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class TestRunner : TestApp<TestRunner>
{
    protected override Assembly TargetComponent
        => Parts.TestUnits.Assembly;
}
