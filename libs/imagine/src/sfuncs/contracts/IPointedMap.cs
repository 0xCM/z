//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public unsafe interface IPointedMap<S,T>
        where S : unmanaged
    {
        T Map(S* pSrc);
    }

    [Free, SFx]
    public interface IPointedMap<H,S,T> : IPointedMap<S,T>
        where S : unmanaged
        where H : struct, IPointedMap<H,S,T>
    {

    }
}