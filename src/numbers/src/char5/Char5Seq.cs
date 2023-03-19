//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Char5;

    public readonly record struct Char5Seq
    {
        readonly ulong Data;

        public const byte MaxLength = 12;

        const byte SegWidth = 5;

        public static Char5Seq from<S>(in S src, byte offset)
            where S : unmanaged, IAsciSeq<S>
        {
            var storage = 0ul;
            var dst = recover<Char5>(bytes(storage));
            var data = slice(recover<AsciSymbol>(src.View), offset);
            var count = min(Char5Seq.MaxLength, data.Length);
            var counter = z8;
            for(var i=z8; i<count; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(c != Chars.Space)
                    dst[counter++] = (char)c;
                else
                    break;

            }
            return new Char5Seq(slice(dst,0,counter));
        }

        const uint SegMask = (uint)Limits.Max5u;

        [MethodImpl(Inline)]
        public static Char5Seq parse(ReadOnlySpan<char> src)
        {
            var data = 0ul;
            var count = min(src.Length, MaxLength);
            for(var i=z8; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                var c5 = Char5.parse(c);
                if(c5.IsNonEmpty)
                    data |= ((ulong)c5 << i*SegWidth);
                else
                    break;
            }
            return new Char5Seq(data);
        }

        [MethodImpl(Inline)]
        public static Char5Seq literal(byte n, byte value)
        {
            var bits = span(string.Format("0b{0}", value.ToBitVector8().Format()));
            return parse(slice(bits,0, n + 2));
        }

        [MethodImpl(Inline)]
        public static Char5Seq literal(BitNumber<byte> src)
        {
            var storage = 0ul;
            var dst = recover<Char5>(bytes(storage));
            var i=0;
            var n = (int)src.Width;
            dst[i++] = Code.Zero;
            dst[i++] = Code.B;
            var bits = slice(span(src.Value.ToBitVector8().Format()),0,n);
            for(var j=0; j<n; j++)
                dst[i++] = Char5.parse(skip(bits,j));
            literal(src.Width, src.Value);
            return new Char5Seq(dst);
        }

        [MethodImpl(Inline)]
        public bool IsLiteral()
        {
            var result = true;
            var count = CountChars();
            var offset=z8;
            if(count > 2)
            {
                var c0 = this[0];
                var c1 = this[1];
                if(c0 == '0' && c1 == 'b')
                    offset = 2;
            }

            for(var i=offset; i<count; i++)
            {
                if(!digit(this[i]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        [MethodImpl(Inline)]
        Char5Seq(ulong src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public Char5Seq(Char5 c)
        {
            Data = c;
        }

        [MethodImpl(Inline)]
        public Char5Seq(ReadOnlySpan<Char5> src)
        {
            var dst = 0ul;
            var count = min(src.Length, MaxLength);
            for(var i=0; i<count; i++)
                dst |= ((ulong)skip(src,i) << (i*SegWidth));
            Data = dst;
        }

        [MethodImpl(Inline)]
        public Char5Seq(params Char5[] src)
            : this(@readonly(src))
        {

        }

        [MethodImpl(Inline)]
        public Char5 Char(byte index)
            => (Char5.Code)((Data >> (index*SegWidth)) & SegMask);

        public Char5 this[byte index]
        {
            [MethodImpl(Inline)]
            get => Char(index);
        }

        [MethodImpl(Inline)]
        byte CountChars()
        {
            var w = bits.effwidth(Data);
            var d = w / SegWidth;
            var m = w % SegWidth;
            return (byte)(m == 0 ? d : d+1);
        }

        public byte Length
        {
            [MethodImpl(Inline)]
            get => CountChars();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public string Format()
        {
            if(IsEmpty)
            {
                return EmptyString;
            }
            else
            {
                var dst = CharBlock12.Empty;
                var buffer = dst.Data;
                var count = Length;
                for(var i=z8; i<count; i++)
                    seek(buffer,i) = this[i];
                return new string(slice(dst.Data, 0, count));
            }
        }

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get =>(int)sys.nhash((uint)Data, (uint)(Data >> 32));
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(Char5Seq src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Char5Seq src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator Char5Seq(ulong src)
            => new Char5Seq(src);

        [MethodImpl(Inline)]
        public static implicit operator Char5Seq(char c)
            => new Char5Seq(Char5.parse(c));

        [MethodImpl(Inline)]
        public static implicit operator Char5Seq(ReadOnlySpan<Char5> src)
            => new Char5Seq(src);

        [MethodImpl(Inline)]
        public static implicit operator Char5Seq(Span<Char5> src)
            => new Char5Seq(src);

        public static Char5Seq Empty => default;
    }
}