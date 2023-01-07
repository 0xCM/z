//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdServer : ICmdRunner
    {
        CmdCatalog Commmands {get;}

        ICollection<CmdRoute> Routes {get;}
    }
}