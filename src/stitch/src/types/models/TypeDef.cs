//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypeDef
    {
        
    }

    public class TypeDef : IType, IEquatable<TypeDef>
    {
        public Identifier Name {get;}
        public ulong Kind {get;}

        public TypeDef(Identifier name, ulong kind)
        {
            Name = name;
            Kind = 0;
        }

        public virtual string Format()
            => Kind.ToString();

        public sealed override string ToString()
            => Format();

        public bool Equals(TypeDef src)
            => Kind == src.Kind;

        public static TypeDef Empty = new TypeDef(Identifier.Empty,0);
    }
}