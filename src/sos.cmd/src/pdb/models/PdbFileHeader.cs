//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct PdbFileHeader
    {
        public const string TableId = "pdb.header";

        /// <summary>
        /// [0,31]
        /// </summary>
        public Cell256 Magic;

        /// <summary>
        /// [32,35]
        /// </summary>
        public uint PageSize;

        /// <summary>
        /// [36,39]
        /// </summary>
        public uint FreePageMap;

        /// <summary>
        /// [40,43]
        /// </summary>
        public uint PagesUsed;

        /// <summary>
        /// [44,47]
        /// </summary>
        public uint DirectorySize;

        /// <summary>
        /// [48,51]
        public uint Reserved;

        /// <summary>
        /// Computes the number of pages consumed by the directory
        /// </summary>
        /// <remarks>
        /// Calculation from https://github.com/dotnet/symreader-converter/src/Microsoft.DiaSymReader.Converter.Xml/Token2SourceLineExporter.cs
        /// </remarks>
        [MethodImpl(Inline)]
        public uint DirPageCount()
            => ((((DirectorySize + PageSize - 1) / PageSize) * 4) + PageSize - 1) / PageSize;

    }
}
/*
            return new byte[]
            {
                0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, // "Microsof"
                0x74, 0x20, 0x43, 0x2F, 0x43, 0x2B, 0x2B, 0x20, // "t C/C++ "
                0x4D, 0x53, 0x46, 0x20, 0x37, 0x2E, 0x30, 0x30, // "MSF 7.00"
                0x0D, 0x0A, 0x1A, 0x44, 0x53, 0x00, 0x00, 0x00  // "^^^DS^^^"
            };

*/
