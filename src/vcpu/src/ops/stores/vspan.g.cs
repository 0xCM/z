//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial class vgcpu
    {
        [MethodImpl(Inline), Op]
        [Closures(NumericKind.UnsignedInts)]
        public static Span<T> cover<T>(T src, int count)
            => MemoryMarshal.CreateSpan(ref edit(in src), count);

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
            var dst = vcpu.vzero<T>(w);
            ref var storage = ref vfirst(dst);
            vgcpu.vstore(src, ref storage);
            return cover(storage, vcpu.vcount<T>(w));
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
            var dst = vcpu.vzero<T>(w);
            ref var storage = ref vfirst(dst);
            vgcpu.vstore(src, ref storage);
            return cover(storage, vcpu.vcount<T>(w));
        }

        // /// <summary>
        // /// Deposits source vector content to a span without heap allocation
        // /// </summary>
        // /// <param name="src">The source span</param>
        // /// <typeparam name="T">The component type</typeparam>
        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static Span<T> vspan<T>(Vector512<T> src)
        //     where T : unmanaged
        // {
        //     var w = w512;
        //     var dst = vcpu.vzero<T>(w);
        //     ref var storage = ref vfirst(dst);
        //     vgcpu.vstore(src, ref storage);
        //     return cover(storage, vcpu.vcount<T>(w));
        // }
    }
}