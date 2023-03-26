//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public readonly record struct SourceKind : IDataType<SourceKind>, IDataString
        {
            public readonly asci16 Name;

            [MethodImpl(Inline)]
            public SourceKind(string name)
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

            public int CompareTo(SourceKind src)
                => Name.CompareTo(src.Name);

            public override int GetHashCode()
                => Hash;

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator SourceKind(string name)
                => new SourceKind(name);
        }
    }
}