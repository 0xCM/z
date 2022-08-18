//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static intel;
    using static IntelInx.Defs;

    partial class IntelInx
    {
        [ApiHost(refs)]
        public class Refs
        {
            [MethodImpl(Inline), Op]
            public static __m128i<byte> calc(in mm_delta_epu8 src)
                => cpu.vor(cpu.vsubs(src.A, src.B), cpu.vsubs(src.B, src.A));

            [MethodImpl(Inline), Op]
            public static __m256i<byte> calc(in mm256_min_epu8 src)
                => cpu.vmin(src.A,src.B);
        }
    }
}