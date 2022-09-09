//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct FileType : IDataString<FileType>
    {
        public readonly FileKind Kind;

        [MethodImpl(Inline)]
        public FileType(FileKind kind)
        {
            Kind = kind;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(FileType src)
            => ((uint)Kind).CompareTo((uint)src.Kind);

        public string Format()
            => Kind.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FileType(FileKind src)
            => new FileType(src);

        [MethodImpl(Inline)]
        public static implicit operator FileKind(FileType src)
            => src.Kind;
    }
}