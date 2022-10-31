//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct ApiKeys
    {
        [MethodImpl(Inline)]
        public Hex32 id(PartName part)
            => (Hex32)sys.hash(part);

        [Op]
        public static string format(ApiKey src)
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

        [MethodImpl(Inline), Op]
        public static ApiKey key(PartName part, ushort host, ApiClass @class)
        {
            var dst = span16u(Cells.alloc(w128).Bytes);
            seek(dst,0) = (ushort)(uint)sys.hash(part);
            seek(dst,1) = host;
            seek(dst,2) = @class;
            return key(dst);
        }

        [MethodImpl(Inline), Op]
        public static ApiKey key(PartId part, ushort host, ApiClass @class, params ushort[] data)
        {
            var dst = span16u(Cells.alloc(w128).Bytes);
            seek(dst,0) = (ushort)part;
            seek(dst,1) = host;
            seek(dst,2) = @class;
            var src = @readonly(data);
            for(var i=3; i<data.Length + 3; i++)
                seek(dst,i) = skip(src,i);
            return key(dst);
        }

        [MethodImpl(Inline), Op]
        public static ApiKey key(ReadOnlySpan<byte> src)
            => new ApiKey(src);

        [MethodImpl(Inline), Op]
        public static ApiKey key(ReadOnlySpan<ushort> src)
            => new ApiKey(src);

        [MethodImpl(Inline), Op]
        public static ApiKey key(ReadOnlySpan<ApiKeySeg> src)
            => new ApiKey(src);

        [MethodImpl(Inline), Op]
        public static ApiKeySeg segment(ReadOnlySpan<byte> src)
            => first(span16u(src));

        [MethodImpl(Inline), Op]
        public static ApiKeySeg segment(ushort src)
            => new ApiKeySeg(src);

        [MethodImpl(Inline), Op]
        public static ApiKeyJoin join(ReadOnlySpan<byte> src)
            => first(span32u(src));

        [MethodImpl(Inline), Op]
        public static ApiKey insert(ApiKey src, byte index, ApiKeySeg seg)
            => src.WithSeg(index, seg);

        [MethodImpl(Inline), Op]
        public static ApiKeyJoin join(uint src)
        {
            var left = (ushort)(src & ushort.MaxValue);
            var right = (ushort)(src >> 16);
            return new ApiKeyJoin(left,right);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> data(ApiKeyJoin src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> data(ApiKeySeg src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(ApiKeySeg src)
        {
            ushort data = src;
            return Hex.render(LowerCase, data);
        }

        [MethodImpl(Inline), Op]
        public static void render(ApiKeySeg src, Span<char> dst)
        {
            ushort data = src;
            Hex.render(LowerCase, data, 0, dst);
        }

        [MethodImpl(Inline), Op]
        public static K kind<K>(ApiKey src)
            => @as<ApiKeySeg,K>(src.Seg(n2));

        [MethodImpl(Inline), Op]
        public static ApiKey<K> kind<K>(K kind, ApiKey src)
            where K : unmanaged
                => insert(src, 2, segment(bw16(kind)));

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