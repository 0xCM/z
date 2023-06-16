//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Numeric;
    using static sys;

    public readonly struct Imm<T> : IImm<Imm<T>,T>
        where T : unmanaged
    {
        public T Value {get;}

        [MethodImpl(Inline)]

        public Imm(T src)
            => Value = src;

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Imm;
        }

        public ImmKind ImmKind
        {
            [MethodImpl(Inline)]
            get => (ImmKind)((byte)width<T>() | (byte)(u8(signed<T>()) << 7));
        }

        public NativeSize OpSize
        {
            [MethodImpl(Inline)]
            get => Sizes.native(width<T>());
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => (AsmOpKind)((ushort)OpClass | ((ushort)OpSize << 8));
        }

        public byte EffWidth
        {
            [MethodImpl(Inline)]
            get => Widths.effective(Imm64u);
        }

        public ulong Imm64u
        {
            [MethodImpl(Inline)]
            get => force<T,ulong>(Value);
        }

        public long Imm64i
        {
            [MethodImpl(Inline)]
            get => force<T,long>(Value);
        }

        public uint Imm32u
        {
            [MethodImpl(Inline)]
            get => force<T,uint>(Value);
        }

        public int Imm32i
        {
            [MethodImpl(Inline)]
            get => force<T,int>(Value);
        }

        public ushort Imm16u
        {
            [MethodImpl(Inline)]
            get => force<T,ushort>(Value);
        }

        public short Imm16i
        {
            [MethodImpl(Inline)]
            get => force<T,short>(Value);
        }

        public byte Imm8u
        {
            [MethodImpl(Inline)]
            get => force<T,byte>(Value);
        }

        public sbyte Imm8i
        {
            [MethodImpl(Inline)]
            get => force<T,sbyte>(Value);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(Value);
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => Imm8u == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Imm8u != 0;
        }


        public override int GetHashCode()
            => (int)Hash;


        [MethodImpl(Inline)]
        public bool Equals(Imm<T> src)
            => Imm64u == src.Imm64u;

        public override bool Equals(object obj)
            => obj is Imm<T> x && Equals(x);

        public string Format()
            => Imm.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(Imm<T> src)
            => Imm64u == src.Imm64u ? 0 : Imm64u < src.Imm64u ? -1 : 1;

        [MethodImpl(Inline)]
        public static implicit operator Imm<T>(byte src)
            => new Imm<T>(force<byte,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Imm<T>(ushort src)
            => new Imm<T>(force<ushort,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Imm<T>(uint src)
            => new Imm<T>(force<uint,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Imm<T>(ulong src)
            => new Imm<T>(force<ulong,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Imm(Imm<T> src)
            => new Imm(src.ImmKind, bw64(src.Value));
    }
}