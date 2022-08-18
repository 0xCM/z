//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Table
    {
        [MethodImpl(Inline), Op]
        public static Table define(string src, uint kind, TableColumn[] cols, TableRow[] rows)
            => new Table(src,kind, cols, rows);

        public string Source {get;}

        public uint Kind {get;}

        readonly TableRow[] Data;

        readonly TableColumn[] _Cols;

        [MethodImpl(Inline)]
        public Table(string src, uint kind, TableColumn[] cols, TableRow[] rows)
        {
            Source = src;
            Kind = kind;
            Data = rows;
            _Cols = cols;
        }

        public Span<TableRow> Rows
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<TableColumn> Cols
        {
            [MethodImpl(Inline)]
            get => _Cols;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }
    }
}