//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Intel
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct mm256_min_epu8
    {
        public readonly __m256i<byte> A;

        public readonly __m256i<byte> B;

        [MethodImpl(Inline)]
        public mm256_min_epu8(in __m256i<byte> a, in __m256i<byte> b)
        {
            A = a;
            B = b;
        }

        public IntrinsicName Kind
            => IntrinsicName.mm256_min_epu8;
    }
}