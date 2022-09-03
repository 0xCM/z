//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents the generic type definition for a 128-bit vector
    /// </summary>
    public readonly struct Vec128Type : IVectorType<Vec128Type,W128>
    {
        public W128 W
            => default;

        public NativeVectorWidth Class
            => NativeVectorWidth.W128;

        public uint Value
            => (uint)W.DataWidth;

        public int BitWidth
            => W;

        [MethodImpl(Inline)]
        public static implicit operator NativeVectorWidth(Vec128Type src)
            => src.W;

        [MethodImpl(Inline)]
        public static implicit operator Vec128Type(W128 src)
            => default;
    }
}