//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeRef
    {
        public TypeSpec Type {get;}

        public TypeRefKind Kind {get;}

        [MethodImpl(Inline)]
        public TypeRef(TypeSpec src, TypeRefKind kind)
        {
            Type = src;
            Kind = kind;
        }

        public string Format(params object[] args)
            => TypeFormatter.format(this,args);
    }
}