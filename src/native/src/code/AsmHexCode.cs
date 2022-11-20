//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record struct AsmHexCode : IDataString<AsmHexCode>
    {     
        const byte SizeIndex = 15;

        Cell128 Data;

        [MethodImpl(Inline)]
        public AsmHexCode(Cell128 data)
        {
            Data = data;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }

        public ref byte Size
        {
            [MethodImpl(Inline)]
            get => ref seek(Bytes, SizeIndex);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public ref byte this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Bytes, index);
        }

        public ref byte this[sbyte index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Bytes, index < 0 ? 0 : (byte)index);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Hash;
        }

        public string BitString
            => ApiNative.bitstring(this);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AsmHexCode src)
            => Data.Equals(src.Data);

        public string Format()
            => ApiNative.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(AsmHexCode src)
            => math.cmp(Bytes, src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(BinaryCode src)
            => ApiNative.asmhex(src.View);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(ReadOnlySpan<byte> src)
            => ApiNative.asmhex(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(byte[] src)
            => ApiNative.asmhex(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(string src)
            => ApiNative.asmhex(src);

        public static AsmHexCode Empty
        {
            [MethodImpl(Inline)]
            get => default;
        }
    }
}