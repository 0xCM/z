//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IOutputIterator<T>
    {
        void Next(out T dst, out bool successs);
    }

    public interface IOutputIterator<H,T> : IOutputIterator<T>
        where H : IOutputIterator<H,T>
    {

    }
}