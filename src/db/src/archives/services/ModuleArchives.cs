//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static FS;

    using K = ApiMdKind;

    public sealed class ModuleArchives : AppData<ModuleArchives>
    {            
        // [Op]
        // public static Files managed(FolderPath src, bool recurse = false, bool dll = true, bool exe = true)
        // {
        //     var dst = Files.Empty;
        //     if(dll && exe)
        //         dst = FS.files(src, recurse, Dll, Exe).Array().Where(FS.managed);
        //     else if(!exe && dll)
        //         dst = FS.files(src, recurse, Dll).Array().Where(FS.managed);
        //     else if(exe && !dll)
        //         dst = FS.files(src, recurse, Exe).Array().Where(FS.managed);
        //     return dst;
        // }

        // static IModuleArchive archive(FolderPath root)
        //     => new ModuleArchive(root);

        // static IModuleArchive archive()
        //     => archive(FS.path(ExecutingPart.Assembly.Location).FolderPath);

        // public static Assembly[] parts()
        //     => get("parts",() => archive().ManagedDll().Where(x => x.FileName.StartsWith("z0")).Map(x => x.Load()).Distinct().Array());
    }
}