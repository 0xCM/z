//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ProjectModels;

    public partial class ProjectServices : WfSvc<ProjectServices>
    {
        public void EmitApiDeps(IDbArchive dst)
        {
            var src = ExecutingPart.Assembly;
            var path = dst.Path($"{src.GetSimpleName()}", FileKind.DepsList);
            if(path.Exists)
                EmitApiDeps(src, path);
        }

        public void EmitApiDeps(Assembly src, FilePath dst)
        {
            var deps = JsonDeps.load(src);
            var buffer = list<string>();
            iteri(deps.RuntimeLibs(), (i,lib) => buffer.Add(string.Format("{0:D4}:{1}",i,lib)));
            var emitter = text.emitter();
            iter(buffer, line => emitter.AppendLine(line));
            Channel.FileEmit(emitter.Emit(), buffer.Count, dst);
        }

        public FileSource CreateFileSource(FilePath src)
            => new FileSource(src);

        public FolderSource CreateFolderSource(FolderPath src)
            => new FolderSource(src);
    }
}