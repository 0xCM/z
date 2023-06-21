//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct PolyOps
    {
        [MethodImpl(Inline)]
        public static PolyG<G> poly<G>(in G g)
           where G : struct, IRandomSource<G,ulong>
                => g;

        [MethodImpl(Inline)]
        public static T next<G,T>(ref G g)
           where G : struct, IRandomSource<G,ulong>
           where T : unmanaged
        {
            var p = poly(g);
            var result = p.Next<T>();
            g = p.Source;
            return result;
        }

        [MethodImpl(Inline)]
        public static T next<G,T>(ref G g, T max)
           where G : struct, IRandomSource<G,ulong>
           where T : unmanaged
        {
            var p = poly(g);
            var result = p.Next<T>(max);
            g = p.Source;
            return result;
        }

        [MethodImpl(Inline)]
        public static T next<G,T>(ref G g, T min, T max)
           where G : struct, IRandomSource<G,ulong>
           where T : unmanaged
        {
            var p = poly(g);
            var result = p.Next<T>(min, max);
            g = p.Source;
            return result;
        }

        [MethodImpl(Inline)]
        public static void fill<G,T>(ref G g, Span<T> dst)
            where T : unmanaged
            where G : struct, IRandomSource<G,T>
        {
            var count = dst.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = g.Next();
        }

        [MethodImpl(Inline)]
        public static void fill<G,T>(ref G g, T min, T max, Span<T> dst)
            where T : unmanaged
            where G : struct, IRandomSource<G,T>
        {
            var count = dst.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = g.Next(min,max);
        }

        [MethodImpl(Inline)]
        public static byte next<G>(ref G g, W8 w)
            where G : struct, IRandomSource<G,ulong>
                => (byte)g.Next(byte.MaxValue);

        [MethodImpl(Inline)]
        public static byte next<G>(ref G g, byte max)
            where G : struct, IRandomSource<G,ulong>
                => (byte)g.Next(max);

        [MethodImpl(Inline)]
        public static byte next<G>(ref G g, byte min, byte max)
            where G : struct, IRandomSource<G,ulong>
                => (byte)g.Next(min, max);

        [MethodImpl(Inline)]
        public static sbyte next<G>(ref G g, W8i w)
            where G : struct, IRandomSource<G,ulong>
             => (sbyte)(g.Next((ulong)sbyte.MaxValue*2) - (ulong)SByte.MaxValue);

        [MethodImpl(Inline)]
        public static sbyte next<G>(ref G g, sbyte max)
            where G : struct, IRandomSource<G,ulong>
        {
            var amax = (ulong)math.abs(max);
            return (sbyte) (g.Next(amax * 2) - amax);
        }

        [MethodImpl(Inline)]
        public static sbyte next<G>(ref G g, sbyte min, sbyte max)
            where G : struct, IRandomSource<G,ulong>
        {
            var delta = math.sub(max, min);
            return delta > 0
                ? math.add(min, (sbyte)g.Next((ulong)delta))
                : math.add(min, (sbyte)g.Next((ulong)math.negate(delta)));
        }

        [MethodImpl(Inline)]
        public static ushort next<G>(ref G g, W16 w)
            where G : struct, IRandomSource<G,ulong>
                => (ushort)g.Next(ushort.MaxValue);

        [MethodImpl(Inline)]
        public static ushort next<G>(ref G g, ushort max)
            where G : struct, IRandomSource<G,ulong>
                => (ushort)g.Next(max);

        [MethodImpl(Inline)]
        public static ushort next<G>(ref G g, ushort min, ushort max)
            where G : struct, IRandomSource<G,ulong>
                => (ushort)g.Next(min, max);

        [MethodImpl(Inline)]
        public static short next<G>(ref G g, W16i w)
            where G : struct, IRandomSource<G,ulong>
                => (short) (g.Next((ulong)short.MaxValue*2) - (ulong)Int16.MaxValue);

        [MethodImpl(Inline)]
        public static uint next<G>(ref G g, W32 w)
            where G : struct, IRandomSource<G,ulong>
                => (uint)g.Next(uint.MaxValue);

        [MethodImpl(Inline)]
        public static uint next<G>(ref G g, uint max)
            where G : struct, IRandomSource<G,ulong>
                => (uint)g.Next(max);

        [MethodImpl(Inline)]
        public static uint next<G>(ref G g, uint min, uint max)
            where G : struct, IRandomSource<G,ulong>
                => (uint)g.Next(min, max);

        [MethodImpl(Inline)]
        public static int next<G>(ref G g, W32i w)
            where G : struct, IRandomSource<G,ulong>
                => (int) (g.Next((ulong)int.MaxValue*2) - Int32.MaxValue);

        [MethodImpl(Inline)]
        public static ulong next<G>(ref G g, W64 w)
            where G : struct, IRandomSource<G,ulong>
                => (ulong)g.Next(ulong.MaxValue);

        [MethodImpl(Inline)]
        public static ulong next<G>(ref G g, ulong max)
            where G : struct, IRandomSource<G,ulong>
                => (ulong)g.Next(max);

        [MethodImpl(Inline)]
        public static ulong next<G>(ref G g, ulong min, ulong max)
            where G : struct, IRandomSource<G,ulong>
                => (ulong)g.Next(min, max);

        [MethodImpl(Inline)]
        public static long next<G>(ref G g, W64i w)
            where G : struct, IRandomSource<G,ulong>
        {
            var next = (long)g.Next(long.MaxValue);
            var negative = bit.test(next, 7);
            var result = bit.test(next, 7) ? bit.enable(next, 63) : next;
            return result;
        }
    }
}