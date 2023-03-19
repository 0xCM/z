//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NativeLibResolver : ModuleResolver<NativeDependency, LibModule>
    {
        public NativeLibResolver(IWfChannel channel, IModuleArchive root)
            : base(channel, root)
        {

        }

        public override LibModule Resolve(NativeDependency dependency)
        {
            throw new NotImplementedException();
        }
    }
}