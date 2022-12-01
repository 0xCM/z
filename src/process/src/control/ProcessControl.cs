//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    [ApiHost]
    public sealed partial class ProcessControl : Control<ProcessControl>
    {
        public static IControl Control()
            => Instance;    

        public static CmdScript script(string name, CmdScriptExpr src)
            => new CmdScript(name, src);

        static ProcessControl Instance = new();
    }
}