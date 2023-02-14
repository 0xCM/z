//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TypeMap<S,T>
        where S : ITypeSystem, new()
        where T : ITypeSystem, new()
    {
        protected TypeMap()
        {
            Sources = new();
            Targets = new();
        }

        protected S Sources {get;}

        protected T Targets {get;}

        public abstract Outcome Map(IType src, out IType dst);
    }
}