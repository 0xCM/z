//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = PageBlock256;

    public class PageBank64x4x8
    {
        public static PageBank64x4x8 allocated()
            => Instance;

        public const uint BlockCount = 8;

        public const uint BlockSize = B.Size;

        public const uint BankSize = BlockCount*BlockSize;

        public const uint TotalPageCount = B.PageCount*BlockCount;

        public const uint PagesPerBlock = B.PageCount;

        [MethodImpl(Inline), Op]
        public ref readonly PageBankInfo Describe()
            => ref Description;

        [MethodImpl(Inline), Op]
        public MemoryPage Block(byte index)
            => new MemoryPage(BlockIndex[index]);

        Index<MemoryRange> BlockIndex;

        PageBankInfo Description;

        PageBank64x4x8()
        {
            BlockIndex = new MemoryRange[BlockCount];
            ref var dst = ref BlockIndex.First;
            seek(dst,0) = new MemoryRange(address(Block0), (ByteSize)BlockSize);
            seek(dst,1) = new MemoryRange(address(Block1), (ByteSize)BlockSize);
            seek(dst,2) = new MemoryRange(address(Block2), (ByteSize)BlockSize);
            seek(dst,3) = new MemoryRange(address(Block3), (ByteSize)BlockSize);
            seek(dst,4) = new MemoryRange(address(Block4), (ByteSize)BlockSize);
            seek(dst,5) = new MemoryRange(address(Block5), (ByteSize)BlockSize);
            seek(dst,6) = new MemoryRange(address(Block6), (ByteSize)BlockSize);
            seek(dst,7) = new MemoryRange(address(Block7), (ByteSize)BlockSize);
            memory.liberate(address(Block0), size<B>());
            memory.liberate(address(Block1), size<B>());
            memory.liberate(address(Block2), size<B>());
            memory.liberate(address(Block3), size<B>());
            memory.liberate(address(Block4), size<B>());
            memory.liberate(address(Block5), size<B>());
            memory.liberate(address(Block6), size<B>());
            memory.liberate(address(Block7), size<B>());
            Description.BankSize = BankSize;
            Description.BlockCount = BlockCount;
            Description.BlockSize = BlockSize;
            Description.PageSize = PageBlocks.PageSize;
            Description.PagesPerBlock = PagesPerBlock;
            Description.TotalPageCount = TotalPageCount;
        }

        static PageBank64x4x8()
        {
            Instance = new PageBank64x4x8();
        }

        static PageBank64x4x8 Instance;

        [FixedAddressValueType]
        static B Block0;

        [FixedAddressValueType]
        static B Block1;

        [FixedAddressValueType]
        static B Block2;

        [FixedAddressValueType]
        static B Block3;

        [FixedAddressValueType]
        static B Block4;

        [FixedAddressValueType]
        static B Block5;

        [FixedAddressValueType]
        static B Block6;

        [FixedAddressValueType]
        static B Block7;
    }
}