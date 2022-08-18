//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataCalcs
    {
        public ConstLookup<string,EntityLineage> CalcDefLineage(Index<LineRelations> src)
            => src.Select(r => new EntityLineage(r.Name, r.Ancestors)).Select(x => (x.EntityName,x)).Storage.ToConstLookup();
    }
}