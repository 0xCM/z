//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HexCsvRow
    {
        const string TableId = "hex";

        public const byte BPL = 64;

        [Render(16)]
        public MemoryAddress Address;

        [Render(1)]
        public BinaryCode Data;

        public static HexCsvRow Empty => default;
    }
}