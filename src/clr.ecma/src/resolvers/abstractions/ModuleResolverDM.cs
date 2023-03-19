//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ModuleResolver<D,M> : IModuleResolver<D,M>
        where M : IBinaryModule
        where D : ModuleDependency
    {
        public abstract M Resolve(D dependency);

        protected readonly IWfChannel Channel;

        protected readonly IModuleArchive Root;
        protected ModuleResolver(IWfChannel channel, IModuleArchive root)
        {
            Channel = channel;
            Root = root;
        }
    }
}