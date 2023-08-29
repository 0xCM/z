//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Collections;
using System.Linq;

/// <summary>
/// Captures a random stream along with the generator classification
/// </summary>
public readonly struct DeferredSource<T> : ISourceStream<T>
{
    readonly IEnumerable<T> Src;

    [MethodImpl(Inline)]
    public DeferredSource(IEnumerable<T> src, ulong classifier = default)
    {
        Src = src;
    }

    [MethodImpl(Inline)]
    public IEnumerator<T> GetEnumerator()
        => Src.GetEnumerator();

    [MethodImpl(Inline)]
    public IEnumerable<T> Next(int count)
        => Src.Take(count);

    [MethodImpl(Inline)]
    public T Next()
        => Src.First();

    IEnumerator IEnumerable.GetEnumerator()
        => Src.GetEnumerator();
}
