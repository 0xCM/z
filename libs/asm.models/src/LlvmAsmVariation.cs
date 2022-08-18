//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmVariation : IComparable<LlvmAsmVariation>, ISequential<LlvmAsmVariation>
    {
        const string TableId = "llvm.asm.variation";

        public const byte FieldCount = 4;

        [Render(8)]
        public uint Seq;

        [Render(32)]
        public asci32 Name;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(1)]
        public AsmVariationCode Code;

        [MethodImpl(Inline)]
        public LlvmAsmVariation(uint id, in asci32 name, in AsmMnemonic monic, in AsmVariationCode code)
        {
            Seq = id;
            Name = name;
            Mnemonic = monic;
            Code = code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Name.IsNull;
        }


        [MethodImpl(Inline)]
        public int CompareTo(LlvmAsmVariation src)
            => Code.CompareTo(src.Code);

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq=value;
        }

        public static LlvmAsmVariation Empty => default;
    }
}