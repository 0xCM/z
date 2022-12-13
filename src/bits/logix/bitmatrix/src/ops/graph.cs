//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitMatrix
    {
        /// <summary>
        /// Constructs the graph determined by an adjacency bitmatrix
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ValueGraph<T> graph<T>(in BitMatrix<T> A)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return graph(BitMatrix.load(n8,A.Content));
            else if(typeof(T) == typeof(ushort))
                return graph(BitMatrix.load(n16,A.Content));
            else if(typeof(T) == typeof(uint))
                return graph(BitMatrix.load(n32,A.Content));
            else if(typeof(T) == typeof(ulong))
                return graph(BitMatrix.load(n64,A.Content));
            else
                throw no<T>();
        }

        /// <summary>
        /// Constructs a 8-node graph via the adjacency matrix interpretation
        /// </summary>
        /// <param name="src">The source matrix</param>
        [MethodImpl(Inline), Op]
        public static ValueGraph<byte> graph(BitMatrix8 A)
            => graph(BitMatrix.natural(A));

        /// <summary>
        /// Constructs a 16-node graph via the adjacency matrix interpretation
        /// </summary>
        /// <param name="src">The source matrix</param>
        [MethodImpl(Inline), Op]
        public static ValueGraph<byte> graph(BitMatrix16 A)
            => graph(BitMatrix.natural(A));

        /// <summary>
        /// Constructs a 32-node graph via the adjacency matrix interpretation
        /// </summary>
        /// <param name="src">The source matrix</param>
        [MethodImpl(Inline), Op]
        public static ValueGraph<byte> graph(BitMatrix32 A)
            => graph(BitMatrix.natural(A));

        /// <summary>
        /// Constructs a 64-node graph via the adjacency matrix interpretation
        /// </summary>
        /// <param name="src">The source matrix</param>
        [MethodImpl(Inline), Op]
        public static ValueGraph<byte> graph(BitMatrix64 A)
            => graph(BitMatrix.natural(A));

        /// <summary>
        /// Constructs a graph from an adjacency bitmatrix of natural order
        /// </summary>
        /// <param name="src">The source matrix</param>
        /// <param name="dim">The dimension of the matrix</param>
        /// <param name="v">An arbitrary value to help type inference</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        /// <typeparam name="N">The dimension type</typeparam>
        /// <typeparam name="T">The source matrix element type</typeparam>
        static ValueGraph<T> graph<N,T>(BitMatrix<N,T> src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var n = nat32u<N>();
            var nodes = ValueGraphs.nodes<T>(n);
            var edges = new List<Arrow<ValueNode<T>>>();
            for(var row=0; row<n; row++)
            for(var col=0; col<n; col++)
                if(src[row,col])
                    edges.Add(ValueGraphs.connect(nodes[row], nodes[col]));
            return ValueGraphs.graph(nodes, edges.ToArray());
        }
    }
}