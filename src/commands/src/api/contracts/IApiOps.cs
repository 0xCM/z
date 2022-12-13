//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdActors
    {
        bool Find(string spec, out CmdActor op);

        ref readonly ReadOnlySeq<CmdActor> Defs {get;}
    }
}