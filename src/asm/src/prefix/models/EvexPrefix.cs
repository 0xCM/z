//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public readonly record struct EvexPrefix
{
    [MethodImpl(Inline)]
    public static EvexPrefix define(byte b0, byte b1, byte b2, byte b3)
        => new (Bytes.join(b0,b1,b2,b3));

    [MethodImpl(Inline)]
    public static EvexPrefix define(ReadOnlySpan<byte> src)
    {
        var count = min(src.Length,4);
        var data = 0u;
        for(var i=0; i<count; i++)
            data |= (uint)skip(src,i) << (i*8);
        return new EvexPrefix(data);
    }

    readonly uint Data;

    [MethodImpl(Inline)]
    internal EvexPrefix(uint data)
    {
        Data = data;
    }

    public string Format()
        => Data == 0 ? EmptyString : bytes(Data).FormatHex();

    public override string ToString()
        => Format();
}
