//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmCallRow : IComparableRecord<AsmCallRow>
    {
        public const string TableId = "asm.calls";

        public static bool parse(in TextRow row, out AsmCallRow record)
        {
            var cells = row.Cells;
            var k = 0;
            DataParser.parse(skip(cells, k++).Text, out record.SourcePart);
            DataParser.parse(skip(cells, k++).Text, out record.Block);
            DataParser.parse(skip(cells, k++).Text, out record.Source);
            DataParser.parse(skip(cells, k++).Text, out record.Target);
            DataParser.parse(skip(cells, k++).Text, out record.InstructionSize);
            DataParser.parse(skip(cells, k++).Text, out record.TargetOffset);
            record.Instruction = skip(cells, k++).Text;
            DataParser.parse(skip(cells, k).Text, out record.Encoded);
            return true;
        }

        /// <summary>
        /// The invoking part
        /// </summary>
        [Render(16)]
        public PartName SourcePart;

        /// <summary>
        /// The block base address
        /// </summary>
        [Render(16)]
        public MemoryAddress Block;

        /// <summary>
        /// The callsite IP
        /// </summary>
        [Render(16)]
        public MemoryAddress Source;

        /// <summary>
        /// The destination address
        /// </summary>
        [Render(16)]
        public MemoryAddress Target;

        /// <summary>
        /// The call instruction size
        /// </summary>
        [Render(16)]
        public ByteSize InstructionSize;

        /// <summary>
        /// Target - (Source + InstructionSize)
        /// </summary>
        [Render(16)]
        public MemoryAddress TargetOffset;

        /// <summary>
        /// The call statement
        /// </summary>
        [Render(36)]
        public AsmExpr Instruction;

        /// <summary>
        /// The statement encoding
        /// </summary>
        [Render(16)]
        public BinaryCode Encoded;

        [MethodImpl(Inline)]
        public int CompareTo(AsmCallRow src)
            => Target.CompareTo(src.Target);
    }
}