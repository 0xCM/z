//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a mapping function that carries cells of one span to another
    /// </summary>
    /// <typeparam name="A">The source span cell type</typeparam>
    /// <typeparam name="B">The target span cell type</typeparam>
    [Free, SFx]
    public interface ISpanMap<A,B> : IFunc
    {
        void Invoke(ReadOnlySpan<A> src, Span<B> dst);
    }
}