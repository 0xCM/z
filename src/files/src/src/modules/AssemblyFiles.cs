//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AssemblyFiles
    {
        public static IEnumerable<AssemblyFile> managed(FolderPath src)
        {
            foreach(var path in src.EnumerateFiles(true, FS.Dll, FS.ext("winmd")))
                if(FS.managed(path, out var assname))
                    yield return new AssemblyFile(new FileUri(path.ToUri().Format()), assname);
        }
    }
}