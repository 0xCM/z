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

        public readonly FileIndex FileIndex;

        public readonly CmdFlows Flows;

        public ProjectContext(IProjectWorkspace project, CmdFlows flows)
        {
            Project = project;
            FileIndex = project.FileIndex;
            Files = flows.Files;
            Flows = flows;
        }

        public IEnumerable<FileIndexEntry> Members()
            => FileIndex.Members();

        public IEnumerable<FileIndexEntry> Members(FileKind kind)
            => FileIndex.Members(kind);

        public Index<FileRef> Docs(FileKind kind)
            => Files.Docs(kind);

        public FileRef Doc(FilePath path)
            => Files[path];

        // public FileRef Doc(Hex32 id)
        //     => Files[id];

        public FileRef Root(FilePath dst)
        {
            if(Flows.Root(dst, out var src))
                return src;
            else
                return Z0.FileRef.Empty;
        }

        // public FileRef Root(FileRef dst)
        // {
        //     if(Flows.Root(dst.Path, out var src))
        //         return src;
        //     else
        //         return Z0.FileRef.Empty;
        // }

    }
}