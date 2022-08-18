//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRepository<K,S,T>
    {
        void Store(S src, T dst);

        S Load(K key);
    }
}