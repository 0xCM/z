//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeRef
    {
        public readonly TypeSpec Type;

        public readonly TypeRefKind Kind;

        [MethodImpl(Inline)]
        public TypeRef(TypeSpec src, TypeRefKind kind)
        {
            Type = src;
            Kind = kind;
        }
    }
}