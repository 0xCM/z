//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TypeDef<K> : TypeDef, IType<K>, IEquatable<TypeDef<K>>
        where K : unmanaged
    {
        public new K Kind {get;}

        public TypeDef(Identifier name, K kind)
            : base(name, sys.bw64(kind))
        {
            Kind = kind;
        }

        public override string Format()
            => Kind.ToString();

        public bool Equals(TypeDef<K> src)
            => sys.bw64(Kind) == sys.bw64(src.Kind);

        public new static TypeDef<K> Empty = new TypeDef<K>(Identifier.Empty, default(K));
    }
}