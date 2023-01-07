//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CmdBinder<T> : ICmdBinder<T>
        where T : ICmd<T>, new()
    {
        public abstract BoundCmd<T> Bind(CmdArgs src);
    }
}