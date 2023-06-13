//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static BinaryCode utf8(string src)
            => Encoding.UTF8.GetBytes(src);
    
        [MethodImpl(Inline), Op]
        public static string utf8(ReadOnlySpan<byte> src)
        {
            var i = SQ.nullpos(sys.recover<AsciCode>(src));
            if(i > 0)                        
                return Encoding.UTF8.GetString(sys.slice(src,0, i));
            else
                return Encoding.UTF8.GetString(src);

        }

        [MethodImpl(Inline), Op]
        public static void utf8(ReadOnlySpan<byte> src, Span<char> dst)
            => Encoding.UTF8.GetChars(src,dst);

        [MethodImpl(Inline), Op]
        public static unsafe string utf8(byte* pSrc, ByteSize size)
            => Encoding.UTF8.GetString(pSrc,size);
    }
}