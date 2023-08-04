//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), ApiComplete]
    public readonly struct Imm : IImm<Imm,ulong>
    {
        public static byte width(ImmKind src)
            => src switch{
                ImmKind.Imm8u => 8,
                ImmKind.Imm8i => 8,
                ImmKind.Imm16u => 16,
                ImmKind.Imm16i => 16,
                ImmKind.Imm32u => 32,
                ImmKind.Imm32i => 32,
                ImmKind.Imm64u => 64,
                ImmKind.Imm64i => 64,
                _ => 0
            };

        public static NativeSizeCode size(ImmKind src)
            => src switch{
                ImmKind.Imm8u => NativeSizeCode.W8,
                ImmKind.Imm8i => NativeSizeCode.W8,
                ImmKind.Imm16u => NativeSizeCode.W16,
                ImmKind.Imm16i => NativeSizeCode.W16,
                ImmKind.Imm32u => NativeSizeCode.W32,
                ImmKind.Imm32i => NativeSizeCode.W32,
                ImmKind.Imm64u => NativeSizeCode.W64,
                ImmKind.Imm64i => NativeSizeCode.W64,
                _ => 0
            };

        [Op]
        public static string format(in Imm src)
            => src.ImmKind switch
            {
                ImmKind.Imm8u => HexFormatter.format(src.Size, src.Imm8u, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm8i => HexFormatter.format(src.Size, src.Imm8i, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm16u => HexFormatter.format(src.Size, src.Imm16u, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm16i => HexFormatter.format(src.Size, src.Imm16i, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm32u => HexFormatter.format(src.Size, src.Imm32u, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm32i => HexFormatter.format(src.Size, src.Imm32u, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm64u => HexFormatter.format(src.Size, src.Imm64u, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm64i => HexFormatter.format(src.Size, src.Imm64u, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                _ => HexFormatter.format(src.Size, src.Imm64u, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
            };

        public static Imm inc(Imm src)
        {
            switch(src.ImmKind)
            {
                case ImmKind.Imm8u:
                    return new Imm(src.ImmKind, (byte)(src.Imm8u+1));
                case ImmKind.Imm8i:
                    return new Imm(src.ImmKind, (sbyte)(src.Imm8i+1));
                case ImmKind.Imm16u:
                    return new Imm(src.ImmKind, (ushort)(src.Imm16u+1));
                case ImmKind.Imm16i:
                    return new Imm(src.ImmKind, (short)(src.Imm16i+1));
                case ImmKind.Imm32u:
                    return new Imm(src.ImmKind, (uint)(src.Imm32u+1));
                case ImmKind.Imm32i:
                    return new Imm(src.ImmKind, (int)(src.Imm32i+1));
                case ImmKind.Imm64u:
                    return new Imm(src.ImmKind, (ulong)(src.Imm64u+1));
                case ImmKind.Imm64i:
                    return new Imm(src.ImmKind, (long)(src.Imm64i+1));
                default:
                    return new Imm(ImmKind.None, ulong.MaxValue);
            }
        }

        public static Imm dec(Imm src)
        {
            switch(src.ImmKind)
            {
                case ImmKind.Imm8u:
                    return new Imm(src.ImmKind, (byte)(src.Imm8u-1));
                case ImmKind.Imm8i:
                    return new Imm(src.ImmKind, (sbyte)(src.Imm8i-1));
                case ImmKind.Imm16u:
                    return new Imm(src.ImmKind, (ushort)(src.Imm16u-1));
                case ImmKind.Imm16i:
                    return new Imm(src.ImmKind, (short)(src.Imm16i-1));
                case ImmKind.Imm32u:
                    return new Imm(src.ImmKind, (uint)(src.Imm32u-1));
                case ImmKind.Imm32i:
                    return new Imm(src.ImmKind, (int)(src.Imm32i-1));
                case ImmKind.Imm64u:
                    return new Imm(src.ImmKind, (ulong)(src.Imm64u-1));
                case ImmKind.Imm64i:
                    return new Imm(src.ImmKind, (long)(src.Imm64i-1));
                default:
                    return new Imm(ImmKind.None, ulong.MaxValue);
            }
        }

        public static bool lt(Imm a, Imm b)
        {
            var kind = a.ImmKind;
            Require.invariant(kind == b.ImmKind);
            switch(kind)
            {
                case ImmKind.Imm8u:
                    return a.Imm8u < b.Imm8u;
                case ImmKind.Imm8i:
                    return a.Imm8i < b.Imm8i;
                case ImmKind.Imm16u:
                    return a.Imm16u < b.Imm16u;
                case ImmKind.Imm16i:
                    return a.Imm16i < b.Imm16i;
                case ImmKind.Imm32u:
                    return a.Imm32u < b.Imm32u;
                case ImmKind.Imm32i:
                    return a.Imm32i < b.Imm32i;
                case ImmKind.Imm64u:
                    return a.Imm64u < b.Imm64u;
                case ImmKind.Imm64i:
                    return a.Imm64i < b.Imm64i;
                default:
                    return false;
            }
        }

        public static bool gt(Imm a, Imm b)
        {
            var kind = a.ImmKind;
            Require.invariant(kind == b.ImmKind);
            switch(kind)
            {
                case ImmKind.Imm8u:
                    return a.Imm8u > b.Imm8u;
                case ImmKind.Imm8i:
                    return a.Imm8i > b.Imm8i;
                case ImmKind.Imm16u:
                    return a.Imm16u > b.Imm16u;
                case ImmKind.Imm16i:
                    return a.Imm16i > b.Imm16i;
                case ImmKind.Imm32u:
                    return a.Imm32u > b.Imm32u;
                case ImmKind.Imm32i:
                    return a.Imm32i > b.Imm32i;
                case ImmKind.Imm64u:
                    return a.Imm64u > b.Imm64u;
                case ImmKind.Imm64i:
                    return a.Imm64i > b.Imm64i;
                default:
                    return false;
            }
        }

        [MethodImpl(Inline)]
        public static bool eq(Imm a, Imm b)
            => a.OpKind == b.OpKind && a.Value == b.Value;

        public ulong Value {get;}

        public ImmKind ImmKind {get;}

        [MethodImpl(Inline)]
        public Imm(ImmKind kind, ulong src)
        {
            ImmKind = kind;
            Value = src;
        }

        [MethodImpl(Inline)]
        public Imm(ImmKind kind, long src)
        {
            ImmKind = kind;
            Value = (ulong)src;
        }

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Imm;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOps.kind(AsmOpClass.Imm, Size);
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => size(ImmKind);
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => width(ImmKind);
        }

        public bool Signed
        {
            [MethodImpl(Inline)]
            get => ((byte)ImmKind & Pow2.T07) != 0;
        }

        public ulong Imm64u
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public long Imm64i
        {
            [MethodImpl(Inline)]
            get => (long)Value;
        }

        public uint Imm32u
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        public int Imm32i
        {
            [MethodImpl(Inline)]
            get => (int)Value;
        }

        public ushort Imm16u
        {
            [MethodImpl(Inline)]
            get => (ushort)Value;
        }

        public short Imm16i
        {
            [MethodImpl(Inline)]
            get => (short)Value;
        }

        public byte Imm8u
        {
            [MethodImpl(Inline)]
            get => (byte)Value;
        }

        public sbyte Imm8i
        {
            [MethodImpl(Inline)]
            get => (sbyte)Value;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value !=0;
        }

        public bool Equals(Imm src)
            => eq(this,src);

        public override bool Equals(object src)
            => src is Imm x && Equals(x);

        public override int GetHashCode()
            => (int)sys.hash(Value | ((ulong)(ImmKind) << 56));

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public static Imm operator ++(Imm src)
            => inc(src);

        public static Imm operator --(Imm src)
            => dec(src);

        public static bool operator ==(Imm a, Imm b)
            => a.Equals(b);

        public static bool operator !=(Imm a, Imm b)
            => !a.Equals(b);

        public static bool operator <(Imm a, Imm b)
            => lt(a,b);

        public static bool operator <=(Imm a, Imm b)
            => lt(a,b) || eq(a,b);

        public static bool operator >(Imm a, Imm b)
            => gt(a,b);

        public static bool operator >=(Imm a, Imm b)
            => gt(a,b) || eq(a,b);

        public static Imm Empty => default;

    }
}