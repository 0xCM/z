//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        [Op]
        public static string FormatHexData(this Cell128 src, byte? count = null)
        {
            var c = count ?? 16;
            if(c <= 16)
            {
                return HexFormatter.format(slice(bytes(src), 0, c), HexOptionData.HexDataOptions);
            }
            return "!!FormatError!!";
        }
    }

    [ApiHost]
    public readonly struct gcells
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell128<T> src, int max, int min)
            where T : unmanaged
        {
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(@as<Cell128<T>,T>(src), offset);
            return ref sys.first(cover(start, length));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell256<T> src, int max, int min)
            where T : unmanaged
        {
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(@as<Cell256<T>,T>(src), offset);
            return ref sys.first(cover(start, length));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell512<T> src, int max, int min)
            where T : unmanaged
        {
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(@as<Cell512<T>,T>(src), offset);
            return ref sys.first(cover(start, length));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref Cell128<T> src, int i)
            where T : unmanaged
        {
            ref var dst = ref @as<Cell128<T>,T>(src);
            return ref seek(dst,i);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref Cell256<T> src, int i)
            where T : unmanaged
        {
            ref var dst = ref @as<Cell256<T>,T>(src);
            return ref seek(dst,i);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref Cell512<T> src, int i)
            where T : unmanaged
        {
            ref var dst = ref @as<Cell512<T>,T>(src);
            return ref seek(dst,i);
        }

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

        /// <summary>
        /// Presents a 128-bit vector as a 128-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Cell128 cell128<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,Cell128>(src);

        /// <summary>
        /// Presents a 256-bit vector as a 256-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Cell256 cell256<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,Cell256>(src);

        /// <summary>
        /// Presents a 512-bit vector as a 512-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref Cell512 cell512<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,Cell512>(src);
    }
}