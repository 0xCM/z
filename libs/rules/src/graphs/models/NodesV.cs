//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Nodes<V>
    {
        /// <summary>
        /// Correlates sources with their targets
        /// </summary>
        Dictionary<Node<V>,List<Node<V>>> SourceIndex;

        /// <summary>
        /// Correlates targets with their sources
        /// </summary>
        Dictionary<Node<V>,List<Node<V>>> TargetIndex;

        public static Nodes<V> Build(Node<V>[] vertices, Arrow<Node<V>>[] edges)
        {
            var index = new Nodes<V>();
            index.SourceIndex = new Dictionary<Node<V>, List<Node<V>>>();
            index.TargetIndex = new Dictionary<Node<V>, List<Node<V>>>();

            for(var i=0; i<edges.Length; i++)
            {
                var edge = edges[i];
                if(index.SourceIndex.TryGetValue(edge.Source, out List<Node<V>> targets))
                    targets.Add(edge.Target);
                else
                    index.SourceIndex[edge.Source] = targets;

                if(index.TargetIndex.TryGetValue(edge.Target, out List<Node<V>> sources))
                    sources.Add(edge.Source);
                else
                    index.TargetIndex[edge.Target] = sources;
            }
            return index;

        }

        /// <summary>
        /// Retrieves the indices of a targets' source vertices
        /// </summary>
        /// <param name="source">The source vertex</param>
        [MethodImpl(Inline)]
        public List<Node<V>> Sources(Node<V> target)
        {
            if(SourceIndex.TryGetValue(target, out List<Node<V>> sources))
                return sources;
            else
                return new List<Node<V>>();
        }

        /// <summary>
        /// Retrieves the indices of a sources' target vertices
        /// </summary>
        /// <param name="source">The source vertex</param>
        [MethodImpl(Inline)]
        public List<Node<V>> Targets(Node<V> source)
        {
            if(TargetIndex.TryGetValue(source, out List<Node<V>> targets))
                return targets;
            else
                return new List<Node<V>>();
        }
    }
}