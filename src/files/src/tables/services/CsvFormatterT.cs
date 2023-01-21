//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Tables;

    public struct CsvFormatter<T> : ICsvFormatter<T>
    {
        public readonly RowFormatSpec FormatSpec;

        internal RowAdapter<T> Adapter;

        ITextBuffer Buffer;

        [MethodImpl(Inline)]
        internal CsvFormatter(RowFormatSpec spec, RowAdapter<T> adapter)
        {
            FormatSpec = spec;
            Adapter = adapter;
            Buffer = text.buffer();
        }

        RowFormatSpec ICsvFormatter.FormatSpec
            => FormatSpec;

        public string Format(in T src)
            => FormatRecord(src, FormatSpec.FormatKind);

        public string Format(in T src, RecordFormatKind kind)
            => FormatRecord(src, kind);

        public string FormatHeader()
        {
            if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
                return FormatSpec.Header.Format();
            else
            {
                return string.Format(api.KvpPattern(FormatSpec), "Name", "Value");
            }
        }

        string FormatRecord(in T src, RecordFormatKind fk)
        {
            api.adapt(src, ref Adapter);
            if(fk == RecordFormatKind.Tablular)
                return Adapter.Adapted.Format(FormatSpec);
            else
            {
                Buffer.Clear();
                api.pairs(FormatSpec, Adapter, Buffer);
                return Buffer.Emit();
            }
        }
    }
}