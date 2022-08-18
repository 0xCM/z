//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeKind : ITypeKind
    {
        public ulong Key {get;}

        public Identifier Class {get;}

        public Identifier Name {get;}

        public byte Arity {get;}

        [MethodImpl(Inline)]
        public TypeKind(ulong key, Identifier @class, Identifier name, byte arity)
        {
            Key = key;
            Class = @class;
            Name = name;
            Arity = arity;
        }

        public string Format()
            => string.Format("{0}:{1}",Name, Class);

        public override string ToString()
            => Format();
    }
}