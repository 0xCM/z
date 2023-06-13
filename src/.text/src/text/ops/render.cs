//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<AsciCode> src, ref uint i, Span<char> dst)
        {
            var count = (uint)src.Length;
            for(var j=0; j<count; j++)
                seek(dst,i++) = (char)skip(src,j);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<AsciSymbol> src, ref uint i, Span<char> dst)
            => render(recover<AsciSymbol,AsciCode>(src), ref i, dst);

        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<char> src, ref uint i, Span<byte> dst)
        {
            var i0=i;
            for(var j=0; j<src.Length; j++)
                seek(dst,i++) = (byte)skip(src,j);
            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<char> src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = (uint)src.Length;
            for(var j=0; j<count; j++)
                seek(dst,i++) = skip(src,j);
            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var i=0u;
            return render(src, ref i, dst);
        }

        [MethodImpl(Inline), Op]
        public static void render(ReadOnlySpan<char> src, ITextBuffer dst)
            => dst.Append(src);

        [MethodImpl(Inline), Op]
        public static void render(ReadOnlySpan<char> src, ITextBuffer dst, bool eol)
        {
            dst.Append(src);
            if(eol)
                dst.Append(RP.WinEol);
        }

        [Op]
        public static void render(ReadOnlySpan<string> src, char delimiter, ITextBuffer dst)
        {
            const string DelimitPattern = " {0} ";
            var last = src.Length - 1;
            var count = src.Length;
            var sep = string.Format(DelimitPattern, delimiter);

            for(var i=0; i<count; i++)
            {
                dst.Append(sep);

                ref readonly var s = ref skip(src,i);
                if(i != last)
                    dst.Append(s.PadRight(16));
                else
                    dst.Append(s);
            }
        }
    }
}