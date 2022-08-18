//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.Unsafe;
    using static Root;

    partial struct core
    {
        /// <summary>
        /// Advances an S-reference in units measured by T-cells and returns the resulting T-cell reference
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of T-cells to advance</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ref T seek<S,T>(in S src, uint count)
            => ref Add(ref As<S,T>(ref edit(src)), (int)count);

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
    }
}