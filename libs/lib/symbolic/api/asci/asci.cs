//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static AsciSymbols;
    using static AsciChars;

    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static asci8 asci(N8 n, char src)
            => new asci8((ulong)src);

        [MethodImpl(Inline), Op]
        public static asci8 asci(N8 n, ReadOnlySpan<byte> src)
        {
            var length = (byte)min(available(src), asci8.Size);
            var storage = 0ul;
            var dst = bytes(storage);
            for(var i=0; i<length; i++)
                seek(dst,i) = skip(src,i);
            return new (storage);
        }
    }
}