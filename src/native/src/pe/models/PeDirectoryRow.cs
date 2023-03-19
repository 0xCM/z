//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct PeDirectoryRow : ISequential<PeDirectoryRow>, IComparable<PeDirectoryRow>
    {
        public uint Seq;

        [Render(64)]
        public FileName File;

        [Render(24)]
        public PeDirectoryKind Kind;
        
        [Render(16)]
        public Address32 Rva;

        [Render(1)]
        public uint Size;

        uint ISequential.Seq { get => Seq; set => Seq = value; }

        [MethodImpl(Inline)]
        public PeDirectoryEntry Entry()
            => new (Rva,Size);
        public int CompareTo(PeDirectoryRow src)
        {
            var result = File.CompareTo(src.File);
            if(result == 0)
                result = Rva.CompareTo(src.Rva);
            return result;
        }
    }
}