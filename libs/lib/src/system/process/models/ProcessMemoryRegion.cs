//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessMemoryRegion : IComparable<ProcessMemoryRegion>, ISequential<ProcessMemoryRegion>
    {
        const string TableId = "image.regions";

        public const byte FieldCount = 9;

        [Render(8)]
        public uint Seq;

        [Render(64)]
        public string ImageName;

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(16)]
        public MemoryAddress MaxAddress;

        [Render(16)]
        public ByteSize Size;

        [Render(12)]
        public MemType Type;

        [Render(16)]
        public PageProtection Protection;

        [Render(16)]
        public MemState State;

        [Render(1)]
        public FileUri ImagePath;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        public int CompareTo(ProcessMemoryRegion src)
            => BaseAddress.CompareTo(src.BaseAddress);

        public string Describe()
            => string.Format("[{0},{1}]({2})", BaseAddress, BaseAddress + Size, (ByteSize)Size);

        public override string ToString()
            => Describe();
    }
}