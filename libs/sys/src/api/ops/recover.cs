//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial class sys
    {
        /// <summary>
        /// Presents a span of S-cells as a span of T-cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> recover<S,T>(Span<S> src)
            => CreateSpan(ref sys.@as<S,T>(sys.first(src)), (int)((src.Length * sys.size<S>())/sys.size<T>()));

        /// <summary>
        /// Presents a readonly span of S-cells as a readonly span of T-cells
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> recover<S,T>(ReadOnlySpan<S> src)
            => CreateReadOnlySpan(ref sys.@as<S,T>(sys.first(src)), (int)((src.Length * sys.size<S>())/sys.size<T>()));

        /// <summary>
        /// Presents a <see cref='sbyte'/> span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        /// <remarks>
        /// width[T] = 8: mov rax,[rdx] => [rcx],rax => mov dword ptr [rcx+8],1 => mov rax,rcx
        /// width[T] = 16: mov rax,[rdx] => [rcx],rax => mov dword ptr [rcx+8],2 => mov rax,rcx
        /// width[T] = 32: mov rax,[rdx] => [rcx],rax => mov dword ptr [rcx+8],4 => mov rax,rcx
        /// width[T] = 64: mov rax,[rdx] => [rcx],rax => mov dword ptr [rcx+8],8 => mov rax,rcx
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<sbyte> src)
            where T : struct
                => recover<sbyte,T>(src);

        /// <summary>
        /// Presents a <see cref='byte'/> span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        /// <remarks>
        /// Using the system-supplid cast function:
        /// 0000h sub rsp,28h
        /// 0004h nop
        /// 0005h mov rax,[rcx]
        /// 0008h mov ecx,[rcx+8]
        /// 000bh cmp ecx,1
        /// 000eh jl short 0018h
        /// 0010h movzx eax,byte ptr [rax]
        /// 0013h add rsp,28h
        /// 0017h ret
        /// 0018h mov ecx,28h
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<byte> src)
            where T : struct
                => recover<byte,T>(src);

        /// <summary>
        /// Presents a <see cref='short'/> span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<short> src)
            where T : struct
                => recover<short,T>(src);

        /// <summary>
        /// Presents a <see cref='ushort'/> span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<ushort> src)
            where T : struct
                => recover<ushort,T>(src);

        /// <summary>
        /// Presents a <see cref='char'/> span as a <typeparamref name='T'/> span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<char> src)
            where T : struct
                => recover<char,T>(src);

        /// <summary>
        /// Presents a <see cref='char'/> span as a <typeparamref name='T'/> span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<char> src)
            where T : struct
                => recover<char,T>(src);

        /// <summary>
        /// Presents a <see cref='int'/> span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<int> src)
            where T : struct
                 => recover<int,T>(src);

        /// <summary>
        /// Presents a <see cref='uint'/> span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<uint> src)
            where T : struct
                => recover<uint,T>(src);

        /// <summary>
        /// Presents a <see cref='long'/>-cell span as a T-cell span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<long> src)
            where T : struct
                 => recover<long,T>(src);

        /// <summary>
        /// Presents a <see cref='ulong'/>-cell span as a T-cell span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<ulong> src)
            where T : struct
                 => recover<ulong,T>(src);

        /// <summary>
        /// Presents a <see cref='float'/>-cell span as a T-cell span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<float> src)
            where T : struct
                => recover<float,T>(src);

        /// <summary>
        /// Presents a <see cref='double'/>-cell span as a T-cell span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<double> src)
            where T : struct
                => recover<double,T>(src);

        /// <summary>
        /// Presents a <see cref='decimal'/>-cell span as a T-cell span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> recover<T>(ReadOnlySpan<decimal> src)
            where T : struct
                => recover<decimal,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<byte> src)
            where T : struct
                => recover<byte,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<uint> src)
            where T : struct
                => recover<uint,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<sbyte> src)
            where T : struct
                => recover<sbyte,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<short> src)
            where T : struct
                => recover<short,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<ushort> src)
            where T : struct
                => recover<ushort,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<int> src)
            where T : struct
                => recover<int,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<long> src)
            where T : struct
                => recover<long,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<ulong> src)
            where T : struct
                 => recover<ulong,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<float> src)
            where T : struct
                 => recover<float,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<double> src)
            where T : struct
                 => recover<double,T>(src);

        /// <summary>
        /// Presents a source span as a T-span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> recover<T>(Span<decimal> src)
            where T : struct
                 => recover<decimal,T>(src);
    }
}