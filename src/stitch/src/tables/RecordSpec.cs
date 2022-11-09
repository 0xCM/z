//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RecordSpec : ITextual
    {
        [Op]
        public static string format(in RecordSpec src)
        {
            var dst = text.build();
            dst.AppendLine(src.TypeName);
            for(var i=0; i<src.Fields.Length; i++)
                dst.AppendLine(src.Fields[i].ToString());
            return dst.ToString();
        }

        public Identifier TypeName {get;}

        readonly Index<ColumnSpec> FieldSpecs;

        [MethodImpl(Inline)]
        public RecordSpec(Identifier name, ColumnSpec[] cells)
        {
            TypeName = name;
            FieldSpecs = cells;
        }

        public ReadOnlySpan<ColumnSpec> Fields
        {
            [MethodImpl(Inline)]
            get => FieldSpecs.View;
        }

        public Count FieldCount
        {
            [MethodImpl(Inline)]
            get => FieldSpecs.Count;
        }
        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}