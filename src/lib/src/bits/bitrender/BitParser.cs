//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct BitParser
    {
        const NumericKind Closure = UnsignedInts;

        public static string cleanse(string src)
            => text.remove(text.remove(src, Chars.Underscore, Chars.Space), "0b");

        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<char> src, Span<bit> dst)
        {
            var input = src;
            var count = (uint)min(src.Length,dst.Length);
            var lastix = count - 1;
            for(var i=0; i<= lastix; i++)
               seek(dst, lastix - i) = skip(input,i) == bit.Zero ? bit.Off : bit.On;
            return count;
        }

        /// <summary>
        /// Constructs a bitstring from text
        /// </summary>
        /// <param name="src">The bit source</param>
        [Op]
        public static int parse(string src, out Span<bit> dst)
        {
            dst = alloc<bit>(src.Length);
            var count = parse(src,dst);
            if(count >= 0)
                dst = slice(dst, 0, count);
            else
                dst = default;
            return count;
        }

        public static bool parse<N,T>(string src, out bits<N,T> dst)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var result = parse<N,T>(src, default(N), out var bits);
            dst = bits.Packed;
            return result;
        }

        public static bool parse<N,T>(string src, N n, out bits<T> dst)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var result = false;
            var width = (byte)n.NatValue;
            if(size<T>() == 1)
            {
                result = parse(src, width, out byte x);
                dst = @as<byte,T>(x);
            }
            else if (size<T>() == 2)
            {
                result = parse(src, width, out ushort x);
                dst = @as<ushort,T>(x);
            }
            else if (size<T>() == 4)
            {
                result = parse(src, width, out uint x);
                dst = @as<uint,T>(x);
            }
            else if (size<T>() == 8)
            {
                result = parse(src, width, out ulong x);
                dst = @as<ulong,T>(x);
            }
            else
            {
                dst = default;
                Errors.Throw(no<T>());
            }

            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(string src, byte n, out byte dst)
        {
            var input = cleanse(src);
            var storage = 0ul;
            var buffer = recover<bit>(slice(bytes(storage), 0, n));
            var count = parse(input, buffer);
            var result = count >= 0;
            dst = bit.scalar<byte>(buffer);
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(string src, byte n, out ushort dst)
        {
            var input = cleanse(src);
            Span<byte> storage = stackalloc byte[16];
            var buffer = recover<bit>(slice(storage, 0, n));
            var count = parse(input, buffer);
            var result = count >= 0;
            dst = bit.scalar<byte>(buffer);
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(string src, byte n, out uint dst)
        {
            var input = cleanse(src);
            Span<byte> storage = stackalloc byte[32];
            var buffer = recover<bit>(slice(storage, 0, n));
            var count = parse(input, buffer);
            var result = count >= 0;
            dst = bit.scalar<byte>(buffer);
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(string src, byte n, out ulong dst)
        {
            var input = cleanse(src);
            Span<byte> storage = stackalloc byte[64];
            var buffer = recover<bit>(slice(storage, 0, n));
            var count = parse(input, buffer);
            var result = count >= 0;
            dst = bit.scalar<byte>(buffer);
            return result;
        }

        [MethodImpl(Inline)]
        public static int parse(string src, Span<bit> dst)
        {
            var input = sys.span(cleanse(src)).Reverse();
            if(input.Length > dst.Length)
                return -1;

            var result = true;
            var count = min(input.Length, dst.Length);
            var counter = 0;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(input,i);
                ref var b = ref seek(dst, i);
                if(c == bit.Zero)
                    b = bit.Off;
                else if(c == bit.One)
                    b = bit.On;
                else
                {
                    result = false;
                    break;
                }
                counter++;
            }
            return result ? counter : -1;
        }

        [Parser]
        public static bool parse(string src, out bit dst)
        {
            var result = false;
            dst = bit.Off;
            var input = text.remove(text.trim(text.ifempty(src,EmptyString)),"0b");
            if(input.Length > 0)
            {
                var c = input[0];
                if(c == bit.Zero)
                {
                    dst = bit.Off;
                    result = true;
                }
                else if(c == bit.One)
                {
                    dst = bit.On;
                    result = true;
                }
            }
            return result;
        }

        [Op]
        public static bool semantic(string src, out bit dst)
        {
            const string On1 = "1";
            const string On2 = "true";
            const string On3 = "yes";
            const string On4 = "on";
            const string Off1 = "0";
            const string Off2 = "false";
            const string Off3 = "no";
            const string Off4 = "off";

            dst = default;
            var result = false;
            if(empty(src))
                return false;

            var input = src.ToLowerInvariant();
            if(matches(input, On1))
            {
                dst = 1;
                result = true;
            }
            else if(matches(input, On2))
            {
                dst = 1;
                result = true;
            }
            else if(matches(input, On3))
            {
                dst = 1;
                result = true;
            }
            else if(matches(input, On4))
            {
                dst = 1;
                result = true;
            }
            else if(matches(input, Off1))
            {
                dst = 0;
                result = true;
            }
            else if(matches(input, Off2))
            {
                dst = 0;
                result = true;
            }
            else if(matches(input, Off3))
            {
                dst = 0;
                result = true;
            }
            else if(matches(input, Off4))
            {
                dst = 0;
                result = true;
            }

            return result;
        }

        [MethodImpl(Inline), Op]
        static bool matches(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            for(var i=0; i<count; i++)
                if(skip(a,i) != skip(b, i))
                    return false;

            return true;
        }
    }
}