//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfEventTarget : ISink<IWfEvent>
    {
        Type Host {get;}
    }
}