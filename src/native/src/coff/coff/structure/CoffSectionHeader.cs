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

        public Address32 VirtualAddress;

        public uint SizeOfRawData;

        public Address32 PointerToRawData;

        public Address32 PointerToRelocations;

        public Address32 PointerToLinenumbers;

        public ushort NumberOfRelocations;

        public ushort NumberOfLinenumbers;

        public ImageSectionFlags Characteristics;        
    }

}
