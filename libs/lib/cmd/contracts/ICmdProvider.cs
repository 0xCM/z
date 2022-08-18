//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdProvider
    {
        IAppCommands Actions {get;}

        Name Name => GetType().DisplayName();
    }
}