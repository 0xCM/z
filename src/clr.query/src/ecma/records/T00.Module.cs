//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(0)]
        public record struct Module
        {
            public ushort Generation;

            public EcmaStringIndex Name;

            public GuidIndex MVId;

            public GuidHandle GenerationId;

            public GuidHandle BaseGenerationId;

            public Module(ushort generation, EcmaStringIndex name, GuidIndex mvId, GuidHandle encId, GuidHandle encBaseId)
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