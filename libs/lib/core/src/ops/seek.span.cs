//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte seek8i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,sbyte>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte seek8<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,byte>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ushort seek16<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,ushort>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref short seek16i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,short>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint seek32<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,uint>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int seek32i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,int>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong seek64<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,ulong>(ref first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long seek64i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,long>(ref first(src)), (int)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<byte> src, uint count)
            => ref seek<byte,T>(skip(src,count*size<T>()), 1);

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

        [MethodImpl(Inline)]
        public static ref T seek<S,T>(Span<S> src, int offset = 0)
            where S : unmanaged
            where T : unmanaged
                => ref MemoryMarshal.AsRef<T>(src.Bytes(offset,null));
    }
}