//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;
    using static EcmaViews;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static FieldView View(this FieldRow row, IEcmaReader reader)
            => new FieldView(reader,row);

        [MethodImpl(Inline), Op]
        public static ModuleView View(this ModuleRow row, IEcmaReader reader)
            => new ModuleView(reader,row);

    }
    [ApiHost]
    public partial class EcmaViews
    {
        public readonly struct FieldView : IEcmaView<FieldView,FieldRow>
        {
            public readonly FieldRow Record;
            
            public IEcmaReader Reader {get;}

            public FieldView(IEcmaReader reader, FieldRow record)
            {
                Reader = reader;
                Record = record;
            }

            public string Name 
                => Reader.String(Record.Name);

            public ReadOnlySpan<byte> Sig
                => Reader.Blob(Record.Sig);
            
            public Address32 Offset
                => Record.Offset;

            public ReadOnlySpan<byte> Marshal
                => Reader.Blob(Record.Marshal);

            public FieldAttributes Attributes
                => Record.Attributes;
        }    

        public readonly struct ModuleView : IEcmaView<ModuleView,ModuleRow>
        {
            public readonly ModuleRow Record;

            public IEcmaReader Reader {get;}

            public ModuleView(IEcmaReader reader, ModuleRow record)
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