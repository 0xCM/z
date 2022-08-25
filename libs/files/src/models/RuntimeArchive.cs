//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    partial class XTend
    {
        public static IRuntimeArchive RuntimeArchive(this Assembly src)
            => Z0.RuntimeArchive.load(src);
    }

    [ApiHost]
    public readonly struct RuntimeArchive : IRuntimeArchive
    {
        public static IRuntimeArchive load()
            => new RuntimeArchive(FS.dir(RuntimeEnvironment.GetRuntimeDirectory()));

        public static IRuntimeArchive load(FolderPath src)
            => new RuntimeArchive(src);

        public static IRuntimeArchive load(Assembly src)
            => new RuntimeArchive(FS.path(src.Location).FolderPath);

        public FolderPath Root {get;}

        public FS.Files Files {get;}

        [Op]
        public static string format(RuntimeAssembly src)
            => string.Format("{0}:{1}", src.Component.GetSimpleName(), src.Path.ToUri());

        [MethodImpl(Inline)]
        public static RuntimeAssembly assembly(Assembly component)
            => new RuntimeAssembly(component, FS.path(component.Location));

        [MethodImpl(Inline)]
        public static RuntimeAssembly assembly(Assembly component, FilePath path)
            => new RuntimeAssembly(component, path);

        [MethodImpl(Inline)]
        internal RuntimeArchive(FolderPath root)
        {
            Root = root;
            Files = root.Files(false, Exe, Dll, Pdb, Json, Xml).Where(x => !x.Name.Contains("System.Private.CoreLib"));
        }
    }
}