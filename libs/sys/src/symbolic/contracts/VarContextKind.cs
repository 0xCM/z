//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x32;

    [Flags]
    public enum VarContextKind : uint
    {
        None = 0,

        Workflow = P2ᐞ00,

        CmdScript = P2ᐞ01 | Script,

        BashScript = P2ᐞ02 | Script,

        PsScript = P2ᐞ03 | Script,

        MsBuild = P2ᐞ04,

        CSharpCode =  P2ᐞ05 | Managed,

        MsilCode = P2ᐞ06 | Managed,

        CppCode =  P2ᐞ07 | Native,

        AsmCode =  P2ᐞ08 | Native,

        Script = P2ᐞ20,

        Managed = P2ᐞ21,

        Native = P2ᐞ22,
    }
}