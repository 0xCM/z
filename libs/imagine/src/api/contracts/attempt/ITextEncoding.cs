//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITextEncoding<H> : IEncoding<char,byte>
    {
        string EncodingName {get;}

        int CodePage {get;}

        ReadOnlySpan<byte> Preamble {get;}

        int WindowsCodePage {get;}

        string WebName {get;}

        char[] GetChars(byte[] bytes);

        int GetCharCount(ReadOnlySpan<byte> bytes);

        unsafe int GetCharCount(byte* bytes, int count);

        unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount);

        byte[] GetBytes(string s);

        int GetChars(ReadOnlySpan<byte> src, Span<char> dst);

        uint IEncoder<char,byte>.Encode(ReadOnlySpan<char> src, Span<byte> dst)
            => (uint)GetBytes(src,dst);

        void IDecoder<byte,char>.Decode(ReadOnlySpan<byte> src, Span<char> dst)
            => GetChars(src,dst);

        /// <summary>
        /// Encodes the source into the target, returning the number of bytes injected
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The data target</param>
        int GetBytes(ReadOnlySpan<char> src, Span<byte> dst);

        byte[] GetBytes(char[] chars);

        int GetByteCount(ReadOnlySpan<char> chars);

        int GetByteCount(string s);

        int GetByteCount(string s, int index, int count);

        unsafe int GetByteCount(char* chars, int count);

        unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount);

        string GetString(byte[] bytes);

        string GetString(ReadOnlySpan<byte> bytes);

        unsafe string GetString(byte* bytes, int byteCount);

        string GetString(byte[] bytes, int index, int count);
    }
}