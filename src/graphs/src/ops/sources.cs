//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Graphs
    {
        /// <summary>
        /// Finds the edges in a graph that target an identified vertex
        /// </summary>
        /// <param name="graph">The declaring graph</param>
        /// <param name="target">The index of the target vertex</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        public static ReadOnlySpan<Arrow<Node<V>>> sources<V>(Graph<V> graph, V target)
        {
            var count = graph.EdgeCount;
            var buffer = alloc<Arrow<Node<V>>>(count);
            Span<Arrow<Node<V>>> edges = buffer;
            var j = 0;
            for(var i = 0; i<count; i++)
            {
                ref readonly var edge = ref graph.Edge(i);
                if(edge.Target.Equals(target))
                    seek(edges,j++) = edge;
            }
            return slice(edges,0, j);
        }
    }
}