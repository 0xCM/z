//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using W = W16;
    using I = Imm16i;

    /// <summary>
    /// Defines a 16-bit immediate value
    /// </summary>
    public readonly struct Imm16i : IImm<I,short>
    {
        public const ImmKind Kind = ImmKind.Imm16i;

        public short Value {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public Imm16i(short src)
            => Value = src;

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Imm;
        }

        public ImmKind ImmKind
            => Kind;

        public AsmOpKind OpKind
            => AsmOpKind.Imm16;

        public NativeSize Size
            => NativeSizeCode.W16;

        public string Format()
            => Imm.format(this);

        public override string ToString()
            => Format();

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address16 ToAddress()
            => (ushort)Value;

        [MethodImpl(Inline)]
        public static bool operator <(I a, I b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(I a, I b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(I a, I b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(I a, I b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bool operator ==(I a, I b)
            => a.Value == b.Value;

        [MethodImpl(Inline)]
        public static bool operator !=(I a, I b)
            => a.Value != b.Value;

        [MethodImpl(Inline)]
        public static implicit operator short(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Imm<short>(I src)
            => new Imm<short>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(short src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator Imm(I src)
            => new Imm(src.ImmKind, src.Value);

        // [MethodImpl(Inline)]
        // public static implicit operator AsmOperand(Imm16i src)
        //     => new AsmOperand(src);
     }
}