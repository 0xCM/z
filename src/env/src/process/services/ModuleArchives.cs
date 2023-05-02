//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ModuleArchives : Channeled<ModuleArchives>
    {        
        public static IModuleArchive modules(FolderPath src, bool recurse = true)
            => new ModuleArchive(src, recurse);

        public static IModuleArchive modules(IDbArchive src, bool recurse = true)
            => new ModuleArchive(src.Root, recurse);

    }
}