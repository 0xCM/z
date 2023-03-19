//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ModuleResolvers : WfSvc<ModuleResolvers>
    {
        public NativeDllResolver DllResolver(IModuleArchive root)
            => new NativeDllResolver(Channel,root);

        public NativeLibResolver LibResolver(IModuleArchive root)
            => new NativeLibResolver(Channel,root);

        public ManagedDependencyResolver AssemblyResolver(IModuleArchive root)
            => new ManagedDependencyResolver(Channel, root);
    }
}