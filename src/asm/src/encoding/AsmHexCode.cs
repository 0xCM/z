//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using Asm;

    public record struct AsmHexCode 
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
            [MethodImpl(Inline), UnscopedRef]
            get => bytes(Data);
        }

        public ref byte Size
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Bytes, SizeIndex);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public ref byte this[byte index]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Bytes, index);
        }

        public ref byte this[sbyte index]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Bytes, index < 0 ? 0 : (byte)index);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Hash;
        }

        public string BitString
            => asm.bitstring(this);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AsmHexCode src)
            => Data.Equals(src.Data);

        public string Format()
            => asm.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(AsmHexCode src)
            => math.cmp(Bytes, src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(BinaryCode src)
            => asm.asmhex(src.View);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(ReadOnlySpan<byte> src)
            => asm.asmhex(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(byte[] src)
            => asm.asmhex(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(string src)
            => asm.asmhex(src);

        public static AsmHexCode Empty
        {
            [MethodImpl(Inline)]
            get => default;
        }
    }
}