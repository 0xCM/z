//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolScript
    {
        public readonly FilePath Script;

        public readonly ScriptVars Vars;

        [MethodImpl(Inline)]
        public ToolScript(FilePath script, ScriptVars vars)
        {
            Script = script;
            Vars = vars;
        }
    }
}