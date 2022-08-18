//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct LcgOps
    {
        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static Lcg<T> create<T>(T mul, T inc, T mod, T seed)
            where T : unmanaged
                => new Lcg<T>(mul, inc, mod, seed);

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static void capture<T>(ref Lcg<T> g, Span<T> dst)
            where T : unmanaged
        {
            var count = (uint)dst.Length;
            for(var i=0u; i<count; i++)
            {
                advance(ref g);
                seek(dst,i) = g.State;
            }
        }

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static ref Lcg<T> skip<T>(ref Lcg<T> g, uint n)
            where T : unmanaged
        {
            for(var i=0; i<n; i++)
                advance(ref g);
            return ref g;
        }

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static T next<T>(in Lcg<T> g)
            where T : unmanaged
                => gmath.mod(gmath.add(gmath.mul(g.Mul,g.State),  g.Inc),  g.Mod);

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static ref Lcg<T> advance<T>(ref Lcg<T> g)
            where T : unmanaged
        {
            g.State = next(g);
            return ref g;
        }

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static ref Lcg<T> advance<T>(ref Lcg<T> g, uint count)
            where T : unmanaged
        {
            for(var i=0; i<count; i++)
                advance(ref g);
            return ref g;
        }

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static T min<T>(in Lcg<T> g)
            where T : unmanaged
                => gmath.nonz(g.Inc) ? zero<T>() : one<T>();

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static T max<T>(in Lcg<T> g)
            where T : unmanaged
                => gmath.sub(g.Mod, one<T>());
    }
}