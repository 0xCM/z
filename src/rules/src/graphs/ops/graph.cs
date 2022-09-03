//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        /// <summary>
        /// Creates a graph from supplied vertices and edges
        /// </summary>
        /// <param name="nodes">The vertices in the graph</param>
        /// <param name="edges">The edges that connect the vertices</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        [MethodImpl(Inline)]
        public static Graph<V> graph<V>(Node<V>[] nodes, Arrow<Node<V>>[] edges)
            => new Graph<V>(nodes, edges);
    }
}