//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdRender<C> : ICmdRender
        where C : ICmd<C>, new()
    {
        CmdId ICmdRender.CmdId 
            => CmdId.identify<C>();

        string Format(C src);
        
        string ICmdRender.Format(ICmd src)
            => Format((C)src);
    }
}