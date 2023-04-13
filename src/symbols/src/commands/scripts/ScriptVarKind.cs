//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum ScriptVarKind : uint
    {
        None = 0,

        Cmd = 1,

        Bash = 2,

        Powershell = 3,

        MsBuild = 4,

        Template = 5,
    }
}