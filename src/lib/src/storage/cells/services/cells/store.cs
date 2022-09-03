//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cells
    {
        /// <summary>
        /// Deposits cell content to specified target beginning at a byte-relative offset
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <param name="offset">The target offset</param>
        [MethodImpl(Inline), Op]
        public static void store(in Cell8 src, Span<byte> dst, uint offset = 0)
            => sys.first(recover<Cell8>(slice(dst, offset))) = src;

        /// <summary>
        /// Deposits cell content to specified target beginning at a byte-relative offset
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <param name="offset">The target offset</param>
        [MethodImpl(Inline), Op]
        public static void store(in Cell16 src, Span<byte> dst, uint offset = 0)
            => sys.first(recover<Cell16>(slice(dst, offset))) = src;

        /// <summary>
        /// Deposits cell content to specified target beginning at a byte-relative offset
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <param name="offset">The target offset</param>
        [MethodImpl(Inline), Op]
        public static void store(in Cell32 src, Span<byte> dst, uint offset = 0)
            => sys.first(recover<Cell32>(slice(dst, offset))) = src;

        /// <summary>
        /// Deposits cell content to specified target beginning at a byte-relative offset
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <param name="offset">The target offset</param>
        [MethodImpl(Inline), Op]
        public static void store(in Cell64 src, Span<byte> dst, uint offset = 0)
            => sys.first(recover<Cell64>(slice(dst, offset))) = src;

        /// <summary>
        /// Deposits cell content to specified target
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static void store(in Cell128 src, Span<byte> dst)
            => gcpu.vstore(src, dst);


        /// <summary>
        /// Deposits cell content to specified target
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <param name="offset">The target offset</param>
        [MethodImpl(Inline), Op]
        public static void store(in Cell256 src, Span<byte> dst, uint offset = 0)
            => gcpu.vstore(src, dst);

        /// <summary>
        /// Deposits cell content to specified target beginning at a byte-relative offset
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <param name="offset">The target offset</param>
        [MethodImpl(Inline), Op]
        public static void store(in Cell512 src, Span<byte> dst, uint offset = 0)
            => gcpu.vstore(src, dst);
    }
}