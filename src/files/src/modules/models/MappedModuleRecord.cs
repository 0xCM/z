//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct MappedModuleRecord : ISequential<MappedModuleRecord>
    {
        // {0,-8} | {1,-16} | {2,-16} | {3,-12} | {4,-56} | {5}
        [Render(8)]
        public uint Seq;

        [Render(16)]
        public FileModuleKind ModuleKind;

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(16)]
        public ByteSize Size;

        [Render(56)]
        public Hash128 ContentHash;

        [Render(1)]
        public FilePath Path;

        uint ISequential.Seq { get => Seq; set => Seq = value; }

        public int CompareTo(MappedModuleRecord src)
            => BaseAddress.CompareTo(src.BaseAddress);   
    }
}