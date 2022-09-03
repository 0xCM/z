//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public abstract class TypeSystem<T,K> : ITypeSystem<K>
        where T : TypeSystem<T,K>, new()
        where K : unmanaged
    {
        public Label Name {get;}

        public abstract ReadOnlySpan<TypeKind<K>> PrimalKinds {get;}

        public abstract ReadOnlySpan<IType> KnownTypes {get;}

        protected TypeSystem(Label name)
        {
            Name = name;
        }
    }
}