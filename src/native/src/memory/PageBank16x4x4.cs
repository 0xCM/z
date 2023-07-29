//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = PageBlock64;

    public abstract class PageBank16x4x4<H>
        where H : PageBank16x4x4<H>, new()         
    {
        public static H allocated()
            => Instance;

        public const uint BlockCount = 8;

        public const uint BlockSize = B.Size;

        public const uint BankSize = BlockCount*BlockSize;

        public const uint TotalPageCount = B.PageCount*BlockCount;

        public const uint PagesPerBlock = B.PageCount;

        [MethodImpl(Inline), Op]
        public MemoryPage Block(byte index)
            => new (BlockIndex[index]);

        [MethodImpl(Inline), Op]
        public MemoryPage Block(N0 n)
            => new (BlockIndex[0]);

        [MethodImpl(Inline), Op]
        public MemoryPage Block(N1 n)
            => new (BlockIndex[1]);

        [MethodImpl(Inline), Op]
        public MemoryPage Block(N2 n)
            => new (BlockIndex[2]);

        [MethodImpl(Inline), Op]
        public MemoryPage Block(N3 n)
            => new (BlockIndex[3]);

        [MethodImpl(Inline), Op]
        public ref readonly PageBankInfo Describe()
            => ref Description;

        Index<MemoryRange> BlockIndex;

        PageBankInfo Description;

        protected PageBank16x4x4()
        {
            BlockIndex = new MemoryRange[4];
            ref var dst = ref BlockIndex.First;
            seek(dst,0) = new MemoryRange(address(Block16x4x0), _BlockSize);
            seek(dst,1) = new MemoryRange(address(Block16x4x1), _BlockSize);
            seek(dst,2) = new MemoryRange(address(Block16x4x2), _BlockSize);
            seek(dst,3) = new MemoryRange(address(Block16x4x3), _BlockSize);
            memory.liberate(address(Block16x4x0), size<B>());
            memory.liberate(address(Block16x4x1), size<B>());
            memory.liberate(address(Block16x4x2), size<B>());
            memory.liberate(address(Block16x4x3), size<B>());
            Description.BankSize = BankSize;
            Description.BlockCount = BlockCount;
            Description.BlockSize = BlockSize;
            Description.PageSize = PageBlocks.PageSize;
            Description.PagesPerBlock = PagesPerBlock;
            Description.TotalPageCount = TotalPageCount;
        }

        static PageBank16x4x4()
        {
            Instance = new ();
        }

        static ByteSize _BlockSize => size<B>();

        static H Instance;

        [FixedAddressValueType]
        static B Block16x4x0;

        [FixedAddressValueType]
        static B Block16x4x1;

        [FixedAddressValueType]
        static B Block16x4x2;

        [FixedAddressValueType]
        static B Block16x4x3;
    }
}