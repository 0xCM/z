//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public record struct ProcessModuleRow : IComparable<ProcessModuleRow>, ISequential<ProcessModuleRow>
    {
        const string TableId = "image.modules";

        [Render(8)]
        public uint Seq;

        [Render(64)]
        public string ImageName;

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(16)]
        public MemoryAddress EntryAddress;

        [Render(16)]
        public MemoryAddress MaxAddress;

        [Render(16)]
        public ByteSize MemorySize;

        [Render(12)]
        public Version128 Version;

        [Render(1)]
        public _FileUri ImagePath;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ProcessModuleRow src)
        {
            var result = BaseAddress.CompareTo(src.BaseAddress);
            if(result == 0)
                result = EntryAddress.CompareTo(src.EntryAddress);
            return result;
        }
    }
}