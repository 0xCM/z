//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FolderName : IFsEntry<FolderName>
    {
        public static FolderName version(byte major, byte minor, byte revision)
            => new (string.Format("{0}.{1}.{2}", major, minor, revision));

        public PathPart Name {get;}

        [MethodImpl(Inline)]
        public FolderName(PathPart name)
            => Name = name;

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
        public FolderName Replace(char src, char dst)
            => new FolderName(Name.Replace(src,dst));

        [MethodImpl(Inline)]
        public FolderName Replace(string src, string dst)
            => new FolderName(Name.Replace(src,dst));

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(FolderName src)
            => Name == src.Name;

        public int CompareTo(FolderName src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static FolderName operator +(FolderName a, FolderName b)
            => new (string.Format("{0}/{1}", a.Name, b.Name));

        public static FolderName Empty
        {
            [MethodImpl(Inline)]
            get => new FolderName(PathPart.Empty);
        }
    }
}