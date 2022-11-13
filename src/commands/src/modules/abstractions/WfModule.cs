//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [WfModule]
    public abstract class WfModule : IWfModule
    {
        protected IWfChannel Channel;

        protected static AppDb AppDb => AppDb.Service;

        protected virtual Task<ExecToken> Start<C>(C cmd)
            where C : IWfCmd<C>, new()
        {
            return sys.start(() => ExecToken.Empty);
        }
        
        Task<ExecToken> IWfModule.Start<C>(C cmd)
        {
            return Start(cmd);
        }       
    }
}