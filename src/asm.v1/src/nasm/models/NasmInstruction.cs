//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct NasmInstruction
    {
        const string TableId = "asm.nasm.instructions";

        public const byte FieldCount = 5;

        [Render(12)]
        public uint Sequence;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(64)]
        public asci64 Operands;

        [Render(64)]
        public asci64 Encoding;

        [Render(32)]
        public asci32 Flags;
    }
}