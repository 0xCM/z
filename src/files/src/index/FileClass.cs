//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public record struct FileClass : IDataType<FileClass>, IDataString
    {
        public readonly @string Name;

        [MethodImpl(Inline)]
        public FileClass(string name)
        {
            Name = name;
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(FileClass src)
            => Name == src.Name;

        [MethodImpl(Inline)]
        public int CompareTo(FileClass src)
            => Name.CompareTo(src.Name);
    
        public string Format()
            => Name;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FileClass(string name)
            => new (name);
    }
}