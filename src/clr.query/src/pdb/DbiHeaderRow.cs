//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct DbiHeaderRow
    {
        public const string TableId = "dbi.header";

        public uint Signature; // 0..3

        public uint Version; // 4..7

        public uint Age; // 8..11

        public ushort gssymStream; // 12..13

        public ushort vers; // 14..15

        public ushort pssymStream; // 16..17

        public ushort pdbver; // 18..19

        public ushort symrecStream;               // 20..21

        public ushort pdbver2;                    // 22..23

        public uint gpmodiSize;                 // 24..27

        public uint secconSize;                 // 28..31

        public uint secmapSize;                 // 32..35

        public uint filinfSize;                 // 36..39

        public uint tsmapSize;                  // 40..43

        public uint mfcIndex;                   // 44..47

        public uint DebugHeaderSize;                 // 48..51

        public uint ecinfoSize;                 // 52..55

        public ushort Flags;                      // 56..57

        public ushort Machine;                    // 58..59

        public uint Reserved;                   // 60..63
    }
}