//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using G = WyHash64;

    /// <summary>
    /// Implements a 64-bit random number generator
    /// </summary>
    /// <remarks>Core algorithm taken from https://github.com/lemire/testingRNG/blob/master/source/wyhash.h</remarks>
    [ApiHost]
    [Rng(nameof(WyHash64))]
    public struct WyHash64 : IRandomSource<WyHash64,ulong>
    {
        [MethodImpl(Inline), Op]
        public static ulong next(ref G g)
        {
            g.State += X1;
            UInt128.mul(g.State, X2, out var Y1);
            var m1 = Y1.Lo ^ Y1.Hi;
            UInt128.mul(m1, X3, out var Y2);
            var m2 = Y2.Lo ^ Y2.Hi;
            return m2;
        }

        [MethodImpl(Inline), Op]
        public static ulong next(ref G g, out ulong dst)
            => dst = next(ref g);

        [MethodImpl(Inline), Op]
        public static ulong next(ref G g, ulong max)
            => math.contract(next(ref g), max);

        [MethodImpl(Inline), Op]
        public static ulong next(ref G g, ulong min, ulong max)
            => min + next(ref g, max - min);

        [MethodImpl(Inline), Op]
        public static uint fill(ref G g, Span<ulong> dst)
        {
            var count = (uint)dst.Length;
            if(count != 0)
            {
                ref var point = ref first(dst);
                for(var i=0; i<count; i++)
                    seek(point,i) = next(ref g);
            }
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint fill(ref G g, Span<byte> dst)
        {
            var q = (uint)dst.Length/8;
            var r = dst.Length%8;
            ref var b0 = ref @as<ulong>(first(dst));
            var cells = cover(b0,q);
            fill(ref g, cells);
            if(r != 0)
            {
                ref var b1 = ref seek(dst, q*8);
                var last = @bytes(next(ref g));
                for(var i=0; i<r; i++)
                    seek(b1,i) = skip(last,i);
            }
            return q;
        }

        [MethodImpl(Inline), Op]
        public static uint fill(ref G g, Span<ulong> dst, ulong max)
        {
            var count = (uint)dst.Length;
            if(count != 0)
            {
                ref var point = ref first(dst);
                for(var i=0; i<count; i++)
                    seek(point,i) = next(ref g, max);
            }
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint fill(ref G g, Span<ulong> dst, ulong min, ulong max)
        {
            var count = (uint)dst.Length;
            if(count != 0)
            {
                ref var point = ref first(dst);
                for(var i=0; i<count; i++)
                    seek(point,i) = next(ref g, min, max);
            }
            return count;
        }

        ulong State;

        [MethodImpl(Inline)]
        public WyHash64(ulong state)
            => State = state;

        public Label Name => nameof(WyHash64);

        [MethodImpl(Inline)]
        public ulong Next()
            => next(ref this);

        [MethodImpl(Inline)]
        public ulong Next(ulong max)
            => next(ref this, max);

        [MethodImpl(Inline)]
        public ulong Next(ulong min, ulong max)
            => next(ref this, min, max);

        const ulong X1 = 0x60bee2bee120fc15;

        const ulong X2 = 0xa3b195354a39b70d;

        const ulong X3 = 0x1b03738712fad5c9;
    }
}