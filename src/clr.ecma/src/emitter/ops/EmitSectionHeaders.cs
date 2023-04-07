//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaEmitter
    {
        public void EmitSectionHeaders(IDbArchive src, IDbArchive dst)
            => EmitSectionHeaders(src.Files(FileKind.Dll, FileKind.Exe, FileKind.Obj, FileKind.Lib, FileKind.Obj), dst.Table<SectionHeaderRow>());

        public void EmitSectionHeaders(IEnumerable<FilePath> src, FilePath dst)
        {
            try
            {
                var total = Count.Zero;
                var formatter = CsvTables.formatter<SectionHeaderRow>();
                var flow = Channel.EmittingTable<SectionHeaderRow>(dst);
                using var writer = dst.AsciWriter();
                writer.WriteLine(formatter.FormatHeader());
                foreach(var file in src)
                {
                    using var reader = PeReader.create(file);
                    var headers = reader.Tables.SectionHeaders;
                    var count = headers.Length;
                    for(var i=0u; i<count; i++)
                        writer.WriteLine(formatter.Format(headers[i]));

                    total += count;
                }
                Channel.EmittedTable(flow, total);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }
    }
}