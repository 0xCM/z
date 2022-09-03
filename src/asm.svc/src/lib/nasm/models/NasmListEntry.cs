//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct NasmListEntry
    {
        public const string TableId = "nasm.listing";

        public uint EntryNumber;

        public uint LineNumber;

        public Identifier Label;

        public MemoryAddress Offset;

        public BinaryCode Encoding;

        public TextBlock SourceText;
    }
}