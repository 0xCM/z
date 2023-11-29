//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a data structure for sparse/partial sequence representation
/// </summary>
public readonly struct SeqTerms<T> : IIndex<SeqTerm<T>>
{
    readonly Index<SeqTerm<T>> Data;

    [MethodImpl(Inline)]
    public SeqTerms(params SeqTerm<T>[] src)
    {
        if(src.Length != 0)
            Data = src;
        else
            Data = Empty.Data;
    }

    public ReadOnlySpan<SeqTerm<T>> View
    {
        [MethodImpl(Inline)]
        get => Data.View;
    }

    public Span<SeqTerm<T>> Edit
    {
        [MethodImpl(Inline)]
        get => Data.Edit;
    }

    public SeqTerm<T>[] Storage
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    /// <summary>
    /// The number of terms in the sequence
    /// </summary>
    public int Length
    {
        [MethodImpl(Inline)]
        get => Data.Length;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Data.IsEmpty;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Data.IsNonEmpty;
    }

    /// <summary>
    /// Returns a reference to an index-identified term
    /// </summary>
    public ref SeqTerm<T> this[long idx]
    {
        [MethodImpl(Inline)]
        get => ref Data[idx];
    }

    /// <summary>
    /// Returns a reference to an index-identified term
    /// </summary>
    public ref SeqTerm<T> this[ulong idx]
    {
        [MethodImpl(Inline)]
        get => ref Data[idx];
    }

    /// <summary>
    /// Returns a reference to the first term of the sequence
    /// </summary>
    public ref SeqTerm<T> First
    {
        [MethodImpl(Inline)]
        get => ref this[0];
    }

    public ref SeqTerm<T> Last
    {
        [MethodImpl(Inline)]
        get => ref this[Length - 1];
    }

    public static SeqTerms<T> Empty
        => new SeqTerms<T>(SeqTerm<T>.Empty);

    [MethodImpl(Inline)]
    public static implicit operator SeqTerms<T>(SeqTerm<T>[] src)
        => new SeqTerms<T>(src);
}
