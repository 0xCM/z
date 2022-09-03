//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public record struct SymHeapStats
    {
        [Render(12)]
        public uint SymbolCount;

        [Render(12)]
        public uint EntryCount;

        [Render(12)]
        public uint CharCount;

        [Render(12)]
        public uint DataSize;
    }
}