//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAppCommands
    {
        bool Find(string spec, out IAppCmdRunner runner);

        ref readonly ReadOnlySeq<AppCmdDef> Defs {get;}

        ICollection<IAppCmdRunner> Invokers {get;}
    }
}