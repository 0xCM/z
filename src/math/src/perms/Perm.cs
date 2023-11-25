//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;

partial class XTend
{
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
}

public readonly struct Perm
{
    /// <summary>
    /// Defines the permutation (0 -> terms[0], 1 -> terms[1], ..., n - 1 -> terms[n-1])
    /// where n is the length of the array
    /// </summary>
    readonly Seq<int> Storage;

    [MethodImpl(Inline)]
    public Perm(int n, Swap[] src)
    {
        Storage = identity(n).Storage;
        Apply(src);
    }

    /// <summary>
    /// Defines an untyped identity permutation
    /// </summary>
    /// <param name="n">The permutation length</param>
    [MethodImpl(Inline), Op]
    static Perm identity(int n)
        => new Perm(gcalc.stream(0, n-1));

    [MethodImpl(Inline)]
    public Perm(int[] src)
    {
        Storage = src;
    }

    [Op]
    void Absorb(ReadOnlySpan<int> src)
    {
        var n = Storage.Length;
        var m = src.Length;
        ref var dst = ref Storage.First;
        for(var i=0; i<m; i++)
            seek(dst, i) = skip(src,i);
        var id = identity(n);
        for(var i=m; i<n; i++)
            seek(dst, i) = id[i - m];
    }

    public Perm(int n, int[] src)
    {
        Storage = new int[n];
        Absorb(src);
    }

    [MethodImpl(Inline)]
    public Perm(IEnumerable<int> src)
    {
        Storage = src.ToArray();
    }

    /// <summary>
    /// Term accessor where the term index is in the inclusive range [0, N-1]
    /// </summary>
    public ref int this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Storage[i];
    }

    /// <summary>
    /// Term accessor where the term index is in the inclusive range [0, N-1]
    /// </summary>
    public ref int this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Storage[i];
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
        Swaps.swap(ref Storage[i], ref Storage[j]);
        return this;
    }

    /// <summary>
    /// Effects a sequence of in-place transpositions
    /// </summary>
    public Perm Swap(params (int i, int j)[] specs)
    {
        for(var k=0; k<specs.Length; k++)
            Swaps.swap(ref Storage[specs[k].i], ref Storage[specs[k].j]);
        return this;
    }

    /// <summary>
    /// Effects a sequence of in-place transpositions
    /// </summary>
    public Perm Apply(params Swap[] specs)
    {
        for(var k=0; k<specs.Length; k++)
            Swaps.swap(ref Storage[specs[k].i], ref Storage[specs[k].j]);
        return this;
    }

    /// <summary>
    /// The length of the permutation
    /// </summary>
    public int Length
        => Storage.Length;

    public ReadOnlySeq<int> Terms
        => Storage;

    /// <summary>
    /// Clones the permutation
    /// </summary>
    public Perm Replicate()
        => new (Storage.Storage.Replicate());

    /// <summary>
    /// Creates a new permutation p via composition, p[i] = g(f(i)) for i = 0, ... n
    /// where f denotes the current permutation
    /// </summary>
    /// <param name="f">The left permutation</param>
    /// <param name="g">The right permutation</param>
    public Perm Compose(Perm g)
    {
        var n = (uint)Storage.Length;
        var dst = new Perm(new int[Length]);
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
        Storage.Reverse();
        return this;
    }

    /// <summary>
    /// Computes the inverse permutation t of the current permutation p
    /// such that p*t = t*p = I where I denotes the identity permutation
    /// </summary>
    public Perm Invert()
    {
        var dst = new Perm(new int[Length]);
        for(var i=0; i< Length; i++)
            dst[Storage[i]] = i;
        return dst;
    }

    /// <summary>
    /// Applies a modular increment to the permutation in-place
    /// </summary>
    public Perm Inc()
    {
        var src = Replicate().Storage;
        var k = 1;
        for(var i=0; i< Length - k; i++)
            Storage[i] = src[i + k];
        Storage[Length - k] = src[k - 1];
        return this;
    }

    /// <summary>
    /// Applies a modular decrement to the permutation in-place
    /// </summary>
    public Perm Dec()
    {
        var src = Replicate().Storage;
        Storage[0] = src[Length - 1];
        for(var i=1; i< Length; i++)
            Storage[i] = src[i - 1];
        return this;
    }

    /// <summary>
    /// Converts the permutation to a generic permutation over the specified target type
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    public Perm<T> Convert<T>()
        where T : unmanaged
    {
        var dst = new T[Storage.Length];
        for(var i=0; i<Storage.Length; i++)
            dst[i] = Numeric.force<T>(Storage[i]);
        return new Perm<T>(dst);
    }

    public Span<Swap> CalcSwaps()
    {
        var max = Storage.Length/2;
        Span<Swap> swaps = new Swap[max];
        var count = 0;
        for(var i=0; i< max; i++)
        {
            var image = Storage[i];

            if(i != image)
            {
                var a = Storage[image];
                var b = Storage[a];
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
            var image = Storage[index];
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
        => ((ReadOnlySpan<int>)Terms).FormatAsPerm(colwidth);

    public override int GetHashCode()
        => Storage.GetHashCode();

    public bool Equals(Perm rhs)
    {
        var len = rhs.Length;
        if(len != Storage.Length)
            return(false);

        for(var i=0; i<len; i++)
            if(Storage[i] != rhs.Storage[i])
                return false;

        return true;
    }

    public override bool Equals(object o)
        => o is Perm p  && Equals(p);

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
