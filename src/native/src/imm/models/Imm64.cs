//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = W64;
    using I = Imm64;

    /// <summary>
    /// Defines a 64-bit immediate value
    /// </summary>
    public readonly struct Imm64 : IImm<Imm64,ulong>
    {
        [Parser]
        public static bool parse(string src, out Imm64 dst)
        {
            var result = Outcome.Success;
            dst = default;
            var i = text.index(src,HexFormatSpecs.PreSpec);
            var imm = 0ul;
            if(i>=0)
            {
                result = Hex.parse64u(src, out imm);
                if(result)
                    dst = imm;
            }
            else
            {
                result = DataParser.parse(src, out imm);
                if(result)
                    dst = imm;
            }
            return result;
        }

        public const ImmKind Kind = ImmKind.Imm64u;

        public ulong Value {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public Imm64(ulong src)
            => Value = src;

        public ImmKind ImmKind
            => Kind;

        public AsmOpClass OpClass
            => AsmOpClass.Imm;

        public AsmOpKind OpKind
            => AsmOpKind.Imm64;

        public NativeSize Size
            => NativeSizeCode.W64;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(Value);
        }


        public override int GetHashCode()
            => Hash;

        public string Format()
            => Imm.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address64 ToAddress()
            => Value;

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
        public static implicit operator ulong(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Imm<ulong>(I src)
            => new Imm<ulong>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(ulong src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator I(MemoryAddress src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator Imm(I src)
            => new Imm(src.ImmKind, src.Value);
   }
}