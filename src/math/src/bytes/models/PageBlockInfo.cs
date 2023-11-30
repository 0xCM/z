//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PageBlockInfo : IComparable<PageBlockInfo>
    {
        readonly MemoryRange Range;

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Range.Min;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Range.Size;
        }

        public readonly uint PageCount;

        [MethodImpl(Inline)]
        public PageBlockInfo(MemoryRange range)
        {
            Range = range;
            PageCount = range.Size/PageBlocks.PageSize;
        }

        public string Format()
            => string.Format(Range.Format());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(PageBlockInfo src)
            => BaseAddress.CompareTo(src.BaseAddress);
    }
}