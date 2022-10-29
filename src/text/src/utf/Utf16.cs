//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static sys;

    [ApiHost("utf16.svc")]
    public readonly unsafe struct Utf16
    {
        [MethodImpl(Inline), Op]
        public static TextEncoding encoding()
            => new TextEncoding(Encoding.Unicode);

        [MethodImpl(Inline), Op]
        public static int length(ReadOnlySpan<byte> src)
            => encoding().GetCharCount(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> encode(string src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> encode(char[] src)
            => recover<byte>(src);

        [MethodImpl(Inline), Op]
        public static ref string decode(ReadOnlySpan<byte> src, out string dst)
        {
            dst = encoding().GetString(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteSize size(utf16p src)
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
        public static byte[] bytes(string src)
            => encoding().GetBytes(src);

        [MethodImpl(Inline), Op]
        public static byte[] bytes(char[] src)
            => encoding().GetBytes(src);

        [MethodImpl(Inline), Op]
        public static bool nonempty(utf16p src)
            => memory.address(src.pData) != 0 && (*src.pData != 0);
    }
}