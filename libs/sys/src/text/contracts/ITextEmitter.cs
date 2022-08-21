//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    public interface ITextEmitter : IFormatProvider, IDisposable
    {
        void Write(bool value);

        void Write(char value);

        void Write(char[]? buffer);

        void Write(char[] buffer, int index, int count);

        void Write(decimal value);

        void Write(double value);

        void Write(int value);

        void Write(long value);

        void Write(object? value);

        void Write(ReadOnlySpan<char> buffer);

        void Write(float value);

        void Write(string? value);

        void Write(string format, object? arg0);

        void Write(string format, object? arg0, object? arg1);

        void Write(string format, object? arg0, object? arg1, object? arg2);

        void Write(string format, params object?[] arg);

        void Write(StringBuilder? value);

        void Write(uint value);

        void Write(ulong value);

        void WriteLine();

        void WriteLine(string src);

        void Append(string src);

        void Append(char[] src);

        void Append(char c);

        void Append<T>(T src);

        void Append(ReadOnlySpan<char> src);

        void AppendLine(string src)
            => WriteLine(src);

        void AppendLine();

        void AppendLine<T>(T src);

        void IndentLine<T>(uint margin, T src);

        void Indent<T>(uint margin, T src);

        void IndentFormat<T>(uint margin, string pattern, T src);

        void IndentLineFormat(uint margin, string pattern, params object[] args);

        void Delimit(string delimiter, params object[] src);

        void Delimit<T>(T content, char delimiter, int pad);

        void Delimit<F,T>(F label, T content, int pad = 0, char delimiter = '|');

        void AppendFormat(string pattern, params object[] args);

        void AppendLineFormat(string pattern, params object[] args);

        void AppendPadded<T,W>(T value, W width, string delimiter = EmptyString);

        IFormatProvider FormatProvider
            => this;

        object IFormatProvider.GetFormat(Type type)
            => System.Globalization.CultureInfo.CurrentCulture;

        void AppendSpace()
            => Write(' ');

        string NewLine
            => "\r\n";

        Encoding Encoding
            => System.Text.Encoding.UTF8;

        string Peek() => EmptyString;

        void Close()
            => throw new NotSupportedException();

        void Flush()
            => throw new NotSupportedException();

        void Clear()
            => throw new NotSupportedException();

        string Emit(bool clear = true)
            => throw new NotSupportedException();

        StringBuilder ToStringBuilder()
            => throw new NotSupportedException();
    }
}