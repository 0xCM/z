//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Projects
    {
        public static FilePath build(IProjectWorkspace src)
            => src.BuildOut() + FS.file($"{src.ProjectId}.build.flows",FileKind.Csv);

        public static IProjectWorkspace load(IDbArchive root, ProjectId id)
            => new ProjectWorkspace(root, id);

        static Outcome parse(string src, out Tool dst)
        {
            dst = text.trim(src);
            return true;
        }

        static CmdFlows flows(IProjectWorkspace src)
        {
            var path = build(src);
            var lines = path.ReadLines(TextEncodingKind.Asci,true);
            var buffer = sys.alloc<CmdFlow>(lines.Length - 1);
            var reader = lines.Storage.Reader();
            reader.Next(out _);
            var i = 0u;
            while(reader.Next(out var line))
            {
                var parts = text.trim(text.split(line, Chars.Pipe));
                Require.equal(parts.Length, CmdFlow.FieldCount);
                var cells = parts.Reader();
                ref var dst = ref seek(buffer,i++);
                parse(cells.Next(), out dst.Tool).Require();
                DataParser.parse(cells.Next(), out dst.SourceName).Require();
                DataParser.parse(cells.Next(), out dst.TargetName).Require();
                DataParser.parse(cells.Next(), out dst.SourcePath).Require();
                DataParser.parse(cells.Next(), out dst.TargetPath).Require();
            }
            return new(FileCatalog.load(src.ProjectFiles().Storage.ToSortedSpan()), buffer);
        }

        [MethodImpl(Inline), Op]
        public static ProjectContext context(IProjectWorkspace src)
            => new ProjectContext(src, flows(src));

        static IProjectWorkspace Project;

        public static ref readonly IProjectWorkspace project()
        {
            if(Project == null)
                sys.@throw("Project is null");
            return ref Project;
        }

        [MethodImpl(Inline)]
        public static ref readonly IProjectWorkspace project(IProjectWorkspace src)
        {
            Project = src;
            return ref Project;
        }
    }
}