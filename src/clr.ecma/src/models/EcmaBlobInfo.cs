//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct EcmaBlobInfo : IComparable<EcmaBlobInfo>
    {
        public const string TableId = "ecma.blob";

        public ByteSize HeapSize;

        public Address32 Offset;

        public ByteSize DataSize;

        public BinaryCode Data;

        public readonly int CompareTo(EcmaBlobInfo other)
            => Offset.CompareTo(other.Offset);

    }
}