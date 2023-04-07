// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ImageFileHeader
    {
        public uint Magic;

        public ushort Machine;

        public ushort NumberOfSections;

        public int TimeDateStamp;

        public uint PointerToSymbolTable;

        public uint NumberOfSymbols;

        public ushort SizeOfOptionalHeader;

        public ushort Characteristics;
    }
}
