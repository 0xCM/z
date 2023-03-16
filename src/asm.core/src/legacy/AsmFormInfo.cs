//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmFormInfo
    {
        public readonly TextBlock OpCode;

        public readonly AsmSigInfo Sig;

        [MethodImpl(Inline)]
        public AsmFormInfo(TextBlock opcode, AsmSigInfo sig)
        {
            OpCode = opcode;
            Sig = sig;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => OpCode.Hash | Sig.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpCode.IsEmpty || Sig.IsEmpty;
        }

        public TextBlock Content
        {
            [MethodImpl(Inline)]
            get => string.Format("({0})<{1}>", Sig, OpCode);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmFormInfo src)
            => OpCode == src.OpCode && Sig == src.Sig;

        public override bool Equals(object src)
            => src is AsmFormInfo x && Equals(x);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmFormInfo((TextBlock oc, AsmSigInfo sig) src)
            => new AsmFormInfo(src.oc, src.sig);

        public static AsmFormInfo Empty
            => new AsmFormInfo(TextBlock.Empty, AsmSigInfo.Empty);
    }
}