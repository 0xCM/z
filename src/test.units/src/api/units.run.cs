//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
partial class ApiOps
{
    [CmdOp("units/run")]
    void RunUnits(CmdArgs args)
    {
        if(args.IsEmpty)
            TestRunner.Run();
        else
        {
            var names = list<string>();
            var matches = list<string>();
            foreach(var name in names)
            {
                if(name.Contains(Chars.Star))
                    matches.Add(text.remove(name,Chars.Star));
                else
                    names.Add(name);
            }
            if(matches.Count != 0)
                TestRunner.RunMatches(matches);
            if(names.Count != 0)
                TestRunner.RunUnits(names);

            TestRunner.Run(args.Map(x => x.Format()));
        }
    }
}