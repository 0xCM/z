//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static InstructionId instid(Hex32 docid, MemoryAddress ip, ReadOnlySpan<byte> encoding)
            => new InstructionId(docid, EncodingId.from(ip, encoding));
    }
}