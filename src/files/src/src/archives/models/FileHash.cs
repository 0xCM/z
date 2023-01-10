//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct FileHash : IDataType<FileHash>, IDataString
    {
        public Hash128 ContentHash;

        public Hash32 LocationHash;     

        [MethodImpl(Inline)]
        public FileHash(Hash128 content, Hash32 location)   
        {
            ContentHash = content;
            LocationHash = location;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => LocationHash == 0 || ContentHash.Lo == 0 && ContentHash.Hi == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => LocationHash | ContentHash.Lo.Lo | ContentHash.Lo.Hi | ContentHash.Hi.Lo | ContentHash.Hi.Hi;
        }

        [MethodImpl(Inline)]
        public bool Equals(FileHash src)
            => LocationHash == src.LocationHash && ContentHash == src.ContentHash;

        public override int GetHashCode()
            => Hash;

        public int CompareTo(FileHash src)
        {
            var result = ContentHash.CompareTo(src.ContentHash);
            if(result == 0)
                result = LocationHash.CompareTo(src.LocationHash);
            return result;
        }

        public string Format()
            => string.Format("{0}:{1}", ContentHash, LocationHash);

        public override string ToString()
            => Format();
    }
}