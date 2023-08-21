//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class LabelAllocator : IStringAllocator<Label>
{
    public static LabelAllocator alloc(ByteSize capacity)
        => new (StringBuffers.buffer(capacity/2));

    public static LabelAllocator cover(StringBuffer src)
        => new (src);

    StringBuffer Buffer;

    MemoryAddress MaxAddress;

    uint Position;

    public MemoryAddress BaseAddress {get;}

    public ByteSize Size {get;}

    public LabelAllocator(StringBuffer buffer)
    {
        Buffer = buffer;
        BaseAddress = buffer.BaseAddress;
        Size = buffer.Size;
        MaxAddress =  buffer.Address(buffer.Length);
        Position = 0;
    }

    public bool Alloc(ReadOnlySpan<char> src, out Label dst)
    {
        var length = (uint)src.Length;
        dst = Label.Empty;
        if(length > 256)
            return false;

        if(Buffer.Address(Position + length) > MaxAddress)
            return false;

        dst = Buffer.StoreLabel(src, Position);
        Position += length;
        return true;
    }

    public ByteSize Consumed
    {
        [MethodImpl(Inline)]
        get => Position*2;
    }

    public ByteSize Remaining
    {
        [MethodImpl(Inline)]
        get => Size - Consumed;
    }

    public void Dispose()
    {
        Buffer.Dispose();
    }
}
