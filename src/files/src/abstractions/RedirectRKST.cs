//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Redirect<R,K,S,T> 
        where R : Redirect<R,K,S,T>, new()
        where K : unmanaged
        where S : IDataType<S>, IExpr, new()
        where T : IDataType<T>, IExpr,new()
    {
        public readonly K Kind;

        public readonly S Source;

        public readonly T Target;

        protected Redirect(K kind)
        {
            Kind = kind;
            Source = new();
            Target = new();
        }

        protected Redirect(K kind, S src, T dst)
        {
            Kind = kind;
            Source = src;
            Target = dst;
        }

        public static R Empty => new();
    }
}