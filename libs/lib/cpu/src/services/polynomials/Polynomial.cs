//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a polynomial
    /// </summary>
    /// <typeparam name="M">The coefficient modulus</typeparam>
    /// <typeparam name="N">The polynomial degree</typeparam>
    /// <typeparam name="T">The primal coefficient type</typeparam>
    public readonly struct Polynomial<T>
        where T : unmanaged
    {
        readonly Monomial<T>[] _Terms;

        /// <summary>
        /// The canonical zero polynomial - with one term of order 0 with coefficient 0
        /// </summary>
        public static Polynomial<T> Zero
            => new Polynomial<T>(sys.empty<Monomial<T>>());

        /// <summary>
        /// Initializes a polynomial from a dense sequence of monomials
        /// </summary>
        [MethodImpl(Inline)]
        internal Polynomial(Monomial<T>[] terms)
        {
            _Terms = terms;
        }

        /// <summary>
        /// Specifies the degree of the polynomial as determined by the value of
        /// the exponent of greatest order
        /// </summary>
        public uint Degree
        {
            [MethodImpl(Inline)]
            get => _Terms[0].Exp;
        }

        /// <summary>
        /// The dense sequence of terms that define the polynomial
        /// </summary>
        public Monomial<T>[] Terms
        {
            [MethodImpl(Inline)]
            get => _Terms;
        }

        public T[] Coefficients()
        {
            var dst = new T[_Terms.Length];
            for(var i=0; i< _Terms.Length; i++)
                dst[i] = _Terms[i].Scalar;
            return dst;
        }

        /// <summary>
        /// Selects the term with the specified order if it exists; otherwise, returns the zero monomial
        /// </summary>
        public Monomial<T> this[uint exp]
        {
            [MethodImpl(Inline)]
            get => Term(exp);
        }

        /// <summary>
        /// Selects the term with the specified order if it exists; otherwise, returns the zero monomial
        /// </summary>
        public Monomial<T> this[int exp]
        {
            [MethodImpl(Inline)]
            get => Term((uint)exp);
        }

        /// <summary>
        /// Specifies whether some term has a nonzero coeficient value
        /// </summary>
        public bool Nonzero
        {
            get
            {
                for(var i=0; i<_Terms.Length; i++)
                    if(_Terms[i].Nonzero)
                        return true;
                return false;
            }
        }

        /// <summary>
        /// Selects the term with the specified order if it exists;
        /// otherwise, returns the zero monomial
        /// </summary>
        [MethodImpl(Inline)]
        public Monomial<T> Term(uint exp)
        {
            var index = _Terms.Length - (exp + 1);
            if(index >=0)
                return _Terms[index];
            else
                return Monomial<T>.Zero(exp);
        }

        [MethodImpl(Inline)]
        public Monomial<T> Term(int exp)
            => Term(exp);

        public Monomial<T> LeadingTerm
        {
            [MethodImpl(Inline)]
            get => _Terms[0];
        }

        /// <summary>
        /// Evaluates the polynomial at a specified point
        /// </summary>
        /// <param name="x">The value at which to evaluate the polynomial</param>
        public T Eval(T x)
        {
            var result = default(T);
            for(var i=0; i<Terms.Length; i++)
                result = gmath.add(result, _Terms[i].Eval(x));
            return result ;
        }

        static string GetSep(Monomial<T> term)
            => gmath.negative(term.Scalar) ? " - " : " + ";

        /// <summary>
        /// Formats the polynomial in canonical form
        /// </summary>
        /// <param name="variable">The name of the placeholder variable</param>
        public string Format(char? variable = null)
        {
            var dst = new List<string>();
            for(var i=0; i< _Terms.Length; i++)
                if(_Terms[i].Nonzero)
                {
                    if(dst.Count != 0)
                        dst.Add(GetSep(_Terms[i]));
                    else
                    {
                        if(gmath.negative(_Terms[i].Scalar))
                            dst.Add("-");
                    }

                    dst.Add(_Terms[i].Format(variable,true));
                }

            return dst.Concat();
        }

        public override string ToString()
            => Format();
    }

    /// <summary>
    /// Represents a base-M polynomial of degree N over values of primal type T
    /// </summary>
    /// <typeparam name="M">The coefficient modulus</typeparam>
    /// <typeparam name="N">The polynomial degree</typeparam>
    /// <typeparam name="T">The primal coefficient type</typeparam>
    public readonly struct Polynomial<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        public readonly Monomial<M,T>[] Terms;

        public static uint Degree => (uint)new N().NatValue;

        /// <summary>
        /// The zero polynomial of degree N
        /// </summary>
        public static Polynomial<M,N,T> Zero
            => new Polynomial<M,N,T>(Monomial<M,T>.Zero(Degree));

        [MethodImpl(Inline)]
        public Polynomial(params Monomial<M,T>[] terms)
        {
            Require.invariant(terms[0].Exp == Degree, () => "no");
            this.Terms = terms;
        }

        /// <summary>
        /// Selects the term with the specified order if it exists;
        /// otherwise, returns the zero monomial
        /// </summary>
        public Monomial<M,T> this[uint exp]
        {
            [MethodImpl(Inline)]
            get => Term(exp);
        }

        /// <summary>
        /// Selects the term with the specified order if it exists;
        /// otherwise, returns the zero monomial
        /// </summary>
        public Monomial<M,T> Term(uint exp)
        {
            for(var j = 0; j<Terms.Length; j++)
                if(Terms[j].Exp == exp)
                    return Terms[j];
            return Monomial<M,T>.Zero(exp);
        }

        public string Format(char? variable = null)
        {
            var terms = Terms;
            var dst = new string[Terms.Length];
            for(var i=0; i<dst.Length; i++)
                dst[i] = terms[i].Format(variable);
            return string.Join(" + ", dst);
        }
   }
}