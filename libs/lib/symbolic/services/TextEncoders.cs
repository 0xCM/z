//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    [ApiHost]
    public unsafe readonly struct TextEncoders
    {
        [MethodImpl(Inline), Op]
        public static TextEncoding service(Encoding src)
            => new TextEncoding(src);

        [MethodImpl(Inline), Op]
        public static int GetCharCount(Encoding e, ReadOnlySpan<byte> bytes)
            => e.GetCharCount(bytes);

        [MethodImpl(Inline), Op]
        public static int GetCharCount(Encoding e, byte* bytes, int count)
            => e.GetCharCount(bytes,count);

        [MethodImpl(Inline), Op]
        public static char[] GetChars(Encoding e, byte[] bytes)
            => e.GetChars(bytes);

        [MethodImpl(Inline), Op]
        public static int GetChars(Encoding e, byte* bytes, int byteCount, char* chars, int charCount)
            => e.GetChars(bytes,byteCount,chars,charCount);

        [MethodImpl(Inline), Op]
        public static int GetChars(Encoding e, ReadOnlySpan<byte> src, Span<char> dst)
            => e.GetChars(src,dst);

        [MethodImpl(Inline), Op]
        public static int GetByteCount(Encoding e, ReadOnlySpan<char> src)
            => e.GetByteCount(src);

        [MethodImpl(Inline), Op]
        public static int GetByteCount(Encoding e, string src)
            => e.GetByteCount(src);

        [MethodImpl(Inline), Op]
        public static int GetByteCount(Encoding e, string src, int index, int count)
            => e.GetByteCount(src, index, count);

        [MethodImpl(Inline), Op]
        public static int GetByteCount(Encoding e, char* src, int count)
            => e.GetByteCount(src, count);

        [MethodImpl(Inline), Op]
        public static byte[] GetBytes(Encoding e, string src)
            => e.GetBytes(src);

        [MethodImpl(Inline), Op]
        public static byte[] GetUtf8Bytes(string src)
            => utf8().GetBytes(src);

        [MethodImpl(Inline), Op]
        public static byte[] GetUtf8Bytes(char[] src)
            => utf8().GetBytes(src);

        [MethodImpl(Inline), Op]
        public static ref string DecodeUtf8(ReadOnlySpan<byte> src, out string dst)
        {
            dst = utf8().GetString(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref string DecodeUtf16(ReadOnlySpan<byte> src, out string dst)
        {
            dst = utf16().GetString(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static int GetUtf8Chars(ReadOnlySpan<byte> src, Span<char> dst)
            => utf8().GetChars(src, dst);

        [MethodImpl(Inline), Op]
        public static int GetBytes(Encoding e, ReadOnlySpan<char> src, Span<byte> dst)
            => e.GetBytes(src, dst);

        [MethodImpl(Inline), Op]
        public static byte[] GetBytes(Encoding e, char[] src)
            => e.GetBytes(src);

        [MethodImpl(Inline), Op]
        public static int GetBytes(Encoding e, char* src, int charCount, byte* bytes, int byteCount)
            => e.GetBytes(src, charCount, bytes, byteCount);

        [MethodImpl(Inline), Op]
        public static string GetString(Encoding e, byte[] src)
            => e.GetString(src);

        [MethodImpl(Inline), Op]
        public static string GetString(Encoding e, ReadOnlySpan<byte> src)
            => e.GetString(src);

        [MethodImpl(Inline), Op]
        public static string GetString(Encoding e, byte* src, int byteCount)
            => e.GetString(src, byteCount);

        [MethodImpl(Inline), Op]
        public static string GetString(Encoding e, byte[] src, int index, int count)
            => e.GetString(src, index, count);

        [MethodImpl(Inline), Op]
        public static ref string Decode(Encoding e, ReadOnlySpan<byte> src, out string dst)
        {
            dst = e.GetString(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref byte[] Encode(Encoding e, string src, out byte[] dst)
        {
            dst = e.GetBytes(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref byte[] Encode(Encoding e, char[] src, out byte[] dst)
        {
            dst = e.GetBytes(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static TextEncoding utf8()
            => new TextEncoding(Encoding.UTF8);

        [MethodImpl(Inline), Op]
        public static TextEncoding utf16()
            => new TextEncoding(Encoding.Unicode);
    }
}