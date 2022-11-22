//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.IO;

    [ApiHost]
    public class PdbSvc : AppService<PdbSvc>
    {
        PdbIndexBuilder PdbIndexBuilder => Wf.PdbIndexBuilder();

        public FilePath IndexAssemblies()
            => IndexAssemblies(ApiMd.parts());

        public FilePath IndexAssemblies(Assembly[] src)
            => PdbIndexBuilder.IndexComponents(src, new PdbIndex());

        public void IndexSymbols(ReadOnlySpan<ResolvedPart> src, FilePath dst)
        {
            var count = src.Length;
            var emitting = EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                counter += IndexMethods(skip(src,i),writer);
            EmittedFile(emitting, counter);
        }

        public uint IndexMethods(in ResolvedPart src, StreamWriter dst)
        {
            var hosts = src.Hosts.View;
            using var symbols = PdbDocs.source(src.Location);
            var reader = PdbDocs.reader(symbols);
            var flow = Running(string.Format("Indexing symbols for {0} from {1}", symbols.PePath, symbols.PdbPath));
            var counter = 0u;
            var buffer = list<PdbMethod>();
            for(var i=0; i<hosts.Length; i++)
            {
                ref readonly var host = ref skip(hosts,i);
                var methods = host.Methods.View;
                for(var j=0; j<methods.Length; j++)
                {
                    ref readonly var method = ref skip(methods,j);
                    var pdbMethod = reader.Method(method.Method.MetadataToken);
                    if(pdbMethod)
                    {
                        var data = pdbMethod.Payload;
                        dst.WriteLine(data.Token.Format());
                        buffer.Add(data);
                        counter++;
                    }
                }
            }
            Ran(flow);
            return counter;
        }

        public FilePath EmitPdbInfo(Assembly src)
        {
            var _name = src.GetSimpleName();
            var module = src.ManifestModule;
            using var symbols = PdbDocs.source(FS.path(src.Location));
            var pePath = symbols.PePath;
            var pdbPath = symbols.PdbPath;
            using var pdbReader = PdbDocs.reader(symbols);
            var counter = 0u;
            var dst = AppDb.Service.ApiTargets("pdb").Path(string.Format("{0}.pdbinfo", src.GetSimpleName()), FileKind.Csv);
            using var writer = dst.Writer();
            var emitting = Wf.EmittingFile(dst);
            Write("Collecting methods");
            var pdbMethods = pdbReader.Methods;
            var methodCount = pdbMethods.Length;
            for(var i=0; i<methodCount; i++)
            {
                ref readonly var pdbMethod = ref skip(pdbMethods,i);
                var info = pdbMethod.Describe();
                var docview = info.Documents.Documents;
                var doc = docview.Count >=1 ? docview.FirstOrDefault(PdbDocument.Empty).Path : FileUri.Empty;
                var token = info.Token;
                var mb = Clr.method(module,token);
                var sig = mb is MethodInfo method ? method.DisplaySig().Format() : EmptyString;
                writer.WriteLine(string.Format("{0,-12} | {1,-24} | {2,-68} | {3}", token, mb.Name, doc, sig));
                counter++;
            }

            EmittedFile(emitting, counter);
            return dst;
        }
    }
}