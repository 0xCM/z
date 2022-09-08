//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = AsmColWidths;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmDataBlock
    {
        public const string TableId = "asm.blocks";

        public const byte FieldCount = 9;

        public uint Key;

        [Render(W.BlockAddress)]
        public MemoryAddress BlockAddress;

        [Render(W.IP)]
        public MemoryAddress IP;

        [Render(W.OffsetAddress)]
        public Address16 BlockOffset;

        [Render(64)]
        public CharBlock64 Expression;

        [Render(W.EncodedHex)]
        public CharBlock48 Encoded;

        [Render(W.InstSig)]
		public CharBlock64 Sig;

        [Render(W.SymbolicOpCode)]
        public CharBlock32 OpCode;

        [Render(W.EncodedBits)]
        public CharBlock128 Bitstring;
    }
}