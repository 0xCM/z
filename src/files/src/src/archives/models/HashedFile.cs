//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct HashedFile : IDataType<HashedFile>, IDataString
    {
        public readonly FilePath Path;

        public readonly FileHash FileHash;

        public HashedFile()
        {
            Path = FilePath.Empty;
            FileHash = default;
        }

        public HashedFile(FilePath path, FileHash hash)
        {
            Path = path;
            FileHash = hash;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Path.Hash | FileHash.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsEmpty || FileHash.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsNonEmpty && FileHash.IsNonEmpty;
        }

        public bool Equals(HashedFile src)
            => FileHash == src.FileHash && Path.Equals(src.Path);

        public int CompareTo(HashedFile src)
        {
            var result = FileHash.CompareTo(src.FileHash);
            if(result == 0)
                result = Path.CompareTo(src.Path);
            return result;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => string.Format("{0} {1}", FileHash, Path);

        public override string ToString()
            => Format();


        public static HashedFile Empty => new();
    }
}