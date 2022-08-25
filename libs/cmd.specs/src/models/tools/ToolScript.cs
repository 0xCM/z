//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolScript
    {
        public readonly FilePath Script;

        public readonly CmdVars Vars;

        [MethodImpl(Inline)]
        public ToolScript(FilePath script, CmdVars vars)
        {
            Script = script;
            Vars = vars;
        }
    }
}