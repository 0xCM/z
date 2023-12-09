//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class ValueNodes<V>
{
    /// <summary>
    /// Correlates sources with their targets
    /// </summary>
    readonly Dictionary<ValueNode<V>,List<ValueNode<V>>> SourceIndex = new();

    /// <summary>
    /// Correlates targets with their sources
    /// </summary>
    readonly Dictionary<ValueNode<V>,List<ValueNode<V>>> TargetIndex = new();

    public static ValueNodes<V> Build(ValueNode<V>[] vertices, Arrow<ValueNode<V>>[] edges)
    {
        var dst = new ValueNodes<V>();

        for(var i=0; i<edges.Length; i++)
        {
            var edge = edges[i];
            if(dst.SourceIndex.TryGetValue(edge.Source, out List<ValueNode<V>> targets))
                targets.Add(edge.Target);
            else
                dst.SourceIndex[edge.Source] = targets;

            if(dst.TargetIndex.TryGetValue(edge.Target, out List<ValueNode<V>> sources))
                sources.Add(edge.Source);
            else
                dst.TargetIndex[edge.Target] = sources;
        }
        return dst;
    }

    /// <summary>
    /// Retrieves the indices of a targets' source vertices
    /// </summary>
    /// <param name="source">The source vertex</param>
    [MethodImpl(Inline)]
    public List<ValueNode<V>> Sources(ValueNode<V> target)
    {
        if(SourceIndex.TryGetValue(target, out List<ValueNode<V>> sources))
            return sources;
        else
            return new ();
    }

    /// <summary>
    /// Retrieves the indices of a sources' target vertices
    /// </summary>
    /// <param name="source">The source vertex</param>
    [MethodImpl(Inline)]
    public List<ValueNode<V>> Targets(ValueNode<V> source)
    {
        if(TargetIndex.TryGetValue(source, out List<ValueNode<V>> targets))
            return targets;
        else
            return new ();
    }
}
