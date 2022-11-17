//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CmdProviders<T> : ReadOnlySeq<T,IApiCmdProvider>
        where T : CmdProviders<T>, new()
    {
        public abstract T Init(IWfRuntime wf);

        protected CmdProviders()
        {

        }

        protected CmdProviders(IApiCmdProvider[] src)
            : base(src)
        {

        }
    }
}