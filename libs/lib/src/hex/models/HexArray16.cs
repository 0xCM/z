//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct HexArray16
    {
        ByteBlock16 Data;

        public uint Count => 16;

        public int Length => 16;

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public ref byte this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        [MethodImpl(Inline)]
        public static implicit operator HexArray16(ReadOnlySpan<byte> src)
        {
            var dst = Empty;
            return Hex.store(src, ref dst);
        }

        [MethodImpl(Inline)]
        public static implicit operator HexArray16(Span<byte> src)
        {
            var dst = Empty;
            return Hex.store(src, ref dst);
        }

        [MethodImpl(Inline)]
        public static implicit operator HexArray16(byte[] src)
        {
            var dst = Empty;
            return Hex.store(src, ref dst);
        }

        [MethodImpl(Inline)]
        public static implicit operator HexArray16(string src)
        {
            var dst = Empty;
            Hex.parse(src, out dst);
            return dst;
        }

        public static HexArray16 Empty => default;
    }
}