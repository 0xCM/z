//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static class PolyBytes
    {
        const NumericKind Closure = AllNumeric;

        /// <summary>
        /// Produces an interminable stream of random bytes
        /// </summary>
        /// <param name="src">The data source</param>
        public static IEnumerable<byte> Bytes(this ISource src)
            => bytes(src);

        /// <summary>
        /// Produces a limited stream of random bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The maximum number of bytes to produce</param>
        public static IEnumerable<byte> Bytes(this ISource src, int count)
            => bytes(src, count);

        /// <summary>
        /// Produces a limited stream of random bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The maximum number of bytes to produce</param>
        public static IEnumerable<byte> Bytes(this ISource src, uint count)
            => bytes(src, count);

        /// <summary>
        /// Fills a caller-supplied buffer with source bytes
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static Span<byte> Bytes(this ISource src, Span<byte> dst)
            => bytes(src, dst);

        /// <summary>
        /// Produces an interminable stream of random bytes
        /// </summary>
        /// <param name="src">The data source</param>
        [Op]
        public static IEnumerable<byte> bytes(ISource source)
        {
            while(true)
            {
                var u64 = source.Next<ulong>();
                for(byte i=0; i<8; i++)
                    yield return sys.@byte(u64, i);
            }
        }

        /// <summary>
        /// Produces a limited stream of random bytes
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="count">The maximum number of bytes to produce</param>
        [Op]
        public static IEnumerable<byte> bytes(ISource source, int count)
        {
            var counter = 0;
            var bytes = new byte[8];
            for(var j=0; j<count; j+=8)
            {
                var src = source.Next<ulong>();
                sys.deposit(src, bytes);
                for(var k=0; k<8; k++, counter++)
                {
                    if(counter == count)
                        break;

                    yield return bytes[k];
                }
            }
        }

        [Op]
        public static IEnumerable<byte> bytes(ISource source, uint count)
            => bytes(source, (int)count);

        [Op]
        public static Span<byte> bytes(ISource source, Span<byte> dst)
        {
            source.Fill(dst);
            return dst;
        }

        /// <summary>
        /// Produces an interminable stream of random bits
        /// </summary>
        /// <param name="src">The data source</param>
        public static IEnumerable<Bit32> BitStream32(this ISource src)
        {
            const int w = 64;
            while(true)
            {
                var data = src.Next<ulong>();
                for(var i=0; i<w; i++)
                    yield return Bit32.test(data,i);
            }
        }

        /// <summary>
        /// Fills a caller-supplied target with random bits
        /// </summary>
        /// <param name="source">The data source</param>
        public static void Fill(this IBoundSource source, Span<bit> dst)
        {
            const int w = 64;
            var pos = -1;
            var last = dst.Length - 1;

            while(pos <= last)
            {
                var data = source.Next<ulong>();

                var i = -1;
                while(++pos <= last && ++i < w)
                    dst[pos] = bit.test(data,(byte)i);
            }
        }

        /// <summary>
        /// Produces an interminable stream of random bits
        /// </summary>
        /// <param name="src">The data source</param>
        public static IEnumerable<bit> BitStream(this ISource src)
            => PolyStreams.bitstream(src);

        /// <summary>
        /// Produces an interminable stream of random bits from a value sequence of parametric type
        /// </summary>
        /// <param name="random">The data source</param>
        public static IEnumerable<T> BitStream<T>(this ISource src)
            where T : unmanaged
                => PolyStreams.bitstream<T>(src);

        /// <summary>
        /// Transforms an primal enumerator into a bitstream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static IEnumerable<bit> BitStream<T>(this IEnumerator<T> src)
            where T : struct
                => PolyStreams.bitstream(src);

        /// <summary>
        /// Transforms an primal source stream into a bitstream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static IEnumerable<bit> BitStream<T>(this IEnumerable<T> src)
            where T : struct
                => PolyStreams.bitstream(src);

    }
}