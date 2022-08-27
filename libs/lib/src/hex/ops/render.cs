//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static HexOptionData;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, Hex8 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, src.Hi);
            seek(dst, i++) = hexchar(@case, src.Lo);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, Hex8 src, ref uint i, Span<char> dst, char sep)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, src.Hi);
            seek(dst,i++) = sep;
            seek(dst, i++) = hexchar(@case, src.Lo);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, Hex8 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, src.Hi);
            seek(dst, i++) = hexchar(@case, src.Lo);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, Hex8 src, ref uint i, Span<char> dst, char sep)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, src.Hi);
            seek(dst, i++) = sep;
            seek(dst, i++) = hexchar(@case, src.Lo);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, byte src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, (Hex4)((byte)src >> 4));
            seek(dst, i++) = hexchar(@case, (Hex4)((byte)src & 0xF));
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, byte src, ref uint i, Span<char> dst, char sep)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, (Hex4)((byte)src >> 4));
            seek(dst, i++) = sep;
            seek(dst, i++) = hexchar(@case, (Hex4)((byte)src & 0xF));
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, Hex16 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, src.Hi.Hi);
            seek(dst, i++) = hexchar(@case, src.Hi.Lo);
            seek(dst, i++) = hexchar(@case, src.Lo.Hi);
            seek(dst, i++) = hexchar(@case, src.Lo.Lo);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, Hex16 src, ref uint i, Span<char> dst, char sep)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, src.Hi.Hi);
            seek(dst, i++) = hexchar(@case, src.Hi.Lo);
            seek(dst, i++) = sep;
            seek(dst, i++) = hexchar(@case, src.Lo.Hi);
            seek(dst, i++) = hexchar(@case, src.Lo.Lo);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, Hex16 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, src.Hi.Hi);
            seek(dst, i++) = hexchar(@case, src.Hi.Lo);
            seek(dst, i++) = hexchar(@case, src.Lo.Hi);
            seek(dst, i++) = hexchar(@case, src.Lo.Lo);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, Hex16 src, ref uint i, Span<char> dst, char sep)
        {
            var i0 = i;
            seek(dst, i++) = hexchar(@case, src.Hi.Hi);
            seek(dst, i++) = hexchar(@case, src.Hi.Lo);
            seek(dst, i++) = sep;
            seek(dst, i++) = hexchar(@case, src.Lo.Hi);
            seek(dst, i++) = hexchar(@case, src.Lo.Lo);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, Hex32 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            render(@case, src.Hi, ref i, dst);
            render(@case, src.Lo, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, Hex32 src, ref uint i, Span<char> dst, char sep)
        {
            var i0 = i;
            render(@case, src.Hi, ref i, dst);
            seek(dst, i++) = sep;
            render(@case, src.Lo, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, Hex32 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            render(@case, src.Hi, ref i, dst);
            render(@case, src.Lo, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, Hex32 src, ref uint i, Span<char> dst, char sep)
        {
            var i0 = i;
            render(@case, src.Hi, ref i, dst);
            seek(dst, i++) = sep;
            render(@case, src.Lo, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, Hex64 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            render(@case, src.Hi, ref i, dst);
            render(@case, src.Lo, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, Hex64 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            render(@case, src.Hi, ref i, dst);
            render(@case, src.Lo, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, Hex64 src, ref uint i, Span<char> dst, char sep)
        {
            var i0 = i;
            render(@case, src.Hi, ref i, dst);
            seek(dst, i++) = sep;
            render(@case, src.Lo, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, Hex8 src, ref uint i, Span<char> dst, HexSpecKind spec)
        {
            var i0 = i;
            if(spec == HexSpecKind.PreSpec)
                prespec(ref i, dst);
            seek(dst, i++) = hexchar(@case, src.Hi);
            seek(dst, i++) = hexchar(@case, src.Lo);
            if(spec == HexSpecKind.PostSpec)
                postspec(ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<HexDigitCode> src, Span<char> dst)
        {
            var j=0u;
            var count = src.Length;
            for(var i=0u; i<count; i+=2, j+=3)
            {
                seek(dst, j) = (char)skip(src, i);
                seek(dst, j + 1) = (char)skip(src, i + 1);
                seek(dst, j + 2) = Chars.Space;
            }

            return j;
        }

        [MethodImpl(Inline), Op]
        public static uint render<C>(C @case, ReadOnlySpan<byte> src, Span<char> dst)
            where C : unmanaged, ILetterCase
        {
            var size = src.Length;
            var j=0u;
            for(var i=0; i<size; i++)
            {
                ref readonly var b = ref skip(src,i);
                seek(dst,j++) = hexchar(@case, b, 0);
                seek(dst,j++) = hexchar(@case, b, 1);
                seek(dst,j++) = Chars.Space;
            }
            return j;
        }

        /// <summary>
        /// Formats a span of hex digits as a contiguous block
        /// </summary>
        /// <param name="src">The source digits</param>
        [MethodImpl(Inline)]
        public static uint render<C>(C @case, ReadOnlySpan<HexDigitValue> src, Span<char> dst)
            where C : unmanaged, ILetterCase
        {
            var count = (uint)src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = (char)symbol(@case, skip(src,i));
            return count;
        }

        /// <summary>
        /// Computes the 2-character hex representation of a byte
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(UpperCased @case, byte src)
            => chars(first(UpperHexDigits),src);

        /// <summary>
        /// Computes the 2-character hex representation of a byte
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(LowerCased @case, byte src)
            => chars(first(LowerHexDigits),src);

        /// <summary>
        /// Computes the 2-character hex representation of a signed byte
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(UpperCased @case, sbyte src)
            => render(@case, (byte)src);

        /// <summary>
        /// Computes the 2-character hex representation of a signed byte
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(LowerCased @case, sbyte src)
            => render(@case, (byte)src);

        /// <summary>
        /// Computes the 4-character hex representation of a signed 16-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(UpperCased @case, short src)
            => render(@case, (ushort)src);

        /// <summary>
        /// Computes the 4-character hex representation of a signed 16-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(LowerCased @case, short src)
            => render(@case, (ushort)src);

        /// <summary>
        /// Computes the 4-character hex representation of an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(UpperCased @case, ushort src)
            => chars(first(UpperHexDigits),src);

        /// <summary>
        /// Computes the 4-character hex representation of an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(LowerCased @case, ushort src)
            => chars(first(LowerHexDigits),src);

        /// <summary>
        /// Computes the 8-character hex representation of a signed 32-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(UpperCased @case, int src)
            => render(@case, (uint)src);

        /// <summary>
        /// Computes the 8-character hex representation of a signed 32-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(LowerCased @case, int src)
            => render(@case, (uint)src);

        /// <summary>
        /// Computes the 8-character hex representation of an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(UpperCased @case, uint src)
            => chars(first(UpperHexDigits), src);

        /// <summary>
        /// Computes the 8-character hex representation of an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(LowerCased @case, uint src)
            => chars(first(LowerHexDigits), src);

        /// <summary>
        /// Computes the 16-character hex representation of a signed 64-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(UpperCased @case, long src)
            => render(@case, (ulong)src);

        /// <summary>
        /// Computes the 16-character hex representation of a signed 64-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(LowerCased @case, long src)
            => render(@case, (ulong)src);

        /// <summary>
        /// Computes the 16-character hex representation of an unsigned 64-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(UpperCased @case, ulong src)
            => chars(first(UpperHexDigits), src);

        /// <summary>
        /// Computes the 16-character hex representation of an unsigned 64-bit integer
        /// </summary>
        /// <param name="src">The byte value</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(LowerCased @case, ulong src)
            => chars(first(LowerHexDigits), src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(in HexString<Hex1Kind> src, Hex1Kind kind)
            => src.Chars(kind);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(in HexString<Hex2Kind> src, Hex2Kind kind)
            => src.Chars(kind);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(in HexString<Hex3Kind> src, Hex3Kind kind)
            => src.Chars(kind);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(in HexString<Hex4Kind> src, Hex4Kind kind)
            => src.Chars(kind);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(Hex1Kind src)
            => render(hexstring<Hex1Kind>(), src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(Hex2Kind src)
            => render(hexstring<Hex2Kind>(), src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(Hex3Kind src)
            => render(hexstring<Hex3Kind>(), src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(Hex4Kind src)
            => render(hexstring<Hex4Kind>(), src);

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, byte src, uint offset, Span<char> dst)
            => deposit(first(UpperHexDigits), src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, byte src, uint offset, Span<char> dst)
            => deposit(first(LowerHexDigits), src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, sbyte src, uint offset, Span<char> dst)
            => render(@case, (byte)src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, sbyte src, uint offset, Span<char> dst)
            => render(@case, (byte)src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, short src, uint offset, Span<char> dst)
            => render(@case, (ushort)src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, short src, uint offset, Span<char> dst)
            => render(@case, (ushort)src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, ushort src, uint offset, Span<char> dst)
            => deposit(first(UpperHexDigits), src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, ushort src, uint offset, Span<char> dst)
            => deposit(first(LowerHexDigits), src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, int src, uint offset, Span<char> dst)
            => render(@case, (uint)src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, int src, uint offset, Span<char> dst)
            => render(@case, (uint)src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, uint src, uint offset, Span<char> dst)
            => deposit(first(UpperHexDigits), src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, uint src, uint offset, Span<char> dst)
            => deposit(first(LowerHexDigits), src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, long src, uint offset, Span<char> dst)
            => render(@case, (ulong)src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, long src, uint offset, Span<char> dst)
            => render(@case, (ulong)src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(UpperCased @case, ulong src, uint offset, Span<char> dst)
            => deposit(first(UpperHexDigits), src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, ulong src, uint offset, Span<char> dst)
            => deposit(first(LowerHexDigits), src, offset, dst);

        [MethodImpl(Inline), Op]
        public static uint render(LowerCased @case, ReadOnlySpan<byte> src, Span<char> dst)
        {
            var j = 0u;
            var count = src.Length;
            var max = dst.Length;

            for(var i=0; i<count && j<max; i++)
            {
                ref readonly var b = ref skip(src,i);
                seek(dst,j++) = hexchar(@case, b, 1);
                seek(dst,j++) = hexchar(@case, b, 0);
                if(i != count-1)
                    seek(dst,j++) = Chars.Space;
            }

            return j;
        }

        [MethodImpl(Inline)]
        static uint deposit(in byte codes, byte src, uint offset, Span<char> dst)
        {
            ref var target = ref first(dst);
            seek(target, offset + 0) = (char)skip(in codes, (byte)(src & 0xF));
            seek(target, offset + 1) = (char)skip(in codes, (byte)((src >> 4) & 0xF));
            return 2;
        }

        [MethodImpl(Inline)]
        static uint deposit(in byte codes, ushort src, uint offset, Span<char> dst)
        {
            ref var target = ref first(dst);
            seek(target, offset + 0) = (char)skip(in codes, (ushort)(src & 0xF));
            seek(target, offset + 1) = (char)skip(in codes, (ushort)((src >> 1*4) & 0xF));
            seek(target, offset + 2) = (char)skip(in codes, (ushort)((src >> 2*4) & 0xF));
            seek(target, offset + 3) = (char)skip(in codes, (ushort)((src >> 3*4) & 0xF));
            return 4;
        }

        [MethodImpl(Inline)]
        static uint deposit(in byte codes, uint src, uint offset, Span<char> dst)
        {
            ref var target = ref first(dst);
            seek(target, offset + 0) = (char)skip(in codes, src & 0xF);
            seek(target, offset + 1) = (char)skip(in codes, (src >> 1*4) & 0xF);
            seek(target, offset + 2) = (char)skip(in codes, (src >> 2*4) & 0xF);
            seek(target, offset + 3) = (char)skip(in codes, (src >> 3*4) & 0xF);
            return 4;
        }

        [MethodImpl(Inline)]
        static uint deposit(in byte codes, ulong src, uint offset, Span<char> dst)
        {
            ref var target = ref first(dst);
            seek(target, offset + 0) = (char)skip(in codes, src & 0xF);
            seek(target, offset + 1) = (char)skip(in codes, (src >> 1*4) & 0xF);
            seek(target, offset + 2) = (char)skip(in codes, (src >> 2*4) & 0xF);
            seek(target, offset + 3) = (char)skip(in codes, (src >> 3*4) & 0xF);
            seek(target, offset + 4) = (char)skip(in codes, (src >> 4*4) & 0xF);
            seek(target, offset + 5) = (char)skip(in codes, (src >> 5*4) & 0xF);
            seek(target, offset + 6) = (char)skip(in codes, (src >> 6*4) & 0xF);
            seek(target, offset + 7) = (char)skip(in codes, (src >> 7*4) & 0xF);
            return 8;
        }

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars(in byte codes, byte src)
        {
            var storage = CharBlock2.Null;
            ref var dst = ref storage.First;
            seek(dst,0) = (char)skip(codes, (byte)(0xF & src));
            seek(dst,1) = (char)skip(codes, (byte)((src >> 4) & 0xF));
            return storage.Data;
        }

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars(in byte codes, ushort src)
        {
            const int count = 4;
            var storage = CharBlock4.Null;
            ref var dst = ref storage.First;
            for(var i=0; i<count; i++)
                seek(dst, i) = (char)skip(codes, (uint)((src >> i*4) & 0xF));
            return storage.Data;
        }

        [MethodImpl(Inline), Op]
        static ReadOnlySpan<char> chars(in byte codes, uint src)
        {
            const byte count = 8;
            var storage = CharBlock8.Null;
            ref var dst = ref storage.First;
            for(byte i=0; i < count; i++)
                seek(dst, i) = (char)skip(in codes, (uint) ((src >> i*4) & 0xF));
            return storage.Data;
        }

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars(in byte codes, ulong src)
        {
            const byte count = 16;
            var storage = CharBlock16.Null;
            ref var dst = ref storage.First;
            for(byte i=0; i<count; i++)
                seek(dst, i) = (char)skip(in codes, (uint) ((src >> i*4) & 0xF));
            return storage.Data;
        }
    }
}