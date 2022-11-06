//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    public class RuntimeArchive : DbArchive<RuntimeArchive>, IRuntimeArchive
    {
        public static IRuntimeArchive load()
            => new RuntimeArchive(FS.dir(RuntimeEnvironment.GetRuntimeDirectory()));

        public static IRuntimeArchive load(FolderPath src)
            => new RuntimeArchive(src);

        public static IRuntimeArchive load(Assembly src)
            => new RuntimeArchive(FS.path(src.Location).FolderPath);

        public Files Files {get;}

        [Op]
        public static string format(RuntimeAssembly src)
            => string.Format("{0}:{1}", src.Component.GetSimpleName(), src.Uri);

        [MethodImpl(Inline)]
        public static RuntimeAssembly assembly(Assembly component)
            => new RuntimeAssembly(component, new FileUri(component.Location));

        [MethodImpl(Inline)]
        public static RuntimeAssembly assembly(Assembly component, FilePath path)
            => new RuntimeAssembly(component, path);

        public RuntimeArchive()
        {
            Files = Files.Empty;
        }

        [MethodImpl(Inline)]
        public RuntimeArchive(FolderPath root)
            : base(root)
        {
            Files = root.Files(false, Exe, Dll, Pdb, Json, Xml).Where(x => !x.Name.Contains("System.Private.CoreLib"));
        }
    }
}