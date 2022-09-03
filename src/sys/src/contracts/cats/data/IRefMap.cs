//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IRefMap<S,T>
    {
        void Map(in S src, ref T dst);
    }

    [Free, SFx]
    public interface IRefMap<H,S,T> : IRefMap<S,T>
        where H : struct, IRefMap<H,S,T>
    {

    }
}