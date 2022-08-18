//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;

    using K = ApiClasses;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory, Closures(Integers)]
        public static VBitLogic128<T> vbitlogic<T>(N128 w)
            where T : unmanaged
                => default(VBitLogic128<T>);

        [MethodImpl(Inline), Factory, Closures(Integers)]
        public static VBitLogic256<T> vbitlogic<T>(N256 w)
            where T : unmanaged
                => default(VBitLogic256<T>);

        [Closures(Integers)]
        public readonly struct VBitLogic256<T> : IUnaryBitLogic<Vector256<T>>, IBinaryBitLogic<Vector256<T>>, ITernaryBitLogic<Vector256<T>>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> and(Vector256<T> a, Vector256<T> b)
                => gcpu.vand(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> or(Vector256<T> a, Vector256<T> b)
                => gcpu.vor(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> xor(Vector256<T> a, Vector256<T> b)
                => gcpu.vxor(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> cimpl(Vector256<T> a, Vector256<T> b)
                => gcpu.vcimpl(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> cnonimpl(Vector256<T> a, Vector256<T> b)
                => gcpu.vcnonimpl(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> @false()
                => default;

            [MethodImpl(Inline)]
            public Vector256<T> identity(Vector256<T> a)
                => a;

            [MethodImpl(Inline)]
            public Vector256<T> impl(Vector256<T> a, Vector256<T> b)
                => gcpu.vimpl(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> nand(Vector256<T> a, Vector256<T> b)
                => gcpu.vnand(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> nonimpl(Vector256<T> a, Vector256<T> b)
                => gcpu.vnonimpl(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> nor(Vector256<T> a, Vector256<T> b)
                => gcpu.vnor(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> not(Vector256<T> a)
                => gcpu.vnot(a);

            [MethodImpl(Inline)]
            public Vector256<T> select(Vector256<T> a, Vector256<T> b, Vector256<T> c)
                => gcpu.vselect(a,b,c);

            [MethodImpl(Inline)]
            public Vector256<T> @true()
                => gcpu.vones<T>(n256);

            [MethodImpl(Inline)]
            public Vector256<T> xnor(Vector256<T> a, Vector256<T> b)
                => gcpu.vxnor(a,b);

            [MethodImpl(Inline)]
            public Vector256<T> eval<K>(Vector256<T> a, K f = default)
                where K : unmanaged, IApiBitLogicClass
                    => eval_unary_1(a,f);

            [MethodImpl(Inline)]
            public Vector256<T> eval<K>(Vector256<T> a, Vector256<T> b, K f = default)
                where K : unmanaged, IApiBitLogicClass
                    => eval_binary_1(a,b,f);

            [MethodImpl(Inline)]
            public Vector256<T> eval<K>(Vector256<T> a, Vector256<T> b, Vector256<T> c, K f = default)
                where K : unmanaged, IApiBitLogicClass
                    => eval_ternary_1(a, b, c,f);

            [MethodImpl(Inline)]
            Vector256<T> eval_unary_1<B>(Vector256<T> a, B kind)
                where B : unmanaged, IApiBitLogicClass
            {
                if(typeof(B) == typeof(K.Not))
                    return not(a);
                else
                    throw no<T>();
            }

            [MethodImpl(Inline)]
            Vector256<T> eval_binary_1<B>(Vector256<T> a, Vector256<T> b, B kind)
                where B : unmanaged, IApiBitLogicClass
            {
                if(typeof(B) == typeof(K.And))
                    return and(a,b);
                else if(typeof(B) == typeof(K.Or))
                    return or(a,b);
                else if(typeof(B) == typeof(K.Xor))
                    return xor(a,b);
                else if(typeof(B) == typeof(K.Nand))
                    return nand(a,b);
                else if(typeof(B) == typeof(K.Nor))
                    return nor(a,b);
                else if(typeof(B) == typeof(K.Xnor))
                    return xnor(a,b);
                else
                    return eval_binary_2(a,b,kind);
            }

            [MethodImpl(Inline)]
            Vector256<T> eval_binary_2<B>(Vector256<T> a, Vector256<T> b, B kind)
                where B : unmanaged, IApiBitLogicClass
            {
                if(typeof(B) == typeof(K.Impl))
                    return impl(a,b);
                else if(typeof(B) == typeof(K.NonImpl))
                    return nonimpl(a,b);
                else if(typeof(B) == typeof(K.CImpl))
                    return cimpl(a,b);
                else if(typeof(B) == typeof(K.CNonImpl))
                    return cnonimpl(a,b);
                else
                    throw no<T>();
            }

            [MethodImpl(Inline)]
            Vector256<T> eval_ternary_1<B>(Vector256<T> a, Vector256<T> b, Vector256<T> c, B kind)
                where B : unmanaged, IApiBitLogicClass
            {
                if(typeof(B) == typeof(K.Select))
                    return select(a,b,c);
                else
                    throw no<T>();
            }
        }

    }
}