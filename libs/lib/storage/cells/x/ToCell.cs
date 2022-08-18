//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial class XCell
    {
        /// <summary>
        /// Presents a 128-bit vector as a 128-bit fixed block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Cell128 ToCell<T>(this in Vector128<T> src)
            where T : unmanaged
                => ref gcells.cell128(src);

        /// <summary>
        /// Presents a 256-bit vector as a 256-bit fixed block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Cell256 ToCell<T>(this in Vector256<T> src)
            where T : unmanaged
                => ref gcells.cell256(src);

        [MethodImpl(Inline)]
        public static ref Cell512 ToCell<T>(this in Vector512<T> src)
            where T : unmanaged
                => ref gcells.cell512(src);

        [MethodImpl(Inline), Op]
        public static Cell8 ToCell(this byte x)
            => x;

        [MethodImpl(Inline), Op]
        public static Cell8 ToCell(this sbyte x)
            => x;

        [MethodImpl(Inline), Op]
        public static Cell16 ToCell(this short x)
            => x;

        [MethodImpl(Inline), Op]
        public static Cell16 ToCell(this ushort x)
            => x;

        [MethodImpl(Inline), Op]
        public static Cell32 ToCell(this int x)
            => x;

        [MethodImpl(Inline), Op]
        public static Cell32 ToCell(this uint x)
            => x;

        [MethodImpl(Inline), Op]
        public static Cell64 ToCell(this long x)
            => x;

        [MethodImpl(Inline), Op]
        public static Cell64 ToCell(this ulong x)
            => x;
    }
}