//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct FileRef : IFileRef, IDataType<FileRef>, ISequential<FileRef>
    {
        const string TableId = "files.index";

        [Render(8)]
        public uint Seq;

        [Render(12)]
        public readonly Hex32 DocId;

        [Render(12)]
        public readonly FileKind Kind;

        [Render(24)]
        public readonly Timestamp Timestamp;

        [Render(1)]
        public readonly FilePath Path;

        [MethodImpl(Inline)]
        public FileRef(uint seq, uint docid, FileKind kind, FilePath path)
        {
            Seq = seq;
            DocId = docid;
            Kind = kind;
            Timestamp = path.Timestamp;
            Path = path;
        }

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
            get => (uint)DocId;
        }

        public string DocName
        {
            [MethodImpl(Inline)]
            get => Path.FileName.Format();
        }

        public int CompareTo(FileRef src)
            => DocId.CompareTo(src.DocId);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Path.ToUri().Format();

        public override string ToString()
            => Format();

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        FileKind IFileRef.Kind
            => Kind;

        FilePath IFileRef.Path
            => Path;

        public static FileRef Empty => default;
    }
}