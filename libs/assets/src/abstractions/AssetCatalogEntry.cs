//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AssetCatalogEntry : IComparable<AssetCatalogEntry>, ISequential<AssetCatalogEntry>
    {
        const string TableId = "api.assets";

        [Render(8)]
        public uint Seq;

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(12)]
        public ByteSize Size;

        [Render(1)]
        public ResourceName Name;

        uint ISequential.Seq { get => Seq; set => Seq = value;}

        public int CompareTo(AssetCatalogEntry src)
            => Name.CompareTo(src.Name);
    }
}