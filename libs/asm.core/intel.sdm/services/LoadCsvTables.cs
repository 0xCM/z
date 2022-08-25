//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static SdmCsvLiterals;
    using static SdmModels;

    using K = SdmModels.SdmTableKind;

    partial class IntelSdm
    {
        [Op]
        public static K tablekind(string name)
            => name switch {
                "OpCodes" => K.OpCodes,
                "Encoding" => K.EncodingRule,
                "BinaryFormat" => K.BinaryFormat,
                "Intrinsics" => K.Intrinsics,
                "Notes" => K.Intrinsics,
                _ => SdmOps.parse(name, out TableNumber dst)
                    ? K.Numbered : K.None
            };

        public ReadOnlySpan<Table> LoadCsvTables()
            => LoadCsvTables(SdmPaths.CsvSources().Files(FS.Csv).ToReadOnlySpan());

        public ReadOnlySpan<Table> LoadCsvTables(ReadOnlySpan<FilePath> src)
        {
            var filecount = src.Length;
            var dst = list<Table>();
            for(var i=0; i<filecount; i++)
                dst.AddRange(LoadCsvTables(skip(src,i)).ToArray());

            return dst.ViewDeposited();
        }

        public ReadOnlySpan<Table> LoadCsvTables(FilePath src)
        {
            var result = Outcome.Success;
            var foundtable = false;
            var parsingrows = false;
            var rowcount = 0;
            var cols = Index<TableColumn>.Empty;
            var rows = list<TableRow>();
            var rowidx = z16;
            var table = TableBuilder.create();
            var tables = list<Table>();
            using var reader = src.LineReader(TextEncodingKind.Utf8);
            while(reader.Next(out var line))
            {
                if((line.IsEmpty || line.StartsWith(TableSeparator)) && !parsingrows)
                    continue;

                if(parsingrows && line.IsEmpty)
                {
                    table.IfNonEmpty(() => tables.Add(table.Emit()));
                    foundtable = false;
                    parsingrows = false;
                    rowcount = 0;
                    continue;
                }

                var content = line.Content;

                if(content.StartsWith(PageTitleMarker))
                {
                    table.WithSource(content.Remove(TableMarker).Trim());
                    continue;
                }

                if(parsingrows)
                {
                    var values = content.SplitClean(ColSep);
                    var valcount = values.Length;

                    if(valcount != cols.Count)
                        Warn($"{valcount} != {cols.Count}");

                    if(valcount != 0)
                    {
                        table.WithRow(values);
                        rowcount++;
                    }
                    continue;
                }

                if(foundtable && !parsingrows)
                {
                    var labels = content.SplitClean(ColSep);
                    if(labels.Length == 0)
                        Warn(string.Format("Expected header"));

                    if(labels.Length != 0)
                    {
                        cols = columns(labels);
                        table.WithColumns(cols);
                        parsingrows = true;
                    }
                }

                if(content.StartsWith(TableMarker))
                {
                    table.Clear();
                    table.WithKind((uint)tablekind(content.Remove(TableMarker).Trim()));
                    foundtable = true;
                }
            }

            table.IfNonEmpty(() => tables.Add(table.Emit()));

            return tables.ViewDeposited();
        }

        static Index<TableColumn> columns(ReadOnlySpan<string> src)
            => Tables.columns<SdmColumnKind>(src);
    }
}