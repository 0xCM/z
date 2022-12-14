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
        /// Materializes an integral value from a bitspan segment
        /// </summary>
        /// <param name="src">The source bitspan</param>
        /// <param name="offset">The bit position at which the slice begins</param>
        /// <param name="count">The number of bits, at most bitsize[T], to pull</param>
        /// <typeparam name="T">The integral numeric type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T slice<T>(in BitSpan32 src, int offset, int count)
            where T : unmanaged
                => slice_u<T>(src,offset,count);

        [MethodImpl(Inline)]
        static T slice_u<T>(in BitSpan32 src, int offset, int count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(slice(src, w8, offset, count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(slice(src, w16, offset, count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(slice(src, w32, offset, count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(slice(src, w64, offset, count));
            else
                return slice_i<T>(src,offset,count);
        }

        [MethodImpl(Inline)]
        static T slice_i<T>(in BitSpan32 src, int offset, int count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(slice(src, w8i, offset, count));
            else if(typeof(T) == typeof(short))
                return generic<T>(slice(src, w16i, offset,count));
            else if(typeof(T) == typeof(int))
                return generic<T>(slice(src, w32i, offset,count));
            else if(typeof(T) == typeof(long))
                return generic<T>(slice(src, w64i, offset, count));
            else
                throw no<T>();
        }

        /// <summary>
        /// Materializes an 8-bit unsigned integer from a bitspan segment
        /// </summary>
        /// <param name="src">The source bitspan</param>
        /// <param name="w">The width selector</param>
        /// <param name="offset">The bit position at which the slice begins</param>
        /// <param name="count">The number of bits, at most 8, to pull</param>
        [MethodImpl(Inline), Op]
        public static byte slice(in BitSpan32 src, W8 w, int offset, int count)
        {
            var block = ByteBlocks.alloc(n8);
            var unpacked = block.Storage<Bit32>();
            ref var dst = ref ByteBlocks.first<Bit32>(ref block);
            memory.copy(in skip(src.Edit, offset), ref dst, count);
            return BitPack32.pack<byte>(unpacked);
        }

        /// <summary>
        /// Materializes a 16-bit unsigned integer from a bitspan segment
        /// </summary>
        /// <param name="src">The source bitspan</param>
        /// <param name="w">The width selector</param>
        /// <param name="offset">The bit position at which the slice begins</param>
        /// <param name="count">The number of bits, at most 16, to pull</param>
        [MethodImpl(Inline), Op]
        public static ushort slice(in BitSpan32 src, W16 w, int offset, int count)
        {
            var block = ByteBlocks.alloc(n16);
            var unpacked = block.Storage<Bit32>();
            ref var dst = ref ByteBlocks.first<Bit32>(ref block);
            memory.copy(in skip(src.Edit, offset), ref dst, count);
            return BitPack32.pack<ushort>(unpacked);
        }

        /// <summary>
        /// Materializes a 32-bit unsigned integer from a bitspan segment
        /// </summary>
        /// <param name="src">The source bitspan</param>
        /// <param name="w">The width selector</param>
        /// <param name="offset">The bit position at which the slice begins</param>
        /// <param name="count">The number of bits, at most 32, to pull</param>
        [MethodImpl(Inline), Op]
        public static uint slice(in BitSpan32 src, W32 w, int offset, int count)
        {
            var block = ByteBlocks.alloc(n32);
            var unpacked = block.Storage<Bit32>();
            var take = math.min(src.Edit.Length -offset, count);
            src.Edit.Slice(offset,take).CopyTo(unpacked);
            return BitPack32.pack<uint>(unpacked);
        }

        /// <summary>
        /// Materializes a 64-bit unsigned integer from a bitspan segment
        /// </summary>
        /// <param name="src">The source bitspan</param>
        /// <param name="w">The width selector</param>
        /// <param name="offset">The bit position at which the slice begins</param>
        /// <param name="count">The number of bits, at most 64, to pull</param>
        [MethodImpl(Inline), Op]
        public static ulong slice(in BitSpan32 src, W64 w, int offset, int count)
        {
            var buffer = ByteBlocks.alloc(n64);
            var unpacked = buffer.Storage<Bit32>();
            ref var dst = ref ByteBlocks.first<Bit32>(ref buffer);
            memory.copy(skip(src.Edit, offset), ref dst, count);
            return BitPack32.pack<ulong>(unpacked);
        }

        [MethodImpl(Inline), Op]
        public static sbyte slice(in BitSpan32 src, W8i w, int offset, int count)
        {
            var buffer = ByteBlocks.alloc(n8);
            var unpacked = buffer.Storage<Bit32>();
            ref var dst = ref ByteBlocks.first<Bit32>(ref buffer);
            memory.copy(skip(src.Edit, offset), ref dst, count);
            return BitPack32.pack<sbyte>(unpacked);
        }

        [MethodImpl(Inline), Op]
        public static short slice(in BitSpan32 src, W16i w, int offset, int count)
        {
            var buffer = ByteBlocks.alloc(n16);
            var unpacked = buffer.Storage<Bit32>();
            ref var dst = ref ByteBlocks.first<Bit32>(ref buffer);
            memory.copy(skip(src.Edit, offset), ref dst, count);
            return BitPack32.pack(unpacked, z16i);
        }

        [MethodImpl(Inline), Op]
        public static int slice(in BitSpan32 src, W32i w, int offset, int count)
        {
            var buffer = ByteBlocks.alloc(n32);
            var unpacked = buffer.Storage<Bit32>();
            ref var dst = ref ByteBlocks.first<Bit32>(ref buffer);
            memory.copy(skip(src.Edit, offset), ref dst, count);
            return BitPack32.pack(unpacked,z32i);
        }

        [MethodImpl(Inline), Op]
        public static long slice(in BitSpan32 src, W64i w, int offset, int count)
        {
            var buffer = ByteBlocks.alloc(n64);
            var unpacked = buffer.Storage<Bit32>();
            ref var dst = ref ByteBlocks.first<Bit32>(ref buffer);
            memory.copy(skip(src.Edit, offset), ref dst, count);
            return BitPack32.pack(unpacked, z64i);
        }
    }
}