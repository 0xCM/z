//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    using api = Perm;

    partial class XTend
    {
        public static Swap[] Unsized<N>(this NatSwap<N>[] src)
            where N : unmanaged, ITypeNat
        {
            var dst = new Swap[src.Length];
            for(var i=0; i<src.Length; i++)
                dst[i] = src[i];
            return dst;
        }

        public static Swap<T>[] Unsized<N,T>(this NatSwap<N,T>[] src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var dst = new Swap<T>[src.Length];
            for(var i=0; i<src.Length; i++)
                dst[i] = src[i];
            return dst;
        }

        /// <summary>
        /// Shuffles span content as determined by a permutation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="p">The permutation to apply</param>
        public static Span<T> Permute<T>(this ReadOnlySpan<T> src, Perm p)
        {
            Span<T> dst = new T[src.Length];
            for(var i=0; i<p.Length; i++)
                dst[i] = src[p[i]];
            return dst;
        }

        /// <summary>
        /// Shuffles span content as determined by a permutation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="p">The permutation to apply</param>
        [MethodImpl(Inline)]
        public static Span<T> Permute<T>(this Span<T> src, Perm p)
            => src.ReadOnly().Permute(p);

        /// <summary>
        /// Applies a sequence of transpositions to source span elements
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> Swap<T>(this Span<T> src, params Swap[] swaps)
            where T : unmanaged
        {
            api.apply(src, swaps);
            return src;
        }

        /// <summary>
        /// Formats the terms of a permutation
        /// </summary>
        /// <param name="terms">The permutation terms</param>
        /// <param name="colwidth">The width of each column</param>
        /// <typeparam name="T">The term type</typeparam>
        public static string FormatAsPerm<T>(this Span<T> terms,  int? colwidth = null)
            => terms.ReadOnly().FormatAsPerm(colwidth);

        /// <summary>
        /// Formats the terms of a permutation
        /// </summary>
        /// <param name="terms">The permutation terms</param>
        /// <param name="colwidth">The width of each column</param>
        /// <typeparam name="T">The term type</typeparam>
        public static string FormatAsPerm<T>(this ReadOnlySpan<T> terms,  int? colwidth = null)
        {
            var line1 = text.build();
            var line2 = text.build();
            var pad = colwidth ?? 3;
            var leftBoundary = $"{Chars.Pipe}";
            var rightBoundary = $"{Chars.Pipe}".PadLeft(2);

            line1.Append(leftBoundary);
            line2.Append(leftBoundary);
            for(var i=0; i < terms.Length; i++)
            {
                line1.Append($"{i}".PadLeft(pad));
                line2.Append($"{terms[i]}".PadLeft(pad));
            }
            line1.Append(rightBoundary);
            line2.Append(rightBoundary);

            return line1.ToString() + Eol + line2.ToString();
        }

        /// <summary>
        /// Formats a sequence of successive transpositions (a chain)
        /// </summary>
        /// <param name="src">The transpositions</param>
        [MethodImpl(Inline)]
        public static string Format(this Swap[] src)
            => string.Join(" -> ", src.Map(x => x.Format()));

        /// <summary>
        /// Applies a sequence of transpositions to a blocked container
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static SpanBlock128<T> Swap<T>(this SpanBlock128<T> src, params Swap[] swaps)
            where T : unmanaged
        {
             if(swaps == null || swaps.Length == 0)
                return src;

             src.Storage.Swap(swaps);
             return src;
        }

        /// <summary>
        /// Applies a sequence of transpositions to a blocked container
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static SpanBlock256<T> Swap<T>(this SpanBlock256<T> src, params Swap[] swaps)
            where T : unmanaged
        {
             if(swaps == null || swaps.Length == 0)
                return src;

             src.Storage.Swap(swaps);
             return src;
        }

        /// <summary>
        /// Constructs the canonical literal representation of a natural permutation on 4 symbols
        /// </summary>
        /// <param name="src">The natural permutation</param>
        [MethodImpl(Inline)]
        public static Perm4L ToLiteral(this NatPerm<N4> src)
            => api.pack(src);

        /// <summary>
        /// Constructs the canonical literal representation of a natural permutation on 8 symbols
        /// </summary>
        /// <param name="src">The natural permutation</param>
        [MethodImpl(Inline)]
        public static Perm8L ToLiteral(this NatPerm<N8> src)
            => api.pack(src);

        /// <summary>
        /// Constructs the canonical literal representation of a natural permutation on 16 symbols
        /// </summary>
        /// <param name="src">The natural permutation</param>
        [MethodImpl(Inline)]
        public static Perm16L ToLiteral(this NatPerm<N16> src)
            => api.pack(src);

        /// <summary>
        /// Defines a shuffle spec from a permutation
        /// </summary>
        /// <param name="src">The defining permutation</param>
        [MethodImpl(Inline)]
        public static Vector128<byte> ToShuffleSpec(this NatPerm<N16> src)
            => api.shuffles(src);

    }
    /// <summary>
    /// Defines a permutation of natural length N over the natural numbers 0,1,...,N-1
    /// </summary>
    public readonly struct NatPerm<N>
        where N : unmanaged, ITypeNat
    {
        readonly Perm perm;

        static int n => nat32i<N>();

        /// <summary>
        /// The canonical identity permutation of length N
        /// </summary>
        public static NatPerm<N> Identity
            => new NatPerm<N>(AllocIdentity());

        /// <summary>
        /// The empty permutation of length N
        /// </summary>
        public static NatPerm<N> Empty
            => new NatPerm<N>(new int[n]);

        [MethodImpl(Inline)]
        static int[] AllocIdentity()
            => gcalc.stream(0, n - 1).ToArray();

        /// <summary>
        /// Allocates an empty permutation
        /// </summary>
        [MethodImpl(Inline)]
        public static NatPerm<N> Alloc()
            => Empty.Replicate();

        /// <summary>
        /// Initializes a permutation with the identity followed by a sequence of transpostions
        /// </summary>
        /// <param name="swaps">The transpositions to apply to the identity</param>
        [MethodImpl(Inline)]
        public NatPerm(NatSwap<N>[] swaps)
        {
            perm = new Perm(n, swaps.Unsized());
        }

        [MethodImpl(Inline)]
        internal NatPerm(Perm src)
        {
            perm = src;
        }

        /// <summary>
        /// Initializes a permutation with array content that implicitly defines a permutation
        /// </summary>
        /// <param name="src">The source array</param>
        public NatPerm(int[] src)
        {
            if(src.Length == n)
                perm = new Perm(src);
            else
            {
                var tmp = new int[n];

                var m = src.Length;
                for(var i=0; i< m; i++)
                    tmp[i] = src[i];

                for(var i=m; i< n; i++)
                    tmp[i] = Identity[i - m];
                perm = new Perm(tmp);
            }
        }

        public ReadOnlySpan<int> Terms
            => perm.Terms;

        /// <summary>
        /// Term evaluator/manipulator where
        /// </summary>
        public ref int this[int i]
        {
            [MethodImpl(Inline)]
            get => ref perm[i];
        }

        /// <summary>
        /// The permutation length
        /// </summary>
        public int Length
        {
            [MethodImpl(Inline)]
            get => (int)n;
        }

        /// <summary>
        /// Effects a transposition (i,j) -> (j, i)
        /// </summary>
        /// <param name="swap">The transposition to apply</param>
        [MethodImpl(Inline)]
        public NatPerm<N> Swap(in NatSwap<N> src)
        {
            (var i, var j) = src;
            perm.Swap(src);
            return this;
        }

        /// <summary>
        /// Effects a transposition (i,j) -> (j, i)
        /// </summary>
        /// <param name="swap">The transposition to apply</param>
        [MethodImpl(Inline)]
        public NatPerm<N> Swap(int i, int j)
        {
            perm.Swap(i,j);
            return this;
        }

        /// <summary>
        /// Effects a sequence of transpositions
        /// </summary>
        /// <param name="specs">The transpositions to apply</param>
        [MethodImpl(Inline)]
        public NatPerm<N> Swap(params (int i, int j)[] specs)
        {
            perm.Swap(specs);
            return this;
        }

        /// <summary>
        /// Effects a sequence of transpositions
        /// </summary>
        public NatPerm<N> Swap(params NatSwap<N>[] specs)
        {
            for(var k=0; k<specs.Length; k++)
                perm.Swap(specs[k]);
            return this;
        }

        /// <summary>
        /// Clones the permutation
        /// </summary>
        public NatPerm<N> Replicate()
            => new NatPerm<N>(perm.Replicate());

        /// <summary>
        /// Clones the permutation and applies the transposition (i,j)
        /// </summary>
        /// <param name="i">The first term index</param>
        /// <param name="j">The second term index</param>
        public NatPerm<N> Replicate(in NatSwap<N> s)
        {
            var p = Replicate();
            p.Swap(s);
            return p;
        }

        /// <summary>
        /// Reverses the permutation in-place
        /// </summary>
        public NatPerm<N> Reverse()
        {
            perm.Reverse();
            return this;
        }

        /// <summary>
        /// Computes the inverse permutation t of the current permutation p
        /// such that p*t = t*p = I where I denotes the identity permutation
        /// </summary>
        public NatPerm<N> Invert()
            => new NatPerm<N>(perm.Invert());

        /// <summary>
        /// Creates a new permutation p via composition, p[i] = g(f(i)) for i = 0, ... n
        /// where f denotes the current permutation
        /// </summary>
        /// <param name="f">The left permutation</param>
        /// <param name="g">The right permutation</param>
        public NatPerm<N> Compose(NatPerm<N> g)
            => new NatPerm<N>(perm.Compose(g.perm));

        /// <summary>
        /// Applies a modular increment to the permutation in-place
        /// </summary>
        [MethodImpl(Inline)]
        public NatPerm<N> Inc()
        {
            perm.Inc();
            return this;
        }

        /// <summary>
        /// Applies a modular decrement to the permutation in-place
        /// </summary>
        [MethodImpl(Inline)]
        public NatPerm<N> Dec()
        {
            perm.Dec();
            return this;
        }

        public Span<Swap> CalcSwaps()
            => perm.CalcSwaps();

        /// <summary>
        /// Computes a permutation cycle originating at a specified point
        /// </summary>
        /// <param name="start">The domain point at which evaluation will begin</param>
        public PermCycle Cycle(int start)
            => perm.Cycle(start);

        [MethodImpl(Inline)]
        public bool Equals(NatPerm<N> g)
            => perm.Equals(g.perm);

        /// <summary>
        /// Formats a permutation as a 2-column matrix
        /// </summary>
        /// <param name="src">The source permutation</param>
        /// <param name="colwidth">The width of the matrix columns, if specified</param>
        [MethodImpl(Inline)]
         public string Format(int? colwidth = null)
            => perm.Format(colwidth);

         public override string ToString()
            => this.Format();

         public override int GetHashCode()
            => perm.GetHashCode();

         public override bool Equals(object o)
            => o is NatPerm<N> p  && p.perm.Equals(perm);

        /// <summary>
        /// Implicitly converts the source to an unsized permutation
        /// </summary>
        /// <param name="f">The permutation to convert</param>
        [MethodImpl(Inline)]
        public static implicit operator Perm(NatPerm<N> f)
            => f.perm;

        /// <summary>
        /// Computes the composition h of f and g where h(i) = g(f(i)) for i = 0, ... n
        /// </summary>
        /// <param name="f">The left permutation</param>
        /// <param name="g">The right permutation</param>
        [MethodImpl(Inline)]
        public static NatPerm<N> operator *(NatPerm<N> f, NatPerm<N> g)
            => f.Compose(g);

        /// <summary>
        /// Computes the inverse of f
        /// </summary>
        /// <param name="f">The source permutation</param>
        [MethodImpl(Inline)]
        public static NatPerm<N> operator ~(NatPerm<N> f)
            => f.Invert();

        [MethodImpl(Inline)]
        public static NatPerm<N> operator ++(in NatPerm<N> lhs)
            => lhs.Inc();

        [MethodImpl(Inline)]
        public static NatPerm<N> operator --(in NatPerm<N> lhs)
            => lhs.Dec();

        [MethodImpl(Inline)]
        public static bool operator ==(NatPerm<N> f, NatPerm<N> g)
            => f.Equals(g);

        [MethodImpl(Inline)]
        public static bool operator !=(NatPerm<N> f, NatPerm<N> g)
            => !f.Equals(g);
    }
}