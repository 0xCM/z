//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class PdbIndexBuilder : AppService<PdbIndexBuilder>
    {
        public PdbReaderStats IndexComponent(Assembly src, PdbIndex dst)
        {
            var name = src.GetSimpleName();
            var flow = Running(Msg.ReadingPdb.Format(name));
            var asmpath = FS.path(src.Location);
            var pdbpath = asmpath.ChangeExtension(FS.Pdb);
            var stats = new PdbReaderStats();
            if(pdbpath.Exists)
            {
                stats.Pdb = pdbpath;
                stats.Assembly = asmpath;
                var reader = PdbSymbols.reader(asmpath, pdbpath);
                var methods = src.Methods().Index();
                var count = methods.Length;
                stats.DocCount += dst.Include(reader.Documents);
                for(var i=0; i<count; i++)
                {
                    var result = reader.Method(methods[i].MetadataToken);
                    if(result)
                    {
                        var pdbMethod = result.Payload;
                        var points = pdbMethod.SequencePoints;
                        var methodDocs = pdbMethod.Documents;
                        stats.MethodCount++;
                        stats.SeqPointCount += (uint)points.Length;
                    }
                }
            }
            else
            {
                Warn(Msg.PdbNotFound.Format(name));
            }

            Ran(flow, string.Format("Read {0} pdb methods with {1} documents and {2} sequence points from {3}", stats.MethodCount, stats.DocCount, stats.SeqPointCount, name));
            return stats;
        }

        public FilePath IndexComponents(ReadOnlySpan<Assembly> src, PdbIndex dst)
        {
            var count = src.Length;
            var flow = Running(Msg.IndexingPdbFiles.Format(count));
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                var stats = IndexComponent(skip(src,i), dst);
                counter += stats.MethodCount;
            }

            var path = AppDb.Service.ApiTargets().Path(FS.file("pdbdocs", FS.Md));
            var emitting = EmittingFile(path);
            var docs = dst.Documents;
            using var writer = path.Writer();
            foreach(var doc in docs)
                writer.WriteLine(string.Format("<{0}>", doc.Path.ToUri()));
            EmittedFile(emitting, docs.Count);
            Ran(flow, Msg.IndexedPdbMethods.Format(counter));
            return path;
        }
    }
}