//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static core;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmDetailRow : IComparable<AsmDetailRow>
    {
        public static Outcome parse(TextRow src, out AsmDetailRow dst)
        {
            var input = src.Cells;
            var i = 0;
            var outcome = Outcome.Empty;
            dst = default;
            outcome = DataParser.parse(skip(input, i++), out dst.Sequence);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.BlockAddress);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.IP);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.GlobalOffset);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.LocalOffset);
            if(!outcome)
                return outcome;

            dst.Mnemonic = new AsmMnemonic(skip(input, i++));
            dst.OpCode = skip(input,i++);

            outcome = DataParser.parse(skip(input, i++), out dst.Instruction);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.Statement);
            if(!outcome)
                return outcome;

            outcome = ApiNative.parse(skip(input, i++).View, out dst.Encoded);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.CpuId);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.OpCodeId);
            if(!outcome)
                return outcome;
            return true;
        }

        public const string TableId = "asm.rows";

        public const byte FieldCount = 12;

        public uint Sequence;

        public MemoryAddress BlockAddress;

        public MemoryAddress IP;

        public Address32 GlobalOffset;

        public Address16 LocalOffset;

		public AsmMnemonic Mnemonic;

		public TextBlock OpCode;

        public string Instruction;

        public string Statement;

        public AsmHexCode Encoded;

		public string CpuId;

        public string OpCodeId;

        [MethodImpl(Inline)]
        public int CompareTo(AsmDetailRow src)
            => Sequence.CompareTo(src.Sequence);

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{12,16,16,16,16,32,32,32,32,32,32,32};
    }
}