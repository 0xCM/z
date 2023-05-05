//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record TypeInterfaces
    {
        public readonly TypeDefinition Type;

        public readonly ReadOnlySeq<TypeDefinition> Implementations;

        public TypeInterfaces(TypeDefinition type, TypeDefinition[] impls)
        {
            Type = type;
            Implementations = impls;
        }
    }
}