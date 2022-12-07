//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiEfectors
    {
        bool Find(string spec, out ApiEffector op);

        ref readonly ReadOnlySeq<ApiEffector> Defs {get;}
    }
}