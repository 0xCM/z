//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<Dependency<string>> DefDependencies()
        {
            return (Index<Dependency<string>>)DataSets.GetOrAdd(nameof(DefDependencies), key => Load());

            Index<Dependency<string>> Load()
            {
                var relations = DefRelations();
                var count = relations.Count;
                var dst = hashset<Dependency<string>>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var relation = ref relations[i];
                    ref readonly var child = ref relation.Name;
                    var ancestors = relation.AncestorNames;
                    if(ancestors.Length != 0)
                        dst.Add((child, ancestors.First));
                }

                return dst.Array().Sort();
            }
        }
    }
}