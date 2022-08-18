//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines potential values for machine-aligned data widths
    /// </summary>
    [DataWidth(8)]
    public readonly struct AlignedWidth : IDataString<AlignedWidth>, IDataType<AlignedWidth>
    {
        readonly byte Data;

        public static AlignedWidth None => new AlignedWidth(3);

        public static AlignedWidth W8 => new AlignedWidth(Log2x64.L3);

        public static AlignedWidth W16 => new AlignedWidth(Log2x64.L4);

        public static AlignedWidth W32 => new AlignedWidth(Log2x64.L5);

        public static AlignedWidth W64 => new AlignedWidth(Log2x64.L6);

        public static AlignedWidth W128 => new AlignedWidth(Log2x64.L7);

        public static AlignedWidth W256 => new AlignedWidth(Log2x64.L8);

        public static AlignedWidth W512 => new AlignedWidth(Log2x64.L9);

        public static AlignedWidth W1024 => new AlignedWidth(Log2x64.L10);

        public static AlignedWidth W2048 => new AlignedWidth(Log2x64.L11);

        [MethodImpl(Inline)]
        public static uint calc(NativeTypeWidth src)
            => (uint)src >= 8 ? (uint)Pow2.log((Pow2x64)src) : 0u;

        [MethodImpl(Inline)]
        public static bit test(ulong src)
            => Pow2.test(src);

        const byte StateBit = 7;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => this == None;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => this != None;
        }

        readonly Log2x64 Code
        {
            [MethodImpl(Inline)]
            get => (Log2x64)bit.disable(Data, StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Log2x2 src)
            => Data = bit.enable((byte)src, StateBit);

        [MethodImpl(Inline)]
        public AlignedWidth(Log2x3 src)
        {
            Data = bit.enable((byte)src, StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Log2x4 src)
        {
            Data = bit.enable((byte)src, StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Log2x8 src)
        {
            Data = bit.enable((byte)src, StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Log2x16 src)
        {
            Data = bit.enable((byte)src, StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Log2x32 src)
        {
            Data = bit.enable((byte)src, StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Log2x64 src)
        {
            Data = bit.enable((byte)src, StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Pow2x2 src)
        {
            Data = bit.enable((byte)Pow2.log(src), StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Pow2x3 src)
        {
            Data = bit.enable((byte)Pow2.log(src), StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Pow2x4 src)
        {
            Data = bit.enable((byte)Pow2.log(src), StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Pow2x8 src)
        {
            Data = bit.enable((byte)Pow2.log(src), StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Pow2x16 src)
        {
            Data = bit.enable((byte)Pow2.log(src), StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Pow2x32 src)
        {
            Data = bit.enable((byte)Pow2.log(src), StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(Pow2x64 src)
        {
            Data = bit.enable((byte)Pow2.log(src), StateBit);
        }

        [MethodImpl(Inline)]
        public AlignedWidth(ByteSize src)
        {
            var width = (ulong)src*8;
            Data = test(width) ? bit.enable((byte)Pow2.log(width), StateBit) : z8;
        }

        [MethodImpl(Inline)]
        public AlignedWidth(ulong src)
        {
            Data = test(src) ? bit.enable((byte)Pow2.log(src), StateBit) : z8;
        }

        [MethodImpl(Inline)]
        public AlignedWidth(byte src)
        {
            Data = test(src) ? bit.enable(src, StateBit) : z8;
        }

        public byte Log2
        {
            [MethodImpl(Inline)]
            get => (byte)Code;
        }

        public ulong Value
        {
            [MethodImpl(Inline)]
            get => Pow2.pow((byte)Code);
        }

        public BitWidth Bits
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Log2;
        }
        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => ((ulong)Value/8);
        }

        public bool IsDefined
        {
            [MethodImpl(Inline)]
            get => bit.test(Data,7);
        }

        [MethodImpl(Inline)]
        public int CompareTo(AlignedWidth src)
            => Log2.CompareTo(src.Log2);

        [MethodImpl(Inline)]
        public bool Equals(AlignedWidth src)
            => Code == src.Code;

        public override bool Equals([NotNullWhen(true)] object src)
            => src is AlignedWidth a && Equals(a);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Value.ToString();

        public string Format(FormatKind kind)
            => kind switch
            {
                FormatKind.Pow2 => $"2^{Log2}",
                FormatKind.Log2=> $"log({Value})",
                _ => Format()
            };

        public enum FormatKind
        {
            Default,

            Pow2,

            Log2,
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(ulong src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(ByteSize src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Log2x2 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Log2x3 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Log2x4 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Log2x8 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Log2x16 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Log2x32 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Log2x64 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Pow2x2 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Pow2x3 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Pow2x4 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Pow2x8 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Pow2x16 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Pow2x32 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator AlignedWidth(Pow2x64 src)
            => new AlignedWidth(src);

        [MethodImpl(Inline)]
        public static explicit operator byte(AlignedWidth src)
            => src.Log2;

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(AlignedWidth src)
            => src.Size;

        [MethodImpl(Inline)]
        public static explicit operator BitWidth(AlignedWidth src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(AlignedWidth src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Log2x2(AlignedWidth src)
            => (Log2x2)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x3(AlignedWidth src)
            => (Log2x3)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x4(AlignedWidth src)
            => (Log2x4)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x8(AlignedWidth src)
            => (Log2x8)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x16(AlignedWidth src)
            => (Log2x16)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x32(AlignedWidth src)
            => (Log2x32)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x64(AlignedWidth src)
            => src.Code;

        [MethodImpl(Inline)]
        public static bool operator ==(AlignedWidth a, AlignedWidth b)
            => a.Code == b.Code;

        [MethodImpl(Inline)]
        public static bool operator !=(AlignedWidth a, AlignedWidth b)
            => a.Code != b.Code;
    }
}