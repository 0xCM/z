//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using ClrMd = Microsoft.Diagnostics.Runtime;

    partial struct ClrMdRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public record struct ModuleInfo
        {
            public const string TableId = "clr.md.modules";

            public const byte FieldCount = 9;

            [Render(64)]
            public @string Name;

            [Render(16)]
            public MemoryAddress Address;

            [Render(16)]
            public MemoryAddress ImageBase;

            [Render(16)]
            public MemoryAddress AssemblyAddress;

            [Render(16)]
            public MemoryAddress MetadataAddress;

            [Render(16)]
            public ByteSize MetadataSize;

            [Render(16)]
            public ClrMd.ModuleLayout Layout;

            [Render(164)]
            public PdbInfo Pdb;

            [Render(128)]
            public CharBlock128 ModulePath;
        }
    }
}