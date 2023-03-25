//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct NasmEncoding
    {
        public const string TableId = "nasm.encoding";

        public uint LineNumber;

        public MemoryAddress Offset;

        public TextBlock SourceText;

        public BinaryCode Encoded;
    }
}