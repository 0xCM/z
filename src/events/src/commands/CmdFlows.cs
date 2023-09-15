//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CmdFlows
    {        
        public static CmdFlows flows(IProject src)
        {
            var path = flowpath(src);
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

        static Outcome parse(string src, out Tool dst)
        {
            dst = text.trim(src);
            return true;
        }

        public static FilePath flowpath(IProject src)
            => src.Targets().Path(FS.file($"{src.Name}.build.flows",FileKind.Csv));

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath, src.TargetPath));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);        

        public static ReadOnlySpan<CmdFlow> flows(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<CmdFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    Tool tool = text.left(content, j);
                    var flow = Fenced.unfence(text.right(content,j), Fenced.Bracketed);

                    j = text.index(flow, "--");
                    if(j == NotFound)
                        j = text.index(flow, "->");

                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.right(flow,j+2).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new CmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

        ConstLookup<FilePath,List<FilePath>> Children;

        ConstLookup<FilePath,FilePath> Ancestors;

        public readonly FileCatalog Files;

        public CmdFlows(FileCatalog files, ReadOnlySpan<CmdFlow> src)
        {
            Files = files;
            var count = src.Length;
            var flows = sys.alloc<FileFlow>(count);
            var lookup = dict<FilePath,List<FilePath>>();
            var lineage = dict<FilePath,FilePath>();

            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(flows,i);
                dst = flow(skip(src,i));
                if(lookup.TryGetValue(dst.Source, out var targets))
                {
                    targets.Add(dst.Target);
                    lineage[dst.Target] = dst.Source;

                }
                else
                {
                    lookup[dst.Source] = new();
                    lookup[dst.Source].Add(dst.Target);
                    lineage[dst.Target] = dst.Source;
                }
            }

            Children = lookup;
            Ancestors = lineage;
        }

        public Index<FileRef> Docs(FileKind k0)
            => Files.Docs(k0);

        public Index<FileRef> Docs(FileKind k0, FileKind k1)
            => Files.Docs(k0, k1);

        public Index<FileRef> Docs(FileKind k0, FileKind k1, FileKind k2)
            => Files.Docs(k0, k1, k2);

        public Index<FileRef> Sources(FileKind kind)
            => Files.Docs(kind).Where(e => Children.ContainsKey(e.Path));

        public Index<FileRef> Sources()
            => map(Children.Keys, x => Files.Doc(x));

        public bool Root(FilePath dst, out FileRef source)
        {
            var buffer = sys.list<FileRef>();
            var target = Files[dst];
            Lineage(target, buffer);
            buffer.Reverse();
            if(buffer.Count != 0)
            {
                source = buffer[0];
                return true;
            }
            else
            {
                source = FileRef.Empty;
                return false;
            }
        }

        public Index<FileRef> Lineage(FilePath dst)
        {
            var buffer = sys.list<FileRef>();
            var target = Files[dst];
            buffer.Add(target);
            Lineage(target, buffer);
            buffer.Reverse();
            return buffer.ToArray();
        }

        public void Lineage(in FileRef target, List<FileRef> priors)
        {
            if(Source(target.Path, out var prior))
            {
                priors.Add(prior);
                Lineage(prior, priors);
            }
        }

        public bool Source(FilePath target, out FileRef prior)
        {
            if(Ancestors.Find(target, out var uri))
            {
                prior = Files.Doc(uri);
                return true;
            }
            else
            {
                prior = FileRef.Empty;
                return false;
            }
        }

        public Index<FileRef> Targets(FilePath src)
        {
            if(Children.Find(src, out var targets))
                return sys.map(targets, x => Files.Doc(x));
            else
                return sys.empty<FileRef>();
        }

        public void DescribeFlows(FileKind srckind, ITextBuffer dst)
        {
            var sources = Sources(srckind);
            foreach(var source in sources)
            {
                var path = source.Path;
                dst.AppendLine(path.ToUri());
                var targets = Targets(path);
                foreach(var target in targets)
                    DescribeTargets(0u, target, dst);
            }
        }

        void DescribeTargets(uint indent, in FileRef file, ITextBuffer dst)
        {
            var path = file.Path;
            dst.IndentLineFormat(indent, " -> {0}", path.ToUri());
            var targets = Targets(path);
            indent += 4;
            foreach(var target in targets)
            {
                DescribeTargets(indent, target, dst);
            }
        }

        public static CmdFlows Empty => new CmdFlows(FileCatalog.Empty, sys.empty<CmdFlow>());
    }
}