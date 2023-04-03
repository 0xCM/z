//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LogicSig;
    using static BitLogix;

    using BLK = BinaryBitLogicKind;

    using K = ApiClasses;

    partial class BitLogixOps
    {
        [MethodImpl(Inline)]
        public static bit eval<F>(bit a, bit b, F kind = default)
            where F : unmanaged, IApiBitLogicClass
                => eval_1(a,b, kind);

        [MethodImpl(Inline)]
        static bit eval_1<F>(bit a, bit b, F kind = default)
            where F : unmanaged, IApiBitLogicClass
        {
            if(typeof(F) == typeof(K.True))
                return @true(a, b);
            else if(typeof(F) == typeof(K.False))
                return @false(a, b);
            else if(typeof(F) == typeof(K.And))
                return and(a, b);
            else if (typeof(F) == typeof(K.Nand))
                return nand(a, b);
            else
                return eval_2(a, b, kind);
        }

        [MethodImpl(Inline)]
        static bit eval_2<F>(bit a, bit b, F kind = default)
            where F : unmanaged, IApiBitLogicClass
        {
            if (typeof(F) == typeof(K.Or))
                return or(a, b);
            else if (typeof(F) == typeof(K.Nor))
                return nor(a, b);
            else if (typeof(F) == typeof(K.Xor))
                return xor(a, b);
            else if (typeof(F) == typeof(K.Xnor))
                return xnor(a, b);
            else
                return eval_3(a, b, kind);
        }

        [MethodImpl(Inline)]
        static bit eval_3<F>(bit a, bit b, F kind = default)
            where F : unmanaged, IApiBitLogicClass
        {
            if (typeof(F) == typeof(K.Impl))
                return impl(a, b);
            else if (typeof(F) == typeof(K.NonImpl))
                return nonimpl(a, b);
            else if (typeof(F) == typeof(K.LProject))
                return left(a, b);
            else if (typeof(F) == typeof(K.RProject))
                return right(a, b);
            else
                return eval_4(a, b, kind);
        }

        [MethodImpl(Inline)]
        static bit eval_4<F>(bit a, bit b, F kind = default)
            where F : unmanaged, IApiBitLogicClass
        {
            if (typeof(F) == typeof(K.LNot))
                return lnot(a, b);
            else if (typeof(F) == typeof(K.RNot))
                return rnot(a, b);
            else if (typeof(F) == typeof(K.CImpl))
                return cimpl(a, b);
            else if (typeof(F) == typeof(K.CNonImpl))
                return cnonimpl(a, b);
            else
                throw no<F>();
        }

        /// <summary>
        /// Evaluates a binary operator without lookup/delegate indirection
        /// </summary>
        /// <param name="op">The operator classifier</param>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [Op]
        public static bit eval(BLK kind, bit a, bit b)
        {
            switch(kind)
            {
                case BLK.True: return @true(a,b);
                case BLK.False: return @false(a,b);

                case BLK.And: return and(a,b);
                case BLK.Nand: return nand(a,b);

                case BLK.Or: return or(a,b);
                case BLK.Nor: return nor(a,b);

                case BLK.Xor: return xor(a,b);
                case BLK.Xnor: return xnor(a,b);

                case BLK.Impl: return impl(a,b);
                case BLK.NonImpl: return nonimpl(a,b);

                case BLK.Left: return left(a,b);
                case BLK.Right: return right(a,b);

                case BLK.LNot: return lnot(a,b);
                case BLK.RNot: return rnot(a,b);

                case BLK.CImpl: return cimpl(a,b);
                case BLK.CNonImpl: return cnonimpl(a,b);

                default: throw Unsupported.value(sig(kind));
            }
        }
    }
}