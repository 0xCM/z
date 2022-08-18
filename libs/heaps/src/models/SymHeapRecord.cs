//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(StructLayout,Pack=1)]
    public struct SymHeapRecord
    {
        const string TableId = "api.symbols.heap";

        [Render(8)]
        public uint Key;

        [Render(12)]
        public Address32 Offset;

        [Render(6)]
        public uint Size;

        [Render(12)]
        public Hex32 Remains;

        [Render(64)]
        public string Source;

        [Render(16)]
        public SymVal Value;

        [Render(64)]
        public string Name;

        [Render(1)]
        public SymExpr Expression;
    }
}