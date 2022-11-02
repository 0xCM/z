//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static sys;

    public class CsvEmitters
    {
        const NumericKind Closure = UInt64k;

        public static void emit<T>(IWfEventTarget log, ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var emitting = Events.emittingTable<T>(log.Host, dst);
            log.Deposit(emitting);
            var formatter = CsvFormatters.create(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
             var emitted = Events.emittedTable<T>(log.Host, rows.Length, dst);
             log.Deposit(emitted);
        }

        public static ExecToken emit<T>(IWfChannel channel, ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var emitting = channel.EmittingTable<T>(dst);
            var formatter = CsvFormatters.create(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
             return channel.EmittedTable(emitting, rows.Length, dst);
        }

        public static void emit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var formatter = CsvFormatters.create(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, StreamWriter dst)
            where T : struct
                => emit(src,Tables.rowspec<T>(Tables.DefaultFieldWidth), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, StreamWriter dst)
            where T : struct
        {
            var formatter = Tables.formatter<T>(spec);
            var count = src.Length;
            dst.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            dst.WriteLine(formatter.Format(skip(src,i)));
            return count;
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, Encoding encoding, FilePath dst)
            where T : struct
        {
            using var writer = dst.Writer(encoding);
            return emit(src, spec, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, TextEncodingKind encoding, FilePath dst)
            where T : struct
                => emit(src, spec, encoding.ToSystemEncoding(), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, FilePath dst)
            where T : struct
                => emit(src, spec, TextEncodingKind.Utf8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, Encoding encoding, FilePath dst)
            where T : struct
        {
            using var writer = dst.Writer(encoding);
            return emit(src, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, FilePath dst)
            where T : struct
                => emit(src, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FilePath dst)
            where T : struct
                => emit(src, widths, z16, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FilePath dst)
            where T : struct
                => emit(src, Tables.rowspec<T>(widths, rowpad), dst);

        public static Count emit<T>(ReadOnlySpan<T> src, ITextEmitter dst)
            where T : struct
        {
            var count = src.Length;
            var f = Tables.formatter<T>();
            dst.AppendLine(f.FormatHeader());
            for(var i=0; i<count; i++)
                dst.AppendLine(f.Format(skip(src,i)));
            return count;
        }        
    }

    partial struct Tables
    {
        public static ExecToken emit<T>(IWfChannel channel, ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var emitting = channel.EmittingTable<T>(dst);
            var formatter = CsvFormatters.create(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
             return channel.EmittedTable(emitting, rows.Length, dst);
        }

        public static void emit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var formatter = CsvFormatters.create(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, StreamWriter dst)
            where T : struct
                => emit(src,Tables.rowspec<T>(DefaultFieldWidth), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, StreamWriter dst)
            where T : struct
        {
            var formatter = Tables.formatter<T>(spec);
            var count = src.Length;
            dst.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            dst.WriteLine(formatter.Format(skip(src,i)));
            return count;
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, Encoding encoding, FilePath dst)
            where T : struct
        {
            using var writer = dst.Writer(encoding);
            return emit(src, spec, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, TextEncodingKind encoding, FilePath dst)
            where T : struct
                => emit(src, spec, encoding.ToSystemEncoding(), dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, RowFormatSpec spec, FilePath dst)
            where T : struct
                => emit(src, spec, TextEncodingKind.Utf8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, Encoding encoding, FilePath dst)
            where T : struct
        {
            using var writer = dst.Writer(encoding);
            return emit(src, writer);
        }

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, FilePath dst)
            where T : struct
                => emit(src, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FilePath dst)
            where T : struct
                => emit(src, widths, z16, Encoding.UTF8, dst);

        [Op, Closures(Closure)]
        public static Count emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FilePath dst)
            where T : struct
                => emit(src, rowspec<T>(widths, rowpad), dst);

        public static Count emit<T>(ReadOnlySpan<T> src, ITextEmitter dst)
            where T : struct
        {
            var count = src.Length;
            var f = formatter<T>();
            dst.AppendLine(f.FormatHeader());
            for(var i=0; i<count; i++)
                dst.AppendLine(f.Format(skip(src,i)));
            return count;
        }
    }
}