//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using W = W8;
    using I = Imm8;

    /// <summary>
    /// Defines an 8-bit immediate value
    /// </summary>
    public readonly struct Imm8 : IImm<I,byte>
    {
        [Op]
        public static Index<Imm8R> refined(byte[] src, ImmRefinementKind kind)
            => src.Map(x => new Imm8R(x));

        [Op]
        public static Index<Imm8R> refined(ParameterInfo param)
        {
            if(param.IsRefinedImmediate())
                return refined(param.ParameterType.GetEnumValues().Cast<byte>().Array(),ImmRefinementKind.Refined);
            else
                return sys.empty<Imm8R>();
        }

        [Parser]
        public static Outcome parse(string src, out Imm8 dst)
        {
            var result = Outcome.Success;
            dst = default;
            var i = text.index(src,HexFormatSpecs.PreSpec);
            var imm = z8;
            if(i>=0)
            {
                result = Hex.parse8u(src, out imm);
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

        public byte Value {get;}

        [MethodImpl(Inline)]
        public Imm8(byte src)
            => Value = src;

        public bit this[int i]
        {
            [MethodImpl(Inline)]
            get => bit.test(Value,(byte)i);
        }

        public ImmKind ImmKind
            => ImmKind.Imm8u;

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Imm;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Imm8;

        public NativeSize Size
            => NativeSizeCode.W8;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public string Format()
            => Imm.format(this);

        public override string ToString()
            => Format();

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
        public Address8 ToAddress()
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
        public static implicit operator byte(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Imm<byte>(I src)
            => new Imm<byte>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(byte src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator Imm(I src)
            => new Imm(src.ImmKind, src.Value);

        // [MethodImpl(Inline)]
        // public static implicit operator AsmOperand(Imm8 src)
        //     => new AsmOperand(src);

        public static W W => default;
    }
}