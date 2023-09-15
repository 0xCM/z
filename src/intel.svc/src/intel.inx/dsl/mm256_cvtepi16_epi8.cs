//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Intel
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct mm256_cvtepi16_epi8
    {
        public readonly __m256i<ushort> A;

        [MethodImpl(Inline)]
        public mm256_cvtepi16_epi8(in __m256i<ushort> a)
        {
            A = a;
        }

        public IntrinsicName Kind
            => IntrinsicName._mm256_cvtepi16_epi8;
    }
}