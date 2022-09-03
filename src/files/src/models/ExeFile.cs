//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExeFile : IFsEntry<ExeFile>
    {
        public FilePath Path {get;}

        public PathPart Name
        {
            [MethodImpl(Inline)]
            get => Path.Name;
        }

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

        [MethodImpl(Inline)]
        public int CompareTo(ExeFile src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(ExeFile src)
            => Name == src.Name;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public ExeFile(FilePath src)
            => Path = src;

        [MethodImpl(Inline)]
        public static implicit operator ExeFile(FilePath src)
            => new ExeFile(src);

        [MethodImpl(Inline)]
        public static implicit operator FilePath(ExeFile src)
            => src.Path;
    }
}