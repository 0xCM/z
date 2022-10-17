//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct GridCol
        {
            public readonly CellKey Key;

            public readonly ColType Type;

            public readonly DataSize Size;

            public LogicClass Logic
            {
                [MethodImpl(Inline)]
                get => Key.Logic;
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Key.Field;
            }

            public ushort Row
            {
                [MethodImpl(Inline)]
                get => Key.Row;
            }

            public byte Index
            {
                [MethodImpl(Inline)]
                get => Key.Col;
            }

            public string Format()
                => string.Format("{2,-24} | {0,-2} | {1,-3} | {3}", XedRender.format(Field), Index, Logic, Size.Format(2,2));

            public override string ToString()
                => Format();
        }
    }
}