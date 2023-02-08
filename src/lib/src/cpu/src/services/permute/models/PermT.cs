//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a permutation over an integral type based at 0, [0, 1, ..., n - 1] where n is the permutation length
    /// </summary>
    /// <typeparam name="T">The integral type</typeparam>
    public readonly ref struct Perm<T>
        where T : unmanaged
    {
        /// <summary>
        /// Defines the permutation (0 -> terms[0], 1 -> terms[1], ..., n - 1 -> terms[n-1]) where n is the length of the array
        /// </summary>
        readonly Span<T> terms;

        /// <summary>
        /// Initializes permutation with the identity followed by a sequence of transpostions
        /// </summary>
        /// <param name="n">The length of the permutation</param>
        /// <param name="swaps">The transpositions applied to the identity</param>
        [MethodImpl(Inline)]
        public Perm(T n, (T i, T j)[] swaps)
        {
            terms = Perm.Identity(n).terms;
            Swap(swaps);
        }

        /// <summary>
        ///  Initializes permutation with the identity followed by a sequence of transpostions
        /// </summary>
        /// <param name="n">The length of the permutation</param>
        /// <param name="swaps">The transpositions applied to the identity</param>
        [MethodImpl(Inline)]
        public Perm(T n, Swap<T>[] swaps)
        {
            terms = Perm.Identity(n).terms;
            Swap(swaps);
        }

        [MethodImpl(Inline)]
        public Perm(T[] src)
            => terms = src;

        [MethodImpl(Inline)]
        public Perm(Span<T> src)
            => terms = src;

        public Perm(IEnumerable<T> src)
            => terms = src.ToArray();

        [MethodImpl(Inline)]
        public Perm(T n, T[] src)
        {
            var count = iVal(n);
            terms = new T[count];

            var m = src.Length;

            for(var i=0; i< m; i++)
                terms[i] = src[i];

            var identity = Perm.Identity(n);
            for(var i=m; i< count; i++)
                terms[i] = identity[i - m];
        }

        ref T Head
        {
            [MethodImpl(Inline)]
            get => ref first(terms);
        }

        /// <summary>
        /// Term accessor where the term index is in the inclusive range [0, N-1]
        /// </summary>
        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Head, (uint)i);
        }

        /// <summary>
        /// Term accessor where the term index is in the inclusive range [0, N-1]
        /// </summary>
        public ref T this[T i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Head, iVal(i));
        }

        [MethodImpl(Inline)]
        public Perm<T> Swap(T i, T j)
        {
            Swaps.swap(ref terms[iVal(i)], ref terms[iVal(j)]);
            return this;
        }

        [MethodImpl(Inline)]
        public Perm<T> Swap((T i, T j) spec)
            => Swap(spec.i,spec.j);

        [MethodImpl(Inline)]
        public Perm<T> Swap(int i, int j)
        {
            Swaps.swap(ref seek(Head, i), ref seek(Head,j));
            return this;
        }

        /// <summary>
        /// Effects a sequence of in-place transpositions
        /// </summary>
        public Perm<T> Swap(params (T i, T j)[] specs)
        {
            for(var k=0; k<specs.Length; k++)
                Swaps.swap(ref terms[iVal(specs[k].i)], ref terms[iVal(specs[k].j)]);
            return this;
        }

        /// <summary>
        /// Effects a sequence of in-place transpositions
        /// </summary>
        public Perm<T> Swap(params (int i, int j)[] specs)
        {
            for(var k=0; k<specs.Length; k++)
                Swaps.swap(ref terms[specs[k].i], ref terms[specs[k].j]);
            return this;
        }

        /// <summary>
        /// Effects a sequence of in-place transpositions
        /// </summary>
        public Perm<T> Swap(params Swap[] specs)
        {
            for(var k=0; k<specs.Length; k++)
                Swaps.swap(ref terms[specs[k].i], ref terms[specs[k].j]);
            return this;
        }

        /// <summary>
        /// Effects a sequence of in-place transpositions
        /// </summary>
        public Perm<T> Swap(params Swap<T>[] specs)
        {
            for(var k=0; k<specs.Length; k++)
                Swap(specs[k]);
            return this;
        }

        /// <summary>
        /// The length of the permutation
        /// </summary>
        public readonly int Length
        {
            [MethodImpl(Inline)]
            get => terms.Length;
        }

        public readonly Span<T> Terms
            => terms;

        /// <summary>
        /// Applies a modular increment to the permutation in-place
        /// </summary>
        public Perm<T> Inc()
        {
            Span<T> src = Replicate().terms;
            var lastix = Length - 1;
            for(var i=0; i< lastix; i++)
                terms[i] = src[i + 1];
            terms[lastix] = src[0];
            return this;
        }

        /// <summary>
        /// Applies a modular decrement to the permutation in-place
        /// </summary>
        public Perm<T> Dec()
        {
            Span<T> src = Replicate().terms;
            terms[0] = src[Length - 1];
            for(var i=1; i< Length; i++)
                terms[i] = src[i - 1];
            return this;
        }

        /// <summary>
        /// Clones the permutation
        /// </summary>
        public readonly Perm<T> Replicate()
            => new Perm<T>(terms.Replicate());

        /// <summary>
        /// Creates a new permutation p via composition, p[i] = g(f(i)) for i = 0, ... n where f denotes the current permutation
        /// </summary>
        /// <param name="f">The left permutation</param>
        /// <param name="g">The right permutation</param>
        public readonly Perm<T> Compose(Perm<T> g)
        {
            var n = g.terms.Length;
            var dst = new Perm<T>(new T[n]);
            var f = this;
            for(var i=0; i< n; i++)
                dst[i] = g[f[i]];
            return dst;
        }

        /// <summary>
        /// Reverses the permutation in-place
        /// </summary>
        [MethodImpl(Inline)]
        public Perm<T> Reverse()
        {
            terms.Reverse();
            return this;
        }

        /// <summary>
        /// Computes the inverse permutation t of the current permutation p such that p*t = t*p = I where I denotes the identity permutation
        /// </summary>
        public readonly Perm<T> Invert()
        {
            var dst = new Perm<T>(new T[Length]);
            for(var i=0; i< Length; i++)
                dst[terms[i]] = Numeric.force<T>(i);
            return dst;
        }

        /// <summary>
        /// Computes a permutation cycle originating at a specified point
        /// </summary>
        /// <param name="start">The domain point at which evaluation will begin</param>
        public readonly PermCycle<T> Cycle(T start)
        {
            var iStart = iVal(start);
            Require.invariant(iStart >= 0 && iStart < Length, () => "no");
            Span<PermTerm<T>> cterms = stackalloc PermTerm<T>[Length];
            var traversed = new HashSet<T>(Length);
            var index = start;
            var ctix = 0;

            while(true)
            {
                var image = terms[iVal(index)];
                if(traversed.Contains(image))
                    break;
                else
                {
                    traversed.Add(image);
                    cterms[ctix++] = new PermTerm<T>(index, image);
                    index = image;
                }
            }

            return new PermCycle<T>(cterms.Slice(0, ctix).ToArray());
        }

        public readonly bool Equals(in Perm<T> rhs)
        {
            var len = rhs.Length;
            if(len != terms.Length)
                return(false);

            for(var i=0; i<len; i++)
                if(gmath.neq(terms[i], rhs.terms[i]))
                    return false;
            return true;
        }

        [MethodImpl(Inline)]
        static int iVal(T src)
            => Numeric.force<T,int>(src);

        public string Format(int? colwidth = null)
            => Terms.FormatAsPerm(colwidth);

        public readonly override int GetHashCode()
            => throw new NotSupportedException();

        public readonly override bool Equals(object o)
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator Perm<T>(Span<T> src)
            => new Perm<T>(src);

        [MethodImpl(Inline)]
        public static explicit operator Perm<T>(ReadOnlySpan<T> src)
            => new Perm<T>(src.ToArray());

        /// <summary>
        /// Implicitly converts an integral value n into an identity permutation of length n
        /// </summary>
        /// <param name="n">The permutation length</param>
        [MethodImpl(Inline)]
        public static implicit operator Perm<T>(T n)
            => Perm.Identity(n);

        /// <summary>
        /// Computes the composition h of f and g where f and g have common length n and h(i) = g(f(i)) for i = 0, ... n-1
        /// </summary>
        /// <param name="a">The left permutation</param>
        /// <param name="b">The right permutation</param>
        [MethodImpl(Inline)]
        public static Perm<T> operator *(in Perm<T> a, in Perm<T> b)
            => a.Compose(b);

        [MethodImpl(Inline)]
        public static Perm<T> operator ++(in Perm<T> src)
            => src.Inc();

        [MethodImpl(Inline)]
        public static Perm<T> operator --(in Perm<T> src)
            => src.Dec();

        [MethodImpl(Inline)]
        public static bool operator ==(in Perm<T> a, in Perm<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(in Perm<T> a, in Perm<T> b)
            => !a.Equals(b);
    }
}