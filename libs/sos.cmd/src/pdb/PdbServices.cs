//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using System.IO;

    [ApiHost]
    public class PdbSvc : WfSvc<PdbSvc>
    {
        PdbIndexBuilder PdbIndexBuilder => Wf.PdbIndexBuilder();

        public FilePath IndexAssemblies()
            => IndexAssemblies(DbArchives.parts());

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
            using var symbols = SymbolSource(src.Location);
            var reader = PdbSymbols.reader(symbols);
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
            using var symbols = SymbolSource(FS.path(src.Location));
            var pePath = symbols.PePath;
            var pdbPath = symbols.PdbPath;
            using var pdbReader = PdbSymbols.reader(symbols);
            var counter = 0u;
            var dst = AppDb.ApiTargets("pdb").Path(string.Format("{0}.pdbinfo", src.GetSimpleName()), FileKind.Csv);
            using var writer = dst.Writer();
            var emitting = Wf.EmittingFile(dst);
            Write("Collecting methods");
            var pdbMethods = pdbReader.Methods;
            var methodCount = pdbMethods.Length;
            for(var i=0; i<methodCount; i++)
            {
                ref readonly var pdbMethod = ref skip(pdbMethods,i);
                var info = pdbMethod.Describe();
                var docview = info.Documents.View;
                var doc = docview.Length >=1 ? first(docview).Path : FilePath.Empty;
                var token = info.Token;
                var mb = Clr.method(module,token);
                var sig = mb is MethodInfo method ? method.DisplaySig().Format() : EmptyString;
                writer.WriteLine(string.Format("{0,-12} | {1,-24} | {2,-68} | {3}", token, mb.Name, doc.ToUri(), sig));
                counter++;
            }

            EmittedFile(emitting, counter);
            return dst;
        }


        public PdbSymbolSource SymbolSource(FilePath module)
            => PdbSymbols.source(module);

        public static unsafe Outcome srclink(ISymUnmanagedReader5 src, out Span<byte> dst)
        {
            dst = default;
            try
            {
                HResult hr = src.GetSourceServerData(out var pData, out var size);
                if(hr)
                {
                    read(pData, size, out dst);
                    return true;
                }
                else
                {
                    size = 0;
                    return (false, hr.Format());
                }
            }
            catch(Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Retrieves symbol server information
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dst"></param>
        /// <remarks>
        /// Adapted from https://github.com/dotnet/symreader-converter/src/Microsoft.DiaSymReader.Converter/Utilities/SymReaderHelpers.cs
        /// </remarks>
        public unsafe static Outcome symserver(ISymUnmanagedReader reader, out Span<byte> dst)
        {
            dst = default;
            if (!(reader is ISymUnmanagedSourceServerModule srcsrv))
                return (false, string.Format("{0} does not support the required iterface", reader.GetType()));

            var pData = default(byte*);
            try
            {
                HResult result = srcsrv.GetSourceServerData(out var size, out pData);
                if(result)
                {
                    read(pData, size, out dst);
                    return true;
                }
                else
                    return (false,result.Format());
            }
            catch(Exception e)
            {
                return e;
            }
            finally
            {
                if (pData != null)
                    Marshal.FreeCoTaskMem((IntPtr)pData);
            }
        }
    }
}