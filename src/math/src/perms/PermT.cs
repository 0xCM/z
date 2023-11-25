//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// Defines a permutation over an integral type based at 0, [0, 1, ..., n - 1] where n is the permutation length
/// </summary>
/// <typeparam name="T">The integral type</typeparam>
public readonly struct Perm<T>
    where T : unmanaged
{
    /// <summary>
    /// Defines an identity permutation on n symbols
    /// </summary>
    /// <param name="n">The permutation length</param>
    [MethodImpl(Inline)]
    public static Perm<T> identity(T n)
        => new (gcalc.stream(default, gmath.dec(n)));

    /// <summary>
    /// Defines the permutation (0 -> terms[0], 1 -> terms[1], ..., n - 1 -> terms[n-1]) where n is the length of the array
    /// </summary>
    public readonly Seq<T> Terms;

    /// <summary>
    /// Initializes permutation with the identity followed by a sequence of transpostions
    /// </summary>
    /// <param name="n">The length of the permutation</param>
    /// <param name="swaps">The transpositions applied to the identity</param>
    [MethodImpl(Inline)]
    public Perm(T n, (T i, T j)[] swaps)
    {
        Terms = identity(n).Terms;
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
        Terms = identity(n).Terms;
        Swap(swaps);
    }

    [MethodImpl(Inline)]
    public Perm(T[] src)
        => Terms = src;

    public Perm(IEnumerable<T> src)
        => Terms = src.Array();

    [MethodImpl(Inline)]
    public Perm(T n, T[] src)
    {
        var count = iVal(n);
        Terms = new T[count];

        var m = src.Length;

        for(var i=0; i< m; i++)
            Terms[i] = src[i];

        var id = identity(n);
        for(var i=m; i< count; i++)
            Terms[i] = id[i - m];
    }

    ref T Head
    {
        [MethodImpl(Inline)]
        get => ref Terms.First;
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
        Swaps.swap(ref Terms[iVal(i)], ref Terms[iVal(j)]);
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
            Swaps.swap(ref Terms[iVal(specs[k].i)], ref Terms[iVal(specs[k].j)]);
        return this;
    }

    /// <summary>
    /// Effects a sequence of in-place transpositions
    /// </summary>
    public Perm<T> Swap(params (int i, int j)[] specs)
    {
        for(var k=0; k<specs.Length; k++)
            Swaps.swap(ref Terms[specs[k].i], ref Terms[specs[k].j]);
        return this;
    }

    /// <summary>
    /// Effects a sequence of in-place transpositions
    /// </summary>
    public Perm<T> Swap(params Swap[] specs)
    {
        for(var k=0; k<specs.Length; k++)
            Swaps.swap(ref Terms[specs[k].i], ref Terms[specs[k].j]);
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
        get => Terms.Length;
    }

    /// <summary>
    /// Applies a modular increment to the permutation in-place
    /// </summary>
    public Perm<T> Inc()
    {
        var src = Replicate().Terms;
        var lastix = Length - 1;
        for(var i=0; i< lastix; i++)
            Terms[i] = src[i + 1];
        Terms[lastix] = src[0];
        return this;
    }

    /// <summary>
    /// Applies a modular decrement to the permutation in-place
    /// </summary>
    public Perm<T> Dec()
    {
        var src = Replicate().Terms;
        Terms[0] = src[Length - 1];
        for(var i=1; i< Length; i++)
            Terms[i] = src[i - 1];
        return this;
    }

    /// <summary>
    /// Clones the permutation
    /// </summary>
    public readonly Perm<T> Replicate()
        => new (Terms.Storage.Replicate());

    /// <summary>
    /// Creates a new permutation p via composition, p[i] = g(f(i)) for i = 0, ... n where f denotes the current permutation
    /// </summary>
    /// <param name="f">The left permutation</param>
    /// <param name="g">The right permutation</param>
    public readonly Perm<T> Compose(Perm<T> g)
    {
        var n = g.Terms.Length;
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
        Terms.Reverse();
        return this;
    }

    /// <summary>
    /// Computes the inverse permutation t of the current permutation p such that p*t = t*p = I where I denotes the identity permutation
    /// </summary>
    public readonly Perm<T> Invert()
    {
        var dst = new Perm<T>(new T[Length]);
        for(var i=0; i< Length; i++)
            dst[Terms[i]] = Numeric.force<T>(i);
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
            var image = Terms[iVal(index)];
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
        if(len != Terms.Length)
            return(false);

        for(var i=0; i<len; i++)
            if(gmath.neq(Terms[i], rhs.Terms[i]))
                return false;
        return true;
    }

    [MethodImpl(Inline)]
    static int iVal(T src)
        => Numeric.force<T,int>(src);

    public string Format(int? colwidth = null)
        => Terms.Edit.FormatAsPerm(colwidth);

    public Hash32 Hash
    {    
        get => Terms.Hash;
    }
    public readonly override int GetHashCode()
        => Hash;

    public readonly override bool Equals(object o)
        => o is Perm<T> p && Equals(p);

    /// <summary>
    /// Implicitly converts an integral value n into an identity permutation of length n
    /// </summary>
    /// <param name="n">The permutation length</param>
    [MethodImpl(Inline)]
    public static implicit operator Perm<T>(T n)
        => identity(n);

    /// <summary>
    /// Computes the composition h of f and g where f and g have common length n and h(i) = g(f(i)) for i = 0, ... n-1
    /// </summary>
    /// <param name="a">The left permutation</param>
    /// <param name="b">The right permutation</param>
    [MethodImpl(Inline)]
    public static Perm<T> operator *(Perm<T> a, Perm<T> b)
        => a.Compose(b);

    [MethodImpl(Inline)]
    public static Perm<T> operator ++(Perm<T> src)
        => src.Inc();

    [MethodImpl(Inline)]
    public static Perm<T> operator --(Perm<T> src)
        => src.Dec();

    [MethodImpl(Inline)]
    public static bool operator ==(Perm<T> a, Perm<T> b)
        => a.Equals(b);

    [MethodImpl(Inline)]
    public static bool operator !=(Perm<T> a, Perm<T> b)
        => !a.Equals(b);
}
