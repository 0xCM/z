//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = W8;
    using I = Imm8R;

    /// <summary>
    /// Describes an 8-bit immediate that is potentially refined
    /// </summary>
    public readonly struct Imm8R : IImm<Imm8R,byte>
    {
        public const ImmKind Kind = ImmKind.Imm8u;

        public byte Value {get;}

        [MethodImpl(Inline)]
        public Imm8R(byte value)
            => Value = value;

        public ImmKind ImmKind
            => Kind;

        public AsmOpKind OpKind
            => AsmOpKind.Imm8;

        public string Format()
            => HexFormatter.format(Value, W, true);

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public static implicit operator byte(Imm8R imm8)
            => imm8.Value;

        [MethodImpl(Inline)]
        public static implicit operator Imm(I src)
            => new Imm(src.ImmKind, src.Value);

       public static W W => default;
    }
}