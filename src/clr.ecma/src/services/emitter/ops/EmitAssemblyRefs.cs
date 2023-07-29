//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

    partial class EcmaEmitter
    {        
        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, IDbArchive dst)
            => EmitAssemblyRefs(src, dst.Table<AssemblyRefRow>());
        
        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, FilePath dst)
        {
            var count = src.Length;
            var counter = 0u;
            var flow = Channel.EmittingTable<AssemblyRefRow>(dst);
            var formatter = CsvTables.formatter<AssemblyRefRow>();
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
                var refs = Ecma.refs(src).Array();
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