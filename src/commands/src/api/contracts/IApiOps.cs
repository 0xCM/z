//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiOps
    {
        bool Find(string spec, out Effector op);

        ref readonly ReadOnlySeq<Effector> Defs {get;}
    }
}