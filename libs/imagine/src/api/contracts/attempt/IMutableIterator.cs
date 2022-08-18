//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMutableIterator<T>
    {
        void Edit(ref T dst, out bool success);
    }

    public interface IMutableIterator<H,T> : IMutableIterator<T>
        where H : IMutableIterator<H,T>
    {

    }
}