//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS.Json;

    /// <summary>
    /// Defines a file system entry
    /// </summary>
    public readonly record struct FsEntry : IFsEntry<FsEntry>
    {
        const string FormatPattern = "{0}: {1}";

        public readonly PathPart Name;

        public readonly FileObjectKind Kind;

        [MethodImpl(Inline)]
        public FsEntry(PathPart name, FileObjectKind kind)
        {
            Name = name;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public FilePath AsFilePath()
            => new FilePath(Name);

        [MethodImpl(Inline)]
        public FolderPath AsFolderPath()
            => new FolderPath(Name);

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(FormatPattern, Kind, Name);

        PathPart IFsEntry.Name
            => Name;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(FsEntry src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(FsEntry src)
            => Name.Equals(src.Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FsEntry(FilePath src)
            => new FsEntry(src.Name, FileObjectKind.FilePath);

        [MethodImpl(Inline)]
        public static implicit operator FsEntry(FolderPath src)
            => new FsEntry(src.Name, FileObjectKind.Directory);

        [MethodImpl(Inline)]
        public static explicit operator FolderPath(FsEntry src)
            => new FolderPath(src.Name);

        [MethodImpl(Inline)]
        public static explicit operator FilePath(FsEntry src)
            => new FilePath(src.Name);

        public static FsEntry Empty => new FsEntry(PathPart.Empty, 0);
    }
}