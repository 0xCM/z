//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines an entry in list of files
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct ListedFile : IDataType<ListedFile>, IDataString<ListedFile>, ISequential<ListedFile>
    {
        public const string TableId = "files";

        [Render(8)]

        public uint Seq;

        [Render(16)]
        public Kb Size;

        [Render(180)]
        public FS.FileUri Path;

        [Render(24)]
        public Timestamp CreateTS;

        [Render(24)]
        public Timestamp UpdateTS;

        [Render(1)]
        public FileAttributeSet Attributes;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => nhash(Size,CreateTS,UpdateTS,Attributes);
        }

        uint ISequential.Seq
        {
             get => Seq;
             set => Seq = value;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0,-10} | {1}", Seq, Path);

        public override string ToString()
            => Format();

        public int CompareTo(ListedFile src)
            => Path.CompareTo(src.Path);

        public bool Equals(ListedFile src)
            => Path == src.Path && Size == src.Size && CreateTS == src.CreateTS && UpdateTS == src.UpdateTS;
    }
}