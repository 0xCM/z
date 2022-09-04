//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Describes an instruction within the context of the defining api member
    /// </summary>
    public class ApiInstruction : IComparable<ApiInstruction>
    {
        public readonly MemoryAddress BaseAddress;

        public readonly ApiCodeBlock Encoded;

        public readonly IceInstruction Instruction;

        [MethodImpl(Inline)]
        public ApiInstruction(MemoryAddress @base, IceInstruction fx, ApiCodeBlock encoded)
        {
            BaseAddress = @base;
            Instruction = fx;
            Encoded = encoded;
        }

        public byte InstructionSize
        {
            [MethodImpl(Inline)]
            get => (byte)Instruction.InstructionSize;
        }

        public PartId Part
        {
            [MethodImpl(Inline)]
            get => Encoded.OpUri.Part;
        }

        public _OpUri Uri
        {
            [MethodImpl(Inline)]
            get => Encoded.OpUri;
        }

        public _OpIdentity OpId
        {
            [MethodImpl(Inline)]
            get => Encoded.OpId;
        }

        public BinaryCode EncodedData
        {
            [MethodImpl(Inline)]
            get => Encoded.Data;
        }

        public AsmHexCode AsmHex
        {
            [MethodImpl(Inline)]
            get => Encoded.Data;
        }

        public MemoryAddress Offset
        {
            [MethodImpl(Inline)]
            get => IP - BaseAddress;
        }

        public AsmExpr Statment
        {
            [MethodImpl(Inline)]
            get => Instruction.FormattedInstruction;
        }

        public AsmFormInfo AsmForm
        {
            [MethodImpl(Inline)]
            get => Instruction.Specifier;
        }

        public AsmSigInfo AsmSig
        {
            [MethodImpl(Inline)]
            get => AsmForm.Sig;
        }

        public MemoryAddress IP
        {
            [MethodImpl(Inline)]
            get => Instruction.IP;
        }

        public MemoryAddress NextIp
        {
            [MethodImpl(Inline)]
            get => Instruction.NextIP;
        }

        public IceMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => Instruction.Mnemonic;
        }

        public AsmMnemonic MnemonicExpr
        {
            [MethodImpl(Inline)]
            get => Mnemonic.ToString();
        }

       public TextBlock OpCode
       {
            [MethodImpl(Inline)]
            get => AsmForm.OpCode;
       }

        [MethodImpl(Inline)]
        public int CompareTo(ApiInstruction src)
            => IP.CompareTo(src.IP);
    }
}