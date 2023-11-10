//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct LayoutComponent
    {
        public readonly FieldKind Field;

        public readonly LayoutCellKind CellKind;

        public readonly ulong CellData;

        [MethodImpl(Inline)]
        public LayoutComponent(FieldKind field, LayoutCellKind kind, ulong data)
        {
            Field = field;
            CellKind = kind;
            CellData = data;
        }

        public string Format()
            => string.Format("{0,-22} | {1,-12} | 0x{2:X}", Field, CellKind, CellData);

        public override string ToString()
            => Format();
    }
}
