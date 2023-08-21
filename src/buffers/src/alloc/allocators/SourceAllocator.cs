//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class SourceAllocator : IStringAllocator<SourceText>
{
    public static SourceAllocator alloc(uint capacity)
        => new (StringBuffers.buffer(capacity/2));

    public static SourceAllocator from(StringBuffer src)
        => new (src);

    StringBuffer Buffer;

    MemoryAddress MaxAddress;

    uint Position;

    public MemoryAddress BaseAddress {get;}

    public ByteSize Size {get;}

    internal SourceAllocator(StringBuffer buffer)
    {
        Buffer = buffer;
        Size = buffer.Size;
        BaseAddress = buffer.BaseAddress;
        MaxAddress = buffer.Address(buffer.Length);
        Position = 0;
    }

    public bool Alloc(ReadOnlySpan<char> src, out SourceText dst)
    {
        var length = (uint)src.Length;
        dst = SourceText.Empty;

        if(Buffer.Address(Position + length) > MaxAddress)
            return false;

        dst = store(src, Position, Buffer);
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

    /// <summary>
    /// Deposits a character sequence into a caller-supplied buffer and returns the label representation of the input
    /// </summary>
    /// <param name="src">The input sequence</param>
    /// <param name="offset">The buffer offset</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    static SourceText store(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
    {
        var length = (uint)src.Length;
        if(StringBuffers.store(src, offset, dst))
            return new SourceText(dst.Address(offset), length);
        else
            return SourceText.Empty;
    }
}
