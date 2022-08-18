//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MsilCapture
    {
        public const string TableId = "cil.data";

        public const byte FieldCount = 4;

        [Render(16)]
        public CliToken Token;

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(80)]
        public OpUri Uri;

        [Render(1)]
        public BinaryCode Encoded;
    }
}