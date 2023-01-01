//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdMethods
    {
        bool Find(string spec, out CmdMethod op);

        ref readonly ReadOnlySeq<CmdMethod> Defs {get;}
    }
}