//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public ConstLookup<string,EntityLineage> ClassLineage()
        {
            return (ConstLookup<string,EntityLineage>)DataSets.GetOrAdd(nameof(ClassLineage), key => Load());

            ConstLookup<string,EntityLineage> Load()
            {
                var items = ClassRelations().Select(r => new EntityLineage(r.Name, r.Ancestors));
                return items.Select(x => (x.EntityName,x)).Storage.ToConstLookup();
            }
       }
    }
}