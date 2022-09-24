//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Build;

    public class Dev : WfSvc<Dev>
    {
        MsBuild MsBuild => Wf.BuildSvc();
        
        public ProjectSpec DirectoryProps(IDbArchive src)
        {
            var path = src.Path("directory.build", FileKind.Props);
            Require.invariant(path.Exists);
            return MsBuild.LoadProject(path);
        }

        public ReadOnlySeq<ProjectSpec> Deps(string project)
        {
            var src = AppDb.DevProject(project);
            var files = src.Scoped("props/deps").Files(FileKind.Props);
            return LoadProjects(files);
        }

        public ReadOnlySeq<ProjectSpec> Exports(IDbArchive src)
        {
            var files = src.Files().Where(x => x.FileName == FS.file("exports", FileKind.Props));
            return LoadProjects(files);
        }

        public ReadOnlySeq<ProjectSpec> Imports(IDbArchive src)
        {
            var files = src.Files().Where(x => x.FileName == FS.file("imports", FileKind.Props));
            return LoadProjects(files);
        }

        public void EmitCfg(ReadOnlySeq<ProjectSpec> src, string kind, IDbArchive dst)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var project = ref src[i];
                var path = dst.Path($"{project.Origin.ToFilePath().FolderName}.{kind}",FileKind.Cfg);
                FileEmit(project.Format(),path);
            }
        }

        ReadOnlySeq<ProjectSpec> LoadProjects(ReadOnlySpan<FilePath> src)
        {
            var count = src.Length;
            var buffer = alloc<ProjectSpec>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = MsBuild.LoadProject(skip(src,i));
            return buffer;
        }
    }
}
