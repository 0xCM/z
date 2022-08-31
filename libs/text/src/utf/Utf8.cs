//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static sys;

    [ApiHost("utf8.svc")]
    public readonly unsafe struct Utf8
    {
        [MethodImpl(Inline), Op]
        public static TextEncoding encoding()
            => new TextEncoding(Encoding.UTF8);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> encode(string src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> encode(char[] src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static bool nonempty(utf8p src)
            => address(src.pData) != 0 && (*src.pData != 0);

        [MethodImpl(Inline), Op]
        public static ByteSize size(utf8p src)
        {
            var pData = src.pData;
            var size = 0ul;
            while(true)
            {
                if(*pData != 0)
                {
                    size++;
                    pData++;
                }
                else
                    break;
            }
            return size;
        }

        [MethodImpl(Inline), Op]
        public static int length(ReadOnlySpan<byte> src)
            => encoding().GetCharCount(src);

        [MethodImpl(Inline), Op]
        public static ref string decode(ReadOnlySpan<byte> src, out string dst)
        {
            dst = encoding().GetString(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static byte[] bytes(string src)
            => encoding().GetBytes(src);

        [MethodImpl(Inline), Op]
        public static byte[] bytes(char[] src)
            => encoding().GetBytes(src);

        /// <summary>
        /// Get number of bytes from offset to given terminator, null terminator, or end-of-block (whichever comes first).
        /// Returned length does not include the terminator, but numberOfBytesRead out parameter does.
        /// </summary>
        /// <param name="offset">Offset in to the block where the UTF8 bytes start.</param>
        /// <param name="terminator">A character in the ASCII range that marks the end of the string.
        /// If a value other than '\0' is passed we still stop at the null terminator if encountered first.</param>
        /// <param name="consumed">The number of bytes read, which includes the terminator if we did not hit the end of the block.</param>
        /// <returns>Length (byte count) not including terminator.</returns>
        /// <remarks>Adapted from https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata</remarks>
        [Op]
        public static unsafe uint length(byte* pSrc, uint maxlen, uint offset, out uint consumed)
        {
            byte* start = pSrc + offset;
            byte* end = pSrc + maxlen;
            byte* current = start;

            while (current < end)
            {
                var b = *current;
                if (b == 0 || b == Chars.Null)
                    break;

                current++;
            }

            var length = (uint)(current - start);
            consumed = length;
            if (current < end)
                consumed++; // null terminator

            return length;
        }
    }
}