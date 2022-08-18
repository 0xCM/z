//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmCallSite
    {
        [MethodImpl(Inline), Op]
        public static AsmCallSite define(LocatedSymbol caller, Address16 offset, uint4 size)
            => new AsmCallSite(caller, offset, size);

        public LocatedSymbol Block {get;}

        public Address16 BlockOffset {get;}

        public uint4 InstSize {get;}

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