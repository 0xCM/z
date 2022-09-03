//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public readonly struct ObjectType : IType<FileObjectKind>
        {
            public FileObjectKind Kind {get;}

            [MethodImpl(Inline)]
            public ObjectType(FileObjectKind kind)
            {
                Kind = kind;
            }
            public Identifier Name
                => Kind.ToString();

            public string Format()
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator ObjectType(FileObjectKind kind)
                => new ObjectType(kind);

            [MethodImpl(Inline)]
            public static implicit operator FileObjectKind(ObjectType type)
                => type.Kind;
        }
    }
}