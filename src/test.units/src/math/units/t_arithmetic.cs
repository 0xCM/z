//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = Surrogates;

    public class t_arithmetic : t_mathsvc<t_arithmetic>
    {
        [MethodImpl(Inline)]
        void add_check<T>(BinarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.add<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        [MethodImpl(Inline)]
        void sub_check<T>(BinarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.sub<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        [MethodImpl(Inline)]
        void mul_check<T>(BinarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.mul<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        [MethodImpl(Inline)]
        void div_check<T>(BinarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.div<T>();
            var validator = this.BinaryOpMatch(true,t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        [MethodImpl(Inline)]
        void mod_check<T>(BinarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.mod<T>();
            var validator = this.BinaryOpMatch(true,t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        [MethodImpl(Inline)]
        void modmul_check<T>(TernarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.modmul<T>();
            var validator = this.TernaryOpMatch(true,t);
            validator.CheckMatch(f,g);
            validator.CheckSpanMatch(f,g);
        }

        [MethodImpl(Inline)]
        void clamp_check<T>(BinarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.clamp<T>();
            var validator = this.BinaryOpMatch(t);
            validator.CheckMatch(f, g);
            validator.CheckSpanMatch(f, g);
        }

        [MethodImpl(Inline)]
        void inc_check<T>(UnarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.inc<T>();
            var comparer = this.UnaryOpMatch(t);
            comparer.CheckMatch(f, g);
            comparer.CheckSpanMatch(f, g);
        }

        [MethodImpl(Inline)]
        void dec_check<T>(UnarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.dec<T>();
            var comparer = this.UnaryOpMatch(t);
            comparer.CheckMatch(f,g);
            comparer.CheckSpanMatch(f,g);
        }

        [MethodImpl(Inline)]
        void negate_check<T>(UnarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.negate<T>();
            var comparer = this.UnaryOpMatch(t);
            comparer.CheckMatch(f, g);
            comparer.CheckSpanMatch(f, g);
        }

        [MethodImpl(Inline)]
        void abs_check<T>(UnarySurrogate<T> f, T t = default)
            where T : unmanaged, IEquatable<T>
        {
            var g = Calcs.abs<T>();
            var comparer = this.UnaryOpMatch(t);
            comparer.CheckMatch(f,g);
            comparer.CheckSpanMatch(f,g);
        }

        void check_increments<T>(T first = default)
            where T : unmanaged
        {
            var count = Random.Next(21u, 256u);
            Span<T> data = new T[count];
            ref var src = ref sys.first(data);
            Partitions.increments(first, count, ref src);

            for(var i=0; i < count; i++)
                NumericClaims.eq(gmath.add(first, Numeric.force<T>(i)), data[i]);
        }

        public void add_check()
        {
            const string name = "add";

            if(DiagnosticMode)
                term.print(text.concat("Executing", Space, name));

            add_check(S.binary(math.add, name, z8));
            add_check(S.binary(math.add, name, z8i));
            add_check(S.binary(math.add, name, z16));
            add_check(S.binary(math.add, name, z16i));
            add_check(S.binary(math.add, name, z32));
            add_check(S.binary(math.add, name, z32i));
            add_check(S.binary(math.add, name, z64));
            add_check(S.binary(math.add, name, z64i));
            add_check(S.binary(fmath.add, name, z32f));
            add_check(S.binary(fmath.add, name, z64f));
        }

        public void sub_check()
        {
            const string name = "sub";
            sub_check(S.binary(math.sub, name, z8));
            sub_check(S.binary(math.sub, name, z8i));
            sub_check(S.binary(math.sub, name, z16));
            sub_check(S.binary(math.sub, name, z16i));
            sub_check(S.binary(math.sub, name, z32));
            sub_check(S.binary(math.sub, name, z32i));
            sub_check(S.binary(math.sub, name, z64));
            sub_check(S.binary(math.sub, name, z64i));
            sub_check(S.binary(fmath.sub, name, z32f));
            sub_check(S.binary(fmath.sub, name, z64f));
        }

        public void mul_check()
        {
            const string name = "mul";
            mul_check(S.binary(math.mul, name, z8));
            mul_check(S.binary(math.mul, name, z8i));
            mul_check(S.binary(math.mul, name, z16));
            mul_check(S.binary(math.mul, name, z16i));
            mul_check(S.binary(math.mul, name, z32));
            mul_check(S.binary(math.mul, name, z32i));
            mul_check(S.binary(math.mul, name, z64));
            mul_check(S.binary(math.mul, name, z64i));
            mul_check(S.binary(fmath.mul, name, z32f));
            mul_check(S.binary(fmath.mul, name, z64f));
        }

        public void div_check()
        {
            const string name = "div";
            div_check(S.binary(math.div, name, z8));
            div_check(S.binary(math.div, name, z8i));
            div_check(S.binary(math.div, name, z16));
            div_check(S.binary(math.div, name, z16i));
            div_check(S.binary(math.div, name, z32));
            div_check(S.binary(math.div, name, z32i));
            div_check(S.binary(math.div, name, z64));
            div_check(S.binary(math.div, name, z64i));
            div_check(S.binary(fmath.div, name, z32f));
            div_check(S.binary(fmath.div, name, z64f));
        }

        public void mod_check()
        {
            const string name = "mod";
            mod_check(S.binary(math.mod, name, z8));
            mod_check(S.binary(math.mod, name, z8i));
            mod_check(S.binary(math.mod, name, z16));
            mod_check(S.binary(math.mod, name, z16i));
            mod_check(S.binary(math.mod, name, z32));
            mod_check(S.binary(math.mod, name, z32i));
            mod_check(S.binary(math.mod, name, z64));
            mod_check(S.binary(math.mod, name, z64i));
            mod_check(S.binary(fmath.mod, name, z32f));
            mod_check(S.binary(fmath.mod, name, z64f));
        }
        

        public void modmul_check()
        {
            const string name = "modmul";
            modmul_check(S.ternary(math.modmul, name, z8));
            modmul_check(S.ternary(math.modmul, name, z8i));
            modmul_check(S.ternary(math.modmul, name, z16));
            modmul_check(S.ternary(math.modmul, name, z16i));
            modmul_check(S.ternary(math.modmul, name, z32));
            modmul_check(S.ternary(math.modmul, name, z32i));
            modmul_check(S.ternary(math.modmul, name, z64));
            modmul_check(S.ternary(math.modmul, name, z64i));
            modmul_check(S.ternary(fmath.modmul, name, z64f));
            modmul_check(S.ternary(fmath.modmul, name, z32f));
        }

        public void clamp_check()
        {
            const string name = "clamp";
            clamp_check(S.binary(math.clamp, name, z8));
            clamp_check(S.binary(math.clamp, name, z8i));
            clamp_check(S.binary(math.clamp, name, z16));
            clamp_check(S.binary(math.clamp, name, z16i));
            clamp_check(S.binary(math.clamp, name, z32));
            clamp_check(S.binary(math.clamp, name, z32i));
            clamp_check(S.binary(math.clamp, name, z64));
            clamp_check(S.binary(math.clamp, name, z64i));
            clamp_check(S.binary(fmath.clamp, name, z32f));
            clamp_check(S.binary(fmath.clamp, name, z64f));
        }

        public void inc_check()
        {
            const string name = "inc";
            inc_check(S.unary(math.inc, name, z8));
            inc_check(S.unary(math.inc, name, z8i));
            inc_check(S.unary(math.inc, name, z16));
            inc_check(S.unary(math.inc, name, z16i));
            inc_check(S.unary(math.inc, name, z32));
            inc_check(S.unary(math.inc, name, z32i));
            inc_check(S.unary(math.inc, name, z64));
            inc_check(S.unary(math.inc, name, z64i));
            inc_check(S.unary(fmath.inc, name, z32f));
            inc_check(S.unary(fmath.inc, name, z64f));
        }

        public void dec_check()
        {
            const string name = "dec";
            dec_check(S.unary(math.dec, name, z8));
            dec_check(S.unary(math.dec, name, z8i));
            dec_check(S.unary(math.dec, name, z16));
            dec_check(S.unary(math.dec, name, z16i));
            dec_check(S.unary(math.dec, name, z32));
            dec_check(S.unary(math.dec, name, z32i));
            dec_check(S.unary(math.dec, name, z64));
            dec_check(S.unary(math.dec, name, z64i));
            dec_check(S.unary(fmath.dec, name, z32f));
            dec_check(S.unary(fmath.dec, name, z64f));
        }

        public void negate_check()
        {
            const string name = "negate";
            negate_check(S.unary(math.negate, name, z8));
            negate_check(S.unary(math.negate, name, z8i));
            negate_check(S.unary(math.negate, name, z16));
            negate_check(S.unary(math.negate, name, z16i));
            negate_check(S.unary(math.negate, name, z32));
            negate_check(S.unary(math.negate, name, z32i));
            negate_check(S.unary(math.negate, name, z64));
            negate_check(S.unary(math.negate, name, z64i));
            negate_check(S.unary(fmath.negate, name, z32f));
            negate_check(S.unary(fmath.negate, name, z64f));
        }

        public void abs_check()
        {
            const string name = "abs";
            abs_check(S.unary(Math.Abs, name, z8i));
            abs_check(S.unary(Math.Abs, name, z16i));
            abs_check(S.unary(Math.Abs, name, z32i));
            abs_check(S.unary(Math.Abs, name, z64i));
            abs_check(S.unary(MathF.Abs, name, z32f));
            abs_check(S.unary(Math.Abs, name, z64f));
        }

        public void check_increments()
        {
            const string name = "increments";
            CheckAction(() => check_increments(z8), CaseName(name, z8));
            CheckAction(() => check_increments(z8i), CaseName(name, z8i));
            CheckAction(() => check_increments(z16), CaseName(name, z16));
            CheckAction(() => check_increments(z16i), CaseName(name, z16i));
            CheckAction(() => check_increments(z32), CaseName(name, z32));
            CheckAction(() => check_increments(z32i), CaseName(name, z32i));
            CheckAction(() => check_increments(z64), CaseName(name, z64));
            CheckAction(() => check_increments(z64i), CaseName(name, z64i));
        }
    }
}