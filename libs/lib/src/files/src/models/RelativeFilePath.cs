//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static FS;

    public readonly struct RelativeFilePath : IFsEntry<RelativeFilePath>
    {
        public RelativePath Location {get;}

        [MethodImpl(Inline)]
        public RelativeFilePath(RelativePath location)
        {
            Location = location;
        }

        public FileName File
            => file(Path.GetFileName(Location.Format()));

        public PathPart Name
            => Location.Format(PathSeparator.FS);

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

        public string Format(PathSeparator sep)
            => Name.Format(sep);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(RelativeFilePath src)
            => Name == src.Name;

        public int CompareTo(RelativeFilePath src)
            => Name.CompareTo(src.Name);

        public string Format()
            => Format(PathSeparator.FS);

        public override string ToString()
            => Format();
    }
}