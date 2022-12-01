//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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


        public static FsEntry Empty => new FsEntry(PathPart.Empty, 0);
    }

}