//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmJmpRow
    {
        public const string TableId = "asm.jumps";

        public const byte FieldCount = 9;

        public PartId SourcePart;

        public MemoryAddress Block;

        public MemoryAddress Source;

        public ByteSize InstructionSize;

        public MemoryAddress CallSite;

        public MemoryAddress Target;

        public AsmJmpKind Kind;

        public AsmExpr Instruction;

        public BinaryCode Encoded;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,16,16,16,16,12,26,26};
    }
}