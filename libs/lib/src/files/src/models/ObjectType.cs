//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{


    partial struct FS
    {
        public readonly struct ObjectType : IType<ObjectKind>
        {
            public ObjectKind Kind {get;}

            [MethodImpl(Inline)]
            public ObjectType(ObjectKind kind)
            {
                Kind = kind;
            }
            public Identifier Name
                => Kind.ToString();

            public string Format()
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator ObjectType(ObjectKind kind)
                => new ObjectType(kind);

            [MethodImpl(Inline)]
            public static implicit operator ObjectKind(ObjectType type)
                => type.Kind;
        }
    }
}