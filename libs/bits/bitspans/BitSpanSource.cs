//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using static Root;
    using static BitSpanSource;

    public readonly struct BitSpanSource
    {
        [MethodImpl(Inline)]
        public static BitSpanSource create(ISource src)
            => new BitSpanSource(src);

        readonly ISource Source;

        [MethodImpl(Inline)]
        internal BitSpanSource(ISource src)
        {
            Source = src;
        }

        public ref readonly BitSpan Fill(in BitSpan dst)
        {
            var count = dst.Length;
            var stream = Source.BitStream().Take(count);
            var e = stream.GetEnumerator();
            var i = 0;
            while(e.MoveNext())
                dst[i] = e.Current;
            return ref dst;
        }

        /// <summary>
        /// Produces a random bitspan of specified length
        /// </summary>
        /// <param name="source">The random source</param>
        [Op]
        public BitSpan Next(int length)
            => Fill(BitSpans.alloc(length));
    }

    public static class XBitSpanSource
    {
        /// <summary>
        /// Produces a bitspan with randomized length
        /// </summary>
        /// <param name="source">The random source</param>
        /// <param name="minlen">The minimum bitspan length</param>
        /// <param name="maxlen">The maximum bitspan length</param>
        [Op]
        public static BitSpan BitSpan(this IBoundSource source, int minlen, int maxlen)
            => create(source).Next(source.Next<int>(minlen, maxlen + 1));

        /// <summary>
        /// Produces a random bitspan of specified length
        /// </summary>
        /// <param name="source">The random source</param>
        [Op]
        public static BitSpan BitSpan(this ISource source, int length)
            => create(source).Next(length);

        /// <summary>
        /// Fills a caller-supplied bitspan with random bits
        /// </summary>
        /// <param name="source">The random source</param>
        [Op]
        public static ref readonly BitSpan BitSpan(this ISource source, in BitSpan dst)
            => ref create(source).Fill(dst);
    }
}