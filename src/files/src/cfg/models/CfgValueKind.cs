//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum CfgValueKind : ushort
    {
        Text = 0,

        Folder = 1,

        File = 2,

        Int = 4,

        Bool = 8,

        Record = 16,

        Seq = 32,

        Optional = Pow2x16.P2ᐞ15
    }
}
