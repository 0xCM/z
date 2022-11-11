//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = HexArray;

    public struct HexArray16
    {
        ulong Lo;

        ulong Hi;

        public uint Count => 16;

        public int Length => 16;


        [MethodImpl(Inline)]
        public static implicit operator HexArray16(ReadOnlySpan<byte> src)
        {
            var dst = Empty;
            return api.store(src, ref dst);
        }

        [MethodImpl(Inline)]
        public static implicit operator HexArray16(Span<byte> src)
        {
            var dst = Empty;
            return api.store(src, ref dst);
        }

        [MethodImpl(Inline)]
        public static implicit operator HexArray16(byte[] src)
        {
            var dst = Empty;
            return api.store(src, ref dst);
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