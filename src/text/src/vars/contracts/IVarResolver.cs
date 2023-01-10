//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVarResolver
    {
        public dynamic Resolve(string name);
    }

    public interface IVarResover<T> : IVarResolver
    {
        new public T Resolve(string name);

        dynamic IVarResolver.Resolve(string name)
            => Resolve(name);
    }
}