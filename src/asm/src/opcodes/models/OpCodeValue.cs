//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class AsmOpCodes
{
    public readonly record struct OpCodeValue : IComparable<OpCodeValue>
    {
        public static string format(OpCodeValue src)
        {
            var data = slice(sys.bytes(src), 0, src.TrimmedSize);
            //var data = src.Trimmed;
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
        public OpCodeValue(byte b0)
        {
            Data = b0;
        }

        [MethodImpl(Inline)]
        public OpCodeValue(byte b0, byte b1)
        {
            Data = Z0.Bytes.join(w32,b0,b1);
        }

        [MethodImpl(Inline)]
        public OpCodeValue(byte b0, byte b1, byte b2)
        {
            Data = Z0.Bytes.join(w32,b0,b1,b2);
        }

        [MethodImpl(Inline)]
        public OpCodeValue(byte b0, byte b1, byte b2, byte b3)
        {
            Data = Z0.Bytes.join(w32, b0, b1, b2, b3);
        }

        [MethodImpl(Inline)]
        public OpCodeValue(ReadOnlySpan<byte> src)
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
        public OpCodeValue(uint src)
        {
            Data = src;
        }

        public ref readonly Hex8 FirstByte
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref @as<Hex8>(this[0]);
        }

        public ref readonly byte this[int i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref skip(sys.bytes(this), i);
        }

        public ref readonly byte this[uint i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref skip(sys.bytes(this), i);
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)this;
        }

        public byte TrimmedSize
        {
            [MethodImpl(Inline), UnscopedRef]
            get => (byte)TrimmedBlocks.trim(Data).TrimmedSize;
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline), UnscopedRef]
            get => sys.bytes(Data);
        }

        public string Format()
            => format(this);

        public string Format(bool prespec, bool uppercase)
            => TrimmedBlocks.trim(Data).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(OpCodeValue src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public int CompareTo(OpCodeValue src)
            => ((uint)Data).CompareTo((uint)src.Data);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator Hex32(OpCodeValue src)
            => (uint)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator OpCodeValue(Hex32 src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator OpCodeValue(uint src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator uint(OpCodeValue src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator OpCodeValue(ReadOnlySpan<byte> src)
            => new OpCodeValue(src);

        [MethodImpl(Inline)]
        public static implicit operator OpCodeValue(ByteBlock4 src)
            => new (src);

        public static OpCodeValue Empty => default;
    }
}
