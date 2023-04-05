//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct CoffSectionHeader
    {
        public CoffSymbolName Name;

        public uint VirtualSize;

        public uint VirtualAddress;

        public uint SizeOfRawData;

        public uint PointerToRawData;

        public uint PointerToRelocations;

        public uint PointerToLinenumbers;

        public ushort NumberOfRelocations;

        public ushort NumberOfLinenumbers;

        public ImageSectionFlags Characteristics;        
    }

}
