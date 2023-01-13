//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = TextEncodingKind;

    using System.Text;

    using static sys;

    public readonly struct AsciPoints : ITextEncodingKind<AsciPoints>
    {
        public static AsciPoints Value => default;

        [MethodImpl(Inline), Op]
        public static string text(ReadOnlySpan<byte> src)
            => Encoding.ASCII.GetString(src);

        [MethodImpl(Inline), Op]
        public static unsafe string text(byte* pSrc, ByteSize size)
            => Encoding.ASCII.GetString(pSrc,size);

        [MethodImpl(Inline), Op]
        public static uint compact(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var chars = src;
            var count = (uint)min(chars.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (byte)skip(chars, i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<byte> src, Span<char> dst)
            => (uint)Encoding.ASCII.GetChars(src,dst);

        public K Kind => K.Asci;
    }
}