//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Expr;

    partial struct expr
    {
        /// <summary>
        /// Creates the empty vector
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v0<T> v<T>(N0 n)
            where T : unmanaged
                => default;

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v1<T> v<T>(N1 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v1<T> v<T>(N1 n, T a0)
            where T : unmanaged
                => a0;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v1<T> src)
            where T : unmanaged
                => ref @as<v1<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v1<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v2<T> v<T>(N2 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v2<T> v<T>(N2 n, T a0, T a1 = default)
            where T : unmanaged
        {
            var v = new v2<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v2<T> src)
            where T : unmanaged
                => ref @as<v2<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v2<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v2<T> src)
            where T : unmanaged
                => string.Format(RpOps.V2, src[0], src[1]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v3<T> v<T>(N3 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v3<T> v<T>(N3 n, T a0, T a1 = default, T a2 = default)
            where T : unmanaged
        {
            var v = new v3<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v3<T> v<T>(T a0, T a1, T a2)
            where T : unmanaged
        {
            var v = new v3<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v3<T> src)
            where T : unmanaged
                => ref @as<v3<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v3<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v3<T> src)
            where T : unmanaged
                => string.Format(RpOps.V3,
                    src[0], src[1], src[2]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v4<T> v<T>(N4 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v4<T> v<T>(N4 n, T a0, T a1 = default, T a2 = default, T a3 = default)
            where T : unmanaged
        {
            var v = new v4<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v4<T> v<T>(N4 n, v2<T> a0, v2<T> a1)
            where T : unmanaged
        {
            var v = new v4<T>();
            lo(ref v) = a0;
            hi(ref v) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v4<T> src)
            where T : unmanaged
                => ref @as<v4<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref v2<T> lo<T>(ref v4<T> src)
            where T : unmanaged
                => ref @as<v4<T>,v2<T>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref v2<T> hi<T>(ref v4<T> src)
            where T : unmanaged
                => ref seek(@as<v4<T>,v2<T>>(src),1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v4<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v4<T> src)
            where T : unmanaged
                => string.Format(RpOps.V4, src[0], src[1], src[2], src[3]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v5<T> v<T>(N5 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v5<T> v<T>(N5 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default)
            where T : unmanaged
        {
            var v = new v5<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v5<T> src)
            where T : unmanaged
                => ref @as<v5<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v5<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v5<T> src)
            where T : unmanaged
                => string.Format(RpOps.V5,
                    src[0], src[1], src[2], src[3], src[4]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v6<T> v<T>(N6 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v6<T> v<T>(N6 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default, T a5 = default)
            where T : unmanaged
        {
            var v = new v6<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v6<T> src)
            where T : unmanaged
                => ref @as<v6<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v6<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v6<T> src)
            where T : unmanaged
                => string.Format(RpOps.V6,
                    src[0], src[1], src[2], src[3], src[4], src[5]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v7<T> v<T>(N7 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v7<T> v<T>(N7 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default, T a5 = default, T a6 = default)
            where T : unmanaged
        {
            var v = new v7<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v7<T> src)
            where T : unmanaged
                => ref @as<v7<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v7<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v7<T> src)
            where T : unmanaged
                => string.Format(RpOps.V7,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[7]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v8<T> v<T>(N8 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v8<T> v<T>(N8 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default, T a5 = default, T a6 = default, T a7 = default)
            where T : unmanaged
        {
            var v = new v8<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
            seek(dst,7) = a7;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v8<T> src)
            where T : unmanaged
                => ref @as<v8<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref v4<T> lo<T>(ref v8<T> src)
            where T : unmanaged
                => ref @as<v8<T>,v4<T>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref v4<T> hi<T>(ref v8<T> src)
            where T : unmanaged
                => ref seek(@as<v8<T>,v4<T>>(src),1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v8<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v8<T> src)
            where T : unmanaged
                => string.Format(RpOps.V8,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v9<T> v<T>(N9 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v9<T> v<T>(N9 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default, T a5 = default, T a6 = default, T a7 = default, T a8 = default)
            where T : unmanaged
        {
            var v = new v9<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
            seek(dst,7) = a7;
            seek(dst,8) = a8;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v9<T> src)
            where T : unmanaged
                => ref @as<v9<T>,T>(src);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v9<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v9<T> src)
            where T : unmanaged
                => string.Format(RpOps.V9,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7], src[8]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v10<T> v<T>(N10 n)
            where T : unmanaged
                => default;

        public static string format<T>(in v10<T> src)
            where T : unmanaged
                => string.Format(RpOps.V8,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7],
                    src[8], src[9]);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v10<T> src)
            where T : unmanaged
                => ref @as<v10<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v10<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v11<T> v<T>(N11 n)
            where T : unmanaged
                => default;

        public static string format<T>(in v11<T> src)
            where T : unmanaged
                => string.Format(RpOps.V8,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7],
                    src[8], src[9], src[10]);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v11<T> src)
            where T : unmanaged
                => ref @as<v11<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v11<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v12<T> v<T>(N12 n)
            where T : unmanaged
                => default;
        public static string format<T>(in v12<T> src)
            where T : unmanaged
                => string.Format(RpOps.V8,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7],
                    src[8], src[9]);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v12<T> src)
            where T : unmanaged
                => ref @as<v12<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v12<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v16<T> v<T>(N16 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v16<T> v<T>(N16 n, v8<T> a0, v8<T> a1 = default)
            where T : unmanaged
        {
            var v = new v16<T>();
            ref var dst = ref @as<T,v8<T>>(cell(ref v));
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v16<T> src)
            where T : unmanaged
                => ref @as<v16<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v16<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v16<T> src)
            where T : unmanaged
                => string.Format(RpOps.V16,
                    src[0],  src[1],  src[2],  src[3],  src[4],  src[5],  src[6],  src[7],
                    src[8],  src[9],  src[10], src[11], src[12], src[13], src[14], src[15]
                    );

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v32<T> v<T>(N32 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v32<T> v<T>(N32 n, v16<T> a0, v16<T> a1 = default)
            where T : unmanaged
        {
            var v = new v32<T>();
            ref var dst = ref @as<T,v16<T>>(cell(ref v));
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v32<T> src)
            where T : unmanaged
                => ref @as<v32<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v32<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v32<T> src)
            where T : unmanaged
                => string.Format(RpOps.V32,
                    src[0],  src[1],  src[2],  src[3],  src[4],  src[5],  src[6],  src[7],  src[8], src[9],
                    src[10], src[11], src[12], src[13], src[14], src[15], src[16], src[17], src[18], src[19],
                    src[20], src[21], src[22], src[23], src[24], src[25], src[26], src[27], src[28], src[29],
                    src[30], src[31]
                    );

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v64<T> v<T>(N64 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v64<T> v<T>(N64 n, v32<T> a0, v32<T> a1 = default)
            where T : unmanaged
        {
            var v = new v64<T>();
            ref var dst = ref @as<T,v32<T>>(cell(ref v));
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v64<T> src)
            where T : unmanaged
                => ref @as<v64<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v64<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v1<T> src)
            where T : unmanaged
                => string.Format(RpOps.V1, src[0]);

        public static string format<T>(in v64<T> src)
            where T : unmanaged
                => string.Format(RpOps.V64,
                    src[0],  src[1],  src[2],  src[3],  src[4],  src[5],  src[6],  src[7],  src[8], src[9],
                    src[10], src[11], src[12], src[13], src[14], src[15], src[16], src[17], src[18], src[19],
                    src[20], src[21], src[22], src[23], src[24], src[25], src[26], src[27], src[28], src[29],
                    src[30], src[31], src[32], src[33], src[34], src[35], src[36], src[37], src[38], src[39],
                    src[40], src[41], src[42], src[43], src[44], src[45], src[46], src[47], src[48], src[49],
                    src[50], src[51], src[52], src[53], src[54], src[55], src[56], src[57], src[58], src[59],
                    src[60], src[61], src[62], src[63]
                    );


        [MethodImpl(Inline), Op]
        public static vNx1<bool> v(N1 n, bool[] src)
            => new vNx1<bool>(src);

        [MethodImpl(Inline), Op]
        public static vNx1<byte> v(N1 n, byte[] src)
            => new vNx1<byte>(src);

        [MethodImpl(Inline), Op]
        public static vNx8<byte> v(N8 n, byte[] src)
            => new vNx8<byte>(src);

        [MethodImpl(Inline), Op]
        public static vNx16<ushort> v(N16 n, ushort[] src)
            => new vNx16<ushort>(src);

        [MethodImpl(Inline), Op]
        public static vNx64<ulong> v(N64 n, ulong[] src)
            => new vNx64<ulong>(src);

        [MethodImpl(Inline), Op]
        public static vNx64<MemoryAddress> v(N64 n, MemoryAddress[] src)
            => new vNx64<MemoryAddress>(src);

       [MethodImpl(Inline), Op]
        public static vNx32<uint> v(N32 n,  uint[] src)
            => new vNx32<uint>(src);

        [MethodImpl(Inline)]
        public static vector<N,T> v<N,T>(N n, T[] src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            if(Typed.nat32i<N>() != src.Length)
                return vector<N,T>.Empty;
            else
                return new vector<N,T>(src);
        }

        public static string format<N,T>(in vector<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var cells = src.Cells;
            var count = cells.Length;
            var buffer = text.buffer();
            var last = cells.Length - 1;
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref skip(cells,i);
                var fmt = string.Format("{0}", cell).Trim();
                if(nonempty(fmt))
                {
                    buffer.Append(fmt);
                    if(i != last)
                        buffer.Append(Chars.Comma);

                }
                else
                    break;
            }
            return buffer.Emit();
        }
    }
}