//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IReadOnlyIterator<T>
    {
        void View(in T dst, out bool success);
    }

    public interface IReadOnlyIterator<H,T> : IReadOnlyIterator<T>
        where H : IReadOnlyIterator<H,T>
    {

    }
}