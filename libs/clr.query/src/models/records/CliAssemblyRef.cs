//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId),  StructLayout(LayoutKind.Sequential)]
    public struct CliAssemblyRef
    {
        const string TableId = "cli.assemblies.refs";

        [Render(12)]
        public CliBlobIndex Token;

        [Render(12)]
        public CliStringIndex Name;

        [Render(12)]
        public AssemblyVersion Version;

        [Render(12)]
        public CliStringIndex Culture;

        [Render(12)]
        public CliBlobIndex Hash;

        [Render(1)]
        public AssemblyFlags Flags;
    }
}