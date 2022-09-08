//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Eq = Equivalence;

    partial class Lines
    {
        public static ReadOnlySpan<Eq.ClassMember> relations(ReadOnlySpan<LineRelations> src)
        {
            var count = (uint)src.Length;
            var classes = Eq.lookup();
            var ancestors = dict<Eq.Class,string>();
            for(var i=0u; i<count; i++)
            {
                ref readonly var relation = ref skip(src,i);
                var @class = new Eq.Class(i, relation.Name);

                if(!classes.Include(@class))
                    continue;

                if(relation.Ancestors.HasAncestor)
                    ancestors[@class] = relation.Ancestors.Name;
            }

            var members = list<Eq.ClassMember>();
            var indexed = classes.Seal();
            for(var i=0u; i<indexed.Length; i++)
            {
                ref readonly var child = ref skip(indexed,i);
                if(ancestors.TryGetValue(child, out var a))
                {
                    if(classes.Find(a, out var parent))
                        members.Add(new Eq.ClassMember(parent, child.ClassId, child.ClassName));
                }
            }

            return members.ViewDeposited();
        }
    }
}