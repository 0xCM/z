//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct EncodingId : IEquatable<EncodingId>
    {
        public static Outcome parse(ReadOnlySpan<char> src, out EncodingId dst)
        {
            var input = text.trim(src);
            dst = EncodingId.Empty;
            var result = Hex64.parse(input, out Hex64 encid);
            if(result)
                dst = encid;
            return result;
        }

        [Op]
        public static EncodingId from(MemoryAddress ip, ReadOnlySpan<byte> encoding)
        {
            var storage = ByteBlock8.Empty;
            var dst = storage.Bytes;
            var ipbytes = bytes((uint)ip);
            var size = (byte)encoding.Length;
            var k=7;
            seek(dst,k--) = size;
            seek(dst,k--) = skip(ipbytes,0);
            seek(dst,k--) = skip(ipbytes,1);

            if(skip(ipbytes,2) != 0)
                seek(dst,k--) = skip(ipbytes,2);
            if(skip(ipbytes,3) != 0)
                seek(dst,k--) = skip(ipbytes,3);

            var j = size - 1;
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);

            return (ulong)storage;
        }

        readonly Hex64 Value;

        [MethodImpl(Inline)]
        public EncodingId(Hex64 value)
        {
            Value = value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(EncodingId src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is EncodingId x && Equals(x);

        public override int GetHashCode()
            => Value.GetHashCode();
        public string Format()
            => string.Format("{0:x16}", (ulong)Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hex64(EncodingId src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator EncodingId(Hex64 src)
            => new EncodingId(src);

        [MethodImpl(Inline)]
        public static explicit operator ulong(EncodingId src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator EncodingId(ulong src)
            => new EncodingId(src);

        [MethodImpl(Inline)]
        public static bool operator ==(EncodingId a, EncodingId b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(EncodingId a, EncodingId b)
            => !a.Equals(b);

        public static EncodingId Empty => default;
    }
}