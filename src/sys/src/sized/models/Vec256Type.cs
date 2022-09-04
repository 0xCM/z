//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents the generic type definition for a 256-bit vector
    /// </summary>
    public readonly struct Vec256Type : IVectorType<Vec256Type,W256>
    {
        public W256 W
            => default;

        public NativeVectorWidth Class
            => NativeVectorWidth.W256;

        public uint Value
            => (uint)W.DataWidth;

        public int BitWidth
            => W;

        [MethodImpl(Inline)]
        public static implicit operator NativeVectorWidth(Vec256Type src)
            => src.W;

        [MethodImpl(Inline)]
        public static implicit operator Vec256Type(W256 src)
            => default;
    }
}