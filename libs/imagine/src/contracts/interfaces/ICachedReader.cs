//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICachedReader<T> : IReader<T>
    {
        ref readonly T ViewNext();

        bool ViewNext(out T dst);
    }
}