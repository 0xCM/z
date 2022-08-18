//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IStore
    {
        void Deposit(IArtifact src);
    }

    public interface IStore<T> : IStore
        where T : IArtifact
    {
        void Store(T value);

        void IStore.Deposit(IArtifact src)
            => Store((T)src);
    }
}