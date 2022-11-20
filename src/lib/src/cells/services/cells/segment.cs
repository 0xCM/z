//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cells
    {
        [MethodImpl(Inline)]
        public static T segment<C,T,W>(in C src, W w, out T dst)
            where T : unmanaged
            where C : IDataCell
            where W : unmanaged, INumericWidth
                => seg1(src, w, out dst);

        /// <summary>
        /// Queries/manipulates a cell within a fixed storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <param name="index">The 0-based type-relative cell index</param>
        /// <typeparam name="T">The reference cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref T segment<F,T>(in F src, byte index)
            where F : unmanaged
            where T : unmanaged
                => ref Unsafe.Add(ref @as<F,T>(src), index);

        /// <summary>
        /// Queries/manipulates a generic cell within an 8-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <param name="index">The 0-based type-relative cell index</param>
        /// <typeparam name="T">The reference cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8k)]
        public static ref T segment<T>(in Cell8 src, byte index)
            where T : unmanaged
                => ref Unsafe.Add(ref @as<Cell8,T>(src), index);

        /// <summary>
        /// Queries/manipulates a generic cell within a 16-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <param name="index">The 0-based type-relative cell index</param>
        /// <typeparam name="T">The reference cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8x16k)]
        public static ref T segment<T>(in Cell16 src, byte index)
            where T : unmanaged
                => ref Unsafe.Add(ref @as<Cell16,T>(src), index);

        /// <summary>
        /// Queries/manipulates a generic cell within a 32-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <param name="index">The 0-based type-relative cell index</param>
        /// <typeparam name="T">The reference cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8x16x32k)]
        public static ref T segment<T>(in Cell32 src, byte index)
            where T : unmanaged
                => ref Unsafe.Add(ref @as<Cell32,T>(src), index);

        /// <summary>
        /// Queries/manipulates a generic cell within a 64-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <param name="index">The 0-based type-relative cell index</param>
        /// <typeparam name="T">The reference cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T segment<T>(in Cell64 src, byte index)
            where T : unmanaged
                => ref Unsafe.Add(ref @as<Cell64,T>(src), index);

        /// <summary>
        /// Queries/manipulates a generic cell within a 128-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <param name="index">The 0-based type-relative cell index</param>
        /// <typeparam name="T">The reference cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T segment<T>(in Cell128 src, byte index)
            where T : unmanaged
                => ref Unsafe.Add(ref @as<Cell128,T>(src), index);

        /// <summary>
        /// Queries/manipulates a generic cell within a 256-bit storage block
        /// </summary>
        /// <param name="src">The storage block</param>
        /// <param name="index">The 0-based type-relative cell index</param>
        /// <typeparam name="T">The reference cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T segment<T>(in Cell256 src, byte index)
            where T : unmanaged
                => ref Unsafe.Add(ref @as<Cell256,T>(src), index);

        [MethodImpl(Inline)]
        static T seg1<C,T,W>(in C src, W w, out T dst)
            where T : unmanaged
            where C : IDataCell
            where W : unmanaged, INumericWidth
        {
            dst = default;
            ref var input = ref @as<C,byte>(src);
            var size = w.BitWidth/8u;
            ref var output = ref @as<T,byte>(dst);
            if(typeof(W) == typeof(W8))
                copy(w8, input, ref output);
            else if(typeof(W) == typeof(W16))
                copy(w16, input, ref output);
            else if(typeof(W) == typeof(W32))
                copy(w32, input, ref output);
            else if(typeof(W) == typeof(W64))
                copy(w64, input, ref output);
            else
                throw no<W>();

            return dst;
        }

        [MethodImpl(Inline), Op]
        static void copy(W8 w, in byte src, ref byte dst)
            => dst = src;

        [MethodImpl(Inline), Op]
        static void copy(W16 w, in byte src, ref byte dst)
            => u16(dst) = u16(src);

        [MethodImpl(Inline), Op]
        static void copy(W32 w, in byte src, ref byte dst)
            => u32(dst) = u32(src);

        [MethodImpl(Inline), Op]
        static void copy(W64 w, in byte src, ref byte dst)
            => u64(dst) = u64(src);
    }
}