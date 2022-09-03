//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct IMAGE_LOAD_CONFIG_CODE_INTEGRITY
    {
        public ushort Flags;

        public ushort Catalog;

        public uint CatalogOffset;

        public uint Reserved;
    }
}