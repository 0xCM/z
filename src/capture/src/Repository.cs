//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Repository<K,S,T> : IRepository<K,S,T>
    {
        public abstract void Store(S src, T dst);

        public abstract S Load(K key);
    }
}