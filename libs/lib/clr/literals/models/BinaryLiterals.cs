//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BinaryLiterals<T>
        where T : unmanaged
    {
        readonly Index<BinaryLiteral<T>> Data;

        [MethodImpl(Inline)]
        public BinaryLiterals(BinaryLiteral<T>[] src)
            => Data = src;

        public BinaryLiteral<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<BinaryLiteral<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        [MethodImpl(Inline)]
        public static implicit operator BinaryLiterals<T>(BinaryLiteral<T>[] src)
            => new BinaryLiterals<T>(src);
    }
}