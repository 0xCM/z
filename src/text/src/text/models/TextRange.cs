//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct TextRange
    {
        public readonly uint MinLine;

        public readonly uint MinCol;

        public readonly uint MaxLine;

        public readonly uint MaxCol;

        [MethodImpl(Inline)]
        public TextRange(uint a0, uint a1, uint a2, uint a3)
        {
            MinLine = a0;
            MinCol = a1;
            MaxLine = a2;
            MaxCol = a3;
        }

        [MethodImpl(Inline)]
        public TextRange(Pair<uint> min, Pair<uint> max)
        {
            MinLine = min.Left;
            MinCol = min.Right;
            MaxLine = max.Left;
            MaxCol = max.Right;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out Pair<uint> min, out Pair<uint> max)
        {
            min = (MinLine,MinCol);
            max = (MaxLine,MaxCol);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(sys.hash(MinLine | (MinCol << 16)),  sys.hash(MaxLine | (MaxCol << 16)));
        }

        public override int GetHashCode()
            => (int)Hash;
    }
}