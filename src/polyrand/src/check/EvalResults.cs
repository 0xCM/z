//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct EvalResults
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static BinaryEval<K,T,R> binary<K,T,R>(K kind, T a, T b, R result)
        {
            var dst = new BinaryEval<K,T,R>();
            dst.Kind = kind;
            dst.A = a;
            dst.B = b;
            dst.Result = result;
            return dst;
        }

        [MethodImpl(Inline)]
        public static UnaryEval<K,T> unary<K,T>(K kind, T a, T result)
        {
            var dst = new UnaryEval<K,T>();
            dst.Kind = kind;
            dst.A = a;
            dst.Result = result;
            return dst;
        }

        [MethodImpl(Inline)]
        public static UnaryPairEval<K,T,R> pair<K,T,R>(UnaryEval<K,T> a, UnaryEval<K,T> b, R result)
        {
            var dst = new UnaryPairEval<K,T,R>();
            dst.A = a;
            dst.B = b;
            dst.Result = result;
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmpEval<T> eq<T>(T a, T b, bit result)
            => new CmpEval<T>(CmpPredKind.EQ, a, b, result);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmpEval<T> neq<T>(T a, T b, bit result)
            => new CmpEval<T>(CmpPredKind.NEQ, a, b, result);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmpEval<T> gt<T>(T a, T b, bit result)
            => new CmpEval<T>(CmpPredKind.GT, a, b, result);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmpEval<T> ngt<T>(T a, T b, bit result)
            => new CmpEval<T>(CmpPredKind.NGT, a, b, result);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmpEval<T> gteq<T>(T a, T b, bit result)
            => new CmpEval<T>(CmpPredKind.GE, a, b, result);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmpEval<T> lt<T>(T a, T b, bit result)
            => new CmpEval<T>(CmpPredKind.LT, a, b, result);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmpEval<T> lteq<T>(T a, T b, bit result)
            => new CmpEval<T>(CmpPredKind.LE, a, b, result);
    }
}