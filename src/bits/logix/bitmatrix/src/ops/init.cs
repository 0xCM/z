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

    partial class BitMatrix
    {
        /// <summary>
        /// Creates a new generic bitmatrix where each row is initialized to a common source vector
        /// </summary>
        /// <param name="row">The source vector used to fill each row</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        public static BitMatrix<N,T> init<N,T>(in BitBlock<N,T> row)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var matrix = alloc<N,T>();
            var srcCellCount = BitBlock<N,T>.RequiredCells;
            var srcBitCount = nat64u<N>();
            ref readonly var src = ref row.Head;
            ref var dst = ref matrix.Head;
            for(var i=0u; i<srcBitCount; i++)
                core.copy(src, ref seek(dst, i*srcCellCount), (int)srcCellCount);
            return matrix;
        }

        /// <summary>
        /// Creates a new generic bitmatrix where each row is initialized to a common row
        /// </summary>
        /// <param name="row">The source vector used to fill each row</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        public static BitMatrix<M,N,T> init<M,N,T>(in BitBlock<N,T> row, M m = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
        {
            var matrix = alloc<M,N,T>();
            var srcCellCount = BitBlock<N,T>.RequiredCells;
            var srcBitCount = nat64u<N>();
            ref readonly var src = ref row.Head;
            ref var dst = ref matrix.Head;
            for(var i=0u; i< srcBitCount; i++)
                core.copy(src, ref seek(dst, i*srcCellCount), (int)srcCellCount);
            return matrix;
        }

        /// <summary>
        /// Creates a new primal bitmatrix where each row is initialized to a common source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitMatrix8 init(BitVector8 x)
        {
            var A = alloc(n8);
            A.Fill(x);
            return A;
        }

        /// <summary>
        /// Creates a new primal bitmatrix where each row is initialized to a common source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitMatrix16 init(BitVector16 x)
        {
            var A = alloc(n16);
            A.Content.Fill(x);
            return A;
        }

        /// <summary>
        /// Creates a new primal bitmatrix where each row is initialized to a common source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitMatrix32 init(BitVector32 x)
        {
            var A = alloc(n32);
            A.Content.Fill(x);
            return A;
        }

        /// <summary>
        /// Creates a new primal bitmatrix where each row is initialized to a common source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitMatrix64 init(BitVector64 x)
        {
            var A = alloc(n64);
            A.Bytes.AsUInt64().Fill(x);
            return A;
        }
    }
}