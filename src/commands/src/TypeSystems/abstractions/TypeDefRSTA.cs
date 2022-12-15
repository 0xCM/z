//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public abstract class TypeDef<R,S,T,A> : TypeDef<R,S,T>, IType<R,T,A>
        where S : ITypeSystem, new()
        where R : TypeDef<R,S,T,A>, new()
    {
        public virtual T Value(A args)
            => Factory()(args);

        public new virtual Func<A,T> Factory() 
            => a => (T)Activator.CreateInstance(typeof(T), new object[]{a});
    }
}