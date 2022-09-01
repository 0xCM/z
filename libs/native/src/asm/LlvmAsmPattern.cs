//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using W = AsmColWidths;

    [Record(TableId)]
    public struct LlvmAsmPattern : IComparable<LlvmAsmPattern>
    {
        public const string TableId = "llvm.asm.strings";

        [Render(W.AsmId)]
        public Identifier InstName;

        [Render(W.Mnemonic)]
        public AsmMnemonic Mnemonic;

        [Render(W.FormatPattern)]
        public TextBlock FormatPattern;

        [Render(1)]
        public TextBlock SourceData;

        public LlvmAsmPattern(Identifier name, AsmMnemonic mnemonic, string pattern, string raw)
        {
            InstName = name;
            Mnemonic = mnemonic;
            FormatPattern = pattern;
            SourceData = raw;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(SourceData.Text);
        }

        public override int GetHashCode()
            => Hash;

        public int CompareTo(LlvmAsmPattern src)
        {
            var result = Mnemonic.CompareTo(src.Mnemonic);
            if(result == 0)
                result = InstName.CompareTo(src.InstName);

            return result;
        }

        public static LlvmAsmPattern Empty => new LlvmAsmPattern(Identifier.Empty, AsmMnemonic.Empty, EmptyString, EmptyString);
    }
}