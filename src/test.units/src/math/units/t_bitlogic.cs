//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = Surrogates;
    using BL = math;
    using C = Calcs;

    public class t_bitlogic : t_mathsvc<t_bitlogic>
    {
        void and_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = C.and<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void or_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.or<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void xor_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.xor<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void nand_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.nand<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void nor_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.nor<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void xnor_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.xnor<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void not_check<T>(S.UnaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.not<T>();
            var validator = this.UnaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }


        void impl_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.impl<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void nonimpl_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.nonimpl<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void cimpl_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.cimpl<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        void cnonimpl_check<T>(S.BinaryOp<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.cnonimpl<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        public void and_check()
        {
            const string name = "and";
            and_check(S.binary(BL.and, name, z8i));
            and_check(S.binary(BL.and, name, z16));
            and_check(S.binary(BL.and, name, z16i));
            and_check(S.binary(BL.and, name, z32));
            and_check(S.binary(BL.and, name, z32i));
            and_check(S.binary(BL.and, name, z64));
            and_check(S.binary(BL.and, name, z64i));
        }

        public void or_check()
        {
            const string name = "or";
            or_check(S.binary(BL.or, name, z8));
            or_check(S.binary(BL.or, name, z8i));
            or_check(S.binary(BL.or, name, z16));
            or_check(S.binary(BL.or, name, z16i));
            or_check(S.binary(BL.or, name, z32));
            or_check(S.binary(BL.or, name, z32i));
            or_check(S.binary(BL.or, name, z64));
            or_check(S.binary(BL.or, name, z64i));
        }


        public void xor_check()
        {
            const string name = "xor";
            xor_check(S.binary(BL.xor, name, z8));
            xor_check(S.binary(BL.xor, name, z8i));
            xor_check(S.binary(BL.xor, name, z16));
            xor_check(S.binary(BL.xor, name, z16i));
            xor_check(S.binary(BL.xor, name, z32));
            xor_check(S.binary(BL.xor, name, z32i));
            xor_check(S.binary(BL.xor, name, z64));
            xor_check(S.binary(BL.xor, name, z64i));
        }


        public void nand_check()
        {
            const string name = "nand";
            nand_check(S.binary(BL.nand, name, z8));
            nand_check(S.binary(BL.nand, name, z8i));
            nand_check(S.binary(BL.nand, name, z16));
            nand_check(S.binary(BL.nand, name, z16i));
            nand_check(S.binary(BL.nand, name, z32));
            nand_check(S.binary(BL.nand, name, z32i));
            nand_check(S.binary(BL.nand, name, z64));
            nand_check(S.binary(BL.nand, name, z64i));
        }

        public void nor_check()
        {
            const string name = "nor";
            nor_check(S.binary(BL.nor, name, z8));
            nor_check(S.binary(BL.nor, name, z8i));
            nor_check(S.binary(BL.nor, name, z16));
            nor_check(S.binary(BL.nor, name, z16i));
            nor_check(S.binary(BL.nor, name, z32));
            nor_check(S.binary(BL.nor, name, z32i));
            nor_check(S.binary(BL.nor, name, z64));
            nor_check(S.binary(BL.nor, name, z64i));
        }


        public void xnor_check()
        {
            const string name = "xnor";
            xnor_check(S.binary(BL.xnor, name, z8));
            xnor_check(S.binary(BL.xnor, name, z8i));
            xnor_check(S.binary(BL.xnor, name, z16));
            xnor_check(S.binary(BL.xnor, name, z16i));
            xnor_check(S.binary(BL.xnor, name, z32));
            xnor_check(S.binary(BL.xnor, name, z32i));
            xnor_check(S.binary(BL.xnor, name, z64));
            xnor_check(S.binary(BL.xnor, name, z64i));
        }


        public void not_check()
        {
            const string name = "not";
            not_check(S.unary(BL.not, name, z8));
            not_check(S.unary(BL.not, name, z8i));
            not_check(S.unary(BL.not, name, z16));
            not_check(S.unary(BL.not, name, z16i));
            not_check(S.unary(BL.not, name, z32));
            not_check(S.unary(BL.not, name, z32i));
            not_check(S.unary(BL.not, name, z64));
            not_check(S.unary(BL.not, name, z64i));
        }

        public void impl_check()
        {
            const string name = "impl";
            impl_check(S.binary(BL.impl, name, z8));
            impl_check(S.binary(BL.impl, name, z8i));
            impl_check(S.binary(BL.impl, name, z16));
            impl_check(S.binary(BL.impl, name, z16i));
            impl_check(S.binary(BL.impl, name, z32));
            impl_check(S.binary(BL.impl, name, z32i));
            impl_check(S.binary(BL.impl, name, z64));
            impl_check(S.binary(BL.impl, name, z64i));
        }

        public void nonimpl_check()
        {
            const string name = "nonimpl";
            nonimpl_check(S.binary(BL.nonimpl, name, z8));
            nonimpl_check(S.binary(BL.nonimpl, name, z8i));
            nonimpl_check(S.binary(BL.nonimpl, name, z16));
            nonimpl_check(S.binary(BL.nonimpl, name, z16i));
            nonimpl_check(S.binary(BL.nonimpl, name, z32));
            nonimpl_check(S.binary(BL.nonimpl, name, z32i));
            nonimpl_check(S.binary(BL.nonimpl, name, z64));
            nonimpl_check(S.binary(BL.nonimpl, name, z64i));
        }

        public void cimpl_check()
        {
            const string name = "cimpl";

            cimpl_check(S.binary(BL.cimpl, name, z8));
            cimpl_check(S.binary(BL.cimpl, name, z8i));
            cimpl_check(S.binary(BL.cimpl, name, z16));
            cimpl_check(S.binary(BL.cimpl, name, z16i));
            cimpl_check(S.binary(BL.cimpl, name, z32));
            cimpl_check(S.binary(BL.cimpl, name, z32i));
            cimpl_check(S.binary(BL.cimpl, name, z64));
            cimpl_check(S.binary(BL.cimpl, name, z64i));
        }

        public void cnonimpl_check()
        {
            const string name = "cnonimpl";

            cnonimpl_check(S.binary(BL.cnonimpl, name, z8));
            cnonimpl_check(S.binary(BL.cnonimpl, name, z8i));
            cnonimpl_check(S.binary(BL.cnonimpl, name, z16));
            cnonimpl_check(S.binary(BL.cnonimpl, name, z16i));
            cnonimpl_check(S.binary(BL.cnonimpl, name, z32));
            cnonimpl_check(S.binary(BL.cnonimpl, name, z32i));
            cnonimpl_check(S.binary(BL.cnonimpl, name, z64));
            cnonimpl_check(S.binary(BL.cnonimpl, name, z64i));
        }
    }
}