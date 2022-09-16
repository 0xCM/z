//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ModuleArchives : AppData<ModuleArchives>
    {            
        static ModuleArchive create()
            => create(FS.path(ExecutingPart.Assembly.Location).FolderPath);

        public static Assembly[] parts()
            => get("parts",() => create().ManagedDll().Where(x => x.FileName.StartsWith("z0")).Select(x => x.Load()).Unwrap().Distinct().Unwrap());

        /// <summary>
        /// Creates an archive over both managed and unmanaged modules
        /// </summary>
        /// <param name="root">The archive root</param>
        [MethodImpl(Inline), Op]
        public static ModuleArchive create(FolderPath root)
            => new ModuleArchive(root);
    }
}