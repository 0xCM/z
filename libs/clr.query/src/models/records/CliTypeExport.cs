//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CliTypeExport
    {
        public const string TableId= "cli.types.exports";

        [Render(12)]
        public CliRowKey TypeDefId;

        [Render(16)]
        public CliStringIndex TypeName;

        [Render(16)]
        public CliStringIndex TypeNamespace;

        [Render(16)]
        public CliRowKey Implementation;

        [Render(1)]
        public TypeAttributes Flags;
    }
}