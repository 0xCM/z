//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a content-parametric segment reference
    /// </summary>
    /// <typeparam name="T">The content type</typeparam>
    [Free]
    public interface ISegRef<T> : IMemorySegment
    {
        Span<S> Data<S>();

        new ref T Cell(int index);

        ref byte IMemorySegment.Cell(int index)
            => ref Unsafe.As<T,byte>(ref Cell(index));

        new ref T this[int index]
            => ref Cell(index);
    }

    /// <summary>
    /// Characterizes a reified content-parameteric segment reference
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="T">The content type</typeparam>
    [Free]
    public interface ISegRef<F,T> : ISegRef<T>, INullary<F>, IEquatable<F>
        where F : ISegRef<F,T>, new()
    {
        F INullary<F>.Zero
            => new F();
    }
}