//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class TableBuilder
{
    List<TableRow> Data;

    TableColumn[] Cols;

    uint Kind;

    uint Index;

    readonly FilePath Source;

    string TableName;

    public static TableBuilder create(FilePath src)
        => new (src);

    public TableBuilder(FilePath src)
    {
        Source = src;
        TableName = EmptyString;
        Data = new();
        Cols = array<TableColumn>();
    }

    public TableBuilder WithKind(uint kind)
    {
        Kind = kind;
        return this;
    }

    public TableBuilder WithRow(in TableRow row)
    {
        Data.Add(row);
        return this;
    }

    public TableBuilder WithColumns(TableColumn[] cols)
    {
        Cols = cols;
        return this;
    }

    public TableBuilder WithRow(TableCell[] cells)
    {
        Data.Add(new TableRow(0, cells));
        return this;
    }

    public TableBuilder WithRow(string[] cells)
    {
        var row  = new TableRow(Index++, alloc<TableCell>(Cols.Length));
        var i=0;
        for(;i<row.ColCount && i<cells.Length ; i++)
            row[i] = new TableCell(text.trim(skip(cells,i)));
        for(;i<row.ColCount; i++)
            row[i] = new TableCell(EmptyString);

        Data.Add(row);
        return this;
    }

    public TableBuilder WithRows(ReadOnlySpan<TableRow> src)
    {
        var count = src.Length;
        for(var i=0; i<count; i++)
            Data.Add(skip(src,i));
        return this;
    }

    public TableBuilder WithTableName(string name)
    {
        TableName = name;
        return this;
    }
    public TableBuilder IfNonEmpty(Action f)
    {
        if(IsNonEmpty)
            f();
        return this;
    }

    public Table Emit()
    {
        var rows = Data.ToArray();
        var count = rows.Length;
        ref var row = ref first(rows);
        for(var i=0u; i<count; i++)
            seek(row,i).Seq = i;
        var dst = Table.define(TableName, Kind, Cols.Replicate(), rows);
        Clear();
        return dst;
    }

    public TableBuilder Clear()
    {
        Data.Clear();
        Cols.Clear();
        Kind = 0;
        return this;
    }

    public bool IsNonEmpty
    {
        get => Data.Count != 0;
    }
}
