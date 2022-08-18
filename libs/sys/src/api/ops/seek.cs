//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        /// <summary>
        /// Skips a specified number of pointer-identified elements and returns a reference to the result
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ref T seek<T>(T* pSrc, long count)
            where T : unmanaged
                => ref @ref(pSrc + size<T>()*count);

        /// <summary>
        /// Skips a specified number of pointer-identified elements and returns a reference to the result
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ref T seek<T>(T* pSrc, ulong count)
            where T : unmanaged
                => ref @ref(pSrc + size<T>()*count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(in T src, byte count)
            => ref Add(ref edit(src), (int)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(in T src, ushort count)
            => ref Add(ref edit(src), (int)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>
        /// Effects
        /// width[T]=8:  movsxd rax,edx => add rax,rcx
        /// width[T]=16: movsxd rax,edx => lea rax,[rcx+rax*2]
        /// width[T]=32: movsxd rax,edx => lea rax,[rcx+rax*4]
        /// width[T]=64: movsxd rax,edx => lea rax,[rcx+rax*8]
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(in T src, uint count)
            => ref Add(ref edit(src), (int)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(in T src, ulong count)
            => ref Add(ref edit(src), (int)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(in T src, long count)
            => ref Add(ref edit(src), (int)count);

       /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(in T src, int count)
            => ref Add(ref edit(src), count);

       /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, sbyte count)
            => ref add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, short count)
            => ref add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>
        /// Effects
        /// width[T]=8:  mov rax,[rcx] => movsxd rdx,edx => add rax,rdx
        /// width[T]=16: mov rax,[rcx] => movsxd rdx,edx => lea rax,[rax+rdx*2]
        /// width[T]=32: mov rax,[rcx] => movsxd rdx,edx => lea rax,[rax+rdx*4]
        /// width[T]=64: mov rax,[rcx] => movsxd rdx,edx => lea rax,[rax+rdx*8]
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, uint count)
            => ref add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, long count)
            => ref add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, ulong count)
            => ref add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, byte count)
            => ref add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, ushort count)
            => ref add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>Approach taken from https://github.com/windows-toolkit/WindowsCommunityToolkit/blob/81a23809c1fc2df912a4687487cae22581695064/Microsoft.Toolkit.HighPerformance%2FExtensions%2FArrayExtensions.1D.cs
        /// See <see cref ='RawArrayData'/> for details
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, ulong count)
        {
            var arrayData = Unsafe.As<RawArrayData>(src);
            ref T r0 = ref Unsafe.As<byte,T>(ref arrayData.Data);
            ref T ri = ref Unsafe.Add(ref r0, (nint)count);
            return ref ri;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, byte count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, ushort count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, int count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, uint count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, long count)
            => ref seek(src, (ulong)count);

        // https://github.com/windows-toolkit/WindowsCommunityToolkit/blob/81a23809c1fc2df912a4687487cae22581695064/Microsoft.Toolkit.HighPerformance%2FExtensions%2FArrayExtensions.1D.cs
        // Description taken from CoreCLR: see https://source.dot.net/#System.Private.CoreLib/src/System/Runtime/CompilerServices/RuntimeHelpers.CoreCLR.cs,285.
        // CLR arrays are laid out in memory as follows (multidimensional array bounds are optional):
        // [ sync block || pMethodTable || num components || MD array bounds || array data .. ]
        //                 ^                                 ^                  ^ returned reference
        //                 |                                 \-- ref Unsafe.As<RawArrayData>(array).Data
        //                 \-- array
        // The base size of an array includes all the fields before the array data,
        // including the sync block and method table. The reference to RawData.Data
        // points at the number of components, skipping over these two pointer-sized fields.
        [StructLayout(LayoutKind.Sequential)]
        sealed class RawArrayData
        {
            public IntPtr Length;

            public byte Data;
        }            
    }
}