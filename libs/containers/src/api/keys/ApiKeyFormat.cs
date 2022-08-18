//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct ApiKeyFormats
    {
        [MethodImpl(Inline)]
        public static byte render<N>(ApiKey src, N n, byte offset, Span<char> dst)
            where N : unmanaged, ITypeNat
        {
            var data = span16u(src.Data);
            var chars = Hex.render(LowerCase,skip(data, n.NatValue));
            seek(dst,offset + 0) = skip(chars,3);
            seek(dst,offset + 1) = skip(chars,2);
            seek(dst,offset + 2) = skip(chars,1);
            seek(dst,offset + 3) = skip(chars,0);
            return 4;
        }

        [MethodImpl(Inline)]
        static byte separate(byte offset, Span<char> dst)
        {
            seek(dst,offset + 0) = Chars.Space;
            seek(dst,offset + 1) = Chars.Pipe;
            seek(dst,offset + 2) = Chars.Space;
            return 3;
        }

        [Op]
        public static string list(ApiKey src)
        {
            var dst = text.buffer();
            var data = span16u(src.Data);
            var j = 0;
            var k = 0;

            const string Pair = "{0}:{1}";

            const string Delimited = Pair + ", ";

            dst.Append(Chars.LBracket);
            dst.Append(string.Format(Delimited, j++, skip(data, k++).ToString("x")));
            dst.Append(string.Format(Delimited, j++, skip(data, k++).ToString("x")));
            dst.Append(string.Format(Delimited, j++, skip(data, k++).ToString("x")));
            dst.Append(string.Format(Delimited, j++, skip(data, k++).ToString("x")));
            dst.Append(string.Format(Delimited, j++, skip(data, k++).ToString("x")));
            dst.Append(string.Format(Delimited, j++, skip(data, k++).ToString("x")));
            dst.Append(string.Format(Delimited, j++, skip(data, k++).ToString("x")));
            dst.Append(string.Format(Pair, j++, skip(data,k++).ToString("x")));
            dst.Append(Chars.RBracket);
            return dst.Emit();
        }

        [Op]
        public static string bitfield(ApiKey src)
        {
            var data = span16u(src.Data);
            var buffer = Storage.chars(n64).Data;
            ref var dst = ref first(buffer);

            var j=z8;

            seek(dst,j++) = Chars.LBracket;

            j += render(src, n7, j, buffer);
            j += separate(j, buffer);

            j += render(src, n6, j, buffer);
            j += separate(j, buffer);

            j += render(src, n5, j, buffer);
            j += separate(j, buffer);

            j += render(src, n4, j, buffer);
            j += separate(j, buffer);

            j += render(src, n3, j, buffer);
            j += separate(j, buffer);

            j += render(src, n2, j, buffer);
            j += separate(j, buffer);

            j += render(src, n1, j, buffer);
            j += separate(j, buffer);

            j += render(src, n0, j, buffer);

            seek(dst,j++) = Chars.RBracket;

            return new string(slice(buffer,0,j));
        }
    }
}