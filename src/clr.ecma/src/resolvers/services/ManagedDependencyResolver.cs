//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ManagedDependencyResolver : ModuleResolver<ManagedDependency, AssemblyFile>
    {        
        public ManagedDependencyResolver(IWfChannel channel, IModuleArchive root)
            : base(channel, root)
        {

        }

        public override AssemblyFile Resolve(ManagedDependency dependency)
        {
            throw new NotImplementedException();
        }
    }
}