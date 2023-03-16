//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.Module)]
        public record struct ModuleRow : IEcmaRow<ModuleRow>
        {
            public ushort Generation;

            public EcmaStringKey Name;

            public EcmaGuidKey MVId;

            public EcmaGuidKey GenerationId;

            public EcmaGuidKey BaseGenerationId;

            public ModuleRow(ushort generation, EcmaStringKey name, EcmaGuidKey mvId, EcmaGuidKey encId, EcmaGuidKey encBaseId)
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