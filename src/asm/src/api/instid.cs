//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static InstructionId instid(uint docid, MemoryAddress ip, ReadOnlySpan<byte> encoding)
        => new (docid, EncodingId.from(ip, encoding));
}
