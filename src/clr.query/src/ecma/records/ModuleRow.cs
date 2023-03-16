//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.Module)]
        public record struct ModuleRow : IEcmaRecord<ModuleRow>
        {
            public ushort Generation;

            public EcmaStringIndex Name;

            public EcmaGuidIndex MVId;

            public EcmaGuidIndex GenerationId;

            public EcmaGuidIndex BaseGenerationId;

            public ModuleRow(ushort generation, EcmaStringIndex name, EcmaGuidIndex mvId, EcmaGuidIndex encId, EcmaGuidIndex encBaseId)
            {
                this.Generation = generation;
                this.Name = name;
                this.MVId = mvId;
                this.GenerationId = encId;
                this.BaseGenerationId = encBaseId;
            }
        }

    }
}