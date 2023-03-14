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
            => EmitAssemblyRefs(src, dst.Table<EcmaTables.AssemblyRef>());
        
        public void EmitAssemblyRefs(IEnumerable<MappedAssembly> src, FilePath dst)
        {
            var flow = EmittingTable<EcmaTables.AssemblyRef>(dst);
            var counter = 0;
            using var writer = dst.Writer();
            var formatter = CsvTables.formatter<EcmaTables.AssemblyRef>();
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
            EmittedTable(flow, counter);
        }

        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, FilePath dst)
        {
            var count = src.Length;
            var counter = 0u;
            var flow = EmittingTable<EcmaTables.AssemblyRef>(dst);
            var formatter = CsvTables.formatter<EcmaTables.AssemblyRef>();
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                EmitAssemblyRefs(skip(src,i), formatter, writer);
            EmittedTable(flow, counter);
        }

        void EmitAssemblyRefs(Assembly src, ICsvFormatter formatter, StreamWriter dst)
        {
            try
            {
                var refs = Ecma.refs(src);
                var count = refs.Length;
                if(count == 0)
                {
                    Babble($"{src.FullName} has no references");
                }
                else
                {
                    for(var i=0; i<count; i++)
                        dst.WriteLine(formatter.Format(refs[i]));
                }
            }
            catch(Exception e)
            {
                Error(e);
            }
        }
    }
}