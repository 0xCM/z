//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T read<T>(ReadOnlySpan<byte> src)
            => Unsafe.ReadUnaligned<T>(ref first(edit(src)));

        /// <summary>
        /// Deposits a source value, identified by pointer and offset, into a target reference
        /// </summary>
        /// <param name="pSrc">The data source</param>
        /// <param name="offset">The value offset</param>
        /// <param name="dst">The receiving reference</param>
        /// <typeparam name="T">The value type</typeparam>
        /// <remarks>u8:  movsxd rax,edx -> movzx eax,byte ptr [rcx+rax] -> mov [r8],al -> mov rax,r8 </remarks>
        /// <remarks>u16: movsxd rax,edx -> movzx eax,word ptr [rcx+rax*2] -> mov [r8],ax -> mov rax,r8 </remarks>
        /// <remarks>u32: movsxd rax,edx -> mov eax,[rcx+rax*4] -> mov [r8],eax -> mov rax,r8 </remarks>
        /// <remarks>u64: movsxd rax,edx -> mov rax,[rcx+rax*8] -> mov [r8],rax -> mov rax,r8 </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ref T read<T>(T* pSrc, int offset, ref T dst)
            where T : unmanaged
        {
            dst = *(pSrc + offset);
            return ref dst;
        }

        /// <summary>
        /// Deposits a source value, identified by pointer and offset, into a target reference
        /// </summary>
        /// <param name="pSrc">The data source</param>
        /// <param name="offset">The value offset</param>
        /// <param name="dst">The receiving reference</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ref T read<T>(T* pSrc, uint offset, ref T dst)
            where T : unmanaged
        {
            dst = *(pSrc + offset);
            return ref dst;
        }

        /// <summary>
        /// Deposits a range of source values into a target reference
        /// </summary>
        /// <param name="pSrc">The data source</param>
        /// <param name="offset">The value offset</param>
        /// <param name="dst">The receiving reference</param>
        /// <param name="count">The number of values to extract/deposit</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe void read<T>(T* pSrc, int offset, ref T dst, int count)
            where T : unmanaged
        {
            var last = offset + count;
            for(var i=offset; i<last; i++)
                read(pSrc, i, ref add(dst, i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte read<T>(in T src, ref byte dst)
        {
            dst = u8(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ushort read<T>(in T src, ref ushort dst)
        {
            dst = u16(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint read<T>(in T src, ref uint dst)
        {
            dst = u32(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong read<T>(in T src, ref ulong dst)
        {
            dst = u64(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte read<T>(W8 w, in T src)
            => u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort read<T>(W16 w, in T src)
        {
            if(size<T>() >= 16)
                return u16(src);
            else
                return u8(src);
        }

        [MethodImpl(Inline), Op]
        public static uint read(W24 w, ReadOnlySpan<byte> src, uint offset)
        {
            var dst = z32;
            dst = ((uint)read16(w16, src, offset)) << 24;
            dst |= skip(src, offset + 2);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint read<T>(W32 w, in T src)
        {
            if(size<T>() >= 32)
                return u32(src);
            else if(size<T>() >= 16)
                return u16(src);
            else
                return u8(src);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong read64<T>(W64 w, in T src)
        {
            if(size<T>() >= 64)
                return u64(src);
            else  if(size<T>() >= 32)
                return u32(src);
            else  if(size<T>() >= 16)
                return u16(src);
            else
                return u8(src);
        }

        [MethodImpl(Inline), Op]
        public static ushort read16(W16 w, ReadOnlySpan<byte> src, uint offset)
            => first(recover<ushort>(slice(src,offset,2)));

        [MethodImpl(Inline), Op]
        public static uint read(W32 w, ReadOnlySpan<byte> src, uint offset)
            => first(recover<uint>(slice(src,offset,4)));

        [MethodImpl(Inline), Op]
        public static uint read(W64 w, ReadOnlySpan<byte> src, uint offset)
            => first(recover<uint>(slice(src,offset,8)));

        [MethodImpl(Inline), Op]
        public static byte read8u(ReadOnlySpan<byte> src)
            => src.Length != 0 ? first(src) : z8;

        [MethodImpl(Inline), Op]
        public static sbyte read8i(ReadOnlySpan<byte> src)
            => @as<sbyte>(read8u(src));

        [MethodImpl(Inline), Op]
        public static ushort read16u(ReadOnlySpan<byte> src)
        {
            var len = src.Length;
            if(len >= 2)
                return first16u(src);
            else if(len > 0)
                return first(src);
            else
                return 0;
        }

        [MethodImpl(Inline), Op]
        public static short read16i(ReadOnlySpan<byte> src)
            => @as<short>(read16u(src));

        [MethodImpl(Inline), Op]
        public static uint read32u(ReadOnlySpan<byte> src)
        {
            var len = src.Length;
            if(len >= 4)
                return first32u(src);
            else
                return read16u(src);
        }

        [MethodImpl(Inline), Op]
        public static int read32i(ReadOnlySpan<byte> src)
            => @as<int>(read32u(src));

        [MethodImpl(Inline), Op]
        public static float read32f(ReadOnlySpan<byte> src)
            => @as<float>(read32u(src));

        [MethodImpl(Inline), Op]
        public static ulong read64u(ReadOnlySpan<byte> src)
        {
            var len = src.Length;
            if(len >= 8)
                return first64u(src);
            else
                return read32u(src);
        }

        [MethodImpl(Inline), Op]
        public static long read64i(ReadOnlySpan<byte> src)
            => @as<long>(read64u(src));

        [MethodImpl(Inline), Op]
        public static double read64f(ReadOnlySpan<byte> src)
            => @as<double>(read64u(src));

        [MethodImpl(Inline), Op]
        public unsafe static void read(byte* pSrc, ByteSize size, out Span<byte> dst)
        {
            var buffer = alloc<byte>(size);
            Marshal.Copy((IntPtr)pSrc, buffer, 0, size);
            dst = buffer;
        }
    }
}