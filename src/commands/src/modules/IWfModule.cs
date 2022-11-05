//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfModule : IActor
    {
        Task<ExecToken> Start<C>(C cmd)
            where C : IWfCmd<C>, new();
        
        @string INamed.Name
            => GetType().AssemblyQualifiedName;

        Hash32 IHashed.Hash
            => sys.hash(GetType().AssemblyQualifiedName);

        bool INullity.IsEmpty
            => false;

        bool INullity.IsNonEmpty
            => true;

    }

    public interface IWfModule<M> : IWfModule
        where M : IWfModule<M>, new()
    {

    }
}