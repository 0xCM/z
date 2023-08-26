//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;   

public readonly record struct CallSite
{
    public readonly LocatedSymbol Block;

    public readonly Address16 BlockOffset;

    public readonly uint4 InstSize;

    [MethodImpl(Inline)]
    public CallSite(LocatedSymbol caller, Address16 offset, uint4 size)
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
