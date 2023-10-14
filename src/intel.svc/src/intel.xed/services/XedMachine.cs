//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;
using static XedRules;


public class XedMachine
{


    public XedMachine()
    {
        var lines = XedTables.BlockLines();
        var patterns = XedTables.BlockPatterns(lines);
        var rules = XedZ.rules(lines);
    }

    public void Invoke(RuleIdentity rule)
    {

    }
}
