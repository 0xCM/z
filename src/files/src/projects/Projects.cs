//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Projects
    {
        // public static IProjectWorkspace load(IDbArchive root)
        //     => new ProjectWorkspace(root, root.Root.FolderName.Format());

        public static FilePath flowpath(IProject src)
            => src.Build().Path(FS.file($"{src.Name}.build.flows",FileKind.Csv));

        public static ProjectContext context(IProject src)
            => new ProjectContext(src, flows(src));

        static Outcome parse(string src, out Tool dst)
        {
            dst = text.trim(src);
            return true;
        }

        static CmdFlows flows(IProject src)
        {
            var path = Projects.flowpath(src);
            if(path.Exists)
            {
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
                return new(FileCatalog.load(src.Files().Array().ToSortedSpan()), buffer);
            }
            else
                return CmdFlows.Empty;
        }

        static IProject Project;

        public static ref readonly IProject project()
        {
            if(Project == null)
                sys.@throw("Project is null");
            return ref Project;
        }

        [MethodImpl(Inline)]
        public static ref readonly IProject project(IProject src)
        {
            Project = src;
            return ref Project;
        }
    }
}