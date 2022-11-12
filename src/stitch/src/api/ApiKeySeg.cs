//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines an apikey segment
    /// </summary>
    public readonly struct ApiKeySeg
    {
        readonly ushort Storage;

        [MethodImpl(Inline)]
        public ApiKeySeg(ushort data)
            => Storage = data;

        public DataWidth Width => DataWidth.W16;

        [MethodImpl(Inline)]
        public static implicit operator ApiKeySeg(ReadOnlySpan<byte> src)
            => new ApiKeySeg(first(src));

        [MethodImpl(Inline)]
        public static implicit operator ApiKeySeg(ushort src)
            => new ApiKeySeg(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(ApiKeySeg src)
            => src.Storage;
    }
}