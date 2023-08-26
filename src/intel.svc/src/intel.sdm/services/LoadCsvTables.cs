//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using System.Linq;

using static sys;
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

    public ParallelQuery<Table> LoadCsvTables()
    {
        var src = AsmDocs.SdmInstructionFiles();
        var tables = from file in src
                    from table in LoadCsvTables(file)
                    select table;
        return tables;
    }

    public IEnumerable<Table> LoadCsvTables(FilePath src)
    {
        var result = Outcome.Success;
        var foundtable = false;
        var parsingrows = false;
        var rowcount = 0;
        var cols = Seq<TableColumn>.Empty;
        var rows = list<TableRow>();
        var rowidx = z16;
        var table = TableBuilder.create(src);
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
                table.WithTableName(content.Remove(TableMarker).Trim());
                continue;
            }

            if(parsingrows)
            {
                var values = content.SplitClean(ColSep);
                var valcount = values.Length;

                if(valcount != cols.Count)
                    Channel.Warn($"{valcount} != {cols.Count}");

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
                    Channel.Warn(string.Format("Expected header"));

                if(labels.Length != 0)
                {
                    cols = Table.columns<SdmColumnKind>(labels);
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

        if(table.IsNonEmpty)
            yield return table.Emit();

        //table.IfNonEmpty(() => tables.Add(table.Emit()));            
    }

}
