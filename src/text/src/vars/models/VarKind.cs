//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum VarKind : uint
    {
        None = 0,

        CmdScript,

        BashScript,

        PsScript,

        MsBuild,

        Template,
    }
}