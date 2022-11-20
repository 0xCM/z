//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Reflection.TypeAttributes;
    using static sys;
    using static TableDef;

    [ApiHost]
    public ref struct ColumnSet
    {
        readonly Span<Column> Columns;

        ushort Index;

        const TypeAttributes Default = BeforeFieldInit | Public | Sealed | AnsiClass;

        public const TypeAttributes ExplicitAnsi
            = Default | ExplicitLayout;

        public const TypeAttributes SequentialAnsi
            = Default | SequentialLayout;

        [MethodImpl(Inline),Op]
        public ColumnSet(uint capacity)
        {
            Index = 0;
            Columns = span<Column>(capacity);
        }

        [MethodImpl(Inline),Op]
        public ColumnSet WithColumn(in Column src)
        {
            seek(Columns, Index++) = src;
            return this;
        }

        [MethodImpl(NotInline), Op]
        public TableDef Complete(TableId name)
        {
            var cells = Columns.Slice(0,(int)Index).ToArray();
            Columns.Clear();
            return new TableDef(name, cells);
        }
    }
}