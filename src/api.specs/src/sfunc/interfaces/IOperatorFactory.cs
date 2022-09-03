//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IOperatorFactory<D,T>
        where D : Delegate
    {
        D Create(MethodInfo method, object instance);

        D Create(MethodInfo method)
            => Create(method,null);
    }
}