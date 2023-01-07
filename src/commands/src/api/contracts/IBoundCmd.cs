//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBoundCmd
    {
        ICmd Command {get;}

        CmdArgs Args {get;}
    }

    public interface IBoundCmd<T> : IBoundCmd
        where T : ICmd<T>, new()
    {
        new T Command {get;}

        ICmd IBoundCmd.Command
            => Command;
    }
}