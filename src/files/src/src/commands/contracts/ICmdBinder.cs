//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdBinder
    {
        BoundCmd Bind(CmdArgs args);
    }

    public interface ICmdBinder<T> : ICmdBinder
        where T : IApiCmd<T>, new()
    {
        new BoundCmd<T> Bind(CmdArgs cmd);

        BoundCmd ICmdBinder.Bind(Z0.CmdArgs args)
            => Bind(args);
    }
}