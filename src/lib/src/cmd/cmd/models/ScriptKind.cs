//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum ScriptKind : ushort
    {
        None = 0,

        [Symbol("cmd")]
        Cmd = 1,

        [Symbol("ps1")]
        Ps = 2,

        [Symbol("sh")]
        Bash = 4,

        Z = 128
    }
}