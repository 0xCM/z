//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    /// <summary>
    /// Defines a permutation over the integers [0, 1, ..., n - 1] where n is the permutation length
    /// </summary>
    [ApiHost]
    public readonly partial struct Perm
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static Vector128<byte> shuffles(NatPerm<N16> src)
            => cpu.vload(w128, (byte)first(src.Terms));

        [MethodImpl(Inline), Op]
        public static Perm32 unsize(in NatPerm<N32,byte> spec)
            => new Perm32(gcpu.vload(w256, spec.Terms));

        [MethodImpl(Inline), Op]
        public static Perm16 unsize(in NatPerm<N16,byte> spec)
            => new Perm16(gcpu.vload(w128, spec.Terms));

        /// <summary>
        /// Defines the permutation (0 -> terms[0], 1 -> terms[1], ..., n - 1 -> terms[n-1])
        /// where n is the length of the array
        /// </summary>
        readonly int[] terms;

        /// <summary>
        /// Creates a generic permutation by application of a sequence of transpositions to the identity permutation
        /// </summary>
        /// <param name="n">The permutation length</param>
        /// <param name="swaps">Pairs of permutation indices (i,j) to be transposed</param>
        /// <typeparam name="T">The integral type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> build<T>(T n, params (T i, T j)[] swaps)
            where T : unmanaged
                => new Perm<T>(n, swaps);

        /// <summary>
        /// Creates a generic permutation by application of a sequence of transpositions to the identity permutation
        /// </summary>
        /// <param name="n">The permutation length</param>
        /// <param name="swaps">Pairs of permutation indices (i,j) to be transposed</param>
        /// <typeparam name="T">The integral type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> build<T>(T n, params Swap<T>[] swaps)
            where T : unmanaged
                => new Perm<T>(n,swaps);

        /// <summary>
        /// Allocates an empty permutation
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Perm Alloc(int n)
            => new Perm(new int[n]);

        /// <summary>
        /// Allocates an empty permutation of specified length
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> Alloc<T>(uint n)
            where T : unmanaged
                => new Perm<T>(new T[n]);

        /// <summary>
        /// Defines an identity permutation on n symbols
        /// </summary>
        /// <param name="n">The permutation length</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Perm<T> Identity<T>(T n)
            where T : unmanaged
                => new Perm<T>(gcalc.stream(default, gmath.dec(n)));

        /// <summary>
        /// Distills a natural permutation on 4 symbols to its canonical literal specification
        /// </summary>
        /// <param name="src">The source permutation</param>
        [MethodImpl(Inline), Op]
        public static Perm4L pack(NatPerm<N4> src)
        {
            const int segwidth = 2;
            const int length = 4;

            var dst = 0u;
            for(int i=0, offset = 0; i< length; i++, offset +=segwidth)
                dst |= (uint)src[i] << offset;
            return (Perm4L)dst;
        }

        /// <summary>
        /// Distills a natural permutation on 8 symbols to its canonical literal specification
        /// </summary>
        /// <param name="src">The source permutation</param>
        [MethodImpl(Inline), Op]
        public static Perm8L pack(NatPerm<N8> src)
        {
            const int segwidth = 3;
            const int length = 8;

            var dst = 0u;
            for(int i=0, offset = 0; i< length; i++, offset +=segwidth)
                dst |= (uint)src[i] << offset;
            return (Perm8L)dst;
        }

        /// <summary>
        /// Distills a natural permutation on 16 symbols to its canonical literal specification
        /// </summary>
        /// <param name="src">The source permutation</param>
        [MethodImpl(Inline), Op]
        public static Perm16L pack(NatPerm<N16> src)
        {
            const int segwidth = 4;
            const int length = 16;

            var dst = 0ul;
            for(int i=0, offset = 0; i< length; i++, offset +=segwidth)
                dst |= (ulong)src[i] << offset;
            return (Perm16L)dst;
        }

        [MethodImpl(Inline)]
        public Perm(int n, Swap[] src)
        {
            terms = identity(n).terms;
            Apply(src);
        }

        [MethodImpl(Inline)]
        public Perm(int[] src)
        {
            terms = src;
        }

        [Op]
        void Absorb(ReadOnlySpan<int> src)
        {
            var n = terms.Length;
            var m = src.Length;
            ref var dst = ref first(terms);

            for(var i=0; i<m; i++)
                seek(dst, i) = skip(src,i);

            var identity = Perm.identity(n);
            for(var i=m; i<n; i++)
                seek(dst, i) = identity[i - m];
        }

        public Perm(int n, int[] src)
        {
            terms = new int[n];
            Absorb(src);
        }

        [MethodImpl(Inline)]
        public Perm(IEnumerable<int> src)
        {
            terms = src.ToArray();
        }

        /// <summary>
        /// Term accessor where the term index is in the inclusive range [0, N-1]
        /// </summary>
        public ref int this[int i]
        {
            [MethodImpl(Inline)]
            get => ref terms[i];
        }

        /// <summary>
        /// Term accessor where the term index is in the inclusive range [0, N-1]
        /// </summary>
        public ref int this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref terms[i];
        }

        /// <summary>
        /// Effects an in-place transposition, returning the result for convenience
        /// </summary>
        /// <remarks>
        /// A transposition (l,r) is interpreted as a function composition
        /// that carries the l-value (from the domain) to the r-value
        /// (in the l-relative codomain) and then the r-value to the l-value
        /// (in the r-relative codomain & l-relative domain). So, if
        /// a function f sends l to r and a function g sends r to l then
        /// the transposition t is the function t(l) = g(f(l)) == l.
        /// </remarks>
        [MethodImpl(Inline)]
        public Perm Swap(int i, int j)
        {
            Swaps.swap(ref terms[i], ref terms[j]);
            return this;
        }

        /// <summary>
        /// Effects a sequence of in-place transpositions
        /// </summary>
        public Perm Swap(params (int i, int j)[] specs)
        {
            for(var k=0; k<specs.Length; k++)
                Swaps.swap(ref terms[specs[k].i], ref terms[specs[k].j]);
            return this;
        }

        /// <summary>
        /// Effects a sequence of in-place transpositions
        /// </summary>
        public Perm Apply(params Swap[] specs)
        {
            for(var k=0; k<specs.Length; k++)
                Swaps.swap(ref terms[specs[k].i], ref terms[specs[k].j]);
            return this;
        }

        /// <summary>
        /// The length of the permutation
        /// </summary>
        public int Length
            => terms.Length;

        public ReadOnlySpan<int> Terms
            => terms;

        /// <summary>
        /// Clones the permutation
        /// </summary>
        public Perm Replicate()
            => new Perm(terms.Replicate());

        /// <summary>
        /// Creates a new permutation p via composition, p[i] = g(f(i)) for i = 0, ... n
        /// where f denotes the current permutation
        /// </summary>
        /// <param name="f">The left permutation</param>
        /// <param name="g">The right permutation</param>
        public Perm Compose(Perm g)
        {
            var n = terms.Length;
            var dst = Alloc(n);
            var f = this;
            for(var i=0; i< n; i++)
                dst[i] = g[f[i]];
            return dst;
        }

        /// <summary>
        /// Reverses the permutation in-place
        /// </summary>
        [MethodImpl(Inline)]
        public Perm Reverse()
        {
            terms.Reverse();
            return this;
        }

        /// <summary>
        /// Computes the inverse permutation t of the current permutation p
        /// such that p*t = t*p = I where I denotes the identity permutation
        /// </summary>
        public Perm Invert()
        {
            var dst = Alloc(Length);
            for(var i=0; i< Length; i++)
                dst[terms[i]] = i;
            return dst;
        }

        /// <summary>
        /// Applies a modular increment to the permutation in-place
        /// </summary>
        public Perm Inc()
        {
            Span<int> src = Replicate().terms;
            var k = 1;
            for(var i=0; i< Length - k; i++)
                terms[i] = src[i + k];
            terms[Length - k] = src[k - 1];
            return this;
        }

        /// <summary>
        /// Applies a modular decrement to the permutation in-place
        /// </summary>
        public Perm Dec()
        {
            Span<int> src = Replicate().terms;
            terms[0] = src[Length - 1];
            for(var i=1; i< Length; i++)
                terms[i] = src[i - 1];
            return this;
        }

        /// <summary>
        /// Converts the permutation to a generic permutation over the specified target type
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        public Perm<T> Convert<T>()
            where T : unmanaged
        {
            var dst = new T[terms.Length];
            for(var i=0; i<terms.Length; i++)
                dst[i] = Numeric.force<T>(terms[i]);
            return new Perm<T>(dst);
        }

        public Span<Swap> CalcSwaps()
        {
            var max = terms.Length/2;
            Span<Swap> swaps = new Swap[max];
            var count = 0;
            for(var i=0; i< max; i++)
            {
                var image = terms[i];

                if(i != image)
                {
                    var a = terms[image];
                    var b = terms[a];
                    if(image == b)
                        swaps[count++] = (a,image);
                }
            }

            return swaps.Slice(0,count);
        }

        /// <summary>
        /// Computes a permutation cycle originating at a specified point
        /// </summary>
        /// <param name="start">The domain point at which evaluation will begin</param>
        public PermCycle Cycle(int start)
        {
            Require.invariant(start >= 0 && start < Length, () => $"{start} doesn't work");
            Span<PermTerm> cterms = stackalloc PermTerm[Length];
            var traversed = new HashSet<int>(Length);
            var index = start;
            var ctix = 0;

            while(true)
            {
                var image = terms[index];
                if(traversed.Contains(image))
                    break;
                else
                {
                    traversed.Add(image);
                    cterms[ctix++] = new PermTerm(index, image);
                    index = image;
                }
            }

            return new PermCycle(cterms.Slice(0, ctix).ToArray());
        }

        /// <summary>
        /// Formats a permutation as a 2-column matrix
        /// </summary>
        /// <param name="src">The source permutation</param>
        /// <param name="colwidth">The width of the matrix columns, if specified</param>
        [MethodImpl(Inline)]
        public string Format(int? colwidth = null)
            => Terms.FormatAsPerm(colwidth);

        public override int GetHashCode()
            => terms.GetHashCode();

        public bool Equals(Perm rhs)
        {
            var len = rhs.Length;
            if(len != terms.Length)
                return(false);

            for(var i=0; i<len; i++)
                if(terms[i] != rhs.terms[i])
                    return false;

            return true;
        }

        public override bool Equals(object o)
            => o is Perm p  && Equals(p);

        [MethodImpl(Inline)]
        public static implicit operator Perm(Span<int> src)
            => new Perm(src.ToArray());

        [MethodImpl(Inline)]
        public static implicit operator Perm(ReadOnlySpan<int> src)
            => Init(src);

        /// <summary>
        /// Computes the composition h of f and g where f and g have common length n and
        /// h(i) = g(f(i)) for i = 0, ... n-1
        /// </summary>
        /// <param name="f">The left permutation</param>
        /// <param name="g">The right permutation</param>
        [MethodImpl(Inline)]
        public static Perm operator *(Perm f, Perm g)
            => f.Compose(g);

        [MethodImpl(Inline)]
        public static Perm operator ++(in Perm src)
            => src.Inc();

        [MethodImpl(Inline)]
        public static Perm operator --(in Perm src)
            => src.Dec();

        [MethodImpl(Inline)]
        public static bool operator ==(Perm a, Perm b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Perm a, Perm b)
            => !(a == b);
    }
}