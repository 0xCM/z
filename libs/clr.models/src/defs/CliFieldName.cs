//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CliFieldName
    {
        public const string TableId = "cli.fields.names";

        [Render(8)]
        public uint Seq;

        [Render(12)]
        public ByteSize HeapSize;

        [Render(12)]
        public Count Length;

        [Render(12)]
        public Address32 Offset;

        [Render(1)]
        public string Value;

        [MethodImpl(Inline)]
        public CliFieldName(Count seq, ByteSize heap, Address32 offset, string value)
        {
            Seq = seq;
            HeapSize = heap;
            Length = value.Length;
            Offset = offset;
            Value = value;
        }
    }
}