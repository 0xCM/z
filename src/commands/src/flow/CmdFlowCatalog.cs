//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CmdFlowCatalog
    {
        [MethodImpl(Inline)]
        static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);

        [MethodImpl(Inline)]
        static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        ConstLookup<_FileUri,List<_FileUri>> Children;

        ConstLookup<_FileUri,_FileUri> Ancestors;

        public readonly FileCatalog Files;

        public CmdFlowCatalog(FileCatalog files, ReadOnlySpan<CmdFlow> src)
        {
            Files = files;
            var count = src.Length;
            var flows = sys.alloc<FileFlow>(count);
            var lookup = dict<_FileUri,List<_FileUri>>();
            var lineage = dict<_FileUri,_FileUri>();

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
            => map(Children.Keys, x => Files.Doc(x.Path));

        public bool Root(FilePath dst, out FileRef source)
        {
            var buffer = core.list<FileRef>();
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
            var buffer = core.list<FileRef>();
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

        public bool Source(_FileUri target, out FileRef prior)
        {
            if(Ancestors.Find(target, out var uri))
            {
                prior = Files.Doc(uri.Path);
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
                return core.map(targets, x => Files.Doc(x.Path));
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
    }
}