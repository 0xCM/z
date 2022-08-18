//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = ApiKeys;

    public readonly struct ApiKeyJoin
    {
        public readonly ApiKeySeg Left;

        public readonly ApiKeySeg Right;

        [MethodImpl(Inline)]
        public ApiKeyJoin(ApiKeySeg left, ApiKeySeg right)
        {
            Left = left;
            Right = right;
        }

        public DataWidth Width => DataWidth.W32;

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<byte>(ApiKeyJoin src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator ApiKeyJoin(ReadOnlySpan<byte> src)
            => api.join(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiKeyJoin(uint src)
            => api.join(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiKeyJoin((ApiKeySeg left, ApiKeySeg right) src)
            => new ApiKeyJoin(src.left, src.right);
    }
}