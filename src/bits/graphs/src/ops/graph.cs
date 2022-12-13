//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ValueGraphs
    {
        /// <summary>
        /// Creates a graph from supplied vertices and edges
        /// </summary>
        /// <param name="nodes">The vertices in the graph</param>
        /// <param name="edges">The edges that connect the vertices</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        [MethodImpl(Inline)]
        public static ValueGraph<V> graph<V>(ValueNode<V>[] nodes, Arrow<ValueNode<V>>[] edges)
            => new ValueGraph<V>(nodes, edges);
    }
}