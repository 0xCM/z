//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using G = Lcg8;
    using api = Lcg8Ops;

    [ApiHost]
    public readonly struct Lcg8Ops
    {
        [MethodImpl(Inline), Op]
        public static byte min(in G g)
            => g.Inc == 0 ? (byte)1 : (byte)0;

        [MethodImpl(Inline), Op]
        public static byte max(in G g)
            => (byte)(g.Mod - 1);

        [MethodImpl(Inline), Op]
        public static G create(N8 n, byte mul, byte inc, byte mod, byte seed)
            => new G(mul, inc, mod, seed);

        [MethodImpl(Inline), Op]
        public static void capture(ref G g, Span<byte> dst)
        {
            var count = (uint)dst.Length;
            for(var i=0u; i<count; i++)
            {
                advance(ref g);
                seek(dst,i) = g.State;
            }
        }

        [MethodImpl(Inline), Op]
        public static ref G skip(ref G g, uint n)
        {
            for(var i=0; i<n; i++)
                advance(ref g);
            return ref g;
        }

        [MethodImpl(Inline), Op]
        public static byte next(in G g)
            => (byte)((g.Mul*g.State + g.Inc) % g.Mod);

        [MethodImpl(Inline), Op]
        public static ref G advance(ref G g)
        {
            g.State = api.next(g);
            return ref g;
        }

        [MethodImpl(Inline), Op]
        public static ref G advance(ref G g, uint count)
        {
            for(var i=0; i<count; i++)
                api.advance(ref g);
            return ref g;
        }
    }
}