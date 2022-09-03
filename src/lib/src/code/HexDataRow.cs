//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HexDataRow
    {
        const string TableId = "hex.dat";

        public MemoryAddress Address;

        public BinaryCode Data;

        public static HexDataRow Empty => default;
    }
}