//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Tables;

    public class CsvFormatter : ICsvFormatter
    {
        internal class Formatter2<T> : ICsvFormatter<T>
            where T : struct
        {
            readonly RenderBuffers Buffers;

            public Formatter2(RowFormatSpec spec, RowAdapter adapter)
            {
                Buffers =RenderBuffers.create(spec.CellCount);
                FormatSpec = spec;
                Adapter = adapter;
            }

            public RowFormatSpec FormatSpec {get;}

            RowAdapter Adapter;

            public string Format(in T src)
            {
                api.adapt(src, ref Adapter);
                return api.format(FormatSpec, Buffers, Adapter.Adapted);
            }

            public string FormatHeader()
            {
                if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
                    return FormatSpec.Header.Format();
                else
                    return string.Format(Tables.KvpPattern(FormatSpec), "Name", "Value");
            }
        }

        RowAdapter Adapter;

        public readonly RowFormatSpec FormatSpec;

        public readonly TableId TableId;

        readonly RenderBuffers Buffers;

        [MethodImpl(Inline)]
        internal CsvFormatter(Type record, RowFormatSpec spec, RowAdapter adapter)
        {
            TableId = Tables.identify(record);
            FormatSpec = spec;
            Adapter = adapter;
            Buffers =RenderBuffers.create(spec.CellCount);
        }

        public string Format<T>(in T src)
            where T : struct
        {
            api.adapt<T>(src, ref Adapter);
            return api.format(FormatSpec, Buffers, Adapter.Adapted);
        }

        public string FormatHeader()
        {
            if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
                return FormatSpec.Header.Format();
            else
                return string.Format(Tables.KvpPattern(FormatSpec), "Name", "Value");
        }

        RowFormatSpec ICsvFormatter.FormatSpec
            => FormatSpec;

        TableId ICsvFormatter.TableId
            => TableId;

        /// <summary>
        /// Defines a row over a specified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        internal struct RowAdapter
        {
            internal uint Index;

            internal dynamic Source;

            internal DynamicRow Row;

            public readonly Type RowType;

            [MethodImpl(Inline)]
            internal RowAdapter(Type type, ClrTableCells fields)
            {
                RowType = type;
                Source = type;
                Index = 0;
                Row = Tables.dynarow(fields);
            }

            public readonly DynamicRow Adapted
            {
                [MethodImpl(Inline)]
                get => Row;
            }
        }
    }
}