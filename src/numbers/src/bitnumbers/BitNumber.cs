//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct BitNumber : IBitNumber<BitNumber,ulong>
    {
        static bool IsBinaryLiteral(ReadOnlySpan<char> src)
            => text.begins(src, "0b");

        public static void validate<N,T>(N n, T value, ITextEmitter log)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var bn = BitNumber.generic(n,value);
            var width = Require.equal((byte)n.NatValue, bn.Width);
            var bs = BitNumber.bitstring(n,value);
            var scalar = bn.Value;
            Require.invariant(gmath.eq(scalar,value));
            var f0 = Require.equal(bs.Format(), bn.Format());
            BitNumber.parse(f0,n, out BitNumber<T> roundtrip);
            Require.equal(f0, roundtrip.Format());
            var storage = ByteBlock32.Empty;
            var bits = BitNumber.parse(f0, n, storage);
            var f1 = bits.ToArray().Reverse().Select(x => x.Format()).Concat();
            Require.equal(f0,f1);
            log.AppendLine(string.Format("{0:D2} | {1:X4} | {2}", width, scalar, f0));
        }

        public static BitString bitstring<N,T>(N n, T src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            if(size<T>() <=8)
                return u8(src).ToBitString((byte)n.NatValue);
            else if(size<T>() <=16)
                return u16(src).ToBitString((byte)n.NatValue);
            else if(size<T>() <=32)
                return u32(src).ToBitString((byte)n.NatValue);
            else
                return u64(src).ToBitString((byte)n.NatValue);
        }


        static int parse(string src, Span<bit> dst)
        {
            var input = core.span(BitParser.cleanse(src)).Reverse();
            var result = true;
            var count = min(input.Length, dst.Length);
            var counter = 0;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(input,i);
                if(skip(input,i) == bit.Zero)
                    seek(dst, i) = bit.Off;
                else if(skip(input,i) == bit.One)
                    seek(dst, i) = bit.On;
                else
                {
                    result = false;
                    break;
                }
                counter++;
            }
            return result ? counter : -1;
        }

        public static Span<bit> parse<N,B>(string src, N n, B buffer)
            where N : unmanaged, ITypeNat
            where B : unmanaged, IStorageBlock<B>
        {
            var length = (byte)BitParser.cleanse(src).Length;
            var width = (byte)n.NatValue;
            Require.invariant(length >= width);
            var dst = recover<bit>(buffer.Bytes);
            var count = Require.equal((byte)parse(src, dst),width);
            var result= slice(dst,0,count);
            return result;
        }

        public static BitNumber<N,T> parse<N,T>(string src, N n, out BitNumber<T> dst)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var length = (byte)BitParser.cleanse(src).Length;
            var width = (byte)n.NatValue;
            Require.invariant(length >= width);
            Span<bit> buffer = stackalloc bit[width];
            parse(src, buffer);
            var bn = generic(n, bit.scalar<T>(buffer));
            dst = bn;
            return bn;
        }

        public static bits<byte> parse<N>(string data, W8 w, N n = default)
            where N : unmanaged, ITypeNat
        {
            BitsParser.parse(data, n, out bits<byte> dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public static BitNumber<T> generic<T>(byte n, T src)
            where T : unmanaged
                => new BitNumber<T>(n, src);

        [MethodImpl(Inline)]
        public static BitNumber<T> generic<T>(int n, T src)
            where T : unmanaged
                => new BitNumber<T>((byte)n, src);

        [MethodImpl(Inline)]
        public static BitNumber<T> generic<T>(uint n, T src)
            where T : unmanaged
                => new BitNumber<T>((byte)n, src);

        [MethodImpl(Inline)]
        public static BitNumber<N,T> generic<N,T>(N n, T src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => new BitNumber<N,T>(src);

        [MethodImpl(Inline)]
        public static uint3 define(N3 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint4 define(N4 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint5 define(N5 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint6 define(N6 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint7 define(N7 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint8b define(N8 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static BitNumber define(byte n, ulong src)
            => new BitNumber(n,src);

        const byte WidthOffset = 56;

        const ulong WidthMask = 0xFF000000_00000000;

        const ulong ValueMask = ~WidthMask;

        readonly ulong Data;

        [MethodImpl(Inline)]
        public BitNumber(byte n, ulong src)
        {
            Data = (src & WidthMask) | ((ulong)n << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint1 data)
        {
            Data = (ulong)data | ((ulong)1 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(bit data)
        {
            Data = (ulong)data | ((ulong)1 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint2 data)
        {
            Data = (ulong)data | ((ulong)2 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint3 data)
        {
            Data = (ulong)data | ((ulong)3 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint4 data)
        {
            Data = (ulong)data | ((ulong)4 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint5 data)
        {
            Data = (ulong)data | ((ulong)5 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint6 data)
        {
            Data = (ulong)data | ((ulong)6 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint7 data)
        {
            Data = (ulong)data | ((ulong)7 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint8b data)
        {
            Data = (ulong)data | ((ulong)8 << WidthOffset);
        }

        public ulong Value
        {
            [MethodImpl(Inline)]
            get => Data & ValueMask;
        }

        public byte Width
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> WidthOffset);
        }

        bit Val1
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint2 Val2
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint3 Val3
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint4 Val4
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint5 Val5
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint6 Val6
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint7 Val7
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint8b Val8
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
        }

        public string Format()
            => BitNumbers.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(BitNumber src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(BitNumber src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint1 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(bit src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint2 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint3 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint4 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint5 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint6 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint7 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint8b src)
            => new BitNumber(src);
    }
}