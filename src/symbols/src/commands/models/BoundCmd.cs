//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class BoundCmd : IBoundCmd
    {
        readonly ICmd Command;

        ICmd IBoundCmd.Command
            => Command;

        public CmdArgs Args {get;}

        public BoundCmd(ICmd cmd, CmdArgs args)
        {
            Command = cmd;
            Args = args;
        }
    }
}