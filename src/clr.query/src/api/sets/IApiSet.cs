//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiSet
    {
        ReadOnlySeq<MethodInfo> Operations {get;}
    }

    public interface IApiSet<T> : IApiSet
        where T : IApiSet<T>, new()
    {
        ReadOnlySeq<MethodInfo> IApiSet.Operations 
            => typeof(T).Methods().Tagged<ApiAttribute>();
    }

    public interface IApiSets
    {
        ref readonly Assembly Source {get;}

        ref readonly ReadOnlySeq<Type> Hosts {get;}

        ref readonly ReadOnlySeq<MethodInfo> Ops {get;}
    }
}