//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath script, CmdVars vars)
            => new ToolScript(script, vars);
    }
}