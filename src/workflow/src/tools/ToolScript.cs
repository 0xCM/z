//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolScript
    {
        [MethodImpl(Inline), Op]
        public static ToolScript define(FilePath script, CmdVars vars)
            => new ToolScript(script, vars);

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