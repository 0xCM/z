//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class BoundCmd<T> : BoundCmd, IBoundCmd<T>
        where T : ICmd<T>, new()
    {
        public T Command {get;}

        public BoundCmd(T cmd, CmdArgs args)
            : base(cmd,args)
        {
            Command = cmd;
        }

        public static implicit operator BoundCmd<T>((T cmd, CmdArgs args) src)
            => new BoundCmd<T>(src.cmd, src.args);
    }
}