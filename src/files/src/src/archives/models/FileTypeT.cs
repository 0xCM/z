//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class FileType<T> : IFileType<T>, IDataString<T>
        where T : FileType<T>, new()
    {
        public @string Name {get;}

        public abstract FileExt DefaultExt {get;}

        protected FileType(string name)
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
            => Name.Hash;

        public string Format()
            => Name.Format();

        public sealed override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        Hash32 IHashed.Hash
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(FileType<T> src)
            => Name.CompareTo(src.Name);
    }
}