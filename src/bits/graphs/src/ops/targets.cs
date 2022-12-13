//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct ValueGraphs
    {
        /// <summary>
        /// Finds the edges in a graph that emit from an identified vertex
        /// </summary>
        /// <param name="graph">The declaring graph</param>
        /// <param name="target">The index of the target vertex</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        public static ReadOnlySpan<Arrow<ValueNode<V>>> targets<V>(ValueGraph<V> graph, V source)
            where V : IEquatable<V>
        {
            var count = graph.EdgeCount;
            var buffer = alloc<Arrow<ValueNode<V>>>(count);
            Span<Arrow<ValueNode<V>>> edges = buffer;
            var j = 0;
            for(var i = 0; i<count; i++)
            {
                ref readonly var edge = ref graph.Edge(i);
                if(edge.Source.Equals(source))
                    seek(edges,j++) = edge;
            }
            return slice(edges,0, j);
        }
    }
}