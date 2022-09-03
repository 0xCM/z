//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = AsmColWidths;

    [StructLayout(StructLayout,Pack=1), Record(TableId)]
    public readonly record struct AsmMnemonicRow : IComparable<AsmMnemonicRow>
    {
        const string TableId = "asm.mnemonic";

        [Render(W.Seq)]
        public readonly ushort Seq;

        [Render(W.Mnemonic)]
        public readonly AsmMnemonic Name;

        [Render(W.Hash)]
        public readonly Hash32 Hash;

        [MethodImpl(Inline)]
        public AsmMnemonicRow(ushort seq, AsmMnemonic name)
        {
            Seq = seq;
            Name = name;
            Hash = name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AsmMnemonicRow src)
            => Name == src.Name;

        public int CompareTo(AsmMnemonicRow src)
            => Name.CompareTo(src.Name);
    }
}