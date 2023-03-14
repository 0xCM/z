//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.Module)]
        public record struct Module : IEcmaRecord<Module>
        {
            public ushort Generation;

            public EcmaStringIndex Name;

            public EcmaGuidIndex MVId;

            public EcmaGuidIndex GenerationId;

            public EcmaGuidIndex BaseGenerationId;

            public Module(ushort generation, EcmaStringIndex name, EcmaGuidIndex mvId, EcmaGuidIndex encId, EcmaGuidIndex encBaseId)
            {
                this.Generation = generation;
                this.Name = name;
                this.MVId = mvId;
                this.GenerationId = encId;
                this.BaseGenerationId = encBaseId;
            }
        }

        public readonly struct ModuleContext : IEcmaContext<ModuleContext,Module>
        {
            public readonly Module Record;

            public IEcmaReader Reader {get;}

            public ModuleContext(IEcmaReader reader, Module record)
            {
                Reader = reader;
                Record = record;
            }

            public ushort Generation
                => Record.Generation;

            public string Name 
                => Reader.String(Record.Name);

            public Guid Mvid
                => Reader.Guid(Record.MVId);

            public Guid GenerationId
                => Reader.Guid(Record.GenerationId);

            public Guid BaseGenerationId
                => Reader.Guid(Record.BaseGenerationId);

        }
    }
}