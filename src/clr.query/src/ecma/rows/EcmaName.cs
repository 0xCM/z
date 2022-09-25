//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct EcmaName
    {
        public const string TableId = "ecma.names";

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
        public EcmaName(Count seq, ByteSize heap, Address32 offset, string value)
        {
            Seq = seq;
            HeapSize = heap;
            Length = value.Length;
            Offset = offset;
            Value = value;
        }
    }
}