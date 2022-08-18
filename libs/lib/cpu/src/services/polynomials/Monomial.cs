//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a one-term polynomial or component of a polynomial with more than one term
    /// </summary>
    public readonly struct Monomial<T>
        where T : unmanaged
    {
        /// <summary>
        /// The monomial coefficient
        /// </summary>
        public readonly T Scalar;

        /// <summary>
        /// The monomial exponent/order
        /// </summary>
        public readonly uint Exp;

        [MethodImpl(Inline)]
        public static Monomial<T> Define(T scalar, uint exp)
            => new Monomial<T>(scalar, exp);

        /// <summary>
        /// Produces the zero monomial of a given order
        /// </summary>
        /// <param name="exp">The monomial exponent/order</param>
        [MethodImpl(Inline)]
        public static Monomial<T> Zero(uint exp)
            => new Monomial<T>(default, exp);

        [MethodImpl(Inline)]
        public static implicit operator (T scalar, uint exp)(Monomial<T> src)
            => (src.Scalar, src.Exp);

        [MethodImpl(Inline)]
        public static implicit operator Monomial<T>((T scalar, uint exp) src)
            => new Monomial<T>(src.scalar, src.exp);

        [MethodImpl(Inline)]
        Monomial(T scalar, uint exp)
        {
            Scalar = scalar;
            Exp = exp;
        }

        /// <summary>
        /// Specifies whether the coeifficient, and thus the monomial, is nonzero
        /// </summary>
        public bool Nonzero
        {
            [MethodImpl(Inline)]
            get => gmath.nonz(Scalar);
        }

        /// <summary>
        /// Evaluates the monomial at a specified point
        /// </summary>
        /// <param name="x">The point of evaluation</param>
        [MethodImpl(Inline)]
        public T Eval(T x)
            => gmath.mul(Scalar, gmath.pow(x,(uint)Exp));

        public string Format(char? variable = null, bool abs = false)
        {
            if(Nonzero)
            {
                var scalarFmt = FormatScalar(abs);
                var varname = variable ?? 'x';
                if(Exp == 1)
                    return $"{scalarFmt}{varname}";
                else if(Exp == 0)
                    return scalarFmt;
                else
                    return $"{scalarFmt}{varname}^{Exp}";
            }
            else
                return string.Empty;

        }

        public override string ToString()
            => Format();

        string FormatScalar(bool abs)
            => abs ? gmath.abs(Scalar).ToString() : Scalar.ToString();
    }

    /// <summary>
    /// Represents a one-term polynomial or component of a polynomial with more than one term
    /// where the scalar coefficient has modulus M
    /// </summary>
    public readonly struct Monomial<N,T>
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        /// <summary>
        /// The monomial coefficient
        /// </summary>
        public readonly T Scalar;

        /// <summary>
        /// The monomial exponent/order
        /// </summary>
        public readonly uint Exp;

        [MethodImpl(Inline)]
        public static implicit operator Monomial<N,T>((T scalar, uint exp) src)
            => new Monomial<N,T>(src.scalar, src.exp);

        [MethodImpl(Inline)]
        public static Monomial<N,T> Zero(uint exp)
            => new Monomial<N,T>(default, exp);

        [MethodImpl(Inline)]
        public Monomial(T scalar, uint exp)
        {
            Scalar = scalar;
            Exp = exp;
        }

        public Monomial<T> Unsized
        {
            [MethodImpl(Inline)]
            get => Monomial<T>.Define(Scalar, Exp);
        }

        /// <summary>
        /// Specifies whether the coeifficient, and thus the monomial, is nonzero
        /// </summary>
        public bool Nonzero
            => gmath.nonz(Scalar);

        public (T scalar, uint exp) ToPair()
            => (Scalar, Exp);

        public string Format(char? variable = null)
            => Nonzero ? $"{Scalar}{variable ?? 'x'}^{Exp}" : string.Empty;

        public override string ToString()
            => Format();
    }
}