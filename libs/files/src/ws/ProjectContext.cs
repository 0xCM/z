//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectContext
    {
        public readonly IProjectWorkspace Project;

        public readonly FileCatalog Files;

        public readonly DataFlowCatalog Flows;

        public ProjectContext(IProjectWorkspace project, DataFlowCatalog flows)
        {
            Project = project;
            Files = flows.Files;
            Flows = flows;
        }

        public Index<FileRef> Docs(FileKind kind)
            => Files.Docs(kind);

        public FileRef Doc(FS.FilePath path)
            => Files[path];

        public FileRef Doc(Hex32 id)
            => Files[id];

        public FileRef Root(FS.FilePath dst)
        {
            if(Flows.Root(dst, out var src))
                return src;
            else
                return Z0.FileRef.Empty;
        }

        public FileRef Root(FileRef dst)
        {
            if(Flows.Root(dst.Path, out var src))
                return src;
            else
                return Z0.FileRef.Empty;
        }
    }
}