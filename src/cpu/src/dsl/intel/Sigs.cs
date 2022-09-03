//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel.intrinsics
{
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
        NativeOpDef Op(string name, string type, NativeOpMod mod = default)
            => NativeTypes.op(name, Type(type), mod);

        public NativeSigSpec _mm_add_epi8()
            => NativeTypes.sig(Scope, nameof(_mm_add_epi8), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSigSpec _mm_add_epi16()
            => NativeTypes.sig(Scope, nameof(_mm_add_epi16), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSigSpec _mm_add_epi32()
            => NativeTypes.sig(Scope, nameof(_mm_add_epi32), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSigSpec _mm_add_epi64()
            => NativeTypes.sig(Scope, nameof(_mm_add_epi64), Type(__m128i), Op("a", __m128i), Op("b", __m128i));
    }
}