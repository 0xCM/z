//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct HeapEntry : IComparable<HeapEntry>
    {
        [Render(8)]
        public readonly uint Index;

        [Render(8)]
        public readonly Hex32 Offset;

        [Render(8)]
        public readonly uint Length;

        readonly uint Pad;

        [MethodImpl(Inline)]
        public HeapEntry(uint index, uint offset, uint length)
        {
            Index = index;
            Offset = offset;
            Length = length;
            Pad = 0;
        }

        const string IndexPattern = "D5";

        [MethodImpl(Inline)]
        public int CompareTo(HeapEntry src)
            => Index.CompareTo(src.Index);

        public string Format()
            => $"[${Index.ToString(IndexPattern)}::${Offset}:${Length}]";

        public override string ToString()
            => Format();
    }
}