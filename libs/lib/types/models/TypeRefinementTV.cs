//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TypeRefinement<T,V> : IType
        where T : IType
    {
        public Identifier Name {get;}

        public T Base {get;}

        protected TypeRefinement(Identifier name, T @base)
        {
            Name = name;
            Base = @base;
        }

        public abstract Predicate<V> Predicate {get;}
    }
}