//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    readonly struct TextWriterWrap : ITextWriter
    {
        readonly TextWriter Target;

        [MethodImpl(Inline)]
        public TextWriterWrap(TextWriter writer)
        {
            Target = writer;
        }

        public void Dispose()
            => Target?.Dispose();

        [MethodImpl(Inline)]
        public void Append(string src)
            => Target.Write(src);

        [MethodImpl(Inline)]
        public void Append(char[] src)
            => Target.Write(src);

        [MethodImpl(Inline)]
        public void Append(char c)
            => Target.Write(c);

        [MethodImpl(Inline)]
        public void Append<T>(T src)
            => Target.Write(src);

        [MethodImpl(Inline)]
        public void Append(ReadOnlySpan<char> src)
            => Target.Write(src);

        [MethodImpl(Inline)]
        public void Write(bool value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(char value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(char[] buffer)
           => Target.Write(buffer);

        [MethodImpl(Inline)]
        public void Write(char[] buffer, int index, int count)
           => Target.Write(buffer, index, count);

        [MethodImpl(Inline)]
        public void Write(decimal value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(double value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(int value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(long value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(object value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(ReadOnlySpan<char> buffer)
           => Target.Write(buffer);

        [MethodImpl(Inline)]
        public void Write(float value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(string value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(string format, object arg0)
           => Target.Write(format, arg0);

        [MethodImpl(Inline)]
        public void Write(string format, object arg0, object arg1)
           => Target.Write(format, arg0, arg1);

        [MethodImpl(Inline)]
        public void Write(string format, object arg0, object arg1, object arg2)
           => Target.Write(format, arg0, arg1, arg2);

        [MethodImpl(Inline)]
        public void Write(string format, params object[] arg)
           => Target.Write(format, arg);

        [MethodImpl(Inline)]
        public void Write(StringBuilder value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(uint value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void Write(ulong value)
           => Target.Write(value);

        [MethodImpl(Inline)]
        public void WriteLine()
            => Target.WriteLine();

        [MethodImpl(Inline)]
        public void WriteLine(string src)
            => Target.WriteLine(src);

        [MethodImpl(Inline)]
        public void AppendLine()
            => Target.WriteLine();

        [MethodImpl(Inline)]
        public void AppendLine<T>(T src)
            => Target.WriteLine(src);

        public void Indent<T>(uint margin, T src)
            => Target.Write(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public void IndentFormat<T>(uint margin, string format, T src)
            => Indent(margin, string.Format(format,src));

        public void IndentLine<T>(uint margin, T src)
            => AppendLine(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public void IndentLineFormat(uint margin, string pattern, params object[] args)
            => IndentLine(margin, string.Format(pattern, args));

        public void AppendFormat(string pattern, params object[] args)
            => Target.Write(pattern, args);

        public void AppendLineFormat(string pattern, params object[] args)
            => AppendLine(string.Format(pattern, args));

        public void Delimit(string delimiter, params object[] src)
        {
            var count = src.Length;
            var sep = string.Format("{0} ", delimiter);
            for(var i=0; i<src.Length; i++)
                Target.Write(string.Format("{0}{1}", sep, src[i]));
        }

        public void Delimit<T>(T content, char delimiter, int pad)
        {
            Target.Write(RP.rspace(delimiter));
            Target.Write($"{content}".PadRight((int)pad));
        }

        public void Delimit<F,T>(F label, T content, int pad = 0, char delimiter = '|')
        {
            Target.Write(RP.rspace(delimiter));
            Target.Write(string.Format(RP.pad(pad), label));
            Target.Write(content?.ToString() ?? RP.Null);
        }

        public void AppendPadded<T,W>(T value, W width, string delimiter = EmptyString)
        {
            if(sys.nonempty(delimiter))
                Target.Write(delimiter);
            Target.Write(string.Format(RP.pad(-TextBuffer.int16(width)), value));
        }

        public void Close()
            => Target.Close();

        public void Flush()
            => Target.Flush();

        [MethodImpl(Inline)]
        public static implicit operator TextWriter(TextWriterWrap src)
            => src.Target;

        [MethodImpl(Inline)]
        public static implicit operator TextWriterWrap(TextWriter src)
            => new TextWriterWrap(src);

        [MethodImpl(Inline)]
        public static implicit operator TextWriterWrap(StreamWriter src)
            => new TextWriterWrap(src);
    }
}