// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     partial struct core
//     {
//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static uint copy<T>(in MemoryCells<T> src, uint offset, uint cells, Span<T> dst)
//             where T : unmanaged
//         {
//             var j=0u;
//             var max = min(offset + cells, dst.Length);
//             for(var i=offset; i<max; i++)
//                 seek(dst,j++) = skip(src.View, i);
//             return j;
//         }

//         /// <summary>
//         /// Copies a source array to a target array
//         /// </summary>
//         /// <param name="src">The list containing the elements to copy</param>
//         /// <param name="dst">The array that will receive the copied elements</param>
//         /// <typeparam name="T">The element type</typeparam>
//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static int copy<T>(T[] src, T[] dst)
//         {
//             var count = min(src?.Length ?? 0, dst?.Length ?? 0);
//             if(count != 0)
//             {
//                 ref var target = ref sys.first(dst);
//                 ref readonly var source = ref sys.first(src);
//                 for(var i=0; i<count; i++)
//                     sys.seek(target,i) = sys.skip(source, i);
//             }
//             return count;
//         }

//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static unsafe void copy<T>(MemoryRange src, Span<T> dst)
//             where T : unmanaged
//                 => MemoryReader.create<T>(src).ReadAll(dst);

//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static uint copy<T>(Span<T> src, Span<T> dst)
//         {
//             var count = min(src.Length, dst.Length);
//             for(var i=0; i<count; i++)
//                 seek(dst,i) = skip(src,i);
//             return (uint)count;
//         }

//         /// <summary>
//         /// Copies a specified number of source values to the target and returns the count of copied bytes
//         /// </summary>
//         /// <param name="src">The source reference</param>
//         /// <param name="count">The number of source cells to copy</param>
//         /// <param name="dst">The target reference</param>
//         /// <typeparam name="S">The source type</typeparam>
//         /// <typeparam name="T">The target type</typeparam>
//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static ref T copy<S,T>(in S src, ref T dst, int count, int dstOffset = 0)
//             where S: unmanaged
//             where T :unmanaged
//         {
//             sys.copy(view<S,byte>(src), ref edit<T,byte>(add(dst, dstOffset)), (uint)count);
//             return ref dst;
//         }

//         /// <summary>
//         /// Copies a contiguous segments of bytes from one location to another
//         /// </summary>
//         /// <param name="pSrc">The location of the source bytes</param>
//         /// <param name="pDst">The location of the target</param>
//         /// <param name="srcCount">The number of values to copy</param>
//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static unsafe void copy(byte* pSrc, byte* pDst, uint srcCount)
//             => sys.copy(pSrc, pDst, srcCount);

//         /// <summary>
//         /// Copies a contiguous segments of values from one location to another
//         /// </summary>
//         /// <param name="pSrc">The location of the source bytes</param>
//         /// <param name="pDst">The location of the target</param>
//         /// <param name="srcCount">The number of values to copy</param>
//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static unsafe void copy<T>(T* pSrc, T* pDst, uint srcCount)
//             where T : unmanaged
//                 => sys.copy(pSrc, pDst, srcCount);

//         /// <summary>
//         /// Copies a contiguous segments of values to a span
//         /// </summary>
//         /// <param name="pSrc">The location of the source bytes</param>
//         /// <param name="pDst">The location of the target</param>
//         /// <param name="srcCount">The number of values to copy</param>
//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static unsafe void copy<T>(T* pSrc, Span<T> dst, int offset, uint srcCount)
//             where T : unmanaged
//                 => copy(pSrc, gptr(first(dst), offset), srcCount);

//         /// <summary>
//         /// Copies a contiguous segments of bytes from a source location to a target span
//         /// </summary>
//         /// <param name="pSrc">The location of the source bytes</param>
//         /// <param name="dst">The location of the target</param>
//         /// <param name="srcCount">The number of values to copy</param>
//         [MethodImpl(Inline), Op]
//         public static unsafe void copy(byte* pSrc, Span<byte> dst, int offset, uint srcCount)
//             => copy(pSrc, gptr(seek(dst, (uint)offset)) , srcCount);

//         /// <summary>
//         /// Copies a specified number source cells to the target and returns the count of copied bytes
//         /// </summary>
//         /// <param name="src">The data source</param>
//         /// <param name="start">The source start index</param>
//         /// <param name="count">The source cell count</param>
//         /// <param name="dst">The data target</param>
//         /// <param name="offset">The target offset</param>
//         /// <typeparam name="S">The source cell type</typeparam>
//         /// <typeparam name="T">The target cell type</typeparam>
//         [MethodImpl(Inline)]
//         public static uint copy<S,T>(ReadOnlySpan<S> src, int start, int count, Span<T> dst, int offset = 0)
//             where S: unmanaged
//             where T :unmanaged
//         {
//             ref var input =  ref u8(skip(src, (uint)start));
//             ref var target = ref u8(seek(dst, (uint)offset));
//             var bytecount =  (uint)(count*size<S>());
//             sys.copy(input, ref target, bytecount);
//             return bytecount;
//         }

//         /// <summary>
//         /// Copies a specified number source cells to the target and returns the count of copied bytes
//         /// </summary>
//         /// <param name="src">The data source</param>
//         /// <param name="start">The source start index</param>
//         /// <param name="count">The source cell count</param>
//         /// <param name="dst">The data target</param>
//         /// <param name="offset">The target offset</param>
//         /// <typeparam name="S">The source cell type</typeparam>
//         /// <typeparam name="T">The target cell type</typeparam>
//         [MethodImpl(Inline)]
//         public static uint copy<S,T>(Span<S> src, int start, int count, Span<T> dst, int offset = 0)
//             where S: unmanaged
//             where T :unmanaged
//                 => copy(src.ReadOnly(), start,count,dst,offset);

//         /// <summary>
//         /// Copies a specified number of source values to the target and returns the count of copied bytes
//         /// </summary>
//         /// <param name="src">The source reference</param>
//         /// <param name="srcCount">The number of source values to copy</param>
//         /// <param name="dst">The target reference</param>
//         /// <typeparam name="S">The source type</typeparam>
//         /// <typeparam name="T">The target type</typeparam>
//         [MethodImpl(Inline)]
//         public static void copy<S,T>(in S src, ref T dst, uint srcCount, uint dstOffset = 0)
//             where S: unmanaged
//             where T :unmanaged
//                 => sys.copy(u8(src), ref uint8(ref seek(dst, dstOffset)), srcCount*size<S>());

//         /// <summary>
//         /// Copies a specified number source cells to the target and returns the count of copied bytes
//         /// </summary>
//         /// <param name="src">The data source</param>
//         /// <param name="start">The source start index</param>
//         /// <param name="count">The source cell count</param>
//         /// <param name="dst">The data target</param>
//         /// <param name="offset">The target offset</param>
//         /// <typeparam name="S">The source cell type</typeparam>
//         /// <typeparam name="T">The target cell type</typeparam>
//         [MethodImpl(Inline)]
//         public static void copy<S,T>(ReadOnlySpan<S> src, uint start, uint count, Span<T> dst, uint offset = 0)
//             where S: unmanaged
//             where T :unmanaged
//                 => sys.copy(uint8(edit(skip(src, start))), ref uint8(ref seek(first(dst), offset)),count*size<S>());

//         /// <summary>
//         /// Copies a specified number source cells to the target and returns the count of copied bytes
//         /// </summary>
//         /// <param name="src">The data source</param>
//         /// <param name="start">The source start index</param>
//         /// <param name="count">The source cell count</param>
//         /// <param name="dst">The data target</param>
//         /// <param name="offset">The target offset</param>
//         /// <typeparam name="S">The source cell type</typeparam>
//         /// <typeparam name="T">The target cell type</typeparam>
//         [MethodImpl(Inline)]
//         public static void copy<S,T>(Span<S> src, uint start, uint count, Span<T> dst, uint offset = 0)
//             where S: unmanaged
//             where T :unmanaged
//                 => copy(@readonly(src), start, count, dst, offset);
//     }
// }