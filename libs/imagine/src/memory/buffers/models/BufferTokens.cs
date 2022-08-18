
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BufferTokens : IBufferTokenSource
    {
        readonly BufferToken[] Data;

        [MethodImpl(Inline)]
        public BufferTokens(BufferToken[] src)
            => Data = src;

        public ref readonly BufferToken this[BufferSeqId id]
        {
            [MethodImpl(Inline)]
            get => ref Data[(byte)id];
        }

        [MethodImpl(Inline)]
        public static implicit operator BufferTokens(BufferToken[] src)
            => new BufferTokens(src);
    }
}