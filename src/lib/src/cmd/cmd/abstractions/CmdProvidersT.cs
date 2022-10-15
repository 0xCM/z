//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CmdProviders<T> : ReadOnlySeq<T,ICmdProvider>
        where T : CmdProviders<T>, new()
    {
        public abstract T Init(IWfRuntime wf);

        protected CmdProviders()
        {

        }

        protected CmdProviders(ICmdProvider[] src)
            : base(src)
        {

        }
    }

}