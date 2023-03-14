//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {     
        [Table(TableIndex.Field), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct Field : IEcmaRecord<Field>
        {
            [Render(12)]
            public EcmaStringIndex Name;

            [Render(12)]
            public EcmaBlobIndex Sig;

            [Render(12)]
            public Address32 Offset;

            [Render(12)]
            public EcmaBlobIndex Marshal;

            [Render(1)]
            public FieldAttributes Attributes;
        }

        public readonly struct FieldContext : IEcmaContext<FieldContext,Field>
        {
            public readonly Field Record;
            
            public IEcmaReader Reader {get;}

            public FieldContext(IEcmaReader reader, Field record)
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
    }
}