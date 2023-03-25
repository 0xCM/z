//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {        
        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, IDbArchive dst)
            => EmitAssemblyRefs(src, dst.Table<EcmaTables.AssemblyRefRow>());
        
        public void EmitAssemblyRefs(IEnumerable<MappedAssembly> src, FilePath dst)
        {
            var flow = Channel.EmittingTable<EcmaTables.AssemblyRefRow>(dst);
            var counter = 0;
            using var writer = dst.Writer();
            var formatter = CsvTables.formatter<EcmaTables.AssemblyRefRow>();
            foreach(var a in src)
            {
                var reader = a.EcmaReader();
                var refs = reader.ReadAssemblyRefRows();
                foreach(var @ref in refs)
                {
                    writer.WriteLine(formatter.Format(@ref));
                    counter++;
                }
            }
            Channel.EmittedTable(flow, counter);
        }

        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, FilePath dst)
        {
            var count = src.Length;
            var counter = 0u;
            var flow = Channel.EmittingTable<EcmaTables.AssemblyRefRow>(dst);
            var formatter = CsvTables.formatter<EcmaTables.AssemblyRefRow>();
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                EmitAssemblyRefs(skip(src,i), formatter, writer);
            Channel.EmittedTable(flow, counter);
        }

        void EmitAssemblyRefs(Assembly src, ICsvFormatter formatter, StreamWriter dst)
        {
            try
            {
                var refs = Ecma.refs(src);
                var count = refs.Length;
                if(count == 0)
                {
                    Channel.Babble($"{src.FullName} has no references");
                }
                else
                {
                    for(var i=0; i<count; i++)
                        dst.WriteLine(formatter.Format(refs[i]));
                }
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }
    }
}