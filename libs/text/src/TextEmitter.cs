//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    public sealed class TextEmitter : TextWriter, ITextEmitter
    {
        [MethodImpl(Inline)]
        public static ITextEmitter cover(StringBuilder src)
            => new TextEmitter(new TextBuffer(src), false);

        readonly bool Owns;

        readonly ITextBuffer Target;

        internal TextEmitter(ITextBuffer dst, bool owns)
        {
            Owns = owns;
            Target = dst;
        }

        void IDisposable.Dispose()
        {
            if(Owns)
            {
                if(Target is IDisposable d)
                    d.Dispose();
            }
        }

        public override Encoding Encoding
            => Target.Encoding;

        public override IFormatProvider FormatProvider
            => Target.FormatProvider;

        public override string NewLine
            => Target.NewLine;

        public override void Close()
        {
             if(Target is ITextWriter w)
                w.Close();
        }

        public string Emit(bool clear = true)
            => Target.Emit(clear);

        public override void Flush()
        {
             if(Target is ITextWriter w)
                w.Flush();
        }

        public override void Write(bool value)
            => Target.Write(value);

        public override void Write(char value)
            => Target.Write(value);

        public override void Write(char[]? buffer)
            => Target.Write(buffer);

        public override void Write(char[] buffer, int index, int count)
            => Target.Write(buffer, index, count);

        public override void Write(decimal value)
            => Target.Write(value);

        public override void Write(double value)
            => Target.Write(value);

        public override void Write(int value)
            => Target.Write(value);

        public override void Write(long value)
            => Target.Write(value);

        public override void Write(object? value)
            => Target.Write(value);

        public override void Write(ReadOnlySpan<char> buffer)
            => Target.Write(buffer);

        public override void Write(float value)
            => Target.Write(value);

        public override void Write(string? value)
            => Target.Write(value);

        public override void Write(string format, object? arg0)
            => Target.Write(format, arg0);

        public override void Write(string format, object? arg0, object? arg1)
            => Target.Write(format, arg0, arg1);

        public override void Write(string format, object? arg0, object? arg1, object? arg2)
            => Target.Write(format, arg0, arg1, arg2);

        public override void Write(string format, params object?[] arg)
            => Target.Write(format, arg);

        public override void Write(StringBuilder? value)
            => Target.Write(value);

        public override void Write(uint value)
            => Target.Write(value);

        public override void Write(ulong value)
            => Target.Write(value);

        public void AppendLine()
            => Target.WriteLine();

        public void Write(ITextBuffer src, bool reset = true)
            => Target.Write(src.Emit(reset));

        public void Append(ReadOnlySpan<char> src)
            => Target.Write(src);

        public void Append(char[] src)
            => Target.Write(src);

        public void Append(char c)
            => Target.Write(c);

        public void Append(string src)
            => Target.Write(src);

        public void Append<T>(T src)
            => Target.Append(src);

        public void AppendFormat(string pattern, params object[] args)
            => Target.Write(string.Format(pattern, args));

        public void AppendLineFormat(string pattern, params object[] src)
            => Target.WriteLine(string.Format(pattern, src));

        public void AppendLine(string src)
            => Target.WriteLine(src);

        public void AppendLine<T>(T src)
            => Target.WriteLine(src?.ToString() ?? RP.Null);

        public void IndentLine<T>(uint margin, T src)
            => Target.WriteLine(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public void IndentLineFormat(uint margin, string pattern, params object[] args)
            => IndentLine(margin, string.Format(pattern, args));

        public void Delimit(string delimiter, params object[] src)
            => Target.Delimit(delimiter, src);

        public void Delimit<T>(T content, char delimiter, int pad)
            => Target.Delimit(content, delimiter, pad);

        public void Delimit<F,T>(F label, T content, int pad = 0, char delimiter = '|')
            => Target.Delimit(label, content, pad, delimiter);

        public void AppendPadded<T,W>(T value, W width, string delimiter = EmptyString)
            => Target.AppendPadded(value,width,delimiter);

        public void Indent<T>(uint margin, T src)
            => Target.Indent(margin,src);

        public void IndentFormat<T>(uint margin, string pattern, T src)
            => Target.IndentFormat(margin, pattern,src);
    }

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static ITextEmitter Emitter(this TextWriter src)
            => new TextWriterWrap(src);

        [MethodImpl(Inline)]
        public static ITextEmitter Emitter(this StringBuilder src)
            => new TextBuffer(src);
    }
}