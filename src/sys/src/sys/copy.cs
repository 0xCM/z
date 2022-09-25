//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        [MethodImpl(Options), Op]
        public static void copy(in byte src, ref byte dst, uint count)
            => CopyBlock(ref dst, ref AsRef(src), count);

        [MethodImpl(Options), Op]
        public static unsafe void copy(byte* pSrc, byte* pDst, uint count)
            => CopyBlock(pDst, pSrc, count);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static unsafe void copy<T>(T* pSrc, T* pDst, uint count)
            where T : unmanaged
                => CopyBlock(pDst, pSrc, count* (uint)SizeOf<T>());

        [MethodImpl(Options), Op, Closures(Closure)]
        public static Span<T> copy<T>(ReadOnlySpan<T> src, in Span<T> dst)
        {
            src.CopyTo(dst);
            return dst;
        }

        /// <summary>
        /// Copies a source array to a target array
        /// </summary>
        /// <param name="src">The list containing the elements to copy</param>
        /// <param name="dst">The array that will receive the copied elements</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int copy<T>(T[] src, T[] dst)
        {
            var count = min(src?.Length ?? 0, dst?.Length ?? 0);
            if(count != 0)
            {
                ref var target = ref sys.first(dst);
                ref readonly var source = ref sys.first(src);
                for(var i=0; i<count; i++)
                    sys.seek(target,i) = sys.skip(source, i);
            }
            return count;
        }
    }
}