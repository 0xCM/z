//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static System.Runtime.CompilerServices.Unsafe;

    public class TextBuffer : ITextBuffer
    {
        [MethodImpl(Inline)]
        internal static short int16<T>(T src)
            => As<T,short>(ref src);

        readonly StringBuilder Target;

        [MethodImpl(Inline)]
        public TextBuffer(StringBuilder dst)
            => Target = dst;

        [MethodImpl(Inline)]
        public TextBuffer(uint capacity)
            => Target = new StringBuilder((int)capacity);

        [MethodImpl(Inline)]
        public StringBuilder ToStringBuilder()
            => Target;

        public override string ToString()
            => Target.ToString();

        public string Peek()
            => ToString();

        public string Emit(bool reset = true)
        {
            var content = Target.ToString();
            if(reset)
                Clear();
            return content;
        }

        public void Clear()
        {
            Target.Clear();
        }

        public void Append(string src)
            => Target.Append(src);

        public void AppendLine(string src)
            => Target.AppendLine(src);

        public void AppendLine()
            => Target.AppendLine();

        public void Append(char src)
            => Target.Append(src);

        public void Append(char[] src)
            => Target.Append(src);

        public void Append<T>(T src)
            => Target.Append(src);

        public void Append(ReadOnlySpan<char> src)
            => Target.Append(src);

        public void AppendFormat(string pattern, params object[] args)
            => Target.AppendFormat(pattern, args);

        public void AppendLineFormat(string pattern, params object[] args)
            => AppendLine(string.Format(pattern, args));

        public void AppendLine<T>(T src)
            => Target.AppendLine(src?.ToString() ?? RP.Null);

        public void Indent<T>(uint margin, T src)
            => Target.Append(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public void IndentFormat<T>(uint margin, string format, T src)
            => Indent(margin, string.Format(format,src));

        public void IndentLine<T>(uint margin, T src)
            => AppendLine(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public void IndentLineFormat(uint margin, string pattern, params object[] args)
            => IndentLine(margin, string.Format(pattern, args));

        public void AppendPadded<T,W>(T value, W width, string delimiter = EmptyString)
        {
            if(sys.nonempty(delimiter))
                Target.Append(delimiter);
            Target.Append(string.Format(RP.pad(-int16(width)), value));
        }

        public void Delimit(string delimiter, params object[] src)
        {
            var count = src.Length;
            var terms = src;
            var sep = string.Format("{0} ", delimiter);
            for(var i=0; i<src.Length; i++)
                Target.Append(string.Format("{0}{1}", sep, terms[i]));
        }

        public void Delimit<T>(T content, char delimiter, int pad)
        {
            Target.Append(RP.rspace(delimiter));
            Target.Append($"{content}".PadRight((int)pad));
        }

        public void Delimit<F,T>(F label, T content, int pad = 0, char delimiter = Chars.Pipe)
        {
            Target.Append(RP.rspace(delimiter));
            Target.AppendFormat(RP.pad(pad), label);
            Target.Append(content);
        }

        public void Write(bool value)
            => Target.Append(value);

        public void Write(char value)
            => Target.Append(value);

        public void Write(char[]? buffer)
            => Target.Append(buffer);

        public void Write(char[] buffer, int index, int count)
            => Target.Append(buffer, index, count);

        public void Write(decimal value)
            => Target.Append(value);

        public void Write(double value)
            => Target.Append(value);

        public void Write(int value)
            => Target.Append(value);

        public void Write(long value)
            => Target.Append(value);

        public void Write(object? value)
            => Target.Append(value);

        public void Write(ReadOnlySpan<char> buffer)
            => Target.Append(buffer);

        public void Write(float value)
            => Target.Append(value);

        public void Write(string? value)
            => Target.Append(value);

        public void Write(string format, object? arg0)
            => Target.AppendFormat(format, arg0);

        public void Write(string format, object? arg0, object? arg1)
            => Target.AppendFormat(format, arg0, arg1);

        public void Write(string format, object? arg0, object? arg1, object? arg2)
            => Target.AppendFormat(format, arg0, arg1, arg2);

        public void Write(string format, params object?[] arg)
            => Target.AppendFormat(format, arg);

        public void Write(StringBuilder? value)
            => Target.Append(value);

        public void Write(uint value)
            => Target.Append(value);

        public void Write(ulong value)
            => Target.Append(value);

        [MethodImpl(Inline)]
        public void WriteLine()
            => Target.AppendLine();

        [MethodImpl(Inline)]
        public void WriteLine(string src)
            => Target.AppendLine(src);

        void IDisposable.Dispose()
        {

        }
    }
}