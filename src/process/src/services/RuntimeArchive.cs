//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    public class RuntimeArchive : DbArchive<RuntimeArchive>, IDbArchive
    {
        public static IDbArchive load()
            => new RuntimeArchive(FS.dir(RuntimeEnvironment.GetRuntimeDirectory()));

        public static IDbArchive load(FolderPath src)
            => new RuntimeArchive(src);

        public static IDbArchive load(Assembly src)
            => new RuntimeArchive(FS.path(src.Location).FolderPath);

        public Files Files {get;}

        public RuntimeArchive()
        {
            Files = Files.Empty;
        }

        [MethodImpl(Inline)]
        public RuntimeArchive(FolderPath root)
            : base(root)
        {
            Files = root.Files(false, Exe, Dll, Pdb, FS.ext("json"), Xml).Where(x => !x.Name.Contains("System.Private.CoreLib"));
        }
    }

    partial class XTend
    {
        public static IDbArchive RuntimeArchive(this Assembly src)
            => Z0.RuntimeArchive.load(src);
    }    
}