//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct TextGrids
    {

        [Op]
        public static Outcome<Count> normalize(string data, string delimiter, ReadOnlySpan<byte> widths, FilePath dst)
        {
            var result = parse(data, out var doc);
            var fieldCount = widths.Length;
            var header = doc.Header.ToRowHeader(delimiter, widths);
            if(header.CellCount != fieldCount)
                return (false,Tables.FieldCountMismatch.Format(fieldCount, header.CellCount));

            using var writer = dst.Writer();
            writer.WriteLine(header.Format());

            var rows = doc.Rows;
            var count = rows.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                var cells = row.Cells;
                if(row.CellCount != fieldCount)
                    return (false, Tables.FieldCountMismatch.Format(fieldCount, row.CellCount));

                for(var j=0; j<fieldCount; j++)
                {
                    ref readonly var cell = ref skip(cells,j);
                    var formatted = cell.Format(-skip(widths,j));
                    if(j != 0)
                        formatted = string.Format("{0}{1}",delimiter, formatted);
                    if(j != fieldCount - 1)
                        writer.Write(formatted);
                    else
                        writer.WriteLine(formatted);
                }
            }

            return (true, count);
        }

        public static Outcome load(FilePath src, TextEncodingKind encoding, out TextGrid dst)
        {
            dst = TextGrid.Empty;
            if(!src.Exists)
                return (false, FS.missing(src));

            using var reader = src.Reader(encoding);
            var result =  parse(reader);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                return (false, string.Format("Unable to parse grid: {0}", result.Message));
            }
        }

        public static Outcome load(FilePath src, out TextGrid dst)
            => load(src, TextDocFormat.Structured(), out dst);

        public static Outcome load(FilePath src, TextDocFormat format, out TextGrid dst)
        {
            dst = TextGrid.Empty;
            if(!src.Exists)
                return (false,FS.missing(src));

            using var reader = src.Utf8Reader();
            var attempt =  parse(reader,format);
            if(attempt)
            {
                dst = attempt.Value;
                return true;
            }
            else
            {
                return (false, attempt.Message?.ToString());
            }
        }

        public static ReadOnlySpan<TextGrid> load(ReadOnlySpan<FilePath> src)
        {
            var dst = sys.bag<TextGrid>();
            iter(src, path => {
                using var reader = path.Utf8Reader();
                var attempt = parse(reader);
                if(attempt)
                    dst.Add(attempt.Value);
            },true);
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static TextGrid<B> grid<B>(uint width, ReadOnlySpan<B> src)
            where B : unmanaged, IStorageBlock<B>
                => new TextGrid<B>(width,src);

        public static ReadOnlySpan<string> split(string src, in TextDocFormat spec)
            => sys.nonempty(src) ? spec.SplitClean ? src.SplitClean(spec.Delimiter) : src.Split(spec.Delimiter) : sys.empty<string>();

        /// Parses a header row from a line of text
        /// </summary>
        /// <param name="src">The source line</param>
        /// <param name="spec">The text format</param>
        [Op]
        public static bool header(TextLine src, in TextDocFormat spec, out TextDocHeader dst)
        {
            var parts = split(src.Content, spec);
            var count = parts.Length;
            var buffer = list<string>();

            if(parts.Length != 0)
            {
                for(var i=0; i<count; i++)
                {
                    var part = skip(parts,i).Trim();
                    if(nonempty(part))
                        buffer.Add(part);
                }
            }

            if(buffer.Count != 0)
            {
                dst = new TextDocHeader(buffer.ToArray());
                return true;
            }

            dst = TextDocHeader.Empty;
            return false;
        }

        public static ReadOnlySpan<string> header(string src, char delimiter)
        {
            var dst = Span<string>.Empty;
            if(nonempty(src))
            {
                var parts = src.SplitClean(delimiter).ToReadOnlySpan();
                var count = (uint)parts.Length;
                dst = span<string>(count);
                for(var i=0; i<count; i++)
                    seek(dst,i) = skip(parts,i);
            }
            return dst;
        }

        public static Outcome parse(string src, out TextGrid dst, TextDocFormat? format = null)
        {
            using var stream = src.ToStream();
            using var reader = stream.CreateReader();
            var result = parse(reader, format);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = default;
                return (false,result.Message?.ToString());
            }
        }

        public static Outcome load(ReadOnlySpan<string> src, out TextGrid dst)
        {
            dst = TextGrid.Empty;
            var result = Outcome.Success;
            var rows = list<TextRow>();
            var counter = 1u;
            var fmt = TextDocFormat.Structured();
            var comment = fmt.CommentPrefix;
            var rowsep = fmt.RowBlockSep;
            var count = src.Length;
            Option<TextDocHeader> docheader = default;

            try
            {
                for(var i=0; i<count; i++)
                {
                    var data = skip(src,i).Trim();

                    if(text.blank(data))
                        continue;

                    counter++;

                    var line = new TextLine(counter, data);
                    var lead = line[0];

                    // skip comments
                    if(lead == comment)
                        continue;

                    // skip row separators
                    if(line.Content.StartsWith(rowsep))
                        continue;

                    if(fmt.HasHeader && docheader.IsNone() && rows.Count == 0)
                    {
                        if(header(line, fmt, out var _docheader))
                            docheader = _docheader;
                    }
                    else
                    {
                        if(row(line,fmt, out var _row))
                            rows.Add(_row);
                    }
                }

                dst = new TextGrid(fmt, docheader ? docheader.Value : TextDocHeader.Empty, rows.ToArray());
            }
            catch(Exception e)
            {
                return e;
            }

            return result;
        }

        /// <summary>
        /// Attempts to parse a text document and returns the result if successful
        /// </summary>
        /// <param name="src">The source document path</param>
        /// <param name="format">The document format</param>
        /// <param name="observer">An optional observer to witness intersting events</param>
        public static ParseResult<TextGrid> parse(StreamReader reader, TextDocFormat? format = null)
        {
            var rows = list<TextRow>();
            var counter = 1u;
            var fmt = format ?? TextDocFormat.Structured();
            var comment = fmt.CommentPrefix;
            var rowsep = fmt.RowBlockSep;
            Option<TextDocHeader> docheader = default;
            try
            {
                while(!reader.EndOfStream)
                {
                    var data = reader.ReadLine().Trim();

                    counter++;

                    // Nothing to see here
                    if(text.blank(data))
                        continue;

                    var line = new TextLine(counter, data);
                    var lead = line[0];

                    // skip comments
                    if(lead == comment)
                        continue;

                    // skip row separators
                    if(line.Content.StartsWith(rowsep))
                        continue;

                    if(fmt.HasHeader && docheader.IsNone() && rows.Count == 0)
                    {
                        if(header(line, fmt, out var _docheader))
                            docheader = _docheader;
                    }
                    else
                    {
                        if(row(line,fmt, out var _row))
                            rows.Add(_row);
                    }
                }

                var doc = new TextGrid(fmt, docheader ? docheader.Value : TextDocHeader.Empty, rows.ToArray());
                return ParseResult.parsed(string.Empty, doc);
            }
            catch(Exception e)
            {
                return ParseResult.unparsed<TextGrid>(EmptyString,e);
            }
        }

        /// <summary>
        /// Parses a row from a line of text
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="spec">The text format spec</param>
        [Op]
        public static bool row(TextLine src, in TextDocFormat spec, out TextRow dst)
        {
            if(skipline(src, spec))
            {
                dst = TextRow.Empty;
                return false;
            }
            else
            {
                if(spec.HasHeader)
                {
                    var parts = split(src.Content, spec);
                    var count = parts.Length;
                    var buffer = alloc<TextBlock>(count);
                    ref var target= ref first(buffer);
                    for(var i=0u; i<count; i++)
                        seek(target, i) = new TextBlock(skip(parts,i).Trim());
                    dst= new TextRow(buffer);
                }
                else
                    dst = new TextRow(new TextBlock(src.Content));

                return true;
            }
        }

        public static ParseResult<string,TextGrid> parse(FilePath src, TextDocFormat? format = null)
        {
            using var reader = src.Utf8Reader();
            return parse(reader, format).Select(doc => ParseResult.parsed(src.Name.Format(), doc)).Value;
        }

        public static ParseResult<T> parse<T>(string data, Func<TextGrid,ParseResult<T>> pfx)
        {
            using var stream = Streams.memory(data);
            using var reader = Streams.reader(stream);
            return from doc in parse(reader)
                from content in pfx(doc)
                select content;
        }

        [MethodImpl(Inline), Op]
        static bool skipline(TextLine src, in TextDocFormat spec)
            => src.IsEmpty || src.StartsWith(spec.CommentPrefix) || src.StartsWith(spec.RowBlockSep);
    }
}