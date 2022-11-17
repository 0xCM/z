//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct PdbSeqPoint
    {
        public readonly uint Offset;

        public readonly CellIndex UpperLeft;

        public readonly CellIndex LowerRight;

        [MethodImpl(Inline)]
        public PdbSeqPoint(uint offset, CellIndex x, CellIndex y)
        {
            Offset = offset;
            UpperLeft = x;
            LowerRight = y;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => UpperLeft.IsZero && LowerRight.IsZero;
        }

        public uint StartLine
        {
            [MethodImpl(Inline)]
            get => UpperLeft.Row;
        }

        public uint StartColumn
        {
            [MethodImpl(Inline)]
            get => UpperLeft.Col;
        }

        public uint EndLine
        {
            [MethodImpl(Inline)]
            get => LowerRight.Row;
        }

        public uint EndColumn
        {
            [MethodImpl(Inline)]
            get => LowerRight.Col;
        }

        public bool IsHidden
        {
            [MethodImpl(Inline)]
            get => StartLine == 0xfeefee;
        }

        public string Format()
            => string.Format("[{0:D3}, ({1:D3},{2:D3}), ({3:D3},{4:D3})]", Offset, StartLine, StartColumn, EndLine, EndColumn);

        public override string ToString()
            => Format();
    }
}