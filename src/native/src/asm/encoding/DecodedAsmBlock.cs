//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct DecodedAsmBlock
    {
        public readonly AsmLabel Label;

        public readonly Index<DecodedAsmStatement> Code;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public DecodedAsmBlock(AsmLabel label, DecodedAsmStatement[] src)
        {
            Label = label;
            Code = src;
            Size = src.Select(x => (uint)x.Encoded.Size).Sum();
        }
    }
}