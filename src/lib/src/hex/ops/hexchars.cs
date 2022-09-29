//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static uint hexchars(Hex64 src, LowerCased @case, Span<char> dst)
        {
            var i=0u;
            var data = sys.bytes(src);
            var count = data.Length;
            for(var j=0; j<count; j++)
            {
                ref readonly var b = ref skip(data, j);
                render(@case, (Hex8)b, ref i, dst);
                if(j != count - 1)
                    seek(dst, i++) = Chars.Space;
            }
            return i;
        }

        [MethodImpl(Inline), Op]
        public static uint hexchars(Hex64 src, UpperCased @case, Span<char> dst)
        {
            var i=0u;
            var data = sys.bytes(src);
            var count = data.Length;
            for(var j=0; j<count; j++)
            {
                ref readonly var b = ref skip(data, j);
                render(@case, (Hex8)b, ref i, dst);
                if(j != count - 1)
                    seek(dst, i++) = Chars.Space;
            }
            return i;
        }

        [MethodImpl(Inline), Op]
        public static uint hexchars(Hex64 src, LowerCased @case, ref uint i, Span<char> dst)
        {
            var i0=i;
            var data = sys.bytes(src);
            var count = data.Length;
            for(var j=0; j<count; j++)
            {
                ref readonly var b = ref skip(data, j);
                render(@case, (Hex8)b, ref i, dst);
                if(j != count - 1)
                    seek(dst, i++) = Chars.Space;
            }
            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static uint hexchars(Hex64 src, UpperCased @case, ref uint i, Span<char> dst)
        {
            var i0=i;
            var data = sys.bytes(src);
            var count = data.Length;
            for(var j=0; j<count; j++)
            {
                ref readonly var b = ref skip(data, j);
                render(@case, (Hex8)b, ref i, dst);
                if(j != count - 1)
                    seek(dst, i++) = Chars.Space;
            }
            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static CharBlock24 hexchars(Hex64 src, LowerCased @case)
        {
            var dst = CharBlock24.Null;
            hexchars(src, @case, dst.Data);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static CharBlock24 hexchars(Hex64 src, UpperCased @case)
        {
            var dst = CharBlock24.Null;
            hexchars(src, @case, dst.Data);
            return dst;
        }
    }
}