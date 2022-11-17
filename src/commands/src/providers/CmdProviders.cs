//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdProviders : CmdProviders<CmdProviders>
    {
        readonly Func<IWfRuntime,ReadOnlySeq<IApiCmdProvider>> Factory;

        public CmdProviders()
        {
            Factory = wf => ReadOnlySeq<IApiCmdProvider>.Empty;
        }

        CmdProviders(IApiCmdProvider[] src)
            : base(src)
        {
            Factory = _ => src;
        }

        public CmdProviders(Func<IWfRuntime,ReadOnlySeq<IApiCmdProvider>> f)
        {
            Factory = f;
        }

        public override CmdProviders Init(IWfRuntime wf)
            => new(Factory(wf).Unwrap());
    }
}