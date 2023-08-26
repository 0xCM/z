//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public readonly struct Table<K>
    where K : unmanaged, Enum
{
    public readonly string Name;

    public readonly K Kind;

    readonly TableRow[] _Rows;

    readonly TableColumn[] _Cols;

    public Table(string name, K kind, TableColumn[] cols, TableRow[] rows)
    {
        Kind = kind;
    }

    public Span<TableRow> Rows
    {
        [MethodImpl(Inline)]
        get => _Rows;
    }

    public Span<TableColumn> Cols
    {
        [MethodImpl(Inline)]
        get => _Cols;
    }

    public uint Count
    {
        get => (uint)_Rows.Length;
    }

    public ref TableRow this[uint row]
    {
        [MethodImpl(Inline)]
        get => ref seek(_Rows, row);
    }

    public ref TableRow this[int row]
    {
        [MethodImpl(Inline)]
        get => ref seek(_Rows, row);
    }    
}

public readonly struct Table
{
    [MethodImpl(Inline), Op]
    public static Table define(string name, uint kind, TableColumn[] cols, TableRow[] rows)
        => new Table(name,kind, cols, rows);

    [MethodImpl(Inline), Op]
    public static TableColumn column(string name, string type, ushort length)
        => new (name, type, length);

    public static TableColumn column<K>(string name)
        where K : unmanaged, Enum
    {
        var kinds = Symbols.index<K>();
        var result = kinds.Lookup(name.Trim(), out var sym);
        var type = result ? sym.Expr.Format() : string.Format("!{0}!", name);
        var length = name.Length;
        return column(name.Trim(), type, (ushort)length);
    }

    public static Seq<TableColumn> columns<K>(ReadOnlySpan<string> src)
        where K : unmanaged, Enum
    {
        var count = src.Length;
        var buffer = alloc<TableColumn>(count);
        ref var dst = ref first(buffer);
        for(var i=0; i<count; i++)
        {
            ref readonly var x = ref skip(src,i);
            seek(dst,i) = column<K>(skip(src,i));
        }
        return buffer;
    }

    public string Name {get;}

    public uint Kind {get;}

    readonly TableRow[] _Rows;

    readonly TableColumn[] _Cols;

    [MethodImpl(Inline)]
    public Table(string name, uint kind, TableColumn[] cols, TableRow[] rows)
    {
        Name = name;
        Kind = kind;
        _Rows = rows;
        _Cols = cols;
    }

    public Span<TableRow> Rows
    {
        [MethodImpl(Inline)]
        get => _Rows;
    }

    public Span<TableColumn> Cols
    {
        [MethodImpl(Inline)]
        get => _Cols;
    }

    public ref TableRow this[uint row]
    {
        [MethodImpl(Inline)]
        get => ref seek(_Rows, row);
    }

    public ref TableRow this[int row]
    {
        [MethodImpl(Inline)]
        get => ref seek(_Rows, row);
    }    

}
