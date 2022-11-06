//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ApiModules : AppData<ApiModules>
    {            
        public static IModuleArchive create(FolderPath root)
            => new ApiModule(root);

        static IModuleArchive create()
            => create(FS.path(ExecutingPart.Assembly.Location).FolderPath);

        public static Assembly[] parts()
            => get("parts",() => create().ManagedDll().Where(x => x.FileName.StartsWith("z0")).Map(x => x.Load()).Distinct().Array());
    }
}