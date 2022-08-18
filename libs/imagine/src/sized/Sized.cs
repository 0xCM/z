//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public partial class Sized
    {
        public const ulong BytesPerKb = 1024;

        public const ulong BytesPerMb = 1000*BytesPerKb;

        public const ulong BytesPerGb = 1073741824;

        public const ulong BitsPerByte = 8;

        public const ulong BitsPerKb = BytesPerKb*BitsPerByte;

        public const ulong BitsPerMb = 1000*BitsPerKb;

        public const ulong BitsPerGb = 1000*BitsPerMb;

        const NumericKind Closure = UnsignedInts;

        public static string format(Kb src)
            => size(src).Format();

        public static string format(Mb src)
            => size(src).Format();

        [MethodImpl(Inline), Op]
        public static ByteSize bytes(NativeSizeCode src)
            => (ByteSize)width(src);

        [MethodImpl(Inline), Op]
        public static ByteSize bytes(ulong src)
            => new ByteSize(src);

        [MethodImpl(Inline), Op]
        public static ByteSize bytes(long src)
            => new ByteSize(src);

        // [MethodImpl(Inline), Op, Closures(Integers)]
        // public static ByteSize untyped<T>(Size<T> src)
        //     where T : unmanaged
        //         => bw64(src.Measure);

        [MethodImpl(Inline), Op]
        public static bool eq(Kb a, Kb b)
            => a.Count == b.Count && a.Rem == b.Rem;

        [MethodImpl(Inline)]
        public static DataSize datasize(BitWidth packed)
            => new DataSize(packed,(uint)(packed % 8 == 0 ? packed/8 : (packed/8) + 1));

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 8
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static byte bw8<T>(T src)
            where T : unmanaged
                => u8(src);

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 16
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ushort bw16<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return (ushort)u32(src);
            else
                return (ushort)u64(src);
        }

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 32
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static uint bw32<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return u32(src);
            else
                return (uint)u64(src);
        }

        [MethodImpl(Inline), Op]
        public static int bw32i(ReadOnlySpan<byte> src)
        {
            var storage = z32i;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(4,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static uint bw32u(ReadOnlySpan<byte> src)
        {
            var storage = z32;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(4,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 64
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong bw64<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return u32(src);
            else
                return u64(src);
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long bw64i<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return i8(src);
            if(width<T>() == 16)
                return i16(src);
            else if(width<T>() == 32)
                return i32(src);
            else
                return i64(src);
        }

        [MethodImpl(Inline), Op]
        public static long bw64i(ReadOnlySpan<byte> src)
        {
            var storage = z64i;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(8,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static ulong bw64u(ReadOnlySpan<byte> src)
        {
            var storage = z64;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(8,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }
    }
}