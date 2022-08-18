//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct EnvVarRow
    {
        public const string TableId = "setting";

        [Render(8)]
        public uint Seq;

        [Render(16)]
        public asci32 EnvName;

        [Render(64)]
        public asci64 VarName;

        [Render(8)]
        public string Join;

        [Render(1)]
        public @string VarValue;
    }
}