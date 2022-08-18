//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct ApiKeys
    {
        [MethodImpl(Inline), Op]
        public static ApiKey key(PartId part, ushort host, ApiClass @class)
        {
            var dst = span16u(Cells.alloc(w128).Bytes);
            seek(dst,0) = (ushort)part;
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
    }
}