//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmEncodingInfo
    {
        public uint Seq;

        public uint DocSeq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public InstructionId InstructionId;

        public MemoryAddress IP;

        public BinaryCode Encoded;

        public byte Size;

        public TextBlock Asm;

        public AsmRowKey Key
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }
    }
}