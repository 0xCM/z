//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Microsoft.Diagnostics.Runtime;

    using DR = ClrMdRecords;

    public sealed class DumpParser : Channeled<DumpParser>
    {
        AppDb AppDb => AppDb.Service;
        
        void Emit(ProcDumpName name, ReadOnlySpan<DR.ModuleInfo> src)
            => Channel.TableEmit(src,  AppDb.Archive($"dumps/{name}").Table<DR.ModuleInfo>(name.Format()));

        void Emit(ProcDumpName name, ReadOnlySpan<DR.MethodTableToken> src)
            => Channel.TableEmit(src, AppDb.Archive($"dumps/{name}").Table<DR.MethodTableToken>(name.Format()));

        void Emit(ProcDumpName name, ModuleProcessPresult src)
        {
            Emit(name, src.Modules);
            Emit(name, src.MethodTables);
        }

        public void ParseDump(FilePath src)
        {
            var name = ProcDumpName.from(src);
            using var dataTarget = DataTarget.LoadDump(src.Name);
            using var runtime = dataTarget.ClrVersions.Single().CreateRuntime();
            var running = Channel.Running(string.Format("Parsing {0}", src.ToUri()));
            var modules = runtime.EnumerateModules().Array();
            var processor = ModuleProcessor.create(new EmissionSink());
            processor.Process(modules);
            Emit(name, processor.Processed());
            Channel.Ran(running, string.Format("Parsed {0}", src.ToUri()));
        }
    }
}