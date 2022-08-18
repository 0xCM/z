//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct CellCopy
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe uint copy<T>(N16 n, T* pSrc, T* pDst)
            where T : unmanaged
        {
            var i = 0u;
            var j = 0u;
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            pDst[i++] = pSrc[j++];
            return j;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T copy<T>(in T src, uint count, ref T dst, ref uint index)
        {
            for(var j=0u; j<count; j++)
                seek(dst, index++) = skip(src, j);
            return ref dst;
        }

        /// <summary>
        /// Copies 8 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W8 w, in byte src, ref byte dst)
        {
            *(gptr(dst)) = src;
            return ref dst;
        }

        /// <summary>
        /// Copies 16 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W16 w, in byte src, ref byte dst)
        {
            *(gptr(@as<ushort>(src))) = @as<ushort>(src);
            return ref dst;
        }

        /// <summary>
        /// Copies 32 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W32 w, in byte src, ref byte dst)
        {
            *(gptr(@as<uint>(src))) = @as<uint>(src);
            return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W64 w, in byte src, ref byte dst)
        {
            *(gptr(@as<ulong>(src))) = @as<ulong>(src);
            return ref dst;
        }

        /// <summary>
        /// Copies 128 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W128 w, in byte src, ref byte dst)
        {
            *(gptr(@as<Cell128>(src))) = @as<Cell128>(src);
            return ref dst;
        }

        /// <summary>
        /// Copies 256 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W256 w, in byte src, ref byte dst)
        {
            *(gptr(@as<Cell256>(src))) = @as<Cell256>(src);
            return ref dst;
        }

        /// <summary>
        /// Copies 512 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W512 w, in byte src, ref byte dst)
        {
            *(gptr(@as<Cell512>(src))) = @as<Cell512>(src);
            return ref dst;
        }

        /// <summary>
        /// Copies 512 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W1024 w, in byte src, ref byte dst)
        {
            ref var x = ref @as<byte,Cell512>(src);
            ref var y = ref @as<byte,Cell512>(dst);
            seek(x,0) = skip(y,0);
            seek(x,1) = skip(y,1);
            return ref dst;
        }

        /// <summary>
        /// Copies 16 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W16 w, in ushort src, ref byte dst)
        {
            *(gptr<ushort>(dst)) = src;
            return ref dst;
        }

        /// <summary>
        /// Copies 32 bits from the source to the target
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref uint copy(W32 w, in ushort src, out uint dst)
        {
            dst = *(uint*)gptr(in src);
            return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref ulong copy(W64 w, in byte src, out ulong dst)
        {
            dst = *(ulong*)gptr(in src);
            return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref ulong copy(W64 w, in ushort src, out ulong dst)
        {
            dst = *(ulong*)gptr(in src);
            return ref dst;
        }

        /// <summary>
        /// Copies 16 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref ushort copy(W16 w,in byte src, out ushort dst)
        {
            dst = *(ushort*)gptr(in src);
            return ref dst;
        }

        /// <summary>
        /// Copies 32 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref uint copy(W32 w,in byte src, out uint dst)
        {
            dst = *(uint*)gptr(in src);
            return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
         /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref ulong copy(W64 w, in uint src, out ulong dst)
        {
            dst = *(ulong*)gptr(in src);
            return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W32 w, in uint src, ref byte dst)
        {
             *(gptr<uint>(dst)) = src;
            return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref ushort copy(W32 w, in uint src, ref ushort dst)
        {
            *(gptr<uint>(dst)) = src;
            return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref byte copy(W64 w, in ulong src, ref byte dst)
        {
             *(gptr<ulong>(dst)) = src;
             return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref ushort copy(W64 w, in ulong src, ref ushort dst)
        {
            *(gptr<ulong>(dst)) = src;
            return ref dst;
        }

        /// <summary>
        /// Copies 64 bits from the source to the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static unsafe ref uint copy(W64 w, in ulong src, ref uint dst)
        {
            *(gptr<ulong>(dst)) = src;
            return ref dst;
        }
    }
}