//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    
    partial struct gcpu
    {
        /// <summary>
        /// Deposits source vector content to a span without heap allocation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> vspan<T>(Vector128<T> src)
            where T : unmanaged
        {
            var w = w128;
            var dst = vzero<T>(w);
            ref var storage = ref vfirst(dst);
            vstore(src, ref storage);
            return cover(storage, cpu.vcount<T>(w));
        }

        /// <summary>
        /// Deposits source vector content to a span without heap allocation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> vspan<T>(Vector256<T> src)
            where T : unmanaged
        {
            var w = w256;
            var dst = vzero<T>(w);
            ref var storage = ref vfirst(dst);
            vstore(src, ref storage);
            return cover(storage, cpu.vcount<T>(w));
        }

        /// <summary>
        /// Deposits source vector content to a span without heap allocation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> vspan<T>(Vector512<T> src)
            where T : unmanaged
        {
            var w = w512;
            var dst = vzero<T>(w);
            ref var storage = ref vfirst(dst);
            vstore(src, ref storage);
            return cover(storage, cpu.vcount<T>(w));
        }
    }
}