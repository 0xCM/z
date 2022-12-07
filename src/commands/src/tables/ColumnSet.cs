//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Reflection.TypeAttributes;
    using static sys;

    [ApiHost]
    public ref struct ColumnSet
    {
        readonly Span<ColumDef> Columns;

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
            Columns = span<ColumDef>(capacity);
        }

        [MethodImpl(Inline),Op]
        public ColumnSet WithColumn(in ColumDef src)
        {
            seek(Columns, Index++) = src;
            return this;
        }
    }
}