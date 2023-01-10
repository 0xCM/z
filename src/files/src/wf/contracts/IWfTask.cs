//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfTask
    {
        Task<ExecToken> Start(IWfChannel channel);

        ExecToken Run(IWfChannel channel);
    }
}