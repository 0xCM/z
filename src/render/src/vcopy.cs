//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static gcpu;

    [ApiHost]
    public readonly struct vcopy
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Copies the source to the target using 128-bit intrinsic operations
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void copy<T>(W128 w, ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
        {
            var seg = (uint)cpu.vcount<T>(w);
            var length = src.Length;
            var blocks = length/seg;
            var rem = length % seg;
            for(var i=0u; i<blocks; i++)
            {
                var offset = i*seg;
                var vSrc = vload(w, skip(src, offset));
                vstore(vSrc, ref seek(dst,offset));
            }

            for(var i=blocks; i<length; i++)
                seek(dst,i) = skip(src,i);
        }

        /// <summary>
        /// Copies the source to the target using 256-bit intrinsic operations
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void copy<T>(W256 w, ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
        {
            var seg = (uint)vcount<T>(w);
            var length = src.Length;
            var blocks = length/seg;
            var rem = length % seg;
            for(var i=0u; i<blocks; i++)
            {
                var offset = i*seg;
                var vSrc = vload(w, skip(src, offset));
                vstore(vSrc, ref seek(dst,offset));
            }

            for(var i=blocks; i<length; i++)
                seek(dst,i) = skip(src,i);
        }
    }
}