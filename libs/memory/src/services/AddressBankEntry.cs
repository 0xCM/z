//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AddressBankEntry
    {
        public const string TableId = "addresses.entries";

        [Render(16)]
        public AddressBankIndex Index;

        [Render(16)]
        public Address16 Selector;

        [Render(16)]
        public Address32 Base;

        [Render(16)]
        public ByteSize Size;

        [Render(16)]
        public MemoryAddress Target;

        [Render(16)]
        public ByteSize TotalSize;
    }
}