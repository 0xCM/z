//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = BitStrings;

    /// <summary>
    /// Represents a sequence of bits
    /// </summary>
    public struct BitString : IEquatable<BitString>
    {
        internal byte[] Data;

        [MethodImpl(Inline)]
        internal BitString(byte[] src)
            => Data = src;

        [MethodImpl(Inline)]
        internal BitString(ReadOnlySpan<byte> src)
        {
            Data = src.ToArray();
        }

        /// <summary>
        /// Queries/manipulates bit at specified index
        /// </summary>
        public bit this[long index]
        {
            [MethodImpl(Inline)]
            get => Data[index] == 1;

            [MethodImpl(Inline)]
            set => Data[index] = (byte)value;
        }

        /// <summary>
        /// Queries/manipulates bit at specified index
        /// </summary>
        public bit this[ulong index]
        {
            [MethodImpl(Inline)]
            get => Data[index] == 1;

            [MethodImpl(Inline)]
            set => Data[index] = (byte)value;
        }

        /// <summary>
        /// Extracts a substring determined by start/end indices
        /// </summary>
        public BitString this[int i0, int i1]
        {
            [MethodImpl(Inline)]
            get => new BitString(BitSeq.Slice(i0, i1 - i0 + 1));
        }

        /// <summary>
        /// Extracts a substring determined by a range
        /// </summary>
        public BitString this[Range range]
        {
            [MethodImpl(Inline)]
            get => this[range.Start.Value, range.End.Value];
        }

        public readonly int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public uint Width
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public readonly bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => (Data?.Length ?? 0) == 0;
        }

        /// <summary>
        /// The (unpacked) sequence of bits represented by the bitstring
        /// </summary>
        public Span<byte> BitSeq
        {
            [MethodImpl(Inline)]
            get => Data ?? Span<byte>.Empty;
        }

        /// <summary>
        /// Renders a segment as a packed primal value
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public T TakeScalar<T>()
            where T : unmanaged
                => PackOne<T>(0);

        /// <summary>
        /// Renders a segment as a packed primal value
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public T TakeScalar<T>(int offset)
            where T : unmanaged
                => PackOne<T>(offset);

        /// <summary>
        /// Renders a bitstring segment as a packed byte value
        /// </summary>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public byte TakeUInt8(int offset)
            => TakeScalar<byte>(offset);

        /// <summary>
        /// Renders a bitstring segment as a packed byte value
        /// </summary>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public byte TakeUInt8()
            => TakeScalar<byte>();

        /// <summary>
        /// Renders a bitstring segment as a packed ushort value
        /// </summary>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public ushort TakeUInt16(int offset)
            => TakeScalar<ushort>(offset);

        /// <summary>
        /// Renders a bitstring segment as a packed ushort value
        /// </summary>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public ushort TakeUInt16()
            => TakeScalar<ushort>();

        /// <summary>
        /// Renders a bitstring segment as a packed uint value
        /// </summary>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public uint TakeUInt32(int offset)
            => TakeScalar<uint>(offset);

        /// <summary>
        /// Renders a bitstring segment as a packed uint value
        /// </summary>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public uint TakeUInt32()
            => TakeScalar<uint>();

        /// <summary>
        /// Renders a bitstring segment as a packed ulong value
        /// </summary>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline)]
        public ulong TakeUInt64(int offset)
            => TakeScalar<ulong>(offset);

        [MethodImpl(Inline)]
        public ulong TakeUInt64()
            => TakeScalar<ulong>();

        /// <summary>
        /// Packs a section of the represented bits into a bytespan
        /// </summary>
        /// <param name="offset">The position of the first bit</param>
        /// <param name="minlen">The the minimum length of the produced span</param>
        [MethodImpl(Inline)]
        public readonly Span<byte> Pack()
            => api.pack(Data, 0, null);

        [MethodImpl(Inline)]
        public readonly Span<byte> Pack(int offset, int minlen)
            => api.pack(Data, offset, minlen);

        /// <summary>
        /// Counts the number of leading zero bits
        /// </summary>
        public int Nlz()
            => api.nlz(this);

        /// <summary>
        /// Shifts the bits leftwards by a specifed offset in a manner that mimics the canonical scalar left-shift
        /// </summary>
        /// <param name="offset">The number of bits to shift</param>
        public BitString Sll(int offset)
        {
            Array.Copy(Data, 0, Data, offset, offset);
            for(var i=0; i<offset; i++)
                Data[i] = 0;
            return this;
        }

        /// <summary>
        /// Counts the number of enabled bits
        /// </summary>
        public int PopCount()
        {
            var count = 0;
            for(var i=0; i<Data.Length; i++)
                if(Data[i] != 0)
                    count++;
            return count;
        }


        /// <summary>
        /// Returns a new bitstring of length no greater than a specified maximum
        /// </summary>
        /// <param name="maxlen">The maximum length</param>
        public BitString Truncate(int maxlen)
        {
            if(Length <= maxlen)
                return new BitString(Data);
            var dst = Data.AsSpan().Slice(0, maxlen).ToArray();
            return new BitString(dst);
        }

        /// <summary>
        /// Renders the content as a span of bits
        /// </summary>
        public Span<bit> ToBits()
        {
            Span<bit> dst = new bit[Data.Length];
            for(var i=0; i< Data.Length; i++)
                dst[i] = (bit)Data[i];
            return dst;
        }

        [MethodImpl(Inline)]
        public BitString Slice(int offset)
        {
            Span<byte> bits = Data;
            return new BitString(bits.Slice(offset));
        }

        [MethodImpl(Inline)]
        public BitString Slice(int offset, int length)
        {
            Span<byte> bits = Data;
            return new BitString(bits.Slice(offset,length));
        }

        /// <summary>
        /// Renders the content as a natural block of bits
        /// </summary>
        public NatSpan<N,bit> ToNatBits<N>(N n = default)
            where N : unmanaged, ITypeNat
        {
            var dst = NatSpans.alloc<N,bit>();
            for(var i=0; i< Data.Length; i++)
                dst[i] = (bit)Data[i];
            return dst;
        }

        /// <summary>
        /// Packs the bitsequence into a bytespan
        /// </summary>
        public Span<byte> ToPackedBytes()
            => api.pack(Data);

        /// <summary>
        /// Determines whether this bitstring represents the same value as another, ignoring
        /// leading zeroes
        /// </summary>
        /// <param name="rhs">The bitstring with which the comparison will be made</param>
        [MethodImpl(Inline)]
        public bool EqualsTrace(BitString rhs, Action<string> trace = null)
        {
            var x = Truncate(Length - api.nlz(this));
            var y = rhs.Truncate(rhs.Length - api.nlz(rhs));
            if(x.Length != y.Length)
            {
                trace?.Invoke($"The source length {x.Length} differs from the operand length {y.Length}");
                return false;
            }

            for(var i=0; i< x.Length; i++)
                if(x.Data[i] != y.Data[i])
                {
                    trace?.Invoke($"x[{i}] = {x.Data[i]} != {y.Data[i]} = y[{i}]");
                    return false;
                }
            return true;
        }

        /// <summary>
        /// Determines whether this bitstring represents the same value as another, ignoring
        /// leading zeroes
        /// </summary>
        /// <param name="rhs">The bitstring with which the comparison will be made</param>
        [MethodImpl(Inline)]
        public bool Equals(BitString rhs)
        {
            var x = Truncate(Length - api.nlz(this));
            var y = rhs.Truncate(rhs.Length - api.nlz(rhs));
            if(x.Length != y.Length)
            {
                return false;
            }

            for(var i=0; i< x.Length; i++)
                if(x.Data[i] != y.Data[i])
                    return false;

            return true;
        }


        /// <summary>
        /// Partitions the bitstring into blocks of a specified maximum width
        /// </summary>
        /// <param name="width">The maximum block width</param>
        public BitString[] Partition(int width)
        {
            var minCount = Math.DivRem(Data.Length, width, out int remainder);
            var count = remainder != 0 ? minCount + 1 : minCount;
            Span<byte> src = Data;
            var dst = new BitString[count];
            var lastix = dst.Length - 1;
            for(int i=0, offset = 0; i< dst.Length; i++, offset += width)
            {
                if(i == lastix && remainder != 0)
                {
                    Span<byte> fullBlock = new byte[width];
                    src.Slice(offset,remainder).CopyTo(fullBlock);
                    dst[i] = new BitString(fullBlock);
                }
                else
                    dst[i] = new BitString(src.Slice(offset, width));
            }
            return dst;
        }

        readonly string FormatUnblocked(bool tlz, bool specifier)
        {
            if(Data == null || Data.Length == 0)
                return string.Empty;

            Span<char> dst = stackalloc char[Data.Length];
            var lastix = dst.Length - 1;
            for(var i=0; i< dst.Length; i++)
                dst[lastix - i] = Data[i] == 0 ? '0' : '1';

            var result = new string(dst);
            if(tlz)
                result = result.TrimStart('0');
            if(specifier)
                result = $"0b{result}";
            return result;
        }

        /// <summary>
        /// Formats bitstring content
        /// </summary>
        /// <param name="tlz">Indicates whether leading zero bits should be eliminated from the result</param>
        /// <param name="specifier">True if the canonical 0b specifier is to precede bitstring content, false if to omit the speicifier</param>
        /// <param name="blockWidth">If unspecified, no blocking will be applied; otherwise, indicates the width of the block partitions</param>
        /// <param name="blocksep">If unspecified, when block formatting, indicates the default block delimiter (An ASCII space) will be used;
        /// if specified, when block formatting, indicates the block delimiter to place between the block partitions</param>
        public string Format(bool tlz = false, bool specifier = false, int? blockWidth = null, char? blocksep = null, int? rowWidth = null)
        {
            if(blockWidth == null || blockWidth == 0)
                return FormatUnblocked(tlz,specifier);
            else
            {
                var sep = blocksep ?? ' ';
                var sb = text.build();
                var blocks = Partition(blockWidth.Value).Reverse();
                var lastix = blocks.Length - 1;
                var counter = 0;
                for(var i=0; i<=lastix; i++)
                {
                    sb.Append(blocks[i].FormatUnblocked(false,false));
                    if(i != lastix)
                    {
                        if(rowWidth != null && rowWidth != 0)
                        {
                            if(++counter % rowWidth.Value == 0)
                            {
                                counter = 0;
                                sb.AppendLine();
                            }
                            else
                                sb.Append(sep);
                        }
                        else
                            sb.Append(sep);
                    }

                }
                var x = sb.ToString();
                return  (specifier ? "0b" : string.Empty) + (tlz ? x.TrimStart('0') : x);
            }
        }

        public string Format(BitFormat? config = null)
        {
            var style = config ?? BitFormat.Default;
            var sep = style.BlockSep;
            var rowWidth = style.RowWidth;
            var specifier = style.SpecifierPrefix;
            var tlz = style.TrimLeadingZeros;

            if(style.BlockWidth == 0)
                return FormatUnblocked(style.TrimLeadingZeros, specifier);
            else
            {
                var blockWidth = style.BlockWidth;
                var sb = text.build();
                var blocks = Partition(blockWidth).Reverse();
                var lastix = blocks.Length - 1;
                var counter = 0;
                for(var i=0; i<=lastix; i++)
                {
                    sb.Append(blocks[i].FormatUnblocked(false,false));
                    if(i != lastix)
                    {
                        if(rowWidth != 0)
                        {
                            if(++counter % rowWidth == 0)
                            {
                                counter = 0;
                                sb.AppendLine();
                            }
                            else
                                sb.Append(sep);
                        }
                        else
                            sb.Append(sep);
                    }

                }
                var x = sb.ToString();
                return  (specifier ? "0b" : string.Empty) + (tlz ? x.TrimStart('0') : x);
            }
        }

        /// <summary>
        /// Formats bitstring using default parameter values
        /// </summary>
        [MethodImpl(Inline)]
        public string Format()
            => Format(false, false, null, null);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object rhs)
            => rhs is BitString x && Equals(x);

        /// <summary>
        /// Packs a section of bits into a scalar
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        /// <param name="offset">The index of the first bit </param>
        public T Scalar<T>(int offset = 0, int? count = null)
            where T : unmanaged
        {
            var len = min((count == null ? (int)width<T>() : count.Value), Length - offset);
            return BitSeq.Slice(offset, len).Take<T>();
        }

        [MethodImpl(Inline)]
        T PackOne<T>(int offset)
            where T : unmanaged
        {
            var src = View;
            var packed = api.pack(src, offset, (int)width<T>());
            return packed.Length != 0 ? core.seek<byte,T>(packed) : default;
        }

        ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator string(BitString src)
            => src.Format();

        [MethodImpl(Inline)]
        public static bool operator ==(BitString lhs, BitString rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(BitString lhs, BitString rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static BitString operator +(BitString lhs, BitString rhs)
            => api.concat(lhs,rhs);

        [MethodImpl(Inline)]
        public static BitString operator &(BitString lhs, BitString rhs)
            => api.and(lhs,rhs);

        [MethodImpl(Inline)]
        public static BitString operator |(BitString lhs, BitString rhs)
            => api.or(lhs,rhs);

        [MethodImpl(Inline)]
        public static BitString operator ^(BitString lhs, BitString rhs)
            => api.xor(lhs,rhs);

        [MethodImpl(Inline)]
        public static BitString operator <<(BitString lhs, int offset)
            => api.sll(lhs,offset);

        [MethodImpl(Inline)]
        public static BitString operator >>(BitString lhs, int offset)
            => api.srl(lhs,offset);

        [MethodImpl(Inline)]
        public static BitString operator ~(BitString src)
            => api.not(src);

        /// <summary>
        /// Defines the canonical empty bitstring of 0 length
        /// </summary>
        public static BitString Empty
            => api.parse(string.Empty);
    }
}