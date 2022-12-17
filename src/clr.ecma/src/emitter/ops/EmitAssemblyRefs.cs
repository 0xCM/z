//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaEmitter
    {
        public void EmitRefs(IApiPack dst)
        {
            EmitAssemblyRefs(dst);
        }

        public void EmitAssemblyRefs(IApiPack dst)
            => EmitAssemblyRefs(ApiAssemblies.Parts, dst);

        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, IApiPack dst)
            => EmitAssemblyRefs(src, dst.Metadata().Table<AssemblyRefInfo>());

        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, IDbArchive dst)
            => EmitAssemblyRefs(src, dst.Table<AssemblyRefInfo>());
        
        public void EmitAssemblyRefs(IEnumerable<MappedAssembly> src, FilePath dst)
        {
            var flow = EmittingTable<AssemblyRefInfo>(dst);
            var counter = 0;
            using var writer = dst.Writer();
            var formatter = Tables.formatter<AssemblyRefInfo>();

            foreach(var a in src)
            {
                var reader = a.MetadataReader();
                var refs = reader.ReadAssemblyRefs();
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
            var flow = EmittingTable<AssemblyRefInfo>(dst);
            var formatter = Tables.formatter<AssemblyRefInfo>();
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