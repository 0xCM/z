//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        [MethodImpl(Inline), Mod, Closures(Floats)]
        public static Span<T> fmod<T>(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<T> dst)
            where T : unmanaged
        {
            var count = math.min(lhs.Length, dst.Length);
            ref var c = ref first(dst);
            for(var i = 0; i< count; i++)
                seek(c, i) = gfp.mod(skip(lhs, i), skip(rhs, i));
            return dst;
        }
    }
}