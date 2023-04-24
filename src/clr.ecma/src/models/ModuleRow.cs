//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [EcmaRow(TableIndex.Module), StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct ModuleRow : IEcmaRow<ModuleRow>
        {
            [Render(12)]
            public ushort Generation;

            [Render(12)]
            public EcmaStringKey Name;

            [Render(12)]
            public EcmaGuidKey MVId;

            [Render(16)]
            public EcmaGuidKey GenerationId;

            [Render(16)]
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