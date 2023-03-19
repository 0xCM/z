//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NativeDllResolver : ModuleResolver<NativeDependency, DllModule>
    {
        public NativeDllResolver(IWfChannel channel, IModuleArchive root)
            : base(channel, root)
        {

        }

        public override DllModule Resolve(NativeDependency dependency)
        {
            throw new NotImplementedException();
        }
    }
}