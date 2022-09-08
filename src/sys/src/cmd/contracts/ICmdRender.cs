//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdRender
    {
        CmdId CmdId {get;}
        
        string Format(ICmd src);
    }
}