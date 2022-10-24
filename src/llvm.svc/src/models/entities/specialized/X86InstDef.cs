//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static LlvmNames;

    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class X86InstDef : LlvmTableDef
    {
        public const string LlvmName = "Instruction";

        public X86InstDef(LineRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        public string AdSize
            => this[nameof(AdSize)];

        public bits<byte> AdSizeBits
           => LlvmEntities.bits(this[nameof(AdSizeBits)], w8, n2);

        public string AsmStringSource
            => Value(nameof(AsmStringSource),() => text.remove(this[nameof(AsmString)].Replace(Chars.Tab, Chars.Space), Chars.Quote));

        public LlvmAsmPattern AsmString
            => Value(nameof(AsmString), () => llvm.AsmPatterns.extract(this));

        public int CodeSize
            => Parse(nameof(CodeSize), out int _);

       public bits<byte> CD8_Form
           => LlvmEntities.bits(this[nameof(CD8_Form)], w8, n3);

       public bits<byte> CD8_Scale
           => LlvmEntities.bits(this[nameof(CD8_Scale)], w8, n7);

        public string Constraints
            => this[nameof(Constraints)];

        public string DecoderNamespace
            => this[nameof(DecoderNamespace)];

        public string DecoderMethod
            => this[nameof(DecoderMethod)];

        public string Form
            => this[nameof(Form)];

        public bits<byte> FormBits
           => LlvmEntities.bits(this[nameof(FormBits)], w8, n7);

        public string InstName
            => EntityName;

        public dag<IExpr> InOperandList
            => Parse(nameof(InOperandList), out dag<IExpr> _);

        public dag<IExpr> OutOperandList
            => Parse(nameof(OutOperandList), out dag<IExpr> _);

        public bit hasREX_WPrefix
            => Parse(nameof(hasREX_WPrefix), out bit _);

        public bit HasVex_W
            => Parse(nameof(HasVex_W), out bit _);

        public bit hasLockPrefix
            => Parse(nameof(hasLockPrefix), out bit _);

        public bit hasREPPrefix
            => Parse(nameof(hasREPPrefix), out bit _);

        public bit IgnoresVEX_W
            => Parse(nameof(IgnoresVEX_W), out bit _);

        public bit hasVEX_4V
            => Parse(nameof(hasVEX_4V), out bit _);

        public bit hasVEX_L
            => Parse(nameof(hasVEX_L), out bit _);

        public bit ignoresVEX_L
            => Parse(nameof(ignoresVEX_L), out bit _);

        public bit EVEX_W1_VEX_W0
            => Parse(nameof(EVEX_W1_VEX_W0), out bit _);

        public bit hasEVEX_K
            => Parse(nameof(hasEVEX_K), out bit _);

        public bit hasEVEX_Z
            => Parse(nameof(hasEVEX_Z), out bit _);

        public bit hasEVEX_L2
            => Parse(nameof(hasEVEX_L2), out bit _);

        public bit hasEVEX_B
            => Parse(nameof(hasEVEX_B), out bit _);

        public bit hasEVEX_RC
            => Parse(nameof(hasEVEX_RC), out bit _);

        public bit isBranch
            => Parse(nameof(isBranch), out bit _);

        public bit isIndirectBranch
            => Parse(nameof(isIndirectBranch), out bit _);

        public bit isCall
            => Parse(nameof(isCall), out bit _);

        public bit isPseudo
            => Parse(nameof(isPseudo), out bit _);

        public bit isCodeGenOnly
            => Parse(nameof(isCodeGenOnly), out bit _);

        public string ImmT
            => this[nameof(ImmT)];

        public AsmMnemonic Mnemonic
            => Value(nameof(Mnemonic), () => AsmString.Mnemonic);

        public string Namespace
            => this[nameof(Namespace)];

        public string OpMap
            => this[nameof(OpMap)];

        public bits<byte> OpMapBits
            => LlvmEntities.bits(this[nameof(OpMapBits)], w8, n3);

        public string OpSize
            => this[nameof(OpSize)];

        public bits<byte> OpSizeBits
            => LlvmEntities.bits(this[nameof(OpSizeBits)], w8, n2);

        public bits<byte> Opcode
            => LlvmEntities.bits(this[nameof(Opcode)], w8, n8);

        public string OpCodeData
            => this[nameof(Opcode)];

        public string OpEnc
            => this[nameof(OpEnc)];

        public bits<byte> OpEncBits
            => LlvmEntities.bits(this[nameof(OpEncBits)], w8, n2);

        public string OpPrefix
            => this[nameof(OpPrefix)];

        public bits<byte> OpPrefixBits
            => LlvmEntities.bits(this[nameof(OpPrefixBits)], w8, n3);

        public list<string> Predicates
            => Parse(nameof(Predicates), ListTypes.Predicate, out list<string> _);

        public int Size
            => Parse(nameof(Size), out int _);

        public bits<N64,ulong> TSFlags
            => Parse(nameof(TSFlags), out bits<N64,ulong> dst);

        public AsmVariationCode VarCode
            => Value(nameof(VarCode), () => llvm.AsmPatterns.varcode(InstName, Mnemonic));

        public bits<byte> VectSize
            => LlvmEntities.bits(this[nameof(VectSize)], w8, n7);
    }
}