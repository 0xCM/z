//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Extracts operations from an api host
    /// </summary>
    public readonly struct ApiMemberExtractor
    {
        const int DefaultBufferLength = Pow2.T14 + Pow2.T08;

        [Op]
        public static byte[] buffer(ByteSize? size = null)
            => sys.alloc<byte>(size ?? DefaultBufferLength);

        [Op]
        public static ApiMemberExtractor create()
            => new ApiMemberExtractor(buffer());

        [MethodImpl(Inline), Op]
        public static ApiMemberExtractor create(byte[] buffer)
            => new ApiMemberExtractor(buffer);

        readonly byte[] _Buffer;

        Span<byte> Buffer
        {
            [MethodImpl(Inline)]
            get
            {
                Span<byte> buffer = _Buffer;
                buffer.Clear();
                return buffer;
            }
        }

        [MethodImpl(Inline)]
        internal ApiMemberExtractor(byte[] buffer)
            => _Buffer = buffer;

        [MethodImpl(Inline)]
        public Index<ApiMemberExtract> Extract(ApiMembers src)
            => ApiCode.extract(src.View, Buffer);
    }
}