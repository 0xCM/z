//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;

    [Free]
    public interface IDeferredSource<T> : ISource<IEnumerable<T>>, IEnumerable<T>
    {
        IEnumerator IEnumerable.GetEnumerator()
            => Next().GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => Next().GetEnumerator();
    }
}