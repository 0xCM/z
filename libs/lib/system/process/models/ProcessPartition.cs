//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessPartition : IComparable<ProcessPartition>
    {
        const string TableId = "image.partitions";

        [Render(16)]
        public MemoryAddress MinAddress;

        [Render(16)]
        public MemoryAddress MaxAddress;

        [Render(16)]
        public ByteSize Size;

        [Render(1)]
        public string ImageName;

        public int CompareTo(ProcessPartition src)
        {
            var result = MinAddress.CompareTo(src.MinAddress);
            if(result==0)
                result = MaxAddress.CompareTo(src.MaxAddress);
            return result;
        }
    }
}