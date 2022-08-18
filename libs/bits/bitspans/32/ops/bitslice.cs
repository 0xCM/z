//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class BitSpans32
    {
        /// <summary>
        /// Materializes a bitspan segment as a scalar value
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bitslice<T>(in BitSpan32 src, int offset)
            where T : unmanaged
        {
            var dst = span<Bit32>(width<T>());
            var len = math.min(dst.Length, src.Length - offset);
            core.copy(src.Edit, offset, len, dst);
            return BitPack32.pack<T>(dst);
        }

        /// <summary>
        /// Materializes a bitspan segment as a scalar value
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bitslice<T>(in BitSpan32 src)
            where T : unmanaged
        {
            var dst = span<Bit32>(width<T>());
            var len = math.min(dst.Length, src.Length);
            core.copy(src.Edit, 0, len, dst);
            return BitPack32.pack<T>(dst);
        }

        /// <summary>
        /// Materializes an integral value from a bitspan segment
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="offset">The source index to begin extraction</param>
        /// <param name="count">The number of source bits that contribute to the extract</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bitslice<T>(in BitSpan32 src, int offset, int count)
            where T : unmanaged
        {
            var dst = span<Bit32>(width<T>());
            var len = math.min(count, src.Length - offset);
            core.copy(src.Edit, offset, len, dst);
            return BitPack32.pack<T>(dst);
        }
   }
}