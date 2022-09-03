//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        Index<LlvmEntity> CalcEntities(Index<LineRelations> relations, Index<RecordField> fields)
            => (Index<LlvmEntity>)DataSets.GetOrAdd("Entities", _ => DataCalcs.CalcEntities(relations, fields));

        public Index<LlvmEntity> Entities(Func<LlvmEntity,bool> predicate)
            => Entities().Where(predicate);

        public Index<LlvmEntity> Entities(Index<LineRelations> relations, Index<RecordField> fields)
            => (Index<LlvmEntity>)CalcEntities(relations, fields);

        public Index<LlvmEntity> Entities()
            => (Index<LlvmEntity>)CalcEntities(DefRelations(), DefFields(LlvmTargetName.x86));
    }
}