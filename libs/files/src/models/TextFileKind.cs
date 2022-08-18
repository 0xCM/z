//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct TextFileKind : IValueWrapper<asci16>, IDataType<TextFileKind>, IDataString<TextFileKind>
    {
        public readonly asci16 Name;

        [MethodImpl(Inline)]
        public TextFileKind(asci16 name)
        {
            Name = name;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
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
        public int CompareTo(TextFileKind src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(asci16 src)
            => Name == src;

        [MethodImpl(Inline)]
        public bool Equals(TextFileKind src)
            => Name == src.Name;

        public int CompareTo(asci16 src)
            => Name.CompareTo(src);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        asci16 IValueWrapper<asci16>.Value 
            => Name;
    }
}