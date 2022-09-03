//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    [Free]
    public interface ITypeSystem
    {
        Label Name {get;}

        ReadOnlySpan<IType> KnownTypes {get;}

        ReadOnlySpan<TypeKind> PrimalKinds {get;}
    }

    [Free]
    public interface ITypeSystem<K> : ITypeSystem
        where K : unmanaged
    {
        new ReadOnlySpan<TypeKind<K>> PrimalKinds {get;}

        ReadOnlySpan<TypeKind> ITypeSystem.PrimalKinds
            => PrimalKinds.Map(t => (TypeKind)t);
    }
}