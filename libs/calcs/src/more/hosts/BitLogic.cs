//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiClasses;

    [Closures(Integers)]
    public readonly struct BitLogic<T> : IBitLogic<T>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        public T identity(T a)
            => a;

        [MethodImpl(Inline)]
        public T @false()
            => gmath.@false<T>();

        [MethodImpl(Inline)]
        public T @true()
            => gmath.@true<T>();

        [MethodImpl(Inline)]
        public T not(T a)
            => gmath.not(a);

        [MethodImpl(Inline)]
        public T and(T a, T b)
            => gmath.and(a,b);

        [MethodImpl(Inline)]
        public T nand(T a, T b)
            => gmath.nand(a,b);

        [MethodImpl(Inline)]
        public T or(T a, T b)
            => gmath.or(a,b);

        [MethodImpl(Inline)]
        public T nor(T a, T b)
            => gmath.nor(a,b);

        [MethodImpl(Inline)]
        public T xor(T a, T b)
            => gmath.xor(a,b);

        [MethodImpl(Inline)]
        public T xnor(T a, T b)
            => gmath.xnor(a,b);

        [MethodImpl(Inline)]
        public T cimpl(T a, T b)
            => gmath.cimpl(a,b);

        [MethodImpl(Inline)]
        public T cnonimpl(T a, T b)
            => gmath.cnonimpl(a,b);

        [MethodImpl(Inline)]
        public T impl(T a, T b)
            => gmath.impl(a,b);

        [MethodImpl(Inline)]
        public T nonimpl(T a, T b)
            => gmath.nonimpl(a,b);

        [MethodImpl(Inline)]
        public T select(T a, T b, T c)
            => gmath.select(a,b,c);

        [MethodImpl(Inline)]
        public T eval<K>(T a, K kind = default)
            where K : unmanaged, IApiBitLogicClass
                => eval_unary_1(a,kind);

        [MethodImpl(Inline)]
        public T eval<K>(T a, T b, K kind = default)
            where K : unmanaged, IApiBitLogicClass
                => eval_binary_1(a,b,kind);

        [MethodImpl(Inline)]
        public T eval<K>(T a, T b, T c, K kind = default)
            where K : unmanaged, IApiBitLogicClass
                => eval_ternary_1(a, b, c,kind);

        [MethodImpl(Inline)]
        T eval_unary_1<B>(T a, B kind)
            where B : unmanaged, IApiBitLogicClass
        {
            if(typeof(B) == typeof(K.Not))
                return not(a);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        T eval_binary_1<B>(T a, T b, B kind)
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
        T eval_binary_2<B>(T a, T b, B kind)
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
        T eval_ternary_1<B>(T a, T b, T c, B kind)
            where B : unmanaged, IApiBitLogicClass
        {
            if(typeof(B) == typeof(K.Select))
                return select(a,b,c);
            else
                throw no<T>();
        }
    }
}