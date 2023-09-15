//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Intel.intrinsics
{
    using static NativeSigs;

    /*
    _mm_add_epi16  | __m128i _mm_add_epi16(__m128i a, __m128i b)  | PADDW xmm, xmm | PADDW_XMMdq_XMMdq
    _mm_add_epi32  | __m128i _mm_add_epi32(__m128i a, __m128i b)  | PADDD xmm, xmm | PADDD_XMMdq_XMMdq
    _mm_add_epi64  | __m128i _mm_add_epi64(__m128i a, __m128i b)  | PADDQ xmm, xmm | PADDQ_XMMdq_XMMdq
    _mm_add_epi8   | __m128i _mm_add_epi8(__m128i a, __m128i b)   | PADDB xmm, xmm | PADDB_XMMdq_XMMdq
    */

    using static TypeNames;

    [ApiHost]
    public class Sigs
    {
        const string Scope = "inx";

        NativeTypeMap TypeMap;

        public Sigs()
        {
            TypeMap = Types.map();
        }

        [MethodImpl(Inline)]
        NativeType Type(string name)
            => TypeMap[name].Target;

        [MethodImpl(Inline)]
        Operand Op(string name, string type, Modifier mod = default)
            => op(name, Type(type), mod);

        public NativeSig _mm_add_epi8()
            => sig(Scope, nameof(_mm_add_epi8), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSig _mm_add_epi16()
            => sig(Scope, nameof(_mm_add_epi16), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSig _mm_add_epi32()
            => sig(Scope, nameof(_mm_add_epi32), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSig _mm_add_epi64()
            => sig(Scope, nameof(_mm_add_epi64), Type(__m128i), Op("a", __m128i), Op("b", __m128i));
    }
}