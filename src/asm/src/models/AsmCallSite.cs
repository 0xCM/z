//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public readonly record struct AsmCallSite
    {
        [MethodImpl(Inline), Op]
        public static AsmCallSite define(LocatedSymbol caller, Address16 offset, uint4 size)
            => new (caller, offset, size);

        public readonly LocatedSymbol Block;

        public readonly Address16 BlockOffset;

        public readonly uint4 InstSize;

        [MethodImpl(Inline)]
        public AsmCallSite(LocatedSymbol caller, Address16 offset, uint4 size)
        {
            Block = caller;
            BlockOffset = offset;
            InstSize = size;
        }

        public MemoryAddress IP
        {
            [MethodImpl(Inline)]
            get => (MemoryAddress)Block.Location + BlockOffset;
        }

        public MemoryAddress RIP
        {
            [MethodImpl(Inline)]
            get => IP + InstSize;
        }

        public string Format()
            => string.Format("{0}:{1}", Block, BlockOffset);

        public override string ToString()
            => Format();
    }
}