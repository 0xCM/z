//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct EcmaStringDetail
    {
        const string TableId = "ecma.strings";

        [Render(8)]
        public uint Seq;

        [Render(8)]
        public bool System;

        [Render(12)]
        public ByteSize HeapSize;

        [Render(12)]
        public uint Length;

        [Render(12)]
        public Address32 Offset;

        [Render(1)]
        public string Content;

        [MethodImpl(Inline)]
        public EcmaStringDetail(Count seq, ByteSize heap, Address32 offset, string data)
        {
            Seq = seq;
            System = true;
            HeapSize = heap;
            Length = (uint)data.Length;
            Offset = offset;
            Content = data;
        }
    }
}