//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct AsmOcValue : IComparable<AsmOcValue>
    {
        [Parser]
        public static Outcome parse(string src, out AsmOcValue dst)
        {
            var storage = Cells.alloc(w32);
            var result = Hex.parse(src, storage.Bytes);
            dst = AsmOcValue.Empty;
            if(result)
                dst = new AsmOcValue(slice(storage.Bytes,0, result.Data));
            return result;
        }

        public static string format(AsmOcValue src)
        {
            var data = src.Trimmed;
            var dst = "0x00";
            switch(data.Length)
            {
                case 1:
                    dst = string.Format("0x{0:X2}", skip(data,0));
                break;
                case 2:
                    dst = string.Format("0x{0:X2} 0x{1:X2}", skip(data,0), skip(data,1));
                break;
                case 3:
                    dst = string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2}", skip(data,0), skip(data,1), skip(data,2));
                break;
                case 4:
                    dst = string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2} 0x{3:X2}", skip(data,0), skip(data,1), skip(data,2), skip(data,3));
                break;
            }
            return dst;
        }

        readonly ByteBlock4 Data;

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0)
        {
            Data = b0;
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1)
        {
            Data = Z0.Bytes.join(w32,b0,b1);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1, byte b2)
        {
            Data = Z0.Bytes.join(w32,b0,b1,b2);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(byte b0, byte b1, byte b2, byte b3)
        {
            Data = Z0.Bytes.join(w32, b0, b1, b2, b3);
        }

        [MethodImpl(Inline)]
        public AsmOcValue(ReadOnlySpan<byte> src)
        {
            switch(src.Length)
            {
                case 0:
                    Data = 0u;
                break;
                case 1:
                    Data = skip(src,0);
                break;
                case 2:
                    Data = @as<ushort>(src);
                break;
                case 3:
                    Data = (uint)@as<ushort>(src) | ((uint)skip(src,2) << 16);
                break;
                default:
                    Data = @as<uint>(src);
                break;
            }
        }

        [MethodImpl(Inline)]
        public AsmOcValue(uint src)
        {
            Data = src;
        }

        public ref readonly Hex8 FirstByte
        {
            [MethodImpl(Inline)]
            get => ref @as<Hex8>(this[0]);
        }

        public ref readonly byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public uint ToScalar()
        {
            var dst = (uint)FirstByte;
            var sz = TrimmedSize;
            if(sz == 2)
                dst = @as<ushort>(Data.Bytes);
            else if(sz == 3)
                dst = @as<uint>(Data.Bytes);
            return dst;
        }

        public ReadOnlySpan<byte> ToSpan()
            => slice(Data.Bytes, 0, Z0.Storage.trim(Data).TrimmedSize);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)this;
        }

        public byte TrimmedSize
        {
            [MethodImpl(Inline)]
            get => (byte)Z0.Storage.trim(Data).TrimmedSize;
        }

        public ReadOnlySpan<byte> Trimmed
        {
            [MethodImpl(Inline)]
            get => slice(Data.Bytes, 0, TrimmedSize);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public string Format()
            => format(this);

        public string Format(bool prespec, bool uppercase)
            => Z0.Storage.trim(Data).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmOcValue src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public int CompareTo(AsmOcValue src)
            => ((uint)Data).CompareTo((uint)src.Data);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator Hex32(AsmOcValue src)
            => (uint)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(Hex32 src)
            => new AsmOcValue(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(uint src)
            => new AsmOcValue(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(AsmOcValue src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(ReadOnlySpan<byte> src)
            => new AsmOcValue(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcValue(ByteBlock4 src)
            => new AsmOcValue(src);

        public static AsmOcValue Empty => default;
    }
}